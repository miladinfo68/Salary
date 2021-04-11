using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wage.Web.Models
{
    public class DropDownViewModel
    {
        public string DrpId { get; set; }
        public List<SelectListItem> Items { get; set; }
    }
}
