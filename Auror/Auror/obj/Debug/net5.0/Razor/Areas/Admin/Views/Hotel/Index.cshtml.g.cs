#pragma checksum "C:\Users\afsana.mammadova\Downloads\AurorManagementStudio\Auror\Auror\Areas\Admin\Views\Hotel\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "64f195226725b01e8ec0f37dc94975fd3e1e178e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Hotel_Index), @"mvc.1.0.view", @"/Areas/Admin/Views/Hotel/Index.cshtml")]
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
#nullable restore
#line 2 "C:\Users\afsana.mammadova\Downloads\AurorManagementStudio\Auror\Auror\Areas\Admin\Views\_ViewImports.cshtml"
using Auror.Models.Entity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\afsana.mammadova\Downloads\AurorManagementStudio\Auror\Auror\Areas\Admin\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"64f195226725b01e8ec0f37dc94975fd3e1e178e", @"/Areas/Admin/Views/Hotel/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ca37df4d81133738038106ea511843274a424119", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_Hotel_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Hotel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\afsana.mammadova\Downloads\AurorManagementStudio\Auror\Auror\Areas\Admin\Views\Hotel\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div id=""portlet-config"" class=""modal hide"">
    <div class=""modal-header"">
        <button data-dismiss=""modal"" class=""close"" type=""button""></button>
        <h3>Widget Settings</h3>
    </div>
    <div class=""modal-body"">Widget settings form goes here</div>
</div>
<div class=""clearfix""></div>
<div class=""content"">
    
    <div class=""page-title"">
        <i class=""icon-custom-left""></i>
        <h3><span class=""semi-bold"">Hotels</span></h3>
    </div>
    <div class=""row"">
        <div class=""col-md-12"">
            <div class=""grid simple "">
                <div class=""grid-title no-border"">
                  
                    <div class=""tools"">
                        <a href=""javascript:;"" class=""collapse""></a>
                        <a href=""#grid-config"" data-toggle=""modal"" class=""config""></a>
                        <a href=""javascript:;"" class=""reload""></a>
                        <a href=""javascript:;"" class=""remove""></a>
                    </div>
                </");
            WriteLiteral(@"div>
                <div class=""grid-body no-border"">
                    <h3>Hotels </h3>
                    <table class=""table no-more-tables"">
                        <thead>
                            <tr>
                                <th style=""width:9%"">Hotel name</th>
                                <th style=""width:10%"">Phone</th>
                                <th style=""width:6%"">Category</th>
                                <th style=""width:6%"">Rating</th>

                            </tr>
                        </thead>
                        <tbody>
");
#nullable restore
#line 45 "C:\Users\afsana.mammadova\Downloads\AurorManagementStudio\Auror\Auror\Areas\Admin\Views\Hotel\Index.cshtml"
                             foreach (var item in Model)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <tr>\r\n                                <td class=\"v-align-middle\">");
#nullable restore
#line 48 "C:\Users\afsana.mammadova\Downloads\AurorManagementStudio\Auror\Auror\Areas\Admin\Views\Hotel\Index.cshtml"
                                                      Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td class=\"v-align-middle\">\r\n                                    <span class=\"muted\">");
#nullable restore
#line 50 "C:\Users\afsana.mammadova\Downloads\AurorManagementStudio\Auror\Auror\Areas\Admin\Views\Hotel\Index.cshtml"
                                                   Write(item.Phone);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                                </td>\r\n                                <td>\r\n                                    <span class=\"muted\">");
#nullable restore
#line 53 "C:\Users\afsana.mammadova\Downloads\AurorManagementStudio\Auror\Auror\Areas\Admin\Views\Hotel\Index.cshtml"
                                                   Write(item.HotelCategory.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                                </td>\r\n                                <td class=\"v-align-middle\">\r\n                                    <div class=\"progress\">\r\n                                        <div data-percentage=\"");
#nullable restore
#line 57 "C:\Users\afsana.mammadova\Downloads\AurorManagementStudio\Auror\Auror\Areas\Admin\Views\Hotel\Index.cshtml"
                                                         Write(item.Rating);

#line default
#line hidden
#nullable disable
            WriteLiteral("%\" class=\"progress-bar progress-bar-success animate-progress-bar\"> </div>\r\n                                        <span class=\"muted\">");
#nullable restore
#line 58 "C:\Users\afsana.mammadova\Downloads\AurorManagementStudio\Auror\Auror\Areas\Admin\Views\Hotel\Index.cshtml"
                                                       Write(item.Rating);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                                    </div>\r\n                                </td>\r\n                            </tr>\r\n");
#nullable restore
#line 62 "C:\Users\afsana.mammadova\Downloads\AurorManagementStudio\Auror\Auror\Areas\Admin\Views\Hotel\Index.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </tbody>\r\n                    </table>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Hotel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
