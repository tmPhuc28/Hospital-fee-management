#pragma checksum "D:\Document\DoAnCoSoKyThuatPhamMem\HK3-20-21-DoAnCoSoKTPM-TrinhMinhPhuc-1911547706-PhanQuangQui-1911547798-19DTH1A\QuanLyVienPhi\Views\BenhVien\Khoa.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b137eba88265e1cc2fd1d09b05eb2b46ab68fe80"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_BenhVien_Khoa), @"mvc.1.0.view", @"/Views/BenhVien/Khoa.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b137eba88265e1cc2fd1d09b05eb2b46ab68fe80", @"/Views/BenhVien/Khoa.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a50e14ddc42964877ca75d81d148d970d3341b9d", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_BenhVien_Khoa : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<QuanLyVienPhi.Models.Faculty>>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "BenhVien", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "ThemKhoa", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 2 "D:\Document\DoAnCoSoKyThuatPhamMem\HK3-20-21-DoAnCoSoKTPM-TrinhMinhPhuc-1911547706-PhanQuangQui-1911547798-19DTH1A\QuanLyVienPhi\Views\BenhVien\Khoa.cshtml"
  
    ViewData["Title"] = "Khoa";
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
            BeginWriteAttribute("href", " href=\"", 929, "\"", 955, 1);
#nullable restore
#line 30 "D:\Document\DoAnCoSoKyThuatPhamMem\HK3-20-21-DoAnCoSoKTPM-TrinhMinhPhuc-1911547706-PhanQuangQui-1911547798-19DTH1A\QuanLyVienPhi\Views\BenhVien\Khoa.cshtml"
WriteAttributeValue("", 936, Url.Action("Khoa"), 936, 19, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Bệnh viện</a></li>\r\n                    <li class=\"breadcrumb-item\"><a");
            BeginWriteAttribute("href", " href=\"", 1027, "\"", 1053, 1);
#nullable restore
#line 31 "D:\Document\DoAnCoSoKyThuatPhamMem\HK3-20-21-DoAnCoSoKTPM-TrinhMinhPhuc-1911547706-PhanQuangQui-1911547798-19DTH1A\QuanLyVienPhi\Views\BenhVien\Khoa.cshtml"
WriteAttributeValue("", 1034, Url.Action("Khoa"), 1034, 19, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@">Khoa</a></li>
                </ul>
            </div>
        </div>
    </div>
</div>

<!-- [ table ] start -->
<div class=""col-xl-12"">
    <div class=""card"">
        <div class=""card-header"">
            <h5>Khoa</h5>
        </div>
        <div class=""card-block table-border-style"">
            <div style=""text-align:right;"">
                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b137eba88265e1cc2fd1d09b05eb2b46ab68fe807110", async() => {
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
                            <th>Mã khoa</th>
                            <th>Tên khoa</th>
                            <th>Số bác sĩ</th>
                            <th>Chức năng</th>
                        </tr>
                    </thead>
                    <tbody>
");
#nullable restore
#line 59 "D:\Document\DoAnCoSoKyThuatPhamMem\HK3-20-21-DoAnCoSoKTPM-TrinhMinhPhuc-1911547706-PhanQuangQui-1911547798-19DTH1A\QuanLyVienPhi\Views\BenhVien\Khoa.cshtml"
                         foreach (var item in Model)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <tr>\r\n                                <td>");
#nullable restore
#line 62 "D:\Document\DoAnCoSoKyThuatPhamMem\HK3-20-21-DoAnCoSoKTPM-TrinhMinhPhuc-1911547706-PhanQuangQui-1911547798-19DTH1A\QuanLyVienPhi\Views\BenhVien\Khoa.cshtml"
                               Write(Html.DisplayFor(m => item._sMaKhoa));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td>");
#nullable restore
#line 63 "D:\Document\DoAnCoSoKyThuatPhamMem\HK3-20-21-DoAnCoSoKTPM-TrinhMinhPhuc-1911547706-PhanQuangQui-1911547798-19DTH1A\QuanLyVienPhi\Views\BenhVien\Khoa.cshtml"
                               Write(Html.DisplayFor(m => item._sTenKhoa));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td>");
#nullable restore
#line 64 "D:\Document\DoAnCoSoKyThuatPhamMem\HK3-20-21-DoAnCoSoKTPM-TrinhMinhPhuc-1911547706-PhanQuangQui-1911547798-19DTH1A\QuanLyVienPhi\Views\BenhVien\Khoa.cshtml"
                               Write(Html.DisplayFor(m => item._nSoLuong));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td>\r\n                                    <a");
            BeginWriteAttribute("href", " href=\"", 2465, "\"", 2534, 1);
#nullable restore
#line 66 "D:\Document\DoAnCoSoKyThuatPhamMem\HK3-20-21-DoAnCoSoKTPM-TrinhMinhPhuc-1911547706-PhanQuangQui-1911547798-19DTH1A\QuanLyVienPhi\Views\BenhVien\Khoa.cshtml"
WriteAttributeValue("", 2472, Url.Action("SuaKhoa", "BenhVien", new { id = item._sMaKhoa }), 2472, 62, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("\r\n                                       class=\"btn btn-success feather icon-edit\"></a>\r\n                                </td>\r\n                            </tr>\r\n");
#nullable restore
#line 70 "D:\Document\DoAnCoSoKyThuatPhamMem\HK3-20-21-DoAnCoSoKTPM-TrinhMinhPhuc-1911547706-PhanQuangQui-1911547798-19DTH1A\QuanLyVienPhi\Views\BenhVien\Khoa.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </tbody>\r\n                </table>\r\n                <!--Phan trang-->\r\n                <nav aria-label=\"Page navigation example\">\r\n");
#nullable restore
#line 75 "D:\Document\DoAnCoSoKyThuatPhamMem\HK3-20-21-DoAnCoSoKTPM-TrinhMinhPhuc-1911547706-PhanQuangQui-1911547798-19DTH1A\QuanLyVienPhi\Views\BenhVien\Khoa.cshtml"
                     if (pager.TotalPages > 0)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <ul class=\"pagination\">\r\n");
#nullable restore
#line 78 "D:\Document\DoAnCoSoKyThuatPhamMem\HK3-20-21-DoAnCoSoKTPM-TrinhMinhPhuc-1911547706-PhanQuangQui-1911547798-19DTH1A\QuanLyVienPhi\Views\BenhVien\Khoa.cshtml"
                             if (pager.CurrentPage > 1)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <li class=\"page-item\">\r\n                                    <a class=\"page-link\"");
            BeginWriteAttribute("href", " href=\"", 3196, "\"", 3249, 1);
