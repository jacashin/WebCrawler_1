#pragma checksum "C:\Users\YL\source\repos\WebCrawler_1\WebCrawler_1\Views\Home\SaveInfo.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "fe8e0e4dcd8efe5f5e2bb0b2a018535dcab727c5"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_SaveInfo), @"mvc.1.0.view", @"/Views/Home/SaveInfo.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/SaveInfo.cshtml", typeof(AspNetCore.Views_Home_SaveInfo))]
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
#line 1 "C:\Users\YL\source\repos\WebCrawler_1\WebCrawler_1\Views\_ViewImports.cshtml"
using WebCrawler_1;

#line default
#line hidden
#line 2 "C:\Users\YL\source\repos\WebCrawler_1\WebCrawler_1\Views\_ViewImports.cshtml"
using WebCrawler_1.Models;

#line default
#line hidden
#line 1 "C:\Users\YL\source\repos\WebCrawler_1\WebCrawler_1\Views\Home\SaveInfo.cshtml"
using WebCrawler_1.Data;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fe8e0e4dcd8efe5f5e2bb0b2a018535dcab727c5", @"/Views/Home/SaveInfo.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cde8c59a1a664fa08442152e4049e3cd33ae4fa0", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_SaveInfo : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<GetUrl>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(58, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 4 "C:\Users\YL\source\repos\WebCrawler_1\WebCrawler_1\Views\Home\SaveInfo.cshtml"
  
    ViewData["Title"] = "SaveInfo";

#line default
#line hidden
            BeginContext(132, 358, true);
            WriteLiteral(@"
<h1>Save Info</h1>

<table class=""table-bordered"">
    <tr>
        <th class=""col-form-label-sm"">
            Id Number
        </th>
        <th>
            Searched Item
        </th>
        <th>
            Item Name
        </th>
        <th>
            Price
        </th>
        <th>
            Date
        </th>
    </tr>
");
            EndContext();
#line 28 "C:\Users\YL\source\repos\WebCrawler_1\WebCrawler_1\Views\Home\SaveInfo.cshtml"
       foreach (var item in Model)
        {


#line default
#line hidden
            BeginContext(539, 48, true);
            WriteLiteral("        <tr>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(588, 7, false);
#line 33 "C:\Users\YL\source\repos\WebCrawler_1\WebCrawler_1\Views\Home\SaveInfo.cshtml"
           Write(item.ID);

#line default
#line hidden
            EndContext();
            BeginContext(595, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(651, 14, false);
#line 36 "C:\Users\YL\source\repos\WebCrawler_1\WebCrawler_1\Views\Home\SaveInfo.cshtml"
           Write(item.NewSearch);

#line default
#line hidden
            EndContext();
            BeginContext(665, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(721, 13, false);
#line 39 "C:\Users\YL\source\repos\WebCrawler_1\WebCrawler_1\Views\Home\SaveInfo.cshtml"
           Write(item.ItemName);

#line default
#line hidden
            EndContext();
            BeginContext(734, 57, true);
            WriteLiteral("\r\n            </td>\r\n\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(792, 14, false);
#line 43 "C:\Users\YL\source\repos\WebCrawler_1\WebCrawler_1\Views\Home\SaveInfo.cshtml"
           Write(item.ItemPrice);

#line default
#line hidden
            EndContext();
            BeginContext(806, 57, true);
            WriteLiteral("\r\n            </td>\r\n\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(864, 9, false);
#line 47 "C:\Users\YL\source\repos\WebCrawler_1\WebCrawler_1\Views\Home\SaveInfo.cshtml"
           Write(item.Date);

#line default
#line hidden
            EndContext();
            BeginContext(873, 77, true);
            WriteLiteral("\r\n            </td>\r\n\r\n            <td>\r\n            </td>\r\n\r\n        </tr>\r\n");
            EndContext();
#line 54 "C:\Users\YL\source\repos\WebCrawler_1\WebCrawler_1\Views\Home\SaveInfo.cshtml"
        }
    

#line default
#line hidden
            BeginContext(968, 12, true);
            WriteLiteral("</table>\r\n\r\n");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<GetUrl>> Html { get; private set; }
    }
}
#pragma warning restore 1591
