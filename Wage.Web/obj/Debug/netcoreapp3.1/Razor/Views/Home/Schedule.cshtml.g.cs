#pragma checksum "D:\aaa_UniversityProjects\Wage.Web\Wage.Web\Views\Home\Schedule.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c3a28a77b07711ce1168cfe6bc628467e13c5387"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Schedule), @"mvc.1.0.view", @"/Views/Home/Schedule.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c3a28a77b07711ce1168cfe6bc628467e13c5387", @"/Views/Home/Schedule.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"44ef6ad91415ccde4286eb92868bf285fd165d6b", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Schedule : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Wage.Web.DTOs.GroupManagerDto>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "D:\aaa_UniversityProjects\Wage.Web\Wage.Web\Views\Home\Schedule.cshtml"
  
    ViewData["Title"] = "زمانبدی ابتدای ترم مدیر گروه";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            WriteLiteral("\r\n\r\n<div class=\"wrapperSchedule\">\r\n");
            WriteLiteral("    <div id=\"msgSuccess\"></div>\r\n    <div id=\"msgError\"></div>\r\n    <div class=\"text-center alert page-title\">\r\n        <h6> زمان بندی مدیرگروه ها</h6>\r\n    </div>\r\n    <div class=\"my-3\">\r\n        ");
#nullable restore
#line 23 "D:\aaa_UniversityProjects\Wage.Web\Wage.Web\Views\Home\Schedule.cshtml"
   Write(Html.DropDownList((ViewBag.Month as Wage.Core.Constants.DrpMonths).DrpId, (ViewBag.Month as Wage.Core.Constants.DrpMonths).Items, new { @class = "form-control-sm" }));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
    </div>
    <table id=""tblSchedule"" class=""table table-bordered table-responsive table-hover tbl-date-enter text-center  dt-responsive"">
        <thead>
            <tr>
                <th>کد استاد</th>
                <th>نام استاد</th>
                <th>روز </th>
                <th>ساعت ورود</th>
                <th>ساعت خروج</th>
                <th>حداقل زمان حضور</th>
                <th></th>
            </tr>
        </thead>
        <tbody>
");
#nullable restore
#line 38 "D:\aaa_UniversityProjects\Wage.Web\Wage.Web\Views\Home\Schedule.cshtml"
             foreach (var item in Model)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <td>\r\n                        <span class=\"profCode\">");
#nullable restore
#line 42 "D:\aaa_UniversityProjects\Wage.Web\Wage.Web\Views\Home\Schedule.cshtml"
                                          Write(item.ProfCode);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                        <input type=\"hidden\"");
            BeginWriteAttribute("value", " value=\"", 1755, "\"", 1771, 1);
#nullable restore
#line 43 "D:\aaa_UniversityProjects\Wage.Web\Wage.Web\Views\Home\Schedule.cshtml"
WriteAttributeValue("", 1763, item.Id, 1763, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"hdn_grpId\" />\r\n                    </td>\r\n                    <td><span class=\"profName\">");
#nullable restore
#line 45 "D:\aaa_UniversityProjects\Wage.Web\Wage.Web\Views\Home\Schedule.cshtml"
                                          Write(item.ProfName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span></td>\r\n                    <td><input class=\"entranceDate pdate\" type=\"text\"");
            BeginWriteAttribute("id", " id=\"", 1966, "\"", 1998, 2);
            WriteAttributeValue("", 1971, "entranceDate_", 1971, 13, true);
