#pragma checksum "C:\Users\afsana.mammadova\Downloads\AurorManagementStudio\Auror\Auror\Views\Hotel\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "845ab946f67ff84a0027bb20c1b4d3f94c249b7d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Hotel_Index), @"mvc.1.0.view", @"/Views/Hotel/Index.cshtml")]
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
#line 2 "C:\Users\afsana.mammadova\Downloads\AurorManagementStudio\Auror\Auror\Views\_ViewImports.cshtml"
using Auror.Models.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\afsana.mammadova\Downloads\AurorManagementStudio\Auror\Auror\Views\_ViewImports.cshtml"
using Auror.Models.Entity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\afsana.mammadova\Downloads\AurorManagementStudio\Auror\Auror\Views\_ViewImports.cshtml"
using Auror.Models.ViewComponents;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"845ab946f67ff84a0027bb20c1b4d3f94c249b7d", @"/Views/Hotel/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"afc30be60ce12b907391c299b6afbdc2cb3bf8a4", @"/Views/_ViewImports.cshtml")]
    public class Views_Hotel_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<HotelViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Hotel", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Detail", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("hotel-btn"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\afsana.mammadova\Downloads\AurorManagementStudio\Auror\Auror\Views\Hotel\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"

<!-- banner -->
<section class=""hotel-banner-simple hotel-transition-bottom hotelrooms"">

    <div class=""container"">
        <div class=""row"">
            <div class=""col-lg-12"">

                <div class=""hotel-center hotel-title-frame"">
                    <h1 class=""hotel-mb-20 hotel-h1-inner"">Hotel Seçin</h1>
                    <p class=""hotel-mb-30"">Lorem ipsum dolor sit amet, consectetur adipisicing elit. Esse, labore. Beatae sunt impedit accusamus eum.</p>
                    <ul class=""hotel-breadcrumbs"">
                        <li><a href=""index.html"">Ana Səhifə</a></li>
                        <li><span>Hotellər</span></li>
                    </ul>
                </div>

            </div>
        </div>
    </div>
</section>
<!-- banner end -->
<!-- rooms -->
<section class=""hotel-p-100-100"">
    <div class=""container"">

        <div class=""hotel-filter hotel-mb-60"">
            <a href=""#"" data-filter=""*"" class=""hotel-work-category hotel-current"">Bütün Hotellər");
            WriteLiteral("</a>\r\n");
#nullable restore
#line 34 "C:\Users\afsana.mammadova\Downloads\AurorManagementStudio\Auror\Auror\Views\Hotel\Index.cshtml"
             foreach (var item in Model.Categories)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <a href=\"#\" data-filter=\".");
#nullable restore
#line 36 "C:\Users\afsana.mammadova\Downloads\AurorManagementStudio\Auror\Auror\Views\Hotel\Index.cshtml"
                                     Write(item.Name.ToLower());

#line default
#line hidden
#nullable disable
            WriteLiteral("\" class=\"hotel-work-category\">");
#nullable restore
#line 36 "C:\Users\afsana.mammadova\Downloads\AurorManagementStudio\Auror\Auror\Views\Hotel\Index.cshtml"
                                                                                       Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n");
#nullable restore
#line 37 "C:\Users\afsana.mammadova\Downloads\AurorManagementStudio\Auror\Auror\Views\Hotel\Index.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            WriteLiteral("\r\n\r\n        </div>\r\n\r\n        <div class=\"hotel-masonry-grid hotel-3-col\">\r\n\r\n            <div class=\"hotel-grid-sizer\"></div>\r\n\r\n");
#nullable restore
#line 50 "C:\Users\afsana.mammadova\Downloads\AurorManagementStudio\Auror\Auror\Views\Hotel\Index.cshtml"
             foreach (var item in Model.Hotels)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <div");
            BeginWriteAttribute("class", " class=\"", 1777, "\"", 1870, 3);
            WriteAttributeValue("", 1785, "hotel-masonry-grid-item", 1785, 23, true);
            WriteAttributeValue(" ", 1808, "hotel-masonry-grid-item-33", 1809, 27, true);
