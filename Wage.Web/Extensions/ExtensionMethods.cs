using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using Wage.Web.DTOs;

namespace Wage.Web.Extensions
{
    public static class ExtensionMethods
    {
        public static string ToJalali(this string grdate)
        {
            PersianCalendar pc = new PersianCalendar();
            DateTime gd = DateTime.Parse(grdate);
            var jy = pc.GetYear(gd);
            var jm = int.Parse(pc.GetMonth(gd).ToString()) > 9 ? pc.GetMonth(gd).ToString() : "0" + pc.GetMonth(gd).ToString();
            var jd = int.Parse(pc.GetDayOfMonth(gd).ToString()) > 9 ? pc.GetDayOfMonth(gd).ToString() : "0" + pc.GetDayOfMonth(gd).ToString();
            var jalali = string.Format("{0}/{1}/{2}", jy, jm, jd);
            return jalali;
        }
        public static DateTime ToGregorian(this string input)
        {
            DateTime dt_utc=new DateTime();
            if (!string.IsNullOrEmpty(input) && input.Split('/').Length == 3)
            {
                var persianStr = input.Split('/');
                var y = int.Parse(persianStr[0]);
                var m = int.Parse(persianStr[1]);
                var d = int.Parse(persianStr[2]);
                PersianCalendar pc = new PersianCalendar();
                try
                {
                    dt_utc = new DateTime(y, m, d, pc);
                }
                catch (Exception ex1)
                {
                    try
                    {
                        //error in d=31 ===>day=30
                        d -= 1;
                        dt_utc = new DateTime(y, m, d, pc);
                    }
                    catch (Exception ex2)
                    {

                        try
                        {
                            //error in d=30 ===>day=29
                            d -= 1;
                            dt_utc = new DateTime(y, m, d, pc);
                        }
                        catch (Exception ex3)
                        {
                            return dt_utc;
                        }
                    }
                }
            }            
            return dt_utc;

        }
        public static bool IsNumeric(this string input)
        {
            decimal value;
            if (decimal.TryParse(input, out value) && value > 0)
                return true;
            return false;
        }
        public static RangeDateDto GetRangeDate(this WeekDto model)
        {
            var rangeDate = new RangeDateDto();
            if (model != null)
            {
                switch (int.Parse(model.WeekNo))
                {
                    case 1:
                        rangeDate.StratWeek = $"{model.YearNo}/{model.MonthNo}/01";
                        rangeDate.EndWeek = $"{model.YearNo}/{model.MonthNo}/07";
                        break;

                    case 2:
                        rangeDate.StratWeek = $"{model.YearNo}/{model.MonthNo}/08";
                        rangeDate.EndWeek = $"{model.YearNo}/{model.MonthNo}/14";
                        break;

                    case 3:
                        rangeDate.StratWeek = $"{model.YearNo}/{model.MonthNo}/15";
                        rangeDate.EndWeek = $"{model.YearNo}/{model.MonthNo}/21";
                        break;

                    case 4:
                        rangeDate.StratWeek = $"{model.YearNo}/{model.MonthNo}/22";
                        rangeDate.EndWeek = $"{model.YearNo}/{model.MonthNo}/27";
                        break;

                    case 5:
                        rangeDate.StratWeek = $"{model.YearNo}/{model.MonthNo}/28";
                        rangeDate.EndWeek = $"{model.YearNo}/{model.MonthNo}/31";
                        break;

                    default:
                        rangeDate.StratWeek = $"{model.YearNo}/{model.MonthNo}/01";
                        rangeDate.EndWeek = $"{model.YearNo}/{model.MonthNo}/07";
                        break;
                }
            }
            return rangeDate;
        }
        public static string ToStandardPersianDate(this string input)
        {
            //str="1399/10/10"
            string farmatedDate = "";
            if (!string.IsNullOrEmpty(input) && input.Split("/").Length == 3)
            {
                var stplitted = input.Split("/");
                stplitted[1] = int.Parse(stplitted[1]) < 10 ? stplitted[1].PadLeft(2, '0') : stplitted[1];
                stplitted[2] = int.Parse(stplitted[2]) < 10 ? stplitted[2].PadLeft(2, '0') : stplitted[2];

                farmatedDate = $"{stplitted[0]}/{stplitted[1]}/{stplitted[2]}";
            }
            return farmatedDate;
        }
        public static string ToStandardPersianTime(this string input)
        {
            //str="10:03"
            string farmatedDate = "";
            if (!string.IsNullOrEmpty(input) && input.Trim().Length >= 1 && input.Trim().Length <= 5)
            {
                if (input.Contains(':'))
                {
                    if (input.Length == 1) farmatedDate = $"00:00";
                    if (input.Length == 2) farmatedDate = $"0{input}00";
                    if (input.Length == 3)
                    {
                        var x = input.Split(':');
                        if (x[0].Length == 0)
                        {
                            farmatedDate = $"00:{x[1]}";
                        }
                        if (x[1].Length == 0)
                        {
                            farmatedDate = $"{x[0]}:00";
                        }
                        if (x[0].Length == 1 && x[1].Length == 1)
                        {
                            farmatedDate = $"0{x[0]}:0{x[1]}";
                        }
                    }
                    if (input.Length == 4)
                    {
                        var x = input.Split(':');
                        //if (x[0].Length == 0 || x[1].Length == 0) farmatedDate = null;
                        if (x[0].Length == 1) farmatedDate = $"0{x[0]}:{x[1]}";
                        if (x[1].Length == 1) farmatedDate = $"{x[0]}:0{x[1]}";
                        //if (x[0].Length == 3 || x[1].Length == 3) farmatedDate = null;
                    }

                    if (input.Length == 5)
                    {
                        var x = input.Split(':');
                        if (x[0].Length == 2) farmatedDate = input;
                    }
                }
                else
                {
                    if (input.Length == 1)
                    {
                        farmatedDate = $"0{input}:00";
                    }
                    if (input.Length == 2)
                    {
                        farmatedDate = $"{input}:00";
                    }
                    //if (input.Length > 2) farmatedDate= null;
                }
            }
            return farmatedDate;
        }
        public static int ToMinute(this string hhmm)
        {
            int result = 0;
            if (!string.IsNullOrEmpty(hhmm) && hhmm !="00:00" && hhmm.Contains(':') && hhmm.Split(':').Length >= 2 && hhmm.Trim().Length <= 5)
            {
                result = int.Parse(hhmm.Substring(0, 2)) * 60 + int.Parse(hhmm.Substring(3, 2));
            }
            return result;
        }
        public static string ToHHmm(this int input)
        {
            string result = "00:00";
            if (input > 0)
            {
                result = $"{input / 60}:{input % 60}";
                var hh = result.Split(':')[0].Length == 1 ? "0" + result.Split(':')[0] : result.Split(':')[0];
                var mm = result.Split(':')[1].Length == 1 ? "0" + result.Split(':')[1] : result.Split(':')[1];
                result = "";
                result = $"{hh}:{mm}";
            }
            return result;
        }

