using Microsoft.AspNetCore.Mvc;
using Wage.Core.Interfaces.IServices;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Http;
using Wage.Web.Functionality;
using Wage.Core.Entities;
using System.Threading.Tasks;
using Wage.Web.DTOs;
using AutoMapper;
using System.Linq;
using System.Collections.Generic;
using Wage.Core.Enums;

namespace Wage.Web.Controllers
{
    [CustomAuthorize]
    public class UserController : Controller
    {
        private readonly IUserService _userSVC;
        private readonly IRoleService _roleSVC;
        private readonly IUserRoleService _userRolesSVC;
        //private readonly IRoleAccessService _roleAccessSVC;
        //private readonly IAccessLinkService _accessLinkSVC;


        //private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public UserController(IUserService userSVC
            , IRoleService roleSVC
            , IUserRoleService userRolesSVC
            , IRoleAccessService roleAccessSVC
            , IAccessLinkService accessLinkSVC
            , IHttpContextAccessor httpContextAccessor
            , IConfiguration configuration
            , IMapper mapper
            )
        {
            _userSVC = userSVC;
            _roleSVC = roleSVC;
            _userRolesSVC = userRolesSVC;  
            //_roleAccessSVC = roleAccessSVC;
            //_accessLinkSVC = accessLinkSVC;
            //_httpContextAccessor = httpContextAccessor;
            _configuration = configuration;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {    
            var users = await _userSVC.GetAllUsersAsync();
            var mappedList = _mapper.Map<IEnumerable<User>, IEnumerable<UserDto>>(users);
            return View(mappedList);
        }

        [HttpPost]
        public async Task<ActionResult> AddOrUpdateUser(SaveUserDto data)
        {
            var res = new User();
            if (data != null)
            {
                var mappedItem = _mapper.Map<SaveUserDto, User>(data);
                if (mappedItem.Id > 0)
                {
                    res = await _userSVC.EditUserAsync(mappedItem);
                }
                else
                {
                    res = await _userSVC.AddUserAsync(mappedItem);
                }
            }
            return new JsonResult(new { Response = res.Id });
        }

        [HttpPost]
        public async Task<ActionResult> DeleteUser(decimal id)
        {
            var res = false;
            if (id > 0)
            {
                res = await _userSVC.RemoveUserAsync(id);
                var userRoles = await _userRolesSVC.GetManyUserRolesAsync(x => x.UserId == id);
                if (userRoles.ToList().Count() > 0)
                {
                    await _userRolesSVC.RemoveRangeUserRoleAsync(userRoles);
                }
            }
            return new JsonResult(new { Response = res });
        }

        [HttpPost]
        public async Task<ActionResult> UserRoles(string userId)
        {
            return await GetAllUserRolesByUserId(userId);
        }

        [HttpPost]
        public async Task<JsonResult> UpdateUserRoles(UserRoleDto data)
        {
            var userRoleToSave = new List<UserRole>();
            if (!string.IsNullOrEmpty(data.UserId.ToString()))//&& !string.IsNullOrEmpty(data.RoleIDs)
            {
                var rangeUserRoles = await _userRolesSVC.GetManyUserRolesAsync(ur => ur.UserId == data.UserId);
                if (rangeUserRoles.Count() > 0)
                {
                    await _userRolesSVC.RemoveRangeUserRoleAsync(rangeUserRoles);
                }
                var RoleIDs = data.RoleIDs?.Split(',');
                if (RoleIDs != null && RoleIDs.Length > 0)
                {
                    var adminRole = RoleIDs?.FirstOrDefault(r => r.ToString().Equals(EnumRole.ADMIN));
                    if (!string.IsNullOrEmpty(adminRole))
                    {
                        var urole = new UserRole()
                        {
                            UserId = data.UserId,
                            RoleId = decimal.Parse(EnumRole.ADMIN)
                        };
                        var x = await _userRolesSVC.AddUserRoleAsync(urole);
                    }
                    else
                    {
                        RoleIDs.ToList().ForEach(r =>
                         {
                             userRoleToSave.Add(new UserRole()
                             {
                                 UserId = data.UserId,
                                 RoleId = decimal.Parse(r)
                             });
                         });
                        await _userRolesSVC.AddRangeUserRoleAsync(userRoleToSave);
                    }
                    return await GetAllUserRolesByUserId(data.UserId.ToString());
                }
            }
            return Json(null);
        }

        private async Task<JsonResult> GetAllUserRolesByUserId(string userId)
        {
            List<RoleDto> listUserRoles = null;

            var allRoles = await _roleSVC.GetAllRolesAsync();
            var qAllRoles = (from r in allRoles
                             select new RoleDto
                             {
                                 Id = r.Id,
                                 RoleName = r.RoleName,
                                 DisplayName = r.DisplayName,
                                 Checked = false
                             }).ToList();

            if (!string.IsNullOrEmpty(userId))
            {
                decimal uId = decimal.Parse(userId);
                var userRoles = await _userRolesSVC.GetManyUserRolesAsync(x => x.UserId == uId);
                listUserRoles = (from r in qAllRoles
                                 join ur in userRoles on r.Id equals ur.RoleId into leftJUserRoles
                                 from lur in leftJUserRoles.DefaultIfEmpty()
                                 select new RoleDto
                                 {
                                     Id = r.Id,
                                     RoleName = r.RoleName,
                                     DisplayName = r.DisplayName,
                                     Checked = lur != null ? true : false
                                 }).ToList();

                //var adminRole = listUserRoles.FirstOrDefault(ur => ur.RoleId.ToString().Equals(EnumRole.ADMIN));
                //if (adminRole != null)
                //{
                //    listUserRoles.Where(w => !w.RoleId.ToString().Equals(EnumRole.ADMIN)).ToList()
                //        .ForEach(ur =>
                //        {
                //            ur.Checked = false;
                //        });
                //}

            }
            return Json(listUserRoles);

        }

        [HttpGet]
        public async Task<ActionResult> RoleManagement()
        {
            var model = await _roleSVC.GetAllRolesAsync();
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> AddOrUpdateRole(RoleDto data)
        {
            var res = new Role();
            if (data != null)
            {
                var mappedItem = _mapper.Map<RoleDto, Role>(data);
                if (mappedItem.Id > 0)
                {
                    res = await _roleSVC.EditRoleAsync(mappedItem);
                }
                else
                {
                    var roles = await _roleSVC.GetManyRolesAsync(r => r.RoleName.ToLower().Equals(data.RoleName.ToLower()));
                    if (roles.ToList().Count() == 0)
                    {
                        res = await _roleSVC.AddRoleAsync(mappedItem);
                    }
                }
            }
            return new JsonResult(new { Response = res.Id });
        }

        [HttpPost]
        public async Task<ActionResult> DeleteRole(decimal id)
        {
            var res = false;
            if (id > 0)
            {
                res = await _roleSVC.RemoveRoleAsync(id);
                var roles = await _userRolesSVC.GetManyUserRolesAsync(x => x.RoleId == id);
                if (roles.ToList().Count() > 0)
                {
                    await _userRolesSVC.RemoveRangeUserRoleAsync(roles);
                }
            }
            return new JsonResult(new { Response = res });
        }



    }
}