#nullable restore
#line 52 "C:\Users\afsana.mammadova\Downloads\AurorManagementStudio\Auror\Auror\Views\Hotel\Index.cshtml"
WriteAttributeValue(" ", 1835, item.HotelCategory.Name.ToLower(), 1836, 34, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n\r\n                    <!-- room card -->\r\n                    <div class=\"hotel-room-card\">\r\n                        <div class=\"hotel-cover-frame imgLoad\">\r\n                            <a href=\"menu.html\"><img class=\"lozad\"");
            BeginWriteAttribute("src", " src=\"", 2098, "\"", 2153, 1);
#nullable restore
#line 57 "C:\Users\afsana.mammadova\Downloads\AurorManagementStudio\Auror\Auror\Views\Hotel\Index.cshtml"
WriteAttributeValue("", 2104, Url.Content($"~/img/HOTEL/{@item.DefaultImage}"), 2104, 49, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" alt=""cover""></a>
                        </div>
                        <div class=""hotel-description-frame"">
                            <ul class=""rating"">
                                <li class=""star"">&star;</li>
                                <li class=""star"">&star;</li>
                                <li class=""star"">&star;</li>
                                <li class=""star"">&star;</li>
                                <li class=""star"">&star;</li>
                            </ul>
                            <a href=""menu.html"">
                                <h3 class=""hotel-mb-20"">");
#nullable restore
#line 68 "C:\Users\afsana.mammadova\Downloads\AurorManagementStudio\Auror\Auror\Views\Hotel\Index.cshtml"
                                                   Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n                            </a>\r\n                            <div class=\"hotel-text-light hotel-text-sm hotel-mb-20\">\r\n                            \r\n                                    ");
#nullable restore
#line 72 "C:\Users\afsana.mammadova\Downloads\AurorManagementStudio\Auror\Auror\Views\Hotel\Index.cshtml"
                               Write(item.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                \r\n\r\n\r\n                            </div>\r\n                            <div class=\"hotel-card-bottom imgLoad\">\r\n\r\n                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "845ab946f67ff84a0027bb20c1b4d3f94c249b7d10063", async() => {
                WriteLiteral("<img class=\"lozad\" data-src=\"img/icons/bookmark.svg\" alt=\"icon\">Hotelə get");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 79 "C:\Users\afsana.mammadova\Downloads\AurorManagementStudio\Auror\Auror\Views\Hotel\Index.cshtml"
                                                                                WriteLiteral(item.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                            </div>\r\n                        </div>\r\n                    </div>\r\n                    <!-- room card end -->\r\n\r\n                </div>\r\n");
#nullable restore
#line 86 "C:\Users\afsana.mammadova\Downloads\AurorManagementStudio\Auror\Auror\Views\Hotel\Index.cshtml"

            }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n        </div>\r\n\r\n    </div>\r\n</section>\r\n<!-- rooms end -->\r\n\r\n\r\n");
            DefineSection("script", async() => {
                WriteLiteral(@"

    <script>
        $(
            function () {
                $('.star').on('click', function () {
                    var selectedCssClass = 'selected';
                    var $this = $(this);
                    $this.siblings('.' + selectedCssClass).removeClass(selectedCssClass);
                    $this
                        .addClass(selectedCssClass)
                        .parent().addClass('vote-cast');
                });
            }
        );
    </script>

");
            }
            );
            WriteLiteral("\r\n");
            DefineSection("style", async() => {
                WriteLiteral(@"

    <style>

        .star {
            cursor: default;
            display: inline-block;
            font-size: 30px;
            list-style-type: none;
        }

        .star,
        .rating:not(.vote-cast):hover .star:hover ~ .star,
        .rating.vote-cast .star.selected ~ .star {
            /* normal state */
            color: black;
        }

        .rating:hover .star,
        .rating.vote-cast .star {
            /* highlighted state */
            color: gold;
        }
    </style>
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<HotelViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
