#pragma checksum "D:\Document\DoAnCoSoKyThuatPhamMem\HK3-20-21-DoAnCoSoKTPM-TrinhMinhPhuc-1911547706-PhanQuangQui-1911547798-19DTH1A\QuanLyVienPhi\Views\ChiPhi\ChiPhi.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "73a373b2cf68ebd1f8a13758f2a976e467e77cc4"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_ChiPhi_ChiPhi), @"mvc.1.0.view", @"/Views/ChiPhi/ChiPhi.cshtml")]
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
#line 1 "D:\Document\DoAnCoSoKyThuatPhamMem\HK3-20-21-DoAnCoSoKTPM-TrinhMinhPhuc-1911547706-PhanQuangQui-1911547798-19DTH1A\QuanLyVienPhi\Views\_ViewImports.cshtml"
using QuanLyVienPhi;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Document\DoAnCoSoKyThuatPhamMem\HK3-20-21-DoAnCoSoKTPM-TrinhMinhPhuc-1911547706-PhanQuangQui-1911547798-19DTH1A\QuanLyVienPhi\Views\_ViewImports.cshtml"
using QuanLyVienPhi.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"73a373b2cf68ebd1f8a13758f2a976e467e77cc4", @"/Views/ChiPhi/ChiPhi.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a50e14ddc42964877ca75d81d148d970d3341b9d", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_ChiPhi_ChiPhi : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<QuanLyVienPhi.Models.Expenses>>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "ChiPhi", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "ThemChiPhi", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary feather icon-plus"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("text-align:right;"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 2 "D:\Document\DoAnCoSoKyThuatPhamMem\HK3-20-21-DoAnCoSoKTPM-TrinhMinhPhuc-1911547706-PhanQuangQui-1911547798-19DTH1A\QuanLyVienPhi\Views\ChiPhi\ChiPhi.cshtml"
  
    ViewData["Title"] = "Chi phí khám bệnh";
    if (ViewBag.Session == "Ad".ToLower().Trim())
    {
        Layout = "~/Views/Shared/_LayoutAdmin.cshtml";
    }
    else if (ViewBag.Session == "KT".ToLower().Trim())
    {
        Layout = "~/Views/Shared/_LayoutKeToan.cshtml";
    }
    PageList pager = new PageList();
    int pageNo = 0;
    if (ViewBag.Pager != null)
    {
        pager = ViewBag.Pager;
        pageNo = pager.CurrentPage;
    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"

<div class=""page-header"">
    <div class=""page-block"">
        <div class=""row align-items-center"">
            <div class=""col-md-12"">
                <div class=""page-header-title"">

                </div>
                <ul class=""breadcrumb"">
");
            WriteLiteral("                    <li class=\"breadcrumb-item\"><a");
            BeginWriteAttribute("href", " href=\"", 965, "\"", 993, 1);
#nullable restore
#line 31 "D:\Document\DoAnCoSoKyThuatPhamMem\HK3-20-21-DoAnCoSoKTPM-TrinhMinhPhuc-1911547706-PhanQuangQui-1911547798-19DTH1A\QuanLyVienPhi\Views\ChiPhi\ChiPhi.cshtml"
WriteAttributeValue("", 972, Url.Action("ChiPhi"), 972, 21, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Chi phí</a></li>\r\n                    <li class=\"breadcrumb-item\"><a");
            BeginWriteAttribute("href", " href=\"", 1063, "\"", 1091, 1);
#nullable restore
#line 32 "D:\Document\DoAnCoSoKyThuatPhamMem\HK3-20-21-DoAnCoSoKTPM-TrinhMinhPhuc-1911547706-PhanQuangQui-1911547798-19DTH1A\QuanLyVienPhi\Views\ChiPhi\ChiPhi.cshtml"
WriteAttributeValue("", 1070, Url.Action("ChiPhi"), 1070, 21, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@">Chi phí</a></li>
                </ul>
            </div>
        </div>
    </div>
</div>
<!-- [ table ] start -->
<div class=""col-xl-12"">
    <div class=""card"">
        <div class=""card-header"">
            <h5>Chi phí khám bệnh</h5>
        </div>
        <div class=""card-block table-border-style"">
            <div style=""text-align:right;"">
                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "73a373b2cf68ebd1f8a13758f2a976e467e77cc47142", async() => {
                WriteLiteral("     Thêm");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
            </div>
            <div class=""table-responsive"">
                <table class=""table table-striped content-table colortoptable"">
                    <thead>
                        <tr>
                            <th>Mã chi phí</th>
                            <th>Tên chi phí</th>
                            <th>Chức năng</th>
                        </tr>
                    </thead>
                    <tbody>
");
#nullable restore
#line 58 "D:\Document\DoAnCoSoKyThuatPhamMem\HK3-20-21-DoAnCoSoKTPM-TrinhMinhPhuc-1911547706-PhanQuangQui-1911547798-19DTH1A\QuanLyVienPhi\Views\ChiPhi\ChiPhi.cshtml"
                         foreach (var item in Model)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <tr class=\"active-row\">\r\n                                <td>");
#nullable restore
#line 61 "D:\Document\DoAnCoSoKyThuatPhamMem\HK3-20-21-DoAnCoSoKTPM-TrinhMinhPhuc-1911547706-PhanQuangQui-1911547798-19DTH1A\QuanLyVienPhi\Views\ChiPhi\ChiPhi.cshtml"
                               Write(Html.DisplayFor(m => item._nKhoanCP));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td>");
#nullable restore
#line 62 "D:\Document\DoAnCoSoKyThuatPhamMem\HK3-20-21-DoAnCoSoKTPM-TrinhMinhPhuc-1911547706-PhanQuangQui-1911547798-19DTH1A\QuanLyVienPhi\Views\ChiPhi\ChiPhi.cshtml"
                               Write(Html.DisplayFor(m => item._sTenCP));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td>\r\n                                    <a");
            BeginWriteAttribute("href", " href=\"", 2413, "\"", 2482, 1);
#nullable restore
#line 64 "D:\Document\DoAnCoSoKyThuatPhamMem\HK3-20-21-DoAnCoSoKTPM-TrinhMinhPhuc-1911547706-PhanQuangQui-1911547798-19DTH1A\QuanLyVienPhi\Views\ChiPhi\ChiPhi.cshtml"
WriteAttributeValue("", 2420, Url.Action("SuaChiPhi", "ChiPhi", new { id = item._nKhoanCP}), 2420, 62, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-success feather icon-edit\"></a>\r\n                                </td>\r\n                            </tr>\r\n");
#nullable restore
#line 67 "D:\Document\DoAnCoSoKyThuatPhamMem\HK3-20-21-DoAnCoSoKTPM-TrinhMinhPhuc-1911547706-PhanQuangQui-1911547798-19DTH1A\QuanLyVienPhi\Views\ChiPhi\ChiPhi.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </tbody>\r\n                </table>\r\n                <!--Phan trang-->\r\n                <nav aria-label=\"Page navigation example\">\r\n");
#nullable restore
#line 72 "D:\Document\DoAnCoSoKyThuatPhamMem\HK3-20-21-DoAnCoSoKTPM-TrinhMinhPhuc-1911547706-PhanQuangQui-1911547798-19DTH1A\QuanLyVienPhi\Views\ChiPhi\ChiPhi.cshtml"
                     if (pager.TotalPages > 0)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <ul class=\"pagination\">\r\n");
#nullable restore
#line 75 "D:\Document\DoAnCoSoKyThuatPhamMem\HK3-20-21-DoAnCoSoKTPM-TrinhMinhPhuc-1911547706-PhanQuangQui-1911547798-19DTH1A\QuanLyVienPhi\Views\ChiPhi\ChiPhi.cshtml"
                             if (pager.CurrentPage > 1)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <li class=\"page-item\">\r\n                                    <a class=\"page-link\"");
            BeginWriteAttribute("href", " href=\"", 3104, "\"", 3157, 1);
