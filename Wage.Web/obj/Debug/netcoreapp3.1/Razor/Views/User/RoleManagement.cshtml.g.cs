#pragma checksum "D:\aaa_UniversityProjects\Wage.Web\Wage.Web\Views\User\RoleManagement.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ad432fe34f0815bb13bacbca5d605b16726506c0"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_User_RoleManagement), @"mvc.1.0.view", @"/Views/User/RoleManagement.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ad432fe34f0815bb13bacbca5d605b16726506c0", @"/Views/User/RoleManagement.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"44ef6ad91415ccde4286eb92868bf285fd165d6b", @"/Views/_ViewImports.cshtml")]
    public class Views_User_RoleManagement : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Wage.Core.Entities.Role>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "D:\aaa_UniversityProjects\Wage.Web\Wage.Web\Views\User\RoleManagement.cshtml"
  
    ViewData["Title"] = "RoleManagement";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            DefineSection("Styles", async() => {
                WriteLiteral("\r\n    <style>\r\n          #modalRole .form-label {\r\n            display: block;\r\n            margin-top: 10px;\r\n            margin-bottom: 10px;\r\n            font-size: 16px;\r\n            font-weight: bold;\r\n        }\r\n    </style>\r\n");
            }
            );
            WriteLiteral(@"
<div class=""wrapperRole"">
    
    <table id=""tblRoles"" class=""table table-bordered table-responsive table-hover tbl-date-enter text-center"">
        <thead>
            <tr>
                <th>شناسه</th>
                <th>نام نقش</th>
                <th>نام  نمایشی</th>
                <th>
                    <a class=""btn btn-info r1"" href=""#"">افزودن نقش جدید</a>
                </th>
            </tr>
        </thead>
        <tbody>
");
#nullable restore
#line 33 "D:\aaa_UniversityProjects\Wage.Web\Wage.Web\Views\User\RoleManagement.cshtml"
             foreach (var role in Model)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <td>");
#nullable restore
#line 36 "D:\aaa_UniversityProjects\Wage.Web\Wage.Web\Views\User\RoleManagement.cshtml"
                   Write(role.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 37 "D:\aaa_UniversityProjects\Wage.Web\Wage.Web\Views\User\RoleManagement.cshtml"
                   Write(role.RoleName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 38 "D:\aaa_UniversityProjects\Wage.Web\Wage.Web\Views\User\RoleManagement.cshtml"
                   Write(role.DisplayName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>\r\n                        <a class=\"btn btn-primary r2\" href=\"#\" data-roleId=\"");
#nullable restore
#line 40 "D:\aaa_UniversityProjects\Wage.Web\Wage.Web\Views\User\RoleManagement.cshtml"
                                                                       Write(role.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("\" data-roleName=\"");
#nullable restore
#line 40 "D:\aaa_UniversityProjects\Wage.Web\Wage.Web\Views\User\RoleManagement.cshtml"
                                                                                                Write(role.RoleName);

#line default
#line hidden
#nullable disable
            WriteLiteral("\" data-displayName=\"");
#nullable restore
#line 40 "D:\aaa_UniversityProjects\Wage.Web\Wage.Web\Views\User\RoleManagement.cshtml"
                                                                                                                                  Write(role.DisplayName);

#line default
#line hidden
#nullable disable
            WriteLiteral("\">ویرایش</a> |\r\n                        <a class=\"btn btn-danger r3\" href=\"#\" data-roleId=\"");
#nullable restore
#line 41 "D:\aaa_UniversityProjects\Wage.Web\Wage.Web\Views\User\RoleManagement.cshtml"
                                                                      Write(role.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("\" data-roleName=\"");
#nullable restore
#line 41 "D:\aaa_UniversityProjects\Wage.Web\Wage.Web\Views\User\RoleManagement.cshtml"
                                                                                               Write(role.RoleName);

#line default
#line hidden
#nullable disable
            WriteLiteral("\" data-displayName=\"");
#nullable restore
#line 41 "D:\aaa_UniversityProjects\Wage.Web\Wage.Web\Views\User\RoleManagement.cshtml"
                                                                                                                                 Write(role.DisplayName);

#line default
#line hidden
#nullable disable
            WriteLiteral("\">حذف</a>\r\n                    </td>\r\n                </tr>\r\n");
#nullable restore
#line 44 "D:\aaa_UniversityProjects\Wage.Web\Wage.Web\Views\User\RoleManagement.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"        </tbody>
    </table>

    <!-- Modal -->
    <div class=""modal fade"" id=""modalRole"" tabindex=""-1"">
        <div class=""modal-dialog"" role=""document"">
            <div class=""modal-content"">
                <div class=""modal-header"">
                    <h3 class=""modal-title"" id=""modalRoleTitle""></h3>
                    <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                        <span aria-hidden=""true"">&times;</span>
                    </button>
                </div>

                <div class=""col-12 "">
                    <input type=""hidden"" id=""hdnRoleId"" />
                    <div class=""row"">
                        <div class=""col-12"">
                            <lable class=""form-label"">نام کاربری</lable>
                            <input class=""form-control"" type=""text"" name=""RoleName"" id=""RoleName"">
                        </div>
                    </div>

                    <div class=""row"">
                        ");
            WriteLiteral(@"<div class=""col-12"">
                            <lable class=""form-label"">نام </lable>
                            <input class=""form-control"" type=""text"" name=""DisplayName"" id=""DisplayName"">
                        </div>
                    </div>

                    <div class=""row mt-2 mb-2"">
                        <div class=""col-12"">
                            <button class=""btn btn-success"">ثبت</button>
                            <button class=""btn btn-danger"">حـــذف</button>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

</div>

");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"
    <script>
        //add role modal
        $(""#tblRoles a.r1"").on(""click"", function (e) {
            debugger;
           e.preventDefault();
            clearData();
            $(""#modalRoleTitle"").text(""درج نقش جدید"").css({ ""color"": ""#a9013f"" });

            $(""#modalRole.btn-success"").show();
            $(""#modalRole .btn-danger"").hide();

            $(""#modalRole"").modal('show');
        });

        //edit role modal
        $(""#tblRoles a.r2"").on(""click"", function (e) {
            //debugger;
            e.preventDefault();
            clearData();
            $(""#hdnRoleId"").val($(this).attr(""data-roleId""));
            $('#RoleName').val($(this).attr(""data-roleName""));
            $('#DisplayName').val($(this).attr(""data-displayName""));

            $(""#modalRoleTitle"").text(""ویرایش مشخصه "" + $(this).attr(""data-roleId"")).css({ ""color"": ""#a9013f"" });

            $(""#modalRole .btn-success"").show();
            $(""#modalRole .btn-danger"").hide();

            $(""#");
                WriteLiteral(@"modalRole"").modal('show');
        });

        //show modal to delete user
        $(""#tblRoles a.r3"").on(""click"", function (e) {
            //debugger;
            e.preventDefault();
            clearData();
            $(""#hdnRoleId"").val($(this).attr(""data-roleId"")).prop('disabled', true);
            $('#RoleName').val($(this).attr(""data-roleName"")).prop('disabled', true);            
            $('#DisplayName').val($(this).attr(""data-displayName"")).prop('disabled', true);

            $(""#modalRoleTitle"").text(""حذف مشخصه "" + $(this).attr(""data-roleId"")).css({ ""color"": ""#a9013f"" });
            ////$(""#modalUser .btnswitch"").removeClass(""btn-success"").addClass(""btn-danger"").text('').text(""حـــذف"");
            $(""#modalRole .btn-success"").hide();
            $(""#modalRole .btn-danger"").show();

            $(""#modalRole"").modal('show');
        });


        //add or update user
        $(""#modalRole .btn-success"").on(""click"", function (e) {
            debugger
            le");
                WriteLiteral(@"t roleId = $(""#hdnRoleId"").val()
                , roleName = $('#RoleName').val()
                , displayName = $('#DisplayName').val();
            let data = {
                ""Id"": roleId,
                ""RoleName"": roleName,              
                ""DisplayName"": displayName
            }
            if (vilidate()) {
                $.ajax({
                    url: '/User/AddOrUpdateRole',
                    type: 'POST',
                    data: data,
                    success: function (res) {
                        debugger;
                        $(""#modalRole"").modal('hide');
                        //window.Location = window.location;
                        // the value true ensures that the current page is fully loaded ignoring the cache.
                        location.reload(true);
                    },
                    error: function (jqXHR, exception) {
                        alert(""WOW Error Occured !!!!"", ""Error Message"")
                    }
");
                WriteLiteral(@"                });
            }
        });

         //delete user
        $(""#modalRole .btn-danger"").on(""click"", function (e) {
            let roleId = $(""#hdnRoleId"").val();
            if (roleId > 0) {
                $.ajax({
                    url: '/User/DeleteRole',
                    type: 'POST',
                    data: { ""id"": roleId },
                    success: function (res) {
                        debugger;
                        $(""#modalRole"").modal('hide');
                        //window.Location = window.location;
                        // the value true ensures that the current page is fully loaded ignoring the cache.
                        location.reload(true);
                    },
                    error: function (jqXHR, exception) {
                        alert(""WOW Error Occured !!!!"", ""Error Message"")
                    }
                });
            }
        });




        function vilidate() {
            debugger;
      ");
                WriteLiteral(@"      var isValaid = true;

            let $roleName = $('#RoleName')
                , $displayName = $('#DisplayName');

            if ($roleName.val() == '') {
                $roleName.css({ 'border': '2px solid red' });
                isValaid = false;
            }
            if ($displayName.val() == '') {
                $displayName.css({ 'border': '2px solid red' });
                isValaid = false;
            }
            return isValaid;
        };

        function clearData() {
            $(""#modalRole input"").each(function (e) {
                $(this).val('').removeAttr('style').prop(""disabled"", false);
            });
            $(""#modalRoleTitle"").text('').removeAttr('style');
            $(""#hdnRoleId"").val('');
        }

          //remove added style to inputs when modal submit and some fields are invalid
        $(""#modalRole input"").on('change', function (e) {
            if ($(this).val() != '') $(this).removeAttr(""style"");
        });
    </scrip");
                WriteLiteral("t>\r\n\r\n");
            }
            );
            WriteLiteral("\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Wage.Core.Entities.Role>> Html { get; private set; }
    }
}
#pragma warning restore 1591
