#pragma checksum "D:\Document\DoAnCoSoKyThuatPhamMem\HK3-20-21-DoAnCoSoKTPM-TrinhMinhPhuc-1911547706-PhanQuangQui-1911547798-19DTH1A\QuanLyVienPhi\Views\BenhNhan\DSBienLai.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "472f6adf6b081cb20d51aad10df765841fc11688"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_BenhNhan_DSBienLai), @"mvc.1.0.view", @"/Views/BenhNhan/DSBienLai.cshtml")]
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
#line 2 "D:\Document\DoAnCoSoKyThuatPhamMem\HK3-20-21-DoAnCoSoKTPM-TrinhMinhPhuc-1911547706-PhanQuangQui-1911547798-19DTH1A\QuanLyVienPhi\Views\BenhNhan\DSBienLai.cshtml"
using QuanLyVienPhi.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"472f6adf6b081cb20d51aad10df765841fc11688", @"/Views/BenhNhan/DSBienLai.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a50e14ddc42964877ca75d81d148d970d3341b9d", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_BenhNhan_DSBienLai : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<QuanLyVienPhi.Models.Receipts>>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "D:\Document\DoAnCoSoKyThuatPhamMem\HK3-20-21-DoAnCoSoKTPM-TrinhMinhPhuc-1911547706-PhanQuangQui-1911547798-19DTH1A\QuanLyVienPhi\Views\BenhNhan\DSBienLai.cshtml"
  
    ViewData["Title"] = "Biên lai";
    if (ViewBag.Session == "Ad".ToLower().Trim())
    {
        Layout = "~/Views/Shared/_LayoutAdmin.cshtml";
    }
    else if (ViewBag.Session == "KT".ToLower().Trim())
    {
        Layout = "~/Views/Shared/_LayoutKeToan.cshtml";
    }
    else
    {
        Layout = "~/Views/Shared/_LayoutNhanVien.cshtml";
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


<!-- [ breadcrumb ] start -->
<!-- [ breadcrumb ] start -->

<div class=""page-header"">
    <div class=""page-block"">
        <div class=""row align-items-center"">
            <div class=""col-md-12"">
                <div class=""page-header-title"">

                </div>
                <ul class=""breadcrumb"">
");
            WriteLiteral("                    <li class=\"breadcrumb-item\"><a");
            BeginWriteAttribute("href", " href=\"", 1116, "\"", 1147, 1);
#nullable restore
#line 40 "D:\Document\DoAnCoSoKyThuatPhamMem\HK3-20-21-DoAnCoSoKTPM-TrinhMinhPhuc-1911547706-PhanQuangQui-1911547798-19DTH1A\QuanLyVienPhi\Views\BenhNhan\DSBienLai.cshtml"
WriteAttributeValue("", 1123, Url.Action("DSBienLai"), 1123, 24, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Danh sách biên lai</a></li>\r\n                    <li class=\"breadcrumb-item\"><a");
            BeginWriteAttribute("href", " href=\"", 1228, "\"", 1259, 1);
#nullable restore
#line 41 "D:\Document\DoAnCoSoKyThuatPhamMem\HK3-20-21-DoAnCoSoKTPM-TrinhMinhPhuc-1911547706-PhanQuangQui-1911547798-19DTH1A\QuanLyVienPhi\Views\BenhNhan\DSBienLai.cshtml"
WriteAttributeValue("", 1235, Url.Action("DSBienLai"), 1235, 24, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@">Danh sách biên lai</a></li>
                </ul>
            </div>
        </div>
    </div>
</div>
<div class=""row"">
    <!-- [ Breadcrumbs & Pagination ] start -->
    <div class=""col-sm-12"">
        <div class=""card"">
            <div class=""card-header"">
                <h5>Biên lai</h5>
            </div>
            <div class=""card-body"">
                <nav aria-label=""Page navigation example"">
                    <div class=""card-block table-border-style"">
                        <div class=""row"">
                            <div class=""col-md-6"">
                                <!--Tim kiem---------------------------------------------------------------------------------------------------------------------------->
                                <div class=""input-group mb-3"">
                                    <input type=""search"" id=""Search"" class=""form-control"" placeholder=""Tìm kiếm..."">
                                    <div class=""input-group-append"">
                ");
            WriteLiteral(@"                        <button class=""btn btn-success feather icon-search"" type=""button"">    Tìm</button>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class=""table-responsive"">
                            <table class=""table table-striped content-table colortoptabletwo"">
                                <thead>
                                    <tr>
                                        <th>Mã bệnh nhân</th>
                                        <th>Số biên lai</th>
                                        <th>Họ tên</th>
                                        <th>Ngày thanh toán</th>
                                        <th>Tổng tiền</th>
                                        <th>Thanh toán</th>
                                    </tr>
                                </thead>
                                <tbody>
");
#nullable restore
#line 81 "D:\Document\DoAnCoSoKyThuatPhamMem\HK3-20-21-DoAnCoSoKTPM-TrinhMinhPhuc-1911547706-PhanQuangQui-1911547798-19DTH1A\QuanLyVienPhi\Views\BenhNhan\DSBienLai.cshtml"
                                     foreach (var item in Model)
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <tr class=\"Search\">\r\n                                            <td>");
#nullable restore
#line 84 "D:\Document\DoAnCoSoKyThuatPhamMem\HK3-20-21-DoAnCoSoKTPM-TrinhMinhPhuc-1911547706-PhanQuangQui-1911547798-19DTH1A\QuanLyVienPhi\Views\BenhNhan\DSBienLai.cshtml"
                                           Write(Html.DisplayFor(m => item._sMaBN));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                            <td>");
#nullable restore
#line 85 "D:\Document\DoAnCoSoKyThuatPhamMem\HK3-20-21-DoAnCoSoKTPM-TrinhMinhPhuc-1911547706-PhanQuangQui-1911547798-19DTH1A\QuanLyVienPhi\Views\BenhNhan\DSBienLai.cshtml"
                                           Write(Html.DisplayFor(m => item._nSoBienLai));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                            <td>");
#nullable restore
#line 86 "D:\Document\DoAnCoSoKyThuatPhamMem\HK3-20-21-DoAnCoSoKTPM-TrinhMinhPhuc-1911547706-PhanQuangQui-1911547798-19DTH1A\QuanLyVienPhi\Views\BenhNhan\DSBienLai.cshtml"
                                           Write(Html.DisplayFor(m => item._sHoTen));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                            <td>");
#nullable restore
#line 87 "D:\Document\DoAnCoSoKyThuatPhamMem\HK3-20-21-DoAnCoSoKTPM-TrinhMinhPhuc-1911547706-PhanQuangQui-1911547798-19DTH1A\QuanLyVienPhi\Views\BenhNhan\DSBienLai.cshtml"
                                           Write(String.Format("{0:dd/MM/yyyy}", item._dNgayThanhToan));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                            <td>");
#nullable restore
#line 88 "D:\Document\DoAnCoSoKyThuatPhamMem\HK3-20-21-DoAnCoSoKTPM-TrinhMinhPhuc-1911547706-PhanQuangQui-1911547798-19DTH1A\QuanLyVienPhi\Views\BenhNhan\DSBienLai.cshtml"
                                           Write(String.Format("{0:0,0}", item._fTongTien));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                            <td>\r\n                                                <a");
            BeginWriteAttribute("href", " href=\"", 4019, "\"", 4112, 1);
#nullable restore
#line 90 "D:\Document\DoAnCoSoKyThuatPhamMem\HK3-20-21-DoAnCoSoKTPM-TrinhMinhPhuc-1911547706-PhanQuangQui-1911547798-19DTH1A\QuanLyVienPhi\Views\BenhNhan\DSBienLai.cshtml"
WriteAttributeValue("", 4026, Url.Action("ThanhToan", "BenhNhan", new { id = item._nSoBienLai, MaBN = item._sMaBN}), 4026, 86, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("\r\n                                                   class=\"btn btn-info feather icon-file-text\"></a>\r\n                                            </td>\r\n                                        </tr>\r\n");
#nullable restore
#line 94 "D:\Document\DoAnCoSoKyThuatPhamMem\HK3-20-21-DoAnCoSoKTPM-TrinhMinhPhuc-1911547706-PhanQuangQui-1911547798-19DTH1A\QuanLyVienPhi\Views\BenhNhan\DSBienLai.cshtml"
                                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                </tbody>\r\n                            </table>\r\n                            <!--Phan trang-->\r\n                            <nav aria-label=\"Page navigation example\">\r\n");
#nullable restore
#line 99 "D:\Document\DoAnCoSoKyThuatPhamMem\HK3-20-21-DoAnCoSoKTPM-TrinhMinhPhuc-1911547706-PhanQuangQui-1911547798-19DTH1A\QuanLyVienPhi\Views\BenhNhan\DSBienLai.cshtml"
                                 if (pager.TotalPages > 0)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <ul class=\"pagination\">\r\n");
#nullable restore
#line 102 "D:\Document\DoAnCoSoKyThuatPhamMem\HK3-20-21-DoAnCoSoKTPM-TrinhMinhPhuc-1911547706-PhanQuangQui-1911547798-19DTH1A\QuanLyVienPhi\Views\BenhNhan\DSBienLai.cshtml"
                                         if (pager.CurrentPage > 1)
                                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                            <li class=\"page-item\">\r\n                                                <a class=\"page-link\"");
            BeginWriteAttribute("href", " href=\"", 4956, "\"", 5013, 1);