#nullable restore
#line 78 "D:\Document\DoAnCoSoKyThuatPhamMem\HK3-20-21-DoAnCoSoKTPM-TrinhMinhPhuc-1911547706-PhanQuangQui-1911547798-19DTH1A\QuanLyVienPhi\Views\ChiPhi\ChiPhi.cshtml"
WriteAttributeValue("", 3111, Url.Action("ChiPhi", "ChiPhi", new {page =1}), 3111, 46, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Frist</a>\r\n                                </li>\r\n                                <li class=\"page-item\">\r\n                                    <a class=\"page-link\"");
            BeginWriteAttribute("href", " href=\"", 3321, "\"", 3394, 1);
#nullable restore
#line 81 "D:\Document\DoAnCoSoKyThuatPhamMem\HK3-20-21-DoAnCoSoKTPM-TrinhMinhPhuc-1911547706-PhanQuangQui-1911547798-19DTH1A\QuanLyVienPhi\Views\ChiPhi\ChiPhi.cshtml"
WriteAttributeValue("", 3328, Url.Action("ChiPhi", "ChiPhi", new {page =pager.CurrentPage - 1}), 3328, 66, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Previous</a>\r\n                                </li>\r\n");
#nullable restore
#line 83 "D:\Document\DoAnCoSoKyThuatPhamMem\HK3-20-21-DoAnCoSoKTPM-TrinhMinhPhuc-1911547706-PhanQuangQui-1911547798-19DTH1A\QuanLyVienPhi\Views\ChiPhi\ChiPhi.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 85 "D:\Document\DoAnCoSoKyThuatPhamMem\HK3-20-21-DoAnCoSoKTPM-TrinhMinhPhuc-1911547706-PhanQuangQui-1911547798-19DTH1A\QuanLyVienPhi\Views\ChiPhi\ChiPhi.cshtml"
                             for (var pge = pager.StartPage; pge <= pager.EndPage; pge++)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <li");
            BeginWriteAttribute("class", " class=\"", 3639, "\"", 3698, 2);
            WriteAttributeValue("", 3647, "page-item", 3647, 9, true);
#nullable restore
#line 87 "D:\Document\DoAnCoSoKyThuatPhamMem\HK3-20-21-DoAnCoSoKTPM-TrinhMinhPhuc-1911547706-PhanQuangQui-1911547798-19DTH1A\QuanLyVienPhi\Views\ChiPhi\ChiPhi.cshtml"
WriteAttributeValue(" ", 3656, pge == pager.CurrentPage ? "active":"", 3657, 41, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                                    <a class=\"page-link\"");
            BeginWriteAttribute("href", " href=\"", 3758, "\"", 3816, 1);
#nullable restore
#line 88 "D:\Document\DoAnCoSoKyThuatPhamMem\HK3-20-21-DoAnCoSoKTPM-TrinhMinhPhuc-1911547706-PhanQuangQui-1911547798-19DTH1A\QuanLyVienPhi\Views\ChiPhi\ChiPhi.cshtml"
WriteAttributeValue("", 3765, Url.Action("ChiPhi", "ChiPhi", new { page = @pge}), 3765, 51, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 88 "D:\Document\DoAnCoSoKyThuatPhamMem\HK3-20-21-DoAnCoSoKTPM-TrinhMinhPhuc-1911547706-PhanQuangQui-1911547798-19DTH1A\QuanLyVienPhi\Views\ChiPhi\ChiPhi.cshtml"
                                                                                                               Write(pge);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n                                </li>\r\n");
#nullable restore
#line 90 "D:\Document\DoAnCoSoKyThuatPhamMem\HK3-20-21-DoAnCoSoKTPM-TrinhMinhPhuc-1911547706-PhanQuangQui-1911547798-19DTH1A\QuanLyVienPhi\Views\ChiPhi\ChiPhi.cshtml"

                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 93 "D:\Document\DoAnCoSoKyThuatPhamMem\HK3-20-21-DoAnCoSoKTPM-TrinhMinhPhuc-1911547706-PhanQuangQui-1911547798-19DTH1A\QuanLyVienPhi\Views\ChiPhi\ChiPhi.cshtml"
                             if (pager.CurrentPage < pager.TotalPages)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <li class=\"page-item\">\r\n                                    <a class=\"page-link\"");
            BeginWriteAttribute("href", " href=\"", 4117, "\"", 4192, 1);
#nullable restore
#line 96 "D:\Document\DoAnCoSoKyThuatPhamMem\HK3-20-21-DoAnCoSoKTPM-TrinhMinhPhuc-1911547706-PhanQuangQui-1911547798-19DTH1A\QuanLyVienPhi\Views\ChiPhi\ChiPhi.cshtml"
WriteAttributeValue("", 4124, Url.Action("ChiPhi", "ChiPhi", new {page = pager.CurrentPage + 1 }), 4124, 68, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Next</a>\r\n                                </li>\r\n                                <li class=\"page-item\">\r\n                                    <a class=\"page-link\"");
            BeginWriteAttribute("href", " href=\"", 4355, "\"", 4425, 1);
#nullable restore
#line 99 "D:\Document\DoAnCoSoKyThuatPhamMem\HK3-20-21-DoAnCoSoKTPM-TrinhMinhPhuc-1911547706-PhanQuangQui-1911547798-19DTH1A\QuanLyVienPhi\Views\ChiPhi\ChiPhi.cshtml"
WriteAttributeValue("", 4362, Url.Action("ChiPhi", "ChiPhi", new {page = pager.TotalPages }), 4362, 63, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Last</a>\r\n                                </li>\r\n");
#nullable restore
#line 101 "D:\Document\DoAnCoSoKyThuatPhamMem\HK3-20-21-DoAnCoSoKTPM-TrinhMinhPhuc-1911547706-PhanQuangQui-1911547798-19DTH1A\QuanLyVienPhi\Views\ChiPhi\ChiPhi.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                        </ul>\r\n");
#nullable restore
#line 103 "D:\Document\DoAnCoSoKyThuatPhamMem\HK3-20-21-DoAnCoSoKTPM-TrinhMinhPhuc-1911547706-PhanQuangQui-1911547798-19DTH1A\QuanLyVienPhi\Views\ChiPhi\ChiPhi.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </nav>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n<!-- [ table ] end -->\r\n");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<QuanLyVienPhi.Models.Expenses>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591