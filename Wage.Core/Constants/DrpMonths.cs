using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace Wage.Core.Constants
{
    public  class DrpMonths
    {
        public  string DrpId { get; private set; } = "drpMonthes";
        public  List<SelectListItem> Items { get; private set; } = new List<SelectListItem>
        {
            new SelectListItem { Value="0"  , Text ="انتخاب ماه" },
            new SelectListItem { Value="1"  , Text ="فروردین" },
            new SelectListItem { Value = "2", Text = "اردیبهشت" },
            new SelectListItem { Value = "3", Text = "خرداد" },
            new SelectListItem { Value = "4", Text = "تیر" },
            new SelectListItem { Value = "5", Text = "مرداد" },
            new SelectListItem { Value = "6", Text = "شهریور" },
            new SelectListItem { Value = "7", Text = "مهر" },
            new SelectListItem { Value = "8", Text = "آبان" },
            new SelectListItem { Value = "9", Text = "آذر" },
            new SelectListItem { Value = "10", Text = "دی" },
            new SelectListItem { Value = "11", Text = "بهمن" },
            new SelectListItem { Value = "12", Text = "اسفند" },
        };
    }
}
