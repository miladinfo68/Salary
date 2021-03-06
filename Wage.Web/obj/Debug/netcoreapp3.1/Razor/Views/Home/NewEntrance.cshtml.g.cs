#pragma checksum "D:\aaa_UniversityProjects\Wage.Web\Wage.Web\Views\Home\NewEntrance.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6bdf736ee7ec2a53dd627e9db5d3326be68498a4"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_NewEntrance), @"mvc.1.0.view", @"/Views/Home/NewEntrance.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6bdf736ee7ec2a53dd627e9db5d3326be68498a4", @"/Views/Home/NewEntrance.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"44ef6ad91415ccde4286eb92868bf285fd165d6b", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_NewEntrance : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Wage.Web.DTOs.GroupManagerDto>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "0", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "1", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "D:\aaa_UniversityProjects\Wage.Web\Wage.Web\Views\Home\NewEntrance.cshtml"
  
    ViewData["Title"] = "?????? ???????? ???????? ???????? ???????? ????????";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"wrapperNewEntrance\">\r\n");
            WriteLiteral("    <div id=\"msgSuccess\"></div>\r\n    <div id=\"msgError\"></div>\r\n    <div class=\"text-center alert page-title\">\r\n        <h6>  ???????? ???????? ???????????? ?? ???????????? ????????????????</h6>\r\n    </div>\r\n    <div class=\"my-5 d-lg-flex\">\r\n        <div class=\"col-3\">\r\n            ");
#nullable restore
#line 21 "D:\aaa_UniversityProjects\Wage.Web\Wage.Web\Views\Home\NewEntrance.cshtml"
       Write(Html.DropDownList((ViewBag.Month as Wage.Core.Constants.DrpMonths).DrpId, (ViewBag.Month as Wage.Core.Constants.DrpMonths).Items, new { @class = "form-control-sm" }));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
        </div>
        <div class=""col-9 d-lg-flex"">
            <div class=""col-6"">
                <input id=""fileNewEntrance"" class=""form-control-sm"" type=""file"" accept="".csv, application/vnd.openxmlformats-officedocument.spreadsheetml.sheet, application/vnd.ms-excel"">
            </div>
            <div class=""col-6"">
                <button id=""btnBulkInsertNewEntrance"" class=""btn btn-sm btn-success col-lg-5 col-md-12 col-sm-12 offset-lg-6"">?????? ????????</button>
            </div>
        </div>
    </div>
    <table id=""tblNewEntrance"" class=""table table-bordered table-responsive table-hover tbl-date-enter text-center"">
        <thead>
            <tr>
                <th>???? ??????????</th>
                <th>?????? ??????????</th>
                <th>?????? </th>
                <th>???????? ????????</th>
                <th>???????? ????????</th>
                <th>?????? ????????</th>
                <th></th>
            </tr>
        </thead>
        <tbody>
");
#nullable restore
#line 45 "D:\aaa_UniversityProjects\Wage.Web\Wage.Web\Views\Home\NewEntrance.cshtml"
             foreach (var item in Model)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td>\r\n                    <span class=\"profCode\">");
#nullable restore
#line 49 "D:\aaa_UniversityProjects\Wage.Web\Wage.Web\Views\Home\NewEntrance.cshtml"
                                      Write(item.ProfCode);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                    <input type=\"hidden\"");
            BeginWriteAttribute("value", " value=\"", 2217, "\"", 2233, 1);
#nullable restore
#line 50 "D:\aaa_UniversityProjects\Wage.Web\Wage.Web\Views\Home\NewEntrance.cshtml"
WriteAttributeValue("", 2225, item.Id, 2225, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"hdn_grpId\" />\r\n                </td>\r\n                <td><span class=\"profName\">");
#nullable restore
#line 52 "D:\aaa_UniversityProjects\Wage.Web\Wage.Web\Views\Home\NewEntrance.cshtml"
                                      Write(item.ProfName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span></td>\r\n                <td><input class=\"entranceDate pdate\" type=\"text\"");
            BeginWriteAttribute("id", " id=\"", 2416, "\"", 2448, 2);
            WriteAttributeValue("", 2421, "entranceDate_", 2421, 13, true);