        public static T GetComplexData<T>(this ISession session, string key)
        {
            var data = session.GetString(key);
            if (data == null)
            {
                return default(T);
            }
            return JsonConvert.DeserializeObject<T>(data);
        }

        public static void SetComplexData(this ISession session, string key, object value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }

        //=============
        public static DataTable ConvertListToDataTable<T>(this IList<T> data)
        {
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            foreach (PropertyDescriptor prop in properties)
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            foreach (T item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                table.Rows.Add(row);
            }
            return table;
        }

        public static List<T> ConvertDataTableToList<T>(this DataTable dt)
        {
            List<T> data = new List<T>();
            foreach (DataRow row in dt.Rows)
            {
                T item = GetItem<T>(row);
                data.Add(item);
            }
            return data;
        }

        public static T GetItem<T>(DataRow dr)
        {
            Type temp = typeof(T);
            T obj = Activator.CreateInstance<T>();

            foreach (DataColumn column in dr.Table.Columns)
            {
                foreach (PropertyInfo pro in temp.GetProperties())
                {
                    if (pro.Name == column.ColumnName && dr[column.ColumnName] != DBNull.Value && dr[column.ColumnName] != null)
                        pro.SetValue(obj, dr[column.ColumnName], null);
                    else
                        continue;
                }
            }
            return obj;
        }
        //=============
        public static DataTable ToDataTableFromExcel(this Stream stream)
        {
            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
            using (var pck = new ExcelPackage())
            {
                //using (stream = File.OpenRead(path))
                //{
                //    pck.Load(stream);
                //}
                pck.Load(stream);

                var ws = pck.Workbook.Worksheets.First();
                DataTable tbl = new DataTable();
                bool hasHeader = true; // adjust it accordingly( i've mentioned that this is a simple approach)
                foreach (var firstRowCell in ws.Cells[1, 1, 1, ws.Dimension.End.Column])
                {
                    tbl.Columns.Add(hasHeader ? firstRowCell.Text : string.Format("Column {0}", firstRowCell.Start.Column));
                }
                var startRow = hasHeader ? 2 : 1;
                for (var rowNum = startRow; rowNum <= ws.Dimension.End.Row; rowNum++)
                {
                    var wsRow = ws.Cells[rowNum, 1, rowNum, ws.Dimension.End.Column];
                    var row = tbl.NewRow();
                    foreach (var cell in wsRow)
                    {
                        row[cell.Start.Column - 1] = cell.Text;
                    }
                    tbl.Rows.Add(row);
                }
                return tbl;
            }
        }


        /// <summary>
        /// check if the incoming request is an AJAX call
        /// </summary>
        /// <param name="request">IsAjaxRequest</param>
        /// <returns></returns>
        public static bool IsAjaxRequest(this HttpRequest request)
        {
            if (request == null)
                throw new ArgumentNullException("request");

            if (request.Headers != null)
                return request.Headers["X-Requested-With"] == "XMLHttpRequest";
            return false;
        }

        /// <summary>
        /// using inside action for eg this.HavePermission(Role.SUPERVISOR)
        /// </summary>
        /// <param name="c">Controlller name</param>
        /// <param name="claimValue">role claim</param>
        /// <returns></returns>
        public static bool HavePermission(this Controller c, string claimValue)
        {
            var user = c.HttpContext.User as ClaimsPrincipal;
            bool havePer = user.HasClaim(claimValue, claimValue);
            return havePer;
        }


        /// <summary>
        /// using inside view for em ==> if(User.Identity.HavePermission("WRITE_ACCESS") == true)
        /// </summary>
        /// <param name="c">Controlller name</param>
        /// <param name="claimValue">role claim</param>
        /// <returns></returns>
        public static bool HavePermission(this IIdentity claims, string claimValue)
        {
            var userClaims = claims as ClaimsIdentity;
            bool havePer = userClaims.HasClaim(claimValue, claimValue);
            return havePer;
        }

        //public static string Encrypt(this string plainText)
        //{
        //    return Convert.ToBase64String(SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(plainText)));
        //}

        //public static string Decrypt(this string hassedPass)
        //{
        //    return "";
        //}





    }
}