#nullable restore
#line 81 "D:\Document\DoAnCoSoKyThuatPhamMem\HK3-20-21-DoAnCoSoKTPM-TrinhMinhPhuc-1911547706-PhanQuangQui-1911547798-19DTH1A\QuanLyVienPhi\Views\BenhVien\Khoa.cshtml"
WriteAttributeValue("", 3203, Url.Action("Khoa", "BenhVien", new {page =1}), 3203, 46, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Frist</a>\r\n                                </li>\r\n                                <li class=\"page-item\">\r\n                                    <a class=\"page-link\"");
            BeginWriteAttribute("href", " href=\"", 3413, "\"", 3486, 1);
#nullable restore
#line 84 "D:\Document\DoAnCoSoKyThuatPhamMem\HK3-20-21-DoAnCoSoKTPM-TrinhMinhPhuc-1911547706-PhanQuangQui-1911547798-19DTH1A\QuanLyVienPhi\Views\BenhVien\Khoa.cshtml"
WriteAttributeValue("", 3420, Url.Action("Khoa", "BenhVien", new {page =pager.CurrentPage - 1}), 3420, 66, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Previous</a>\r\n                                </li>\r\n");
#nullable restore
#line 86 "D:\Document\DoAnCoSoKyThuatPhamMem\HK3-20-21-DoAnCoSoKTPM-TrinhMinhPhuc-1911547706-PhanQuangQui-1911547798-19DTH1A\QuanLyVienPhi\Views\BenhVien\Khoa.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 88 "D:\Document\DoAnCoSoKyThuatPhamMem\HK3-20-21-DoAnCoSoKTPM-TrinhMinhPhuc-1911547706-PhanQuangQui-1911547798-19DTH1A\QuanLyVienPhi\Views\BenhVien\Khoa.cshtml"
                             for (var pge = pager.StartPage; pge <= pager.EndPage; pge++)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <li");
            BeginWriteAttribute("class", " class=\"", 3731, "\"", 3790, 2);
            WriteAttributeValue("", 3739, "page-item", 3739, 9, true);
#nullable restore
#line 90 "D:\Document\DoAnCoSoKyThuatPhamMem\HK3-20-21-DoAnCoSoKTPM-TrinhMinhPhuc-1911547706-PhanQuangQui-1911547798-19DTH1A\QuanLyVienPhi\Views\BenhVien\Khoa.cshtml"
WriteAttributeValue(" ", 3748, pge == pager.CurrentPage ? "active":"", 3749, 41, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                                    <a class=\"page-link\"");
            BeginWriteAttribute("href", " href=\"", 3850, "\"", 3908, 1);
#nullable restore
#line 91 "D:\Document\DoAnCoSoKyThuatPhamMem\HK3-20-21-DoAnCoSoKTPM-TrinhMinhPhuc-1911547706-PhanQuangQui-1911547798-19DTH1A\QuanLyVienPhi\Views\BenhVien\Khoa.cshtml"
WriteAttributeValue("", 3857, Url.Action("Khoa", "BenhVien", new { page = @pge}), 3857, 51, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 91 "D:\Document\DoAnCoSoKyThuatPhamMem\HK3-20-21-DoAnCoSoKTPM-TrinhMinhPhuc-1911547706-PhanQuangQui-1911547798-19DTH1A\QuanLyVienPhi\Views\BenhVien\Khoa.cshtml"
                                                                                                               Write(pge);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n                                </li>\r\n");
#nullable restore
#line 93 "D:\Document\DoAnCoSoKyThuatPhamMem\HK3-20-21-DoAnCoSoKTPM-TrinhMinhPhuc-1911547706-PhanQuangQui-1911547798-19DTH1A\QuanLyVienPhi\Views\BenhVien\Khoa.cshtml"

                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 96 "D:\Document\DoAnCoSoKyThuatPhamMem\HK3-20-21-DoAnCoSoKTPM-TrinhMinhPhuc-1911547706-PhanQuangQui-1911547798-19DTH1A\QuanLyVienPhi\Views\BenhVien\Khoa.cshtml"
                             if (pager.CurrentPage < pager.TotalPages)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <li class=\"page-item\">\r\n                                    <a class=\"page-link\"");
            BeginWriteAttribute("href", " href=\"", 4209, "\"", 4284, 1);
#nullable restore
#line 99 "D:\Document\DoAnCoSoKyThuatPhamMem\HK3-20-21-DoAnCoSoKTPM-TrinhMinhPhuc-1911547706-PhanQuangQui-1911547798-19DTH1A\QuanLyVienPhi\Views\BenhVien\Khoa.cshtml"
WriteAttributeValue("", 4216, Url.Action("Khoa", "BenhVien", new {page = pager.CurrentPage + 1 }), 4216, 68, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Next</a>\r\n                                </li>\r\n                                <li class=\"page-item\">\r\n                                    <a class=\"page-link\"");
            BeginWriteAttribute("href", " href=\"", 4447, "\"", 4517, 1);
#nullable restore
#line 102 "D:\Document\DoAnCoSoKyThuatPhamMem\HK3-20-21-DoAnCoSoKTPM-TrinhMinhPhuc-1911547706-PhanQuangQui-1911547798-19DTH1A\QuanLyVienPhi\Views\BenhVien\Khoa.cshtml"
WriteAttributeValue("", 4454, Url.Action( "Khoa","BenhVien", new {page = pager.TotalPages }), 4454, 63, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Last</a>\r\n                                </li>\r\n");
#nullable restore
#line 104 "D:\Document\DoAnCoSoKyThuatPhamMem\HK3-20-21-DoAnCoSoKTPM-TrinhMinhPhuc-1911547706-PhanQuangQui-1911547798-19DTH1A\QuanLyVienPhi\Views\BenhVien\Khoa.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                        </ul>\r\n");
#nullable restore
#line 106 "D:\Document\DoAnCoSoKyThuatPhamMem\HK3-20-21-DoAnCoSoKTPM-TrinhMinhPhuc-1911547706-PhanQuangQui-1911547798-19DTH1A\QuanLyVienPhi\Views\BenhVien\Khoa.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </nav>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n<!-- [ table ] end -->");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<QuanLyVienPhi.Models.Faculty>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591