#nullable restore
#line 105 "D:\Document\DoAnCoSoKyThuatPhamMem\HK3-20-21-DoAnCoSoKTPM-TrinhMinhPhuc-1911547706-PhanQuangQui-1911547798-19DTH1A\QuanLyVienPhi\Views\BenhNhan\DSBienLai.cshtml"
WriteAttributeValue("", 4963, Url.Action("DSBienLai","BenhNhan", new {page =1}), 4963, 50, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Frist</a>\r\n                                            </li>\r\n                                            <li class=\"page-item\">\r\n                                                <a class=\"page-link\"");
            BeginWriteAttribute("href", " href=\"", 5213, "\"", 5291, 1);
#nullable restore
#line 108 "D:\Document\DoAnCoSoKyThuatPhamMem\HK3-20-21-DoAnCoSoKTPM-TrinhMinhPhuc-1911547706-PhanQuangQui-1911547798-19DTH1A\QuanLyVienPhi\Views\BenhNhan\DSBienLai.cshtml"
WriteAttributeValue("", 5220, Url.Action("BenhNhan", "DSBienLai", new {page =pager.CurrentPage - 1}), 5220, 71, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Previous</a>\r\n                                            </li>\r\n");
#nullable restore
#line 110 "D:\Document\DoAnCoSoKyThuatPhamMem\HK3-20-21-DoAnCoSoKTPM-TrinhMinhPhuc-1911547706-PhanQuangQui-1911547798-19DTH1A\QuanLyVienPhi\Views\BenhNhan\DSBienLai.cshtml"
                                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 112 "D:\Document\DoAnCoSoKyThuatPhamMem\HK3-20-21-DoAnCoSoKTPM-TrinhMinhPhuc-1911547706-PhanQuangQui-1911547798-19DTH1A\QuanLyVienPhi\Views\BenhNhan\DSBienLai.cshtml"
                                         for (var pge = pager.StartPage; pge <= pager.EndPage; pge++)
                                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                            <li");
            BeginWriteAttribute("class", " class=\"", 5596, "\"", 5655, 2);
            WriteAttributeValue("", 5604, "page-item", 5604, 9, true);
#nullable restore
#line 114 "D:\Document\DoAnCoSoKyThuatPhamMem\HK3-20-21-DoAnCoSoKTPM-TrinhMinhPhuc-1911547706-PhanQuangQui-1911547798-19DTH1A\QuanLyVienPhi\Views\BenhNhan\DSBienLai.cshtml"
WriteAttributeValue(" ", 5613, pge == pager.CurrentPage ? "active":"", 5614, 41, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                                                <a class=\"page-link\"");
            BeginWriteAttribute("href", " href=\"", 5727, "\"", 5790, 1);
#nullable restore
#line 115 "D:\Document\DoAnCoSoKyThuatPhamMem\HK3-20-21-DoAnCoSoKTPM-TrinhMinhPhuc-1911547706-PhanQuangQui-1911547798-19DTH1A\QuanLyVienPhi\Views\BenhNhan\DSBienLai.cshtml"
WriteAttributeValue("", 5734, Url.Action( "DSBienLai","BenhNhan", new { page = @pge}), 5734, 56, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 115 "D:\Document\DoAnCoSoKyThuatPhamMem\HK3-20-21-DoAnCoSoKTPM-TrinhMinhPhuc-1911547706-PhanQuangQui-1911547798-19DTH1A\QuanLyVienPhi\Views\BenhNhan\DSBienLai.cshtml"
                                                                                                                                Write(pge);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n                                            </li>\r\n");
#nullable restore
#line 117 "D:\Document\DoAnCoSoKyThuatPhamMem\HK3-20-21-DoAnCoSoKTPM-TrinhMinhPhuc-1911547706-PhanQuangQui-1911547798-19DTH1A\QuanLyVienPhi\Views\BenhNhan\DSBienLai.cshtml"

                                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 120 "D:\Document\DoAnCoSoKyThuatPhamMem\HK3-20-21-DoAnCoSoKTPM-TrinhMinhPhuc-1911547706-PhanQuangQui-1911547798-19DTH1A\QuanLyVienPhi\Views\BenhNhan\DSBienLai.cshtml"
                                         if (pager.CurrentPage < pager.TotalPages)
                                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                            <li class=\"page-item\">\r\n                                                <a class=\"page-link\"");
            BeginWriteAttribute("href", " href=\"", 6163, "\"", 6243, 1);
#nullable restore
#line 123 "D:\Document\DoAnCoSoKyThuatPhamMem\HK3-20-21-DoAnCoSoKTPM-TrinhMinhPhuc-1911547706-PhanQuangQui-1911547798-19DTH1A\QuanLyVienPhi\Views\BenhNhan\DSBienLai.cshtml"
WriteAttributeValue("", 6170, Url.Action( "DSBienLai","BenhNhan", new {page = pager.CurrentPage + 1 }), 6170, 73, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Next</a>\r\n                                            </li>\r\n                                            <li class=\"page-item\">\r\n                                                <a class=\"page-link\"");
            BeginWriteAttribute("href", " href=\"", 6442, "\"", 6517, 1);
#nullable restore
#line 126 "D:\Document\DoAnCoSoKyThuatPhamMem\HK3-20-21-DoAnCoSoKTPM-TrinhMinhPhuc-1911547706-PhanQuangQui-1911547798-19DTH1A\QuanLyVienPhi\Views\BenhNhan\DSBienLai.cshtml"
WriteAttributeValue("", 6449, Url.Action( "DSBienLai","BenhNhan", new {page = pager.TotalPages }), 6449, 68, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Last</a>\r\n                                            </li>\r\n");
#nullable restore
#line 128 "D:\Document\DoAnCoSoKyThuatPhamMem\HK3-20-21-DoAnCoSoKTPM-TrinhMinhPhuc-1911547706-PhanQuangQui-1911547798-19DTH1A\QuanLyVienPhi\Views\BenhNhan\DSBienLai.cshtml"
                                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    </ul>\r\n");
#nullable restore
#line 130 "D:\Document\DoAnCoSoKyThuatPhamMem\HK3-20-21-DoAnCoSoKTPM-TrinhMinhPhuc-1911547706-PhanQuangQui-1911547798-19DTH1A\QuanLyVienPhi\Views\BenhNhan\DSBienLai.cshtml"
                                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                            </nav>\r\n                        </div>\r\n                    </div>\r\n                </nav>\r\n            </div>\r\n        </div>\r\n    </div>\r\n    <!-- [ Breadcrumbs & Pagination ] end -->\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<QuanLyVienPhi.Models.Receipts>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591