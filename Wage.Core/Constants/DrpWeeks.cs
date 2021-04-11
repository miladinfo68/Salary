using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace Wage.Core.Constants
{
    public  class DrpWeeks
    {
        public  string DrpId { get; private set; } = "drpWeeks";
        public  List<SelectListItem> Items { get; private set; } = new List<SelectListItem>
        {
            new SelectListItem { Value="0" , Text ="انتخاب هفته"},
            new SelectListItem { Value="1" , Text="هفته 1"},
            new SelectListItem { Value = "2", Text = "هفته 2" },
            new SelectListItem { Value = "3", Text = "هفته 3" },
            new SelectListItem { Value = "4", Text = "هفته 4" },
            new SelectListItem { Value = "5", Text = "هفته 5" },
        };
    }
}
