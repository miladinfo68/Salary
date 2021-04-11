using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Wage.Core.Entities;
using Wage.Core.Interfaces.IServices;
using Wage.Web.Models;
using Wage.Web.DTOs;
using Wage.Web.Extensions;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Dapper;
using Wage.Web.Functionality;
using Microsoft.AspNetCore.Authorization;
using Wage.Core.Constants;

namespace Wage.Web.Controllers
{
    [CustomAuthorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IGroupManagerService _groupManagerSVC;
        private readonly IGroupManagerDetailesService _groupManagerDetailesSVC;
        private readonly IGroupManagerScheduleService _groupManagerScheduleSVC;
        private readonly IHolidayService _holidaySVC;
        private readonly IConfiguration _configuration;

        private readonly DrpYears YEARS = null;
        private readonly DrpMonths MONTHES = null;
        private readonly DrpWeeks WEEKS = null;

        private string TODAY = DateTime.Now.ToString().ToJalali();
        private const double BASE_AMOUNT_IN_WEEK_FRACTION = 4.28;

        private readonly IMapper _mapper;
        public HomeController(
            ILogger<HomeController> logger
            , IMapper mapper
            , IHolidayService holidaySVC
            , IGroupManagerScheduleService groupManagerScheduleSVC
            , IGroupManagerService groupManagerSVC
            , IGroupManagerDetailesService groupManagerDetailesSVC
            , IConfiguration configuration
            )
        {
            _logger = logger;
            _mapper = mapper;
            _holidaySVC = holidaySVC;
            _groupManagerScheduleSVC = groupManagerScheduleSVC;
            _groupManagerSVC = groupManagerSVC;
            _groupManagerDetailesSVC = groupManagerDetailesSVC;
            _configuration = configuration;

            YEARS = YEARS ?? new DrpYears();
            MONTHES = MONTHES ?? new DrpMonths();
            WEEKS = WEEKS ?? new DrpWeeks();
        }

        //@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult NotFound()
        {
            return View("404");
        }
        [AllowAnonymous]
        public IActionResult AccessDeny()
        {
            return View();
        }


        [HttpPost]
        public ActionResult BulkAddOrUploadScheduleExcell(IFormFile file)
        {
            var errs = "";
            List<DouplicatedGroupManagerScheduleDto> duplicateRecords = null;
            try
            {
                if (file != null && file.Length > 0)
                {

                    var stream = file.OpenReadStream();
                    var dtXl = stream.ToDataTableFromExcel();
                    var grpSchedule = dtXl.ConvertDataTableToList<DouplicatedGroupManagerScheduleDto>();

                    var uniquRecords = grpSchedule.GroupBy(gr => new
                    {
                        gr.GroupManagerId,
                        gr.EntranceDate,
                        gr.EntranceTime,
                        gr.ExitTime,
                        gr.MinTime,
                        gr.IsOnline
                    }).Select(s => s).ToList();



                    var douplicates = grpSchedule.GroupBy(s => new
                    {
                        GroupManagerId = s.GroupManagerId,
                        EntranceDate = s.EntranceDate,
                        EntranceTime = s.EntranceTime,
                        ExitTime = s.ExitTime,
                        MinTime = s.MinTime,
                        IsOnline = s.IsOnline,
                    }).Where(c => c.Count() > 1).Select(s => s.Key);


                    duplicateRecords = douplicates.ToList()
                    .Select(s => new DouplicatedGroupManagerScheduleDto
                     {
                         GroupManagerId = s.GroupManagerId,
                         EntranceDate = s.EntranceDate,
                         EntranceTime = s.EntranceTime,
                         ExitTime = s.ExitTime,
                         MinTime = s.MinTime,
                         IsOnline = s.IsOnline,
                         PresenceType = s.IsOnline.Equals("1") ? "آنلاین" : "فیزیکی"
                     }).ToList();



                    var tvpDT = uniquRecords.Select(s => new TVP
                    {
                        GroupManagerId = s.Key.GroupManagerId,
                        EntranceDate = s.Key.EntranceDate,
                        EntranceTime = s.Key.EntranceTime,
                        ExitTime = s.Key.ExitTime,
                        MinTime = s.Key.MinTime,
                        IsOnline = s.Key.IsOnline.Equals("1") ? true : false,
                        Active = true,
                    }).ToList().ConvertListToDataTable<TVP>();

                    using (var con = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                    {
                        var res = con.ExecuteScalar<string>("[dbo].[SP_BulkAddOrUpdateGroupManagerSchedules]", new
                        {
                            tvpSchedule = tvpDT.AsTableValuedParameter("[dbo].[TvpGroupManagerSchedules]")
                            //tvpSchedule = items.AsTableValuedParameter("[dbo].[TvpGroupManagerSchedules]")
                        }, commandType: CommandType.StoredProcedure);
                    }

                    //if (errorRecords.Count() > 0)
                    //{
                    //    errs += "<table class=\"table table-bordered table-responsive table-hover tbl-date-enter text-center\"><thead><tr><th>شناسه</th><th>تاریخ ورود</th><th>ساعت ورود</th><th>ساعت خروج</th><th>حداقل زمان حضور</th></tr></thead><tbody>";
                    //    foreach (var err in errorRecords)
                    //    {
                    //        errs += $"<tr><td>{err.GroupManagerId}</td><td>{err.EntranceDate}</td><td>{err.EntranceTime}</td><td>{err.ExitTime}</td><td>{err.MinTime}</td></tr>";
                    //    }
                    //    errs += "</tbody></table>";
                    //}
                }
            }
            catch (Exception exp)
            {
                //throw exp;
            }
            //return Json(errs);
            return Json(duplicateRecords);
        }


        [HttpGet]
        public async Task<ActionResult> Schedule(string month = "0")
        {
            MONTHES.Items.FirstOrDefault(x => int.Parse(x.Value) == int.Parse(month)).Selected = true;
            ViewBag.Month = MONTHES;

            if (month == "0") return View(new List<GroupManagerDto>());
            var currentPersianYear = TODAY.Split('/')[0];
            var fetchedList = await _groupManagerSVC.GetAllGroupManagers(currentPersianYear, month);
            var mappedList = _mapper.Map<IEnumerable<GroupManager>, IEnumerable<GroupManagerDto>>(fetchedList);

            return View(mappedList.OrderBy(ord => ord.Id));

        }

        [HttpPost]
        public async Task<JsonResult> Schedule(SaveGroupManagerScheduleDto data)
        {
            var res = false;
            if (data != null && data.GroupManagerId > 0
                && !string.IsNullOrEmpty(data.EntranceDate) //&& data.EntranceDate.Trim().Length == 10 && data.EntranceDate.Split('/').Length == 3
                && !string.IsNullOrEmpty(data.EntranceTime)
                && !string.IsNullOrEmpty(data.ExitTime)
                //&& int.Parse(data.ExitTime) * 60 >= int.Parse(data.EntranceTime) * 60
                && !string.IsNullOrEmpty(data.MinTime))
            {
                var mappedItem = _mapper.Map<SaveGroupManagerScheduleDto, GroupManagerSchedule>(data);
                res = await _groupManagerScheduleSVC.AddGroupManagerSchedule(mappedItem);

            }
            return Json(res);
        }

        [HttpPost]
        public async Task<JsonResult> RemoveSchedule(string id, string groupManagerId)
        {
            IEnumerable<GroupManagerSchedule> res = new List<GroupManagerSchedule>();
            if (!string.IsNullOrEmpty(id) && decimal.Parse(id) > 0
                && !string.IsNullOrEmpty(groupManagerId) && decimal.Parse(groupManagerId) > 0)
            {
                var boolResult = await _groupManagerScheduleSVC.RemoveGroupManagerSchedule(decimal.Parse(id));
                //if (boolResult)
                res = await _groupManagerScheduleSVC.GetManyGroupManagerSchedules(x => x.GroupManagerId == decimal.Parse(groupManagerId));
            }
            return Json(res.OrderBy(ord => ord.EntranceDate));
        }

        [HttpPost]
        public async Task<JsonResult> SheduleDetails(string id)
        {
            IEnumerable<GroupManagerSchedule> res = new List<GroupManagerSchedule>();
            if (!string.IsNullOrEmpty(id) && decimal.Parse(id) > 0)
            {
                res = await _groupManagerScheduleSVC.GetManyGroupManagerSchedules(x => x.GroupManagerId == decimal.Parse(id));
            }
            return Json(res.OrderBy(ord => ord.EntranceDate));
        }

        //=======================
        [HttpGet]
        public async Task<ActionResult> NewEntrance(string month = "0")
        {
            MONTHES.Items.FirstOrDefault(x => int.Parse(x.Value) == int.Parse(month)).Selected = true;
            ViewBag.Month = MONTHES;

            if (month == "0") return View(new List<GroupManagerDto>());
            var currentPersianYear = TODAY.Split('/')[0];
            var fetchedList = await _groupManagerSVC.GetAllGroupManagers(currentPersianYear ,month);
            var mappedList = _mapper.Map<IEnumerable<GroupManager>, IEnumerable<GroupManagerDto>>(fetchedList);

            return View(mappedList.OrderBy(ord => ord.Id));

        }

        [HttpPost]
        public async Task<JsonResult> NewEntrance(SaveGroupManagerDetailesDto data)
        {
            var res = false;
            if (data != null && data.GroupManagerId > 0 
                && !string.IsNullOrEmpty(data.EntranceDate) 
                && !string.IsNullOrEmpty(data.EntranceTime) 
                && !string.IsNullOrEmpty(data.ExitTime)
                )
            {
                var mappedItem = _mapper.Map<SaveGroupManagerDetailesDto, GroupManagerDetails>(data);
                res = await _groupManagerDetailesSVC.AddNewGroupManagerDetails(mappedItem);

            }
            return Json(res);
        }

        [HttpPost]
        public async Task<JsonResult> EntranceDetails(string groupManagerId)
        {
            IEnumerable<GroupManagerDetailes_ReadDto> mappedList = new List<GroupManagerDetailes_ReadDto>();
            if (!string.IsNullOrEmpty(groupManagerId) && decimal.Parse(groupManagerId) > 0)
            {
                var fetchedList = await _groupManagerDetailesSVC.GetManyGroupManagerDetails(x => x.GroupManagerId == decimal.Parse(groupManagerId));
                mappedList = _mapper.Map<IEnumerable<GroupManagerDetails>, IEnumerable<GroupManagerDetailes_ReadDto>>(fetchedList);
            }
            return Json(mappedList.OrderBy(ord => ord.EntranceDate));
        }

        [HttpPost]
        public async Task<JsonResult> RemoveEntranceDetails(string id, string groupManagerId)
        {
            IEnumerable<GroupManagerDetailes_ReadDto> mappedList = new List<GroupManagerDetailes_ReadDto>();
            if (!string.IsNullOrEmpty(id) && decimal.Parse(id) > 0
                && !string.IsNullOrEmpty(groupManagerId) && decimal.Parse(groupManagerId) > 0)
            {
                var boolResult = await _groupManagerDetailesSVC.RemoveGroupManagerDetails(decimal.Parse(id));
                //if (boolResult)
                var fetchedList = await _groupManagerDetailesSVC.GetManyGroupManagerDetails(x => x.GroupManagerId == decimal.Parse(groupManagerId));
                mappedList = _mapper.Map<IEnumerable<GroupManagerDetails>, IEnumerable<GroupManagerDetailes_ReadDto>>(fetchedList);
            }
            return Json(mappedList.OrderBy(ord => ord.EntranceDate));
        }

        [HttpPost]
        public ActionResult BulkAddNewEntranceExcell(IFormFile file)
        {
            var errs = "";
            List<DouplicatedGroupManagerDetailsDto> duplicateRecords = null;
            try
            {
                if (file != null && file.Length > 0)
                {

                    var stream = file.OpenReadStream();
                    var dtXl = stream.ToDataTableFromExcel();
                    var grManagerDetails = dtXl.ConvertDataTableToList<DouplicatedGroupManagerDetailsDto>();

                    var uniquRecords = grManagerDetails.GroupBy(gr => new
                    {
                        gr.GroupManagerId,
                        gr.EntranceDate,
                        gr.EntranceTime,
                        gr.ExitTime,                 
                        gr.IsOnline
                    }).Select(s => s).ToList();



                    var douplicates = grManagerDetails.GroupBy(s => new
                    {
                        GroupManagerId = s.GroupManagerId,
                        EntranceDate = s.EntranceDate,
                        EntranceTime = s.EntranceTime,
                        ExitTime = s.ExitTime,                  
                        IsOnline = s.IsOnline,
                    }).Where(c => c.Count() > 1).Select(s => s.Key);


                    duplicateRecords = douplicates.ToList()
                    .Select(s => new DouplicatedGroupManagerDetailsDto
                    {
                        GroupManagerId = s.GroupManagerId,
                        EntranceDate = s.EntranceDate,
                        EntranceTime = s.EntranceTime,
                        ExitTime = s.ExitTime,                    
                        IsOnline = s.IsOnline,
                        PresenceType = s.IsOnline.Equals("1") ? "آنلاین" : "فیزیکی"
                    }).ToList();



                    var tvpDT = uniquRecords.Select(s => new TVPGroupManagerDetails
                    {
                        GroupManagerId =Convert.ToDecimal( s.Key.GroupManagerId ),
                        EntranceDate = s.Key.EntranceDate,
                        EntranceTime = s.Key.EntranceTime,
                        ExitTime = s.Key.ExitTime,
                        IsOnline = s.Key.IsOnline.Equals("1") ? true : false,
                        Active = true,
                    }).ToList().ConvertListToDataTable<TVPGroupManagerDetails>();

                    using (var con = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                    {
                        var res = con.ExecuteScalar<string>("[dbo].[SP_BulkAddGroupManagerDetailsNewEntrance]", new
                        {
                            tvpGroupManagerDetailsNewEntrance = tvpDT.AsTableValuedParameter("[dbo].[TvpGroupManagerDetailsNewEntrance]")                            
                        }, commandType: CommandType.StoredProcedure);
                    }

                }
            }
            catch (Exception exp)
            {
                //throw exp;
            }
            //return Json(errs);
            return Json(duplicateRecords);
        }


        //=======================

        [HttpGet]
        public async Task<ActionResult> BaseAmount(string year = "0", string month = "0", string startAt = "0")
        {
            string y = "0", m = "0", t = "0";
            if (year != "0") y = year;
            if (month != "0") m = month;
            if (startAt != "0" && startAt.Split('/').Length == 3) t = startAt.ToStandardPersianDate();

            if (y == "0" && m == "0" && t == "0")
            {
                y = TODAY.Split('/')[0].ToString();
                m = TODAY.Split('/')[1].ToString();
            }

            ViewBag.Month = MONTHES;
            ViewBag.Year = YEARS;

            if (year != "0" && year.IsNumeric())
            {
                YEARS.Items.FirstOrDefault(x => int.Parse(x.Value) == int.Parse(year)).Selected = true;
                ViewBag.Year = YEARS;
            }

            if (month != "0" && month.IsNumeric())
            {
                MONTHES.Items.FirstOrDefault(x => int.Parse(x.Value) == int.Parse(month)).Selected = true;
                ViewBag.Month = MONTHES;
            }

            var fetchedList = await _groupManagerSVC.GetAllGroupManagers(y, m, t);

            var mappedList = _mapper.Map<IEnumerable<GroupManager>, IEnumerable<GroupManagerDto>>(fetchedList);

            return View(mappedList.OrderBy(ord => ord.Id));

        }

        [HttpPost]
        public async Task<JsonResult> BaseAmount(SaveBaseAmountDto data)
        {
            var res = false;
            if (data != null && data.Id > 0 && !string.IsNullOrEmpty(data.BaseAmount))
            {
                var item = await _groupManagerSVC.GetGroupManagerById(data.Id);
                if (item != null)
                {
                    item.BaseAmount = data.BaseAmount;
                    res = await _groupManagerSVC.EditGroupManagerInfo(item);
                }
            }
            return Json(res);
        }

        //=======================

        [HttpGet]
        public async Task<ActionResult> ResearchCouncil(string month="0")
        {
            MONTHES.Items.FirstOrDefault(x => int.Parse(x.Value) == int.Parse(month)).Selected = true;
            ViewBag.Month = MONTHES;

            if (month == "0") return View(new List<GroupManagerDto>());
            var currentPersianYear = TODAY.Split('/')[0];
            var fetchedList = await _groupManagerSVC.GetAllGroupManagers(currentPersianYear, month);
       
            var mappedList = _mapper.Map<IEnumerable<GroupManager>, IEnumerable<GroupManagerDto>>(fetchedList);

            return View(mappedList.OrderBy(ord => ord.Id));

        }

        [HttpPost]
        public async Task<JsonResult> ResearchCouncil(SaveResearchCouncilDto data)
        {
            var res = false;
            if (data != null && data.Id > 0 && !string.IsNullOrEmpty(data.CouncilDate))
            {
                var item = await _groupManagerSVC.GetGroupManagerById(data.Id);
                if (item != null)
                {
                    item.ChkCouncil = data.ChkCouncil;
                    item.CouncilDate = data.CouncilDate.ToStandardPersianDate();
                    res = await _groupManagerSVC.EditGroupManagerInfo(item);
                }
            }
            return Json(res);
        }

        [HttpGet]

        //=======================
        public async Task<ActionResult> PresenceInWeek(string month = "0", string week = "0")
        {
            ViewBag.Month = MONTHES;
            ViewBag.Week = WEEKS;
            List<PresenceInWeekViewModel> presenceInWeeksList = new List<PresenceInWeekViewModel>();
            if (month == "0" || (month != "0" && week == "0")) return View(presenceInWeeksList);


            List<GroupManagerInfoViewModel> qGroupManagersInfo;
            List<GroupManagerDetailsViewModel> qGroupManagersDetailsInOutFilteredByWeek;
            PresenceInWeekViewModel presenceInWeek;
            var currentPersianYear = TODAY.Split('/')[0];
            int OnlineTotalTime = 0, PhysicalTotalTime = 0, TotalTime = 0;
            var allMonthes = new List<string>();

            qGroupManagersInfo = (from gr in await _groupManagerSVC.GetAllGroupManagers(currentPersianYear, month)
                                  join gs in await _groupManagerScheduleSVC.GetAllGroupManagerSchedules() on gr.Id equals gs.GroupManagerId
                                  join gd in await _groupManagerDetailesSVC.GetAllGroupManagerDetails()
                                      on new { gs.GroupManagerId, gs.EntranceDate }
                                      equals new { gd.GroupManagerId, gd.EntranceDate } into GroupManDetails
                                  from grd in GroupManDetails.DefaultIfEmpty()
                                  where//date==> yyyy/mm/dd     , time===> hh:mm
                                  gs.EntranceDate.Trim().Length == 10 && gs.EntranceDate.Split('/').Length == 3
                                  && gs.EntranceTime.Trim().Length == 5 && gs.EntranceTime.Split(':').Length == 2
                                  && gs.ExitTime.Trim().Length == 5 && gs.ExitTime.Split(':').Length == 2
                                  && gs.EntranceDate.Split('/')[0].Equals(currentPersianYear)
                                  //&& gr.Id == 1

                                  select new GroupManagerInfoViewModel
                                  {
                                      Id = gr.Id,
                                      ProfCode = gr.ProfCode,
                                      ProfName = gr.ProfName,
                                      EntranceDate = gs.EntranceDate,
                                      EntranceTime = gs.EntranceTime,
                                      ExitTime = gs.ExitTime,
                                      MinTime = gs.MinTime,
                                      IsOnline = gs.IsOnline,

                                      //real in out time
                                      InTime = grd?.EntranceTime ?? "00:00",
                                      OutTime = grd?.ExitTime ?? "00:00",

                                      BaseAmountInMonth = gr.BaseAmount
                                  }).ToList();

            allMonthes = qGroupManagersInfo?.GroupBy(g => g.EntranceDate.Split('/')[1]).Select(s => s.Key).ToList();

            if (!string.IsNullOrEmpty(month) && int.Parse(month) != 0 && month.IsNumeric())
            {
                MONTHES.Items.FirstOrDefault(x => int.Parse(x.Value) == int.Parse(month)).Selected = true;
                ViewBag.Month = MONTHES;
                qGroupManagersInfo = qGroupManagersInfo.Where(w => int.Parse(w.EntranceDate.Split('/')[1]) == int.Parse(month)).ToList();
            }
            if (!string.IsNullOrEmpty(week) && int.Parse(week) != 0 && week.IsNumeric())
            {
                WEEKS.Items.FirstOrDefault(x => int.Parse(x.Value) == int.Parse(week)).Selected = true;
                ViewBag.Week = WEEKS;
            }

            var qGroupManagers = qGroupManagersInfo
                .GroupBy(gr => new { gr.Id, gr.ProfCode, gr.ProfName, gr.BaseAmountInMonth })
                .Select(s => new GroupManagerViewModel
                {
                    Id = s.Key.Id,
                    ProfCode = s.Key.ProfCode,
                    ProfName = s.Key.ProfName,
                    BaseAmountInMonth = s.Key.BaseAmountInMonth
                }).ToList();

            foreach (var m in allMonthes)
            {
                if (!string.IsNullOrEmpty(month) && month.IsNumeric())
                    if (int.Parse(m) != int.Parse(month))
                        continue;

                var qGroupManagersDetailsInOutFilteredByMonth = qGroupManagersInfo?
                    .Where(w => (int.Parse(w.EntranceDate.Split('/')[1])) == int.Parse(m))
                    .Select(s => new GroupManagerDetailsViewModel
                    {
                        EntranceDate = s.EntranceDate,
                        EntranceTime = s.EntranceTime,
                        ExitTime = s.ExitTime,
                        IsOnline = s.IsOnline,
                        InTime = s.InTime,
                        OutTime = s.OutTime,
                        MinTime = s.MinTime,
                        GroupManagerId = s.Id
                    }).ToList();

                foreach (var gr in qGroupManagers)
                {
                    for (int w = 1; w <= 5; w++)
                    {
                        if (!string.IsNullOrEmpty(week) && week.IsNumeric())
                            if (w != int.Parse(week))
                                continue;

                        presenceInWeek = new PresenceInWeekViewModel();
                        presenceInWeek.GroupManagerId = gr.Id;
                        presenceInWeek.ProfCode = gr.ProfCode;
                        presenceInWeek.ProfName = gr.ProfName;
                        if (w != 5)
                            presenceInWeek.BaseAmountInWeek = (double.Parse(gr.BaseAmountInMonth) * BASE_AMOUNT_IN_WEEK_FRACTION).ToString();
                        else
                            presenceInWeek.BaseAmountInWeek = "0";

                        DateTime startWeekDate, endWeekDate;
                        qGroupManagersDetailsInOutFilteredByWeek = new List<GroupManagerDetailsViewModel>();

                        switch (w)
                        {
                            case 1:
                                startWeekDate = $"{currentPersianYear}/{m}/01".ToGregorian();
                                endWeekDate = $"{currentPersianYear}/{m}/07".ToGregorian();
                                qGroupManagersDetailsInOutFilteredByWeek = qGroupManagersDetailsInOutFilteredByMonth?
                                    .Where(x =>
                                        x.GroupManagerId == gr.Id
                                        && x.EntranceDate.ToGregorian() >= startWeekDate
                                        && x.EntranceDate.ToGregorian() <= endWeekDate
                                ).ToList();
                                break;

                            case 2:
                                startWeekDate = $"{currentPersianYear}/{m}/08".ToGregorian();
                                endWeekDate = $"{currentPersianYear}/{m}/15".ToGregorian();
                                qGroupManagersDetailsInOutFilteredByWeek = qGroupManagersDetailsInOutFilteredByMonth?
                                    .Where(x =>
                                        x.GroupManagerId == gr.Id
                                        && x.EntranceDate.ToGregorian() >= startWeekDate
                                        && x.EntranceDate.ToGregorian() <= endWeekDate
                                ).ToList();
                                break;

                            case 3:
                                startWeekDate = $"{currentPersianYear}/{m}/15".ToGregorian();
                                endWeekDate = $"{currentPersianYear}/{m}/21".ToGregorian();
                                qGroupManagersDetailsInOutFilteredByWeek = qGroupManagersDetailsInOutFilteredByMonth?
                                    .Where(x =>
                                        x.GroupManagerId == gr.Id
                                        && x.EntranceDate.ToGregorian() >= startWeekDate
                                        && x.EntranceDate.ToGregorian() <= endWeekDate
                                ).ToList();
                                break;

                            case 4:
                                startWeekDate = $"{currentPersianYear}/{m}/22".ToGregorian();
                                endWeekDate = $"{currentPersianYear}/{m}/27".ToGregorian();
                                qGroupManagersDetailsInOutFilteredByWeek = qGroupManagersDetailsInOutFilteredByMonth?
                                    .Where(x =>
                                        x.GroupManagerId == gr.Id
                                        && x.EntranceDate.ToGregorian() >= startWeekDate
                                        && x.EntranceDate.ToGregorian() <= endWeekDate
                                ).ToList();
                                break;

                            case 5:
                                startWeekDate = $"{currentPersianYear}/{m}/28".ToGregorian();
                                endWeekDate = $"{currentPersianYear}/{m}/31".ToGregorian();
                                qGroupManagersDetailsInOutFilteredByWeek = qGroupManagersDetailsInOutFilteredByMonth?
                                    .Where(x =>
                                        x.GroupManagerId == gr.Id
                                        && x.EntranceDate.ToGregorian() >= startWeekDate
                                        && x.EntranceDate.ToGregorian() <= endWeekDate
                                ).ToList();
                                break;
                        }
                        //days for each week 
                        foreach (var grd in qGroupManagersDetailsInOutFilteredByWeek)
                        {
                            if (grd.InTime != "00:00" && (int.Parse(grd.InTime.Split(':')[0]) * 60 + int.Parse(grd.InTime.Split(':')[1])) < 7 * 60)
                                grd.InTime = "07:00";

                            if (grd.OutTime != "00:00" && (int.Parse(grd.OutTime.Split(':')[0]) * 60 + int.Parse(grd.OutTime.Split(':')[1])) > 19 * 60)
                                grd.OutTime = "19:00";

                            var presenceTime = (grd.OutTime.ToMinute() - grd.InTime.ToMinute());
                            //var presenceTimeForHoliday= (grd.ExitTime.ToMinute() - grd.EntranceTime.ToMinute());


                            //check if day of week is holiday or not
                            if (await _holidaySVC.IsExists(e => e.HolidayDate == grd.EntranceDate))
                            {
                                if (presenceTime > 0)
                                {
                                    if (grd.IsOnline) OnlineTotalTime += presenceTime;
                                    else PhysicalTotalTime += presenceTime;
                                }
                                else
                                {
                                    if (grd.IsOnline) OnlineTotalTime += grd.MinTime.ToMinute(); //presenceTimeForHoliday
                                    else PhysicalTotalTime += grd.MinTime.ToMinute();//presenceTimeForHoliday
                                }
                            }
                            else
                            {
                                //day is thurthday ===> 0=saturday , 1=sunday ,...
                                if (grd.EntranceDate.ToGregorian().DayOfWeek.ToString().ToLower().Equals("thursday"))
                                {
                                    if (presenceTime > 5 * 60)//more than 5 hours
                                    {
                                        if (grd.IsOnline) OnlineTotalTime += 300;//5 hours
                                        else PhysicalTotalTime += 300;//5 hours
                                    }
                                    else
                                    {
                                        if (grd.IsOnline) OnlineTotalTime += presenceTime;//5 hours
                                        else PhysicalTotalTime += presenceTime;//5 hours
                                    }
                                }
                                else
                                {
                                    if (grd.IsOnline) OnlineTotalTime += presenceTime;//5 hours
                                    else PhysicalTotalTime += presenceTime;//5 hours
                                }

                            }

                        }

                        TotalTime += OnlineTotalTime;
                        TotalTime += PhysicalTotalTime;

                        presenceInWeek.Month = m;
                        presenceInWeek.Week = w.ToString();
                        presenceInWeek.PhysicalTotalTime = PhysicalTotalTime.ToHHmm();
                        presenceInWeek.OnlineTotalTime = OnlineTotalTime.ToHHmm();
                        presenceInWeek.TotalTime = TotalTime.ToHHmm();

                        presenceInWeeksList.Add(presenceInWeek);

                        OnlineTotalTime = PhysicalTotalTime = TotalTime = 0;
                    }

                }
            }

            //var xx = presenceInWeeksList.Where(c => int.Parse(c.Month) == 7 && int.Parse(c.Week) == 1);
            //return View(xx);
            return View(presenceInWeeksList);
        }

        //=======================
        [HttpGet]
        public async Task<ActionResult> PresenceInMonth(string month = "0")
        {
            ViewBag.Month = MONTHES;
            var finalModel = new List<PresenceInMonthViewModel>();
            if (month == "0") return View(finalModel);


            PresenceInMonthViewModel presenceInMonth;
            PresenceInWeekViewModel presenceInWeek;
            List<GroupManagerDetailsViewModel> qGroupManagersDetailsInOutFilteredByWeek;
            List<PresenceInWeekViewModel> presenceInWeeksList = new List<PresenceInWeekViewModel>();
            List<PresenceInMonthViewModel> presenceInMonthList = new List<PresenceInMonthViewModel>();

            var currentPersianYear = TODAY.Split('/')[0];
            int OnlineTotalTime = 0, PhysicalTotalTime = 0, TotalTime = 0;
            var allMonthes = new List<string>();


            var qGroupManagersInfo = (from gr in await _groupManagerSVC.GetAllGroupManagers(currentPersianYear, month)
                                      join gs in await _groupManagerScheduleSVC.GetAllGroupManagerSchedules() on gr.Id equals gs.GroupManagerId
                                      join gd in await _groupManagerDetailesSVC.GetAllGroupManagerDetails()
                                          on new { gs.GroupManagerId, gs.EntranceDate }
                                          equals new { gd.GroupManagerId, gd.EntranceDate } into GroupManDetails
                                      from grd in GroupManDetails.DefaultIfEmpty()
                                      where
                                      gs.EntranceDate.Trim().Length == 10 && gs.EntranceDate.Split('/').Length == 3
                                      && gs.EntranceTime.Trim().Length == 5 && gs.EntranceTime.Split(':').Length == 2
                                      && gs.ExitTime.Trim().Length == 5 && gs.ExitTime.Split(':').Length == 2
                                      && gs.EntranceDate.Split('/')[0].Equals(currentPersianYear)
                                      //&& gr.Id == 1
                                      select new GroupManagerInfoViewModel
                                      {
                                          Id = gr.Id,
                                          ProfCode = gr.ProfCode,
                                          ProfName = gr.ProfName,
                                          EntranceDate = gs.EntranceDate,
                                          EntranceTime = gs.EntranceTime,
                                          ExitTime = gs.ExitTime,
                                          MinTime = gs.MinTime,
                                          IsOnline = gs.IsOnline,
                                          //real in out time
                                          InTime = grd?.EntranceTime ?? "00:00",
                                          OutTime = grd?.ExitTime ?? "00:00",

                                          BaseAmountInMonth = gr.BaseAmount

                                      }).ToList();

            allMonthes = qGroupManagersInfo?.GroupBy(g => g.EntranceDate.Split('/')[1]).Select(s => s.Key).ToList();

            //ViewBag.Week = WEEKS;
            if (!string.IsNullOrEmpty(month) && int.Parse(month) != 0 && month.IsNumeric())
            {
                MONTHES.Items.FirstOrDefault(x => int.Parse(x.Value) == int.Parse(month)).Selected = true;
                ViewBag.Month = MONTHES;
                qGroupManagersInfo = qGroupManagersInfo.Where(w => int.Parse(w.EntranceDate.Split('/')[1]) == int.Parse(month)).ToList();
            }
            //if (!string.IsNullOrEmpty(week) && int.Parse(week) != 0 && week.IsNumeric())
            //{
            //    WEEKS.Items.FirstOrDefault(x => int.Parse(x.Value) == int.Parse(week)).Selected = true;
            //    ViewBag.Week = WEEKS;
            //}
            var qGroupManagers = qGroupManagersInfo?
                    .GroupBy(gr => new { gr.Id, gr.ProfCode, gr.ProfName, gr.ResearchCouncil, gr.BaseAmountInMonth })
                    .Select(s => new GroupManagerViewModel
                    {
                        Id = s.Key.Id,
                        ProfCode = s.Key.ProfCode,
                        ProfName = s.Key.ProfName,
                        ResearchCouncil = s.Key.ResearchCouncil,
                        BaseAmountInMonth = s.Key.BaseAmountInMonth
                    }).ToList();

            foreach (var m in allMonthes)
            {
                if (!string.IsNullOrEmpty(month) && month.IsNumeric())
                    if (int.Parse(m) != int.Parse(month))
                        continue;

                var qGroupManagersDetailsInOutFilteredByMonth = qGroupManagersInfo?
                    .Where(w => (int.Parse(w.EntranceDate.Split('/')[1])) == int.Parse(m))
                    .Select(s => new GroupManagerDetailsViewModel
                    {
                        EntranceDate = s.EntranceDate,
                        EntranceTime = s.EntranceTime,
                        ExitTime = s.ExitTime,
                        IsOnline = s.IsOnline,
                        InTime = s.InTime,
                        OutTime = s.OutTime,
                        MinTime = s.MinTime,
                        GroupManagerId = s.Id
                    }).ToList();

                foreach (var gr in qGroupManagers)
                {
                    for (int w = 1; w <= 5; w++)
                    {
                        //if (!string.IsNullOrEmpty(week) && week.IsNumeric())
                        //    if (w != int.Parse(week))
                        //        continue;

                        presenceInWeek = new PresenceInWeekViewModel();
                        presenceInWeek.GroupManagerId = gr.Id;
                        presenceInWeek.ProfCode = gr.ProfCode;
                        presenceInWeek.ProfName = gr.ProfName;
                        presenceInWeek.ResearchCouncil = gr.ResearchCouncil;

                        qGroupManagersDetailsInOutFilteredByWeek = new List<GroupManagerDetailsViewModel>();
                        DateTime startWeekDate, endWeekDate;

                        switch (w)
                        {
                            case 1:
                                startWeekDate = $"{currentPersianYear}/{m}/01".ToGregorian();
                                endWeekDate = $"{currentPersianYear}/{m}/07".ToGregorian();
                                qGroupManagersDetailsInOutFilteredByWeek = qGroupManagersDetailsInOutFilteredByMonth?
                                    .Where(x =>
                                        x.GroupManagerId == gr.Id
                                        && x.EntranceDate.ToGregorian() >= startWeekDate
                                        && x.EntranceDate.ToGregorian() <= endWeekDate
                                ).ToList();
                                break;

                            case 2:
                                startWeekDate = $"{currentPersianYear}/{m}/08".ToGregorian();
                                endWeekDate = $"{currentPersianYear}/{m}/15".ToGregorian();
                                qGroupManagersDetailsInOutFilteredByWeek = qGroupManagersDetailsInOutFilteredByMonth?
                                    .Where(x =>
                                        x.GroupManagerId == gr.Id
                                        && x.EntranceDate.ToGregorian() >= startWeekDate
                                        && x.EntranceDate.ToGregorian() <= endWeekDate
                                ).ToList();
                                break;

                            case 3:
                                startWeekDate = $"{currentPersianYear}/{m}/15".ToGregorian();
                                endWeekDate = $"{currentPersianYear}/{m}/21".ToGregorian();
                                qGroupManagersDetailsInOutFilteredByWeek = qGroupManagersDetailsInOutFilteredByMonth?
                                    .Where(x =>
                                        x.GroupManagerId == gr.Id
                                        && x.EntranceDate.ToGregorian() >= startWeekDate
                                        && x.EntranceDate.ToGregorian() <= endWeekDate
                                ).ToList();
                                break;

                            case 4:
                                startWeekDate = $"{currentPersianYear}/{m}/22".ToGregorian();
                                endWeekDate = $"{currentPersianYear}/{m}/27".ToGregorian();
                                qGroupManagersDetailsInOutFilteredByWeek = qGroupManagersDetailsInOutFilteredByMonth?
                                    .Where(x =>
                                        x.GroupManagerId == gr.Id
                                        && x.EntranceDate.ToGregorian() >= startWeekDate
                                        && x.EntranceDate.ToGregorian() <= endWeekDate
                                ).ToList();
                                break;

                            case 5:
                                startWeekDate = $"{currentPersianYear}/{m}/28".ToGregorian();
                                endWeekDate = $"{currentPersianYear}/{m}/31".ToGregorian();
                                qGroupManagersDetailsInOutFilteredByWeek = qGroupManagersDetailsInOutFilteredByMonth?
                                    .Where(x =>
                                        x.GroupManagerId == gr.Id
                                        && x.EntranceDate.ToGregorian() >= startWeekDate
                                        && x.EntranceDate.ToGregorian() <= endWeekDate
                                ).ToList();
                                break;
                        }
                        //days for each week 
                        foreach (var grd in qGroupManagersDetailsInOutFilteredByWeek)
                        {
                            if (grd.InTime != "00:00" && (int.Parse(grd.InTime.Split(':')[0]) * 60 + int.Parse(grd.InTime.Split(':')[1])) < 7 * 60)
                                grd.InTime = "07:00";

                            if (grd.OutTime != "00:00" && (int.Parse(grd.OutTime.Split(':')[0]) * 60 + int.Parse(grd.OutTime.Split(':')[1])) > 19 * 60)
                                grd.OutTime = "19:00";

                            var presenceTime = (grd.OutTime.ToMinute() - grd.InTime.ToMinute());
                            //var presenceTimeForHoliday= (grd.ExitTime.ToMinute() - grd.EntranceTime.ToMinute());


                            //check if day of week is holiday or not
                            if (await _holidaySVC.IsExists(e => e.HolidayDate == grd.EntranceDate))
                            {
                                if (presenceTime > 0)
                                {
                                    if (grd.IsOnline) OnlineTotalTime += presenceTime;
                                    else PhysicalTotalTime += presenceTime;
                                }
                                else
                                {
                                    if (grd.IsOnline) OnlineTotalTime += grd.MinTime.ToMinute(); //presenceTimeForHoliday
                                    else PhysicalTotalTime += grd.MinTime.ToMinute();//presenceTimeForHoliday
                                }
                            }
                            else
                            {
                                //day is thurthday ===> 0=saturday , 1=sunday ,...
                                if (grd.EntranceDate.ToGregorian().DayOfWeek.ToString().ToLower().Equals("thursday"))
                                {
                                    if (presenceTime > 5 * 60)//more than 5 hours
                                    {
                                        if (grd.IsOnline) OnlineTotalTime += 300;//5 hours
                                        else PhysicalTotalTime += 300;//5 hours
                                    }
                                    else
                                    {
                                        if (grd.IsOnline) OnlineTotalTime += presenceTime;//5 hours
                                        else PhysicalTotalTime += presenceTime;//5 hours
                                    }
                                }
                                else
                                {
                                    if (grd.IsOnline) OnlineTotalTime += presenceTime;//5 hours
                                    else PhysicalTotalTime += presenceTime;//5 hours
                                }

                            }

                        }

                        TotalTime += OnlineTotalTime;
                        TotalTime += PhysicalTotalTime;

                        presenceInWeek.Month = m;
                        presenceInWeek.Week = w.ToString();
                        presenceInWeek.PhysicalTotalTime = PhysicalTotalTime.ToHHmm();
                        presenceInWeek.OnlineTotalTime = OnlineTotalTime.ToHHmm();
                        presenceInWeek.TotalTime = TotalTime.ToHHmm();

                        presenceInWeeksList.Add(presenceInWeek);

                        OnlineTotalTime = PhysicalTotalTime = TotalTime = 0;
                    }
                    var presenceInWeeksListFilteredByGroupManagerId = presenceInWeeksList?
                            .Where(a => int.Parse(a.Month) == int.Parse(m) && a.GroupManagerId == gr.Id);


                    presenceInMonth = new PresenceInMonthViewModel();
                    presenceInMonth.Id = gr.Id;
                    presenceInMonth.ProfCode = gr.ProfCode;
                    presenceInMonth.ProfName = gr.ProfName;
                    presenceInMonth.ResearchCouncil = gr.ResearchCouncil;
                    presenceInMonth.Month = m;
                    presenceInMonth.BaseAmountInMonth = gr.BaseAmountInMonth;

                    foreach (var item in presenceInWeeksListFilteredByGroupManagerId)
                    {
                        switch (int.Parse(item.Week))
                        {
                            case 1:
                                presenceInMonth.OnlineTimeInWeek1 = item.OnlineTotalTime;
                                presenceInMonth.OfflineTimeInWeek1 = item.PhysicalTotalTime;
                                presenceInMonth.TotalTimeInWeek1 = item.TotalTime;
                                break;

                            case 2:
                                presenceInMonth.OnlineTimeInWeek2 = item.OnlineTotalTime;
                                presenceInMonth.OfflineTimeInWeek2 = item.PhysicalTotalTime;
                                presenceInMonth.TotalTimeInWeek2 = item.TotalTime;
                                break;

                            case 3:
                                presenceInMonth.OnlineTimeInWeek3 = item.OnlineTotalTime;
                                presenceInMonth.OfflineTimeInWeek3 = item.PhysicalTotalTime;
                                presenceInMonth.TotalTimeInWeek3 = item.TotalTime;
                                break;

                            case 4:
                                presenceInMonth.OnlineTimeInWeek4 = item.OnlineTotalTime;
                                presenceInMonth.OfflineTimeInWeek4 = item.PhysicalTotalTime;
                                presenceInMonth.TotalTimeInWeek4 = item.TotalTime;
                                break;

                            case 5:
                                presenceInMonth.OnlineTimeInWeek5 = item.OnlineTotalTime;
                                presenceInMonth.OfflineTimeInWeek5 = item.PhysicalTotalTime;
                                presenceInMonth.TotalTimeInWeek5 = item.TotalTime;
                                break;
                        }
                    }
                    presenceInMonthList.Add(presenceInMonth);
                }
            }


            if (presenceInMonthList.Count() > 0)
            {
                foreach (var item22 in presenceInMonthList.OrderBy(ord => ord.Id).ThenBy(tb => tb.TotalTimeInMounth))
                {
                    var item = CalculateTotalAmountInMonth(item22);
                    finalModel.Add(item);
                }
            }
            return View(finalModel);
        }

        PresenceInMonthViewModel CalculateTotalAmountInMonth(PresenceInMonthViewModel item)
        {
            var BASE_AMOUNT_IN_WEEK = double.Parse(item.BaseAmountInMonth) * BASE_AMOUNT_IN_WEEK_FRACTION;
            int TotalTimeInWeek1 = item.TotalTimeInWeek1.ToMinute();
            int TotalTimeInWeek2 = item.TotalTimeInWeek2.ToMinute();
            int TotalTimeInWeek3 = item.TotalTimeInWeek3.ToMinute();
            int TotalTimeInWeek4 = item.TotalTimeInWeek4.ToMinute();

            int TotalTimeInWeek5 = item.TotalTimeInWeek5.ToMinute();

            int[] totalTimeInWeeks = new int[] { TotalTimeInWeek1, TotalTimeInWeek2, TotalTimeInWeek3, TotalTimeInWeek4 };
            var minTime = totalTimeInWeeks.Min();

            if (TotalTimeInWeek1 == minTime) TotalTimeInWeek1 += TotalTimeInWeek5;
            if (TotalTimeInWeek2 == minTime) TotalTimeInWeek2 += TotalTimeInWeek5;
            if (TotalTimeInWeek3 == minTime) TotalTimeInWeek3 += TotalTimeInWeek5;
            if (TotalTimeInWeek4 == minTime) TotalTimeInWeek4 += TotalTimeInWeek5;

            item.TotalTimeInWeek1 = TotalTimeInWeek1.ToHHmm();
            item.TotalTimeInWeek2 = TotalTimeInWeek2.ToHHmm();
            item.TotalTimeInWeek3 = TotalTimeInWeek3.ToHHmm();
            item.TotalTimeInWeek4 = TotalTimeInWeek4.ToHHmm();



            if (TotalTimeInWeek1 < 6 * 60)
            {
                item.FinalAmountInWeek1 = "0";
            }
            else
            {
                if (TotalTimeInWeek1 >= 6 * 60 && TotalTimeInWeek1 < 7 * 60)
                {
                    item.FinalAmountInWeek1 = (BASE_AMOUNT_IN_WEEK * 0.75).ToString();
                }
                else if (TotalTimeInWeek1 >= 7 * 60 && TotalTimeInWeek1 < 8 * 60)
                {
                    item.FinalAmountInWeek1 = (BASE_AMOUNT_IN_WEEK * 0.8).ToString();
                }
                else if (TotalTimeInWeek1 >= 8 * 60 && TotalTimeInWeek1 < 9 * 60)
                {
                    item.FinalAmountInWeek1 = (BASE_AMOUNT_IN_WEEK * 0.85).ToString();
                }

                else if (TotalTimeInWeek1 >= 9 * 60 && TotalTimeInWeek1 < 10 * 60)
                {
                    item.FinalAmountInWeek1 = (BASE_AMOUNT_IN_WEEK * 0.9).ToString();
                }

                else if (TotalTimeInWeek1 >= 10 * 60 && TotalTimeInWeek1 < 11 * 60)
                {
                    item.FinalAmountInWeek1 = (BASE_AMOUNT_IN_WEEK * 0.95).ToString();
                }
                else //if (TotalTimeInWeek1 >= 11 * 60)
                {
                    item.FinalAmountInWeek1 = BASE_AMOUNT_IN_WEEK.ToString();
                }

                if (item.OnlineTimeInWeek1.ToMinute() < 100)
                    //kasre 20% az meghdar feli
                    item.FinalAmountInWeek1 = (double.Parse(item.FinalAmountInWeek1) * 0.8).ToString();
            }

            //#########################

            if (TotalTimeInWeek2 < 6 * 60)
            {
                item.FinalAmountInWeek2 = "0";
            }
            else
            {
                if (TotalTimeInWeek2 >= 6 * 60 && TotalTimeInWeek2 < 7 * 60)
                {
                    item.FinalAmountInWeek2 = (BASE_AMOUNT_IN_WEEK * 0.75).ToString();
                }
                else if (TotalTimeInWeek2 >= 7 * 60 && TotalTimeInWeek2 < 8 * 60)
                {
                    item.FinalAmountInWeek2 = (BASE_AMOUNT_IN_WEEK * 0.8).ToString();
                }
                else if (TotalTimeInWeek2 >= 8 * 60 && TotalTimeInWeek2 < 9 * 60)
                {
                    item.FinalAmountInWeek2 = (BASE_AMOUNT_IN_WEEK * 0.85).ToString();
                }

                else if (TotalTimeInWeek2 >= 9 * 60 && TotalTimeInWeek2 < 10 * 60)
                {
                    item.FinalAmountInWeek2 = (BASE_AMOUNT_IN_WEEK * 0.9).ToString();
                }

                else if (TotalTimeInWeek2 >= 10 * 60 && TotalTimeInWeek2 < 11 * 60)
                {
                    item.FinalAmountInWeek2 = (BASE_AMOUNT_IN_WEEK * 0.95).ToString();
                }
                else if (TotalTimeInWeek2 >= 11 * 60)
                {
                    item.FinalAmountInWeek2 = BASE_AMOUNT_IN_WEEK.ToString();
                }

                if (item.OnlineTimeInWeek2.ToMinute() < 100)
                    //kasre 20% az meghdar feli
                    item.FinalAmountInWeek2 = (double.Parse(item.FinalAmountInWeek2) * 0.8).ToString();
            }

            //#########################

            if (TotalTimeInWeek3 < 6 * 60)
            {
                item.FinalAmountInWeek3 = "0";
            }
            else
            {
                if (TotalTimeInWeek3 >= 6 * 60 && TotalTimeInWeek3 < 7 * 60)
                {
                    item.FinalAmountInWeek3 = (BASE_AMOUNT_IN_WEEK * 0.75).ToString();
                }
                else if (TotalTimeInWeek3 >= 7 * 60 && TotalTimeInWeek3 < 8 * 60)
                {
                    item.FinalAmountInWeek3 = (BASE_AMOUNT_IN_WEEK * 0.8).ToString();
                }
                else if (TotalTimeInWeek3 >= 8 * 60 && TotalTimeInWeek3 < 9 * 60)
                {
                    item.FinalAmountInWeek3 = (BASE_AMOUNT_IN_WEEK * 0.85).ToString();
                }

                else if (TotalTimeInWeek3 >= 9 * 60 && TotalTimeInWeek3 < 10 * 60)
                {
                    item.FinalAmountInWeek3 = (BASE_AMOUNT_IN_WEEK * 0.9).ToString();
                }

                else if (TotalTimeInWeek3 >= 10 * 60 && TotalTimeInWeek3 < 11 * 60)
                {
                    item.FinalAmountInWeek3 = (BASE_AMOUNT_IN_WEEK * 0.95).ToString();
                }
                else if (TotalTimeInWeek3 >= 11 * 60)
                {
                    item.FinalAmountInWeek3 = BASE_AMOUNT_IN_WEEK.ToString();
                }

                if (item.OnlineTimeInWeek3.ToMinute() < 100)
                    //kasre 20% az meghdar feli
                    item.FinalAmountInWeek3 = (double.Parse(item.FinalAmountInWeek3) * 0.8).ToString();
            }

            //#########################

            if (TotalTimeInWeek4 < 6 * 60)
            {
                item.FinalAmountInWeek4 = "0";
            }
            else
            {
                if (TotalTimeInWeek4 >= 6 * 60 && TotalTimeInWeek4 < 7 * 60)
                {
                    item.FinalAmountInWeek4 = (BASE_AMOUNT_IN_WEEK * 0.75).ToString();
                }
                else if (TotalTimeInWeek4 >= 7 * 60 && TotalTimeInWeek4 < 8 * 60)
                {
                    item.FinalAmountInWeek4 = (BASE_AMOUNT_IN_WEEK * 0.8).ToString();
                }
                else if (TotalTimeInWeek4 >= 8 * 60 && TotalTimeInWeek4 < 9 * 60)
                {
                    item.FinalAmountInWeek4 = (BASE_AMOUNT_IN_WEEK * 0.85).ToString();
                }

                else if (TotalTimeInWeek4 >= 9 * 60 && TotalTimeInWeek4 < 10 * 60)
                {
                    item.FinalAmountInWeek4 = (BASE_AMOUNT_IN_WEEK * 0.9).ToString();
                }

                else if (TotalTimeInWeek4 >= 10 * 60 && TotalTimeInWeek4 < 11 * 60)
                {
                    item.FinalAmountInWeek4 = (BASE_AMOUNT_IN_WEEK * 0.95).ToString();
                }
                else if (TotalTimeInWeek4 >= 11 * 60)
                {
                    item.FinalAmountInWeek4 = BASE_AMOUNT_IN_WEEK.ToString();
                }

                if (item.OnlineTimeInWeek4.ToMinute() < 100)
                    //kasre 20% az meghdar feli
                    item.FinalAmountInWeek4 = (double.Parse(item.FinalAmountInWeek4) * 0.8).ToString();
            }

            var totalTimeInMounth = item.TotalTimeInWeek1.ToMinute();
            totalTimeInMounth += item.TotalTimeInWeek2.ToMinute();
            totalTimeInMounth += item.TotalTimeInWeek3.ToMinute();
            totalTimeInMounth += item.TotalTimeInWeek4.ToMinute();

            item.TotalTimeInMounth = totalTimeInMounth.ToHHmm();

            item.FinalAmountInMonth = (
                    double.Parse(item.FinalAmountInWeek1)
                  + double.Parse(item.FinalAmountInWeek2)
                  + double.Parse(item.FinalAmountInWeek3)
                  + double.Parse(item.FinalAmountInWeek4)
                ).ToString();

            if (!item.ResearchCouncil)
            {
                item.FinalAmountInMonth = (0.8 * double.Parse(item.FinalAmountInMonth)).ToString();
            }
            //#########################
            PresenceInMonthViewModel model = item;
            return item;
        }


        //=======================


        [HttpGet]
        public async Task<ActionResult> Holidays()
        {
            var currentYear = TODAY.Split('/')[0];
            var holidays = (
                    from h in await _holidaySVC.GetManyHolidays(y => !string.IsNullOrEmpty(y.HolidayDate))
                    let date = h.HolidayDate
                    let year = date.Split('/')[0]
                    where year != null && year == currentYear
                    orderby date descending
                    select h
                ).ToList();
            return View(holidays);

        }

        [HttpPost]
        public async Task<ActionResult> Holidays(string date, string note)
        {
            var res = new JsonResult(new { Response = "invalid request" });
            if (!string.IsNullOrEmpty(date) && !string.IsNullOrEmpty(note))
            {
                var items = await _holidaySVC.GetManyHolidays(h => h.HolidayDate == date);
                if (items.Count() > 0)
                {
                    res.Value = "holiday exist";
                }
                else
                {
                    var item2Insert = new Holiday
                    {
                        Active = true,
                        Note = note,
                        HolidayDate = date
                    };
                    var r = await _holidaySVC.AddHoliday(item2Insert);
                    res.Value = "success";
                }
            }
            return res;
        }

        [HttpPost]
        public async Task<ActionResult> RemoveHoliday(string date)
        {
            var res = new JsonResult(new { Response = "invalid request" });
            if (!string.IsNullOrEmpty(date))
            {
                var items = await _holidaySVC.GetManyHolidays(h => h.HolidayDate == date);
                if (items.Count() > 0)
                {
                    var x = await _holidaySVC.RemoveHoliday(items.First());
                    res.Value = "success";
                }
                else
                    res.Value = "holiday note exist";

            }
            return res;
        }

        //=======================


        #region hidden
        /*   
       [HttpPost]
       public async Task<JsonResult> Search(string data)
       {
           //ModelState.Clear();
           IEnumerable<GroupManager> fetchedList = new List<GroupManager>();
           IEnumerable<GroupManagerDto> mappedList = new List<GroupManagerDto>();
           if (!string.IsNullOrEmpty(data))
           {
               if (data.IsNumeric())
                   fetchedList = await _groupManagerSVC.GetManyGroupManagers(x => x.ProfCode == data);
               else
                   fetchedList = await _groupManagerSVC.GetManyGroupManagers(x => x.ProfName.Contains(data));

               if (fetchedList.Count() > 0)
                   mappedList = _mapper.Map<IEnumerable<GroupManager>, IEnumerable<GroupManagerDto>>(fetchedList);

           }

           return Json(mappedList);

       }

       [HttpPost]
       public async Task<ActionResult> PresenceInWeek(WeekDto model)
       {
           IEnumerable<GroupManager> groupManagers = null;
           var modelist = new List<PresenceInWeekViewModel>();
           if (model != null)
           {
               var rangeDate = model.GetRangeDate();
               int OnlineTotalTime = 0, OffLineTime = 0, TotalTime = 0;

               if (!string.IsNullOrEmpty(model.SearchData))
               {
                   groupManagers = new List<GroupManager>();
                   //groupManagers = await _groupManagerSVC.GetAllGroupManagers();
                   if (model.SearchData.IsNumeric())
                   {
                       //groupManagers= groupManagers.Where(w=>w.ProfCode==model.SearchData);
                       groupManagers = await _groupManagerSVC.GetByFilterAsync(x => x.ProfCode == model.SearchData);
                   }
                   else
                   {
                       //groupManagers = groupManagers.Where(w => w.ProfName.Contains(model.SearchData));
                       groupManagers = await _groupManagerSVC.GetByFilterAsync(x => x.ProfName.Contains(model.SearchData));
                   }
               }

               var qGroupManagersInfo = (from gr in groupManagers ?? await _groupManagerSVC.GetAllGroupManagers()
                                         join grd in await _groupManagerDetailesSVC.GetAllGroupManagerDetails() on gr.Id equals grd.GroupManagerId
                                         where
                                         grd.EntranceDate.Trim().Length == 10 && grd.EntranceDate.Split('/').Length == 3
                                         && grd.EntranceTime.Trim().Length == 5 && grd.EntranceTime.Split(':').Length == 2
                                         && grd.ExitTime.Trim().Length == 5 && grd.ExitTime.Split(':').Length == 2
                                         && grd.EntranceDate.ToGregorian() >= rangeDate.StratWeek.ToGregorian()
                                         && grd.EntranceDate.ToGregorian() <= rangeDate.EndWeek.ToGregorian()

                                         select new GroupManagerInfoViewModel
                                         {
                                             Id = gr.Id,
                                             ProfCode = gr.ProfCode,
                                             ProfName = gr.ProfName,
                                             EntranceDate = grd.EntranceDate,
                                             EntranceTime = grd.EntranceTime,
                                             ExitTime = grd.ExitTime,
                                             IsOnline = grd.IsOnline
                                         }).ToList();

               var qGroupManagers = qGroupManagersInfo
                   .GroupBy(gr => new { gr.Id, gr.ProfCode, gr.ProfName })
                   .Select(s => new GroupManagerViewModel
                   {
                       Id = s.Key.Id,
                       ProfCode = s.Key.ProfCode,
                       ProfName = s.Key.ProfName
                   }).ToList();

               foreach (var g in qGroupManagers)
               {
                   var presentModel = new PresenceInWeekViewModel();

                   presentModel.GroupManagerId = g.Id;
                   presentModel.ProfCode = g.ProfCode;
                   presentModel.ProfName = g.ProfName;

                   var filteredDetailes = qGroupManagersInfo.Where(w => w.Id == g.Id).Select(grd => new GroupManagerDetailsViewModel
                   {
                       EntranceDate = grd.EntranceDate,
                       EntranceTime = grd.EntranceTime,
                       ExitTime = grd.ExitTime,
                       IsOnline = grd.IsOnline
                   });

                   OnlineTotalTime = OffLineTime = TotalTime = 0;
                   foreach (var d in filteredDetailes)
                   {
                       if (d.IsOnline)
                       {
                           // 10:20 ==>hh:mm 
                           OnlineTotalTime += (d.ExitTime.ToMinute() - d.EntranceTime.ToMinute());
                       }
                       else
                       {
                           OffLineTime += (d.ExitTime.ToMinute() - d.EntranceTime.ToMinute());
                       }
                   }

                   TotalTime = OnlineTotalTime + OffLineTime;

                   presentModel.Month = model.MonthNo;
                   presentModel.Week = model.WeekNo;
                   presentModel.PhysicalTotalTime = $"{OffLineTime / 60}:{OffLineTime % 60}".ToStandardPersianTime();
                   presentModel.OnlineTotalTime = $"{OnlineTotalTime / 60}:{OnlineTotalTime % 60}".ToStandardPersianTime();
                   presentModel.TotalTime = $"{TotalTime / 60}:{TotalTime % 60}".ToStandardPersianTime();

                   modelist.Add(presentModel);
               }
           }

           var tbody = "";
           if (modelist.Count() > 0)
           {
               foreach (var item in modelist.OrderBy(ord => ord.GroupManagerId).ThenBy(tb => tb.TotalTime))
               {
                   tbody += $"<tr><td>{item.GroupManagerId}</td><td>{item.ProfCode}</td><td>{item.ProfName}</td><td>{item.Month}</td><td>{item.Week}</td><td>{item.OnlineTotalTime}</td><td>{item.PhysicalTotalTime}</td><td>{item.TotalTime}</td></tr>";
               }
           }
           return Content(tbody);
       }


       [HttpPost]
       public async Task<ActionResult> PresenceInMonth(WeekDto model)
       {
           IEnumerable<GroupManager> groupManagers = null;
           PresenceInWeekViewModel presenceInWeek;
           PresenceInMonthViewModel presenceInMonth;
           List<GroupManagerDetailsViewModel> qGroupManagersDetailsInOutFilteredByWeek;
           List<PresenceInWeekViewModel> presenceInWeeksList = new List<PresenceInWeekViewModel>();
           List<PresenceInMonthViewModel> presenceInMonthList = new List<PresenceInMonthViewModel>();

           if (model != null)
           {

               //if (!string.IsNullOrEmpty(model.SearchData))
               //{
               //    groupManagers = new List<GroupManager>();
               //    //groupManagers = await _groupManagerSVC.GetAllGroupManagers();
               //    if (model.SearchData.IsNumeric())
               //    {
               //        //groupManagers= groupManagers.Where(w=>w.ProfCode==model.SearchData);
               //        groupManagers = await _groupManagerSVC.GetByFilterAsync(x => x.ProfCode == model.SearchData);
               //    }
               //    else
               //    {
               //        //groupManagers = groupManagers.Where(w => w.ProfName.Contains(model.SearchData));
               //        groupManagers = await _groupManagerSVC.GetByFilterAsync(x => x.ProfName.Contains(model.SearchData));
               //    }
               //}

               var qGroupManagersInfo = (from gr in groupManagers ?? await _groupManagerSVC.GetAllGroupManagers()
                                         join gs in await _groupManagerScheduleSVC.GetAllGroupManagerSchedules() on gr.Id equals gs.GroupManagerId
                                         join gd in await _groupManagerDetailesSVC.GetAllGroupManagerDetails()
                                             on new { gs.GroupManagerId, gs.EntranceDate }
                                             equals new { gd.GroupManagerId, gd.EntranceDate } into GroupManDetails
                                         from grd in GroupManDetails.DefaultIfEmpty()
                                         where
                                         gs.EntranceDate.Trim().Length == 10 && gs.EntranceDate.Split('/').Length == 3
                                         && gs.EntranceTime.Trim().Length == 5 && gs.EntranceTime.Split(':').Length == 2
                                         && gs.ExitTime.Trim().Length == 5 && gs.ExitTime.Split(':').Length == 2
                                         //&& gr.Id == 1
                                         select new GroupManagerInfoViewModel
                                         {
                                             Id = gr.Id,
                                             ProfCode = gr.ProfCode,
                                             ProfName = gr.ProfName,
                                             EntranceDate = grd?.EntranceDate ?? gs.EntranceDate ?? "",
                                             EntranceTime = grd?.EntranceTime ?? "00:00",
                                             ExitTime = grd?.ExitTime ?? "00:00",
                                             IsOnline = grd?.IsOnline ?? false,
                                             MinTime = gs.MinTime
                                         }).Where(w => w.EntranceDate != "").ToList();


               var qGroupManagers = qGroupManagersInfo?
                   .GroupBy(gr => new { gr.Id, gr.ProfCode, gr.ProfName })
                   .Select(s => new GroupManagerViewModel
                   {
                       Id = s.Key.Id,
                       ProfCode = s.Key.ProfCode,
                       ProfName = s.Key.ProfName
                   }).ToList();

               var currentYear = model.YearNo ?? qGroupManagersInfo?.GroupBy(g => g.EntranceDate.Split('/')[0]).Select(s => s.Key).FirstOrDefault();
               var allMonthes = qGroupManagersInfo?.GroupBy(g => g.EntranceDate.Split('/')[1]).Select(s => s.Key).ToArray();
               int OnlineTotalTime = 0, PhysicalTotalTime = 0, TotalTime = 0;

               foreach (var m in allMonthes)
               {
                   if (!string.IsNullOrEmpty(model.MonthNo))
                       if (int.Parse(model.MonthNo) != int.Parse(m)) continue;

                   var qGroupManagersDetailsInOutFilteredByMonth = qGroupManagersInfo?
                       .Where(w => (int.Parse(w.EntranceDate.Split('/')[1])) == int.Parse(m))
                       .Select(s => new GroupManagerDetailsViewModel
                       {
                           EntranceDate = s.EntranceDate,
                           EntranceTime = s.EntranceTime,
                           ExitTime = s.ExitTime,
                           IsOnline = s.IsOnline,
                           GroupManagerId = s.Id
                       }).ToList();

                   foreach (var gr in qGroupManagers)
                   {
                       for (int w = 1; w <= 5; w++)
                       {
                           presenceInWeek = new PresenceInWeekViewModel();
                           presenceInWeek.GroupManagerId = gr.Id;
                           presenceInWeek.ProfCode = gr.ProfCode;
                           presenceInWeek.ProfName = gr.ProfName;
                           qGroupManagersDetailsInOutFilteredByWeek = new List<GroupManagerDetailsViewModel>();
                           DateTime startWeekDate, endWeekDate;

                           switch (w)
                           {
                               case 1:
                                   startWeekDate = $"{currentYear}/{m}/01".ToGregorian();
                                   endWeekDate = $"{currentYear}/{m}/07".ToGregorian();
                                   qGroupManagersDetailsInOutFilteredByWeek = qGroupManagersDetailsInOutFilteredByMonth?
                                       .Where(x =>
                                           x.GroupManagerId == gr.Id
                                           && x.EntranceDate.ToGregorian() >= startWeekDate
                                           && x.EntranceDate.ToGregorian() <= endWeekDate
                                   ).ToList();
                                   break;

                               case 2:
                                   startWeekDate = $"{currentYear}/{m}/08".ToGregorian();
                                   endWeekDate = $"{currentYear}/{m}/15".ToGregorian();
                                   qGroupManagersDetailsInOutFilteredByWeek = qGroupManagersDetailsInOutFilteredByMonth?
                                       .Where(x =>
                                           x.GroupManagerId == gr.Id
                                           && x.EntranceDate.ToGregorian() >= startWeekDate
                                           && x.EntranceDate.ToGregorian() <= endWeekDate
                                   ).ToList();
                                   break;

                               case 3:
                                   startWeekDate = $"{currentYear}/{m}/15".ToGregorian();
                                   endWeekDate = $"{currentYear}/{m}/21".ToGregorian();
                                   qGroupManagersDetailsInOutFilteredByWeek = qGroupManagersDetailsInOutFilteredByMonth?
                                       .Where(x =>
                                           x.GroupManagerId == gr.Id
                                           && x.EntranceDate.ToGregorian() >= startWeekDate
                                           && x.EntranceDate.ToGregorian() <= endWeekDate
                                   ).ToList();
                                   break;

                               case 4:
                                   startWeekDate = $"{currentYear}/{m}/22".ToGregorian();
                                   endWeekDate = $"{currentYear}/{m}/27".ToGregorian();
                                   qGroupManagersDetailsInOutFilteredByWeek = qGroupManagersDetailsInOutFilteredByMonth?
                                       .Where(x =>
                                           x.GroupManagerId == gr.Id
                                           && x.EntranceDate.ToGregorian() >= startWeekDate
                                           && x.EntranceDate.ToGregorian() <= endWeekDate
                                   ).ToList();
                                   break;

                               case 5:
                                   startWeekDate = $"{currentYear}/{m}/28".ToGregorian();
                                   endWeekDate = $"{currentYear}/{m}/31".ToGregorian();
                                   qGroupManagersDetailsInOutFilteredByWeek = qGroupManagersDetailsInOutFilteredByMonth?
                                       .Where(x =>
                                           x.GroupManagerId == gr.Id
                                           && x.EntranceDate.ToGregorian() >= startWeekDate
                                           && x.EntranceDate.ToGregorian() <= endWeekDate
                                   ).ToList();
                                   break;
                           }
                           //days for each week 
                           foreach (var grd in qGroupManagersDetailsInOutFilteredByWeek)
                           {

                               //check special holidy
                               if (await _holidaySVC.IsExists(e => e.HolidayDate == grd.EntranceDate))
                               {
                                   var scheduleDays = await _groupManagerScheduleSVC
                                       .GetManyGroupManagerSchedules(x => x.GroupManagerId == gr.Id && x.EntranceDate == grd.EntranceDate);

                                   var holidayTime = scheduleDays.Count() > 0 ? scheduleDays.FirstOrDefault().MinTime.ToMinute() : 480;//8*60=480

                                   TotalTime += holidayTime;
                                   holidayTime = 0;
                               }
                               else
                               {
                                   //if has schedule and  entrance
                                   if (grd.EntranceTime != "00:00" && grd.ExitTime != "00:00")
                                   {
                                       //day was thurthday
                                       //0=saturday , 1=sunday ,...
                                       if (grd.EntranceDate.ToGregorian().DayOfWeek.ToString().ToLower().Equals("thursday"))
                                       {
                                           var deff = (grd.ExitTime.ToMinute() - grd.EntranceTime.ToMinute());
                                           //presenceTime more than 5 hours
                                           if (deff > 5 * 60)
                                           {
                                               deff = 300;//300 minute
                                               TotalTime += deff;
                                               deff = 0;
                                           }
                                       }
                                       else
                                       {
                                           if (int.Parse(grd.EntranceTime.Split(':')[0]) < 7) grd.EntranceTime = "07:00";
                                           if (int.Parse(grd.ExitTime.Split(':')[0]) > 19) grd.ExitTime = "19:00";
                                           if (grd.IsOnline)
                                           {
                                               // 10:20 ==>hh:mm
                                               OnlineTotalTime += (grd.ExitTime.ToMinute() - grd.EntranceTime.ToMinute());
                                           }
                                           else
                                           {
                                               PhysicalTotalTime += (grd.ExitTime.ToMinute() - grd.EntranceTime.ToMinute());
                                           }
                                       }
                                   }
                               }
                           }

                           TotalTime += OnlineTotalTime;
                           TotalTime += PhysicalTotalTime;

                           presenceInWeek.Month = model.MonthNo;
                           presenceInWeek.Week = w.ToString();
                           presenceInWeek.PhysicalTotalTime = PhysicalTotalTime.ToHHmm();
                           presenceInWeek.OnlineTotalTime = OnlineTotalTime.ToHHmm();
                           presenceInWeek.TotalTime = TotalTime.ToHHmm();

                           presenceInWeeksList.Add(presenceInWeek);

                           OnlineTotalTime = PhysicalTotalTime = TotalTime = 0;
                       }
                       var presenceInWeeksListFilteredByGroupManagerId = presenceInWeeksList?
                               .Where(a => int.Parse(a.Month) == int.Parse(m) && a.GroupManagerId == gr.Id);


                       presenceInMonth = new PresenceInMonthViewModel();
                       presenceInMonth.Id = gr.Id;
                       presenceInMonth.ProfCode = gr.ProfCode;
                       presenceInMonth.ProfName = gr.ProfName;
                       presenceInMonth.Month = m;

                       foreach (var item in presenceInWeeksListFilteredByGroupManagerId)
                       {
                           switch (int.Parse(item.Week))
                           {
                               case 1:
                                   presenceInMonth.OnlineTimeInWeek1 = item.OnlineTotalTime;
                                   presenceInMonth.OfflineTimeInWeek1 = item.PhysicalTotalTime;
                                   presenceInMonth.TotalTimeInWeek1 = item.TotalTime;
                                   break;

                               case 2:
                                   presenceInMonth.OnlineTimeInWeek2 = item.OnlineTotalTime;
                                   presenceInMonth.OfflineTimeInWeek2 = item.PhysicalTotalTime;
                                   presenceInMonth.TotalTimeInWeek2 = item.TotalTime;
                                   break;

                               case 3:
                                   presenceInMonth.OnlineTimeInWeek3 = item.OnlineTotalTime;
                                   presenceInMonth.OfflineTimeInWeek3 = item.PhysicalTotalTime;
                                   presenceInMonth.TotalTimeInWeek3 = item.TotalTime;
                                   break;

                               case 4:
                                   presenceInMonth.OnlineTimeInWeek4 = item.OnlineTotalTime;
                                   presenceInMonth.OfflineTimeInWeek4 = item.PhysicalTotalTime;
                                   presenceInMonth.TotalTimeInWeek4 = item.TotalTime;
                                   break;

                               case 5:
                                   presenceInMonth.OnlineTimeInWeek5 = item.OnlineTotalTime;
                                   presenceInMonth.OfflineTimeInWeek5 = item.PhysicalTotalTime;
                                   presenceInMonth.TotalTimeInWeek5 = item.TotalTime;
                                   break;
                           }
                       }
                       //var totalTimeInMounth = presenceInMonth.TotalTimeInWeek1.ToMinute();
                       //totalTimeInMounth += presenceInMonth.TotalTimeInWeek2.ToMinute();
                       //totalTimeInMounth += presenceInMonth.TotalTimeInWeek3.ToMinute();
                       //totalTimeInMounth += presenceInMonth.TotalTimeInWeek4.ToMinute();
                       //totalTimeInMounth += presenceInMonth.TotalTimeInWeek5.ToMinute();
                       //presenceInMonth.TotalTimeInMounth = totalTimeInMounth.ToHHmm();
                       presenceInMonthList.Add(presenceInMonth);
                   }
               }


           }

           var tbody = "";
           if (presenceInMonthList.Count() > 0)
           {
               foreach (var item22 in presenceInMonthList.OrderBy(ord => ord.Id).ThenBy(tb => tb.TotalTimeInMounth))
               {
                   var item = CalculateTotalAmountInMonth(item22);

                   tbody += $"<tr><td>{item.Id}</td><td>{item.ProfCode}</td><td>{item.ProfName}</td><td>{item.Month}</td>";
                   tbody += $"<td>{item.OnlineTimeInWeek1}</td><td>{item.OfflineTimeInWeek1}</td><td>{item.TotalTimeInWeek1}</td>";
                   tbody += $"<td>{item.OnlineTimeInWeek2}</td><td>{item.OfflineTimeInWeek2}</td><td>{item.TotalTimeInWeek2}</td>";
                   tbody += $"<td>{item.OnlineTimeInWeek3}</td><td>{item.OfflineTimeInWeek3}</td><td>{item.TotalTimeInWeek3}</td>";
                   tbody += $"<td>{item.OnlineTimeInWeek4}</td><td>{item.OfflineTimeInWeek4}</td><td>{item.TotalTimeInWeek4}</td>";
                   tbody += $"<td>{item.TotalTimeInWeek5}</td><td>{item.TotalTimeInMounth}</td><td>{item.FinalAmountInWeek1}</td>";
                   tbody += $"<td>{item.FinalAmountInWeek2}</td><td>{item.FinalAmountInWeek3}</td><td>{item.FinalAmountInWeek4}</td>";
                   tbody += $"<td>{item.FinalAmountInMonth}</td></tr>";


                   //tbody += $"<tr><td>{item.Id}</td><td>{item.ProfCode}</td><td>{item.ProfName}</td><td>{item.Month}</td>";
                   //tbody += $"<td>{item.OnlineTimeInWeek1}</td><td>{item.OfflineTimeInWeek1}</td><td>{item.TotalTimeInWeek1}</td>";
                   //tbody += $"<td>{item.OnlineTimeInWeek2}</td><td>{item.OfflineTimeInWeek2}</td><td>{item.TotalTimeInWeek2}</td>";
                   //tbody += $"<td>{item.OnlineTimeInWeek3}</td><td>{item.OfflineTimeInWeek3}</td><td>{item.TotalTimeInWeek3}</td>";
                   //tbody += $"<td>{item.OnlineTimeInWeek4}</td><td>{item.OfflineTimeInWeek4}</td><td>{item.TotalTimeInWeek4}</td>";
                   //tbody += $"<td>{item.OnlineTimeInWeek5}</td><td>{item.OfflineTimeInWeek5}</td><td>{item.TotalTimeInWeek5}</td>";
                   //tbody += $"<td>{item.TotalTimeInMounth}</td>";
                   //tbody += "</tr>";
               }
           }
           return Content(tbody);

       }
       */

        #endregion hidden


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
