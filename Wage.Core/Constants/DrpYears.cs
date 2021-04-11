using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace Wage.Core.Constants
{
    public class DrpYears
    {
        public string DrpId { get; private set; } = "drpYears";
        public List<SelectListItem> Items { get; private set; } = new List<SelectListItem>
        {
             new SelectListItem { Value = "0", Text = "انتخاب سال" },
             new SelectListItem { Value = "1380", Text = "1380" },
             new SelectListItem { Value = "1381", Text = "1381" },
             new SelectListItem { Value = "1382", Text = "1382" },
             new SelectListItem { Value = "1383", Text = "1383" },
             new SelectListItem { Value = "1384", Text = "1384" },
             new SelectListItem { Value = "1385", Text = "1385" },
             new SelectListItem { Value = "1386", Text = "1386" },
             new SelectListItem { Value = "1387", Text = "1387" },
             new SelectListItem { Value = "1388", Text = "1388" },
             new SelectListItem { Value = "1389", Text = "1389" },
             new SelectListItem { Value = "1390", Text = "1390" },

             new SelectListItem { Value = "1391", Text = "1391" },
             new SelectListItem { Value = "1392", Text = "1392" },
             new SelectListItem { Value = "1393", Text = "1393" },
             new SelectListItem { Value = "1394", Text = "1394" },
             new SelectListItem { Value = "1395", Text = "1395" },
             new SelectListItem { Value = "1396", Text = "1396" },
             new SelectListItem { Value = "1397", Text = "1397" },
             new SelectListItem { Value = "1398", Text = "1398" },
             new SelectListItem { Value = "1399", Text = "1399" },
             new SelectListItem { Value = "1400", Text = "1400" },

             new SelectListItem { Value = "1401", Text = "1401" },
             new SelectListItem { Value = "1402", Text = "1402" },
             new SelectListItem { Value = "1403", Text = "1403" },
             new SelectListItem { Value = "1404", Text = "1404" },
             new SelectListItem { Value = "1405", Text = "1405" },
             new SelectListItem { Value = "1406", Text = "1406" },
             new SelectListItem { Value = "1407", Text = "1407" },
             new SelectListItem { Value = "1408", Text = "1408" },
             new SelectListItem { Value = "1409", Text = "1409" },
             new SelectListItem { Value = "1410", Text = "1410" },

        };
    }
}