#nullable restore
#line 46 "D:\aaa_UniversityProjects\Wage.Web\Wage.Web\Views\Home\Schedule.cshtml"
WriteAttributeValue("", 1984, item.ProfCode, 1984, 14, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" maxlength=""10"" placeholder=""1400/01/01""></td>
                    <td><input class=""entranceTime"" type=""text"" maxlength=""5"" placeholder=""10:10""></td>
                    <td><input class=""exitTime"" type=""text"" maxlength=""5"" placeholder=""12:30""></td>
                    <td><input class=""minTime"" type=""text"" maxlength=""5"" placeholder=""12:30""></td>
                    <td>
");
            WriteLiteral("                        <button class=\"btn btn-outline-primary btnNewSchedule\">درج تاریخ جدید</button>\r\n                        <button class=\"btn btn-outline-info\"");
            BeginWriteAttribute("onclick", " onclick=\"", 2677, "\"", 2735, 7);
            WriteAttributeValue("", 2687, "fnScheduleDetails(\'", 2687, 19, true);
#nullable restore
#line 53 "D:\aaa_UniversityProjects\Wage.Web\Wage.Web\Views\Home\Schedule.cshtml"
WriteAttributeValue("", 2706, item.Id, 2706, 8, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2714, "\'", 2714, 1, true);
            WriteAttributeValue(" ", 2715, ",", 2716, 2, true);
            WriteAttributeValue(" ", 2717, "\'", 2718, 2, true);
#nullable restore
#line 53 "D:\aaa_UniversityProjects\Wage.Web\Wage.Web\Views\Home\Schedule.cshtml"
WriteAttributeValue("", 2719, item.ProfName, 2719, 14, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2733, "\')", 2733, 2, true);
            EndWriteAttribute();
            WriteLiteral(">\r\n                            نمایش جزییات\r\n                        </button>\r\n                    </td>\r\n                </tr>\r\n");
#nullable restore
#line 58 "D:\aaa_UniversityProjects\Wage.Web\Wage.Web\Views\Home\Schedule.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"        </tbody>
    </table>

    <!-- Modal -->
    <div class=""modal fade"" id=""SchedulModal"" tabindex=""-1"">
        <div class=""modal-dialog"" role=""document"">
            <div class=""modal-content"">
                <div class=""modal-header"">
                    <h5 class=""modal-title"" id=""SchedulModalTitle"">Modal title</h5>
                    <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                        <span aria-hidden=""true"">&times;</span>
                    </button>
                </div>
                <div class=""modal-body"">
                    <table id=""tblScheduleDetails"" class=""table table-bordered table-responsive table-hover tbl-date-enter text-center"">
                        <thead>
                            <tr>
                                <th>روز </th>
                                <th>ساعت ورود</th>
                                <th>ساعت خروج</th>
                                <th>حداقل زمان حضور</th>
            ");
            WriteLiteral("                    <th></th>\r\n                            </tr>\r\n                        </thead>\r\n                        <tbody></tbody>\r\n                    </table>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"
    <script>
        /*
        $(document).ready(function () {  
            alert(""hi 1"");
        });

        $(window).on(""load"",function () {
            alert(""hi 2"");
        });
        */

    
        $(""#tblSchedule_wrapper:input[type=search]"")//.attr(""placeholder"", ""جستجو...."")
            .closest('.col-sm-12')
            .closest('.row')
            .children()
            .removeClass(""col-md-6"")
            .addClass(""col-md-4"")
            .end()
            .append(""<div class=\""col-sm-12 col-md-4\""><button class=\""btn btn-success btnBulkInsertSchedule\"">درج فایل اکسل</button></div>"")
            .css({ ""display"": ""flex"", ""align-self"": ""center"" });


        $(""#drpMonthes"").on(""change"", e => {
            let month = $(""#drpMonthes"").val() || ""0"";
            var url = """";
            url += window.location.origin + window.location.pathname;
            if (month != ""0"") {
                url += ""?month="" + month;
            }
            $(""#hdn_drpMonth""");
                WriteLiteral(").val(month);\r\n            window.location.href = url.toLocaleLowerCase();\r\n        });\r\n\r\n    </script>\r\n\r\n");
            }
            );
            WriteLiteral("\r\n\r\n\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Wage.Web.DTOs.GroupManagerDto>> Html { get; private set; }
    }
}
#pragma warning restore 1591