#nullable restore
#line 53 "D:\aaa_UniversityProjects\Wage.Web\Wage.Web\Views\Home\NewEntrance.cshtml"
WriteAttributeValue("", 2434, item.ProfCode, 2434, 14, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" placeholder=""1400/01/01""></td>
                <td><input class=""entranceTime"" type=""text"" placeholder=""10:10""></td>
                <td><input class=""exitTime"" type=""text"" placeholder=""12:30""></td>
                <td>
                    <select class=""drpPresenceType"">
                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6bdf736ee7ec2a53dd627e9db5d3326be68498a47468", async() => {
                WriteLiteral("????????????");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6bdf736ee7ec2a53dd627e9db5d3326be68498a48651", async() => {
                WriteLiteral("????????????");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                    </select>\r\n                </td>\r\n                <td>\r\n");
            WriteLiteral("                    <button class=\"btn btn-outline-primary btnNewEntrance\">?????? ?????????? ????????</button>\r\n                    <button class=\"btn btn-outline-info\"");
            BeginWriteAttribute("onclick", " onclick=\"", 3193, "\"", 3251, 7);
            WriteAttributeValue("", 3203, "fnEntranceDetails(\'", 3203, 19, true);
#nullable restore
#line 65 "D:\aaa_UniversityProjects\Wage.Web\Wage.Web\Views\Home\NewEntrance.cshtml"
WriteAttributeValue("", 3222, item.Id, 3222, 8, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 3230, "\'", 3230, 1, true);
            WriteAttributeValue(" ", 3231, ",", 3232, 2, true);
            WriteAttributeValue(" ", 3233, "\'", 3234, 2, true);
#nullable restore
#line 65 "D:\aaa_UniversityProjects\Wage.Web\Wage.Web\Views\Home\NewEntrance.cshtml"
WriteAttributeValue("", 3235, item.ProfName, 3235, 14, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 3249, "\')", 3249, 2, true);
            EndWriteAttribute();
            WriteLiteral(">\r\n                        ?????????? ????????????\r\n                    </button>\r\n                </td>\r\n            </tr>\r\n");
#nullable restore
#line 70 "D:\aaa_UniversityProjects\Wage.Web\Wage.Web\Views\Home\NewEntrance.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"        </tbody>
    </table>

    <!-- Modal -->
    <div class=""modal fade"" id=""EntranceDetailsModal"" tabindex=""-1"">
        <div class=""modal-dialog"" role=""document"">
            <div class=""modal-content"">
                <div class=""modal-header"">
                    <h5 class=""modal-title"" id=""EntranceDetailsModalTitle"">Modal title</h5>
                    <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                        <span aria-hidden=""true"">&times;</span>
                    </button>
                </div>
                <div class=""modal-body"">
                    <table id=""tblEntranceDetails"" class=""table table-bordered table-responsive table-hover tbl-date-enter text-center"">
                        <thead>
                            <tr>
                                <th>?????? </th>
                                <th>???????? ????????</th>
                                <th>???????? ????????</th>
                                <th>?????? ????????</th>
   ");
            WriteLiteral(@"                             <th></th>
                            </tr>
                        </thead>
                        <tbody></tbody>
                    </table>
                </div>
            </div>
        </div>
    </div>

</div>


");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"
    <script>
        $(""#drpMonthes"").on(""change"", e => {
            let month = $(""#drpMonthes"").val() || ""0"";
            var url = """";
            url += window.location.origin + window.location.pathname;
            if (month != ""0"") {
                url += ""?month="" + month;
            }
            $(""#hdn_drpMonth"").val(month);
            window.location.href = url.toLocaleLowerCase();
        });

    </script>

");
            }
            );
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
