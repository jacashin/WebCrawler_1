#pragma checksum "C:\Users\YL\source\repos\WebCrawler_1\WebCrawler_1\Views\Home\Chart.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5b95b769bfd760d859385f7e0b637deeab283ef8"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Chart), @"mvc.1.0.view", @"/Views/Home/Chart.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/Chart.cshtml", typeof(AspNetCore.Views_Home_Chart))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5b95b769bfd760d859385f7e0b637deeab283ef8", @"/Views/Home/Chart.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cde8c59a1a664fa08442152e4049e3cd33ae4fa0", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Chart : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<GetUrl>>
    {
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(28, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\YL\source\repos\WebCrawler_1\WebCrawler_1\Views\Home\Chart.cshtml"
  
    var XLabels = Newtonsoft.Json.JsonConvert.SerializeObject(Model.Select(x => x.Date.Date).ToList());
    var YValues = Newtonsoft.Json.JsonConvert.SerializeObject(Model.Select(x => x.ItemPrice).ToList());
    ViewData["Title"] = "Line Chart";

#line default
#line hidden
            BeginContext(286, 29, true);
            WriteLiteral("\r\n<!DOCTYPE html>\r\n\r\n<html>\r\n");
            EndContext();
            BeginContext(315, 99, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5b95b769bfd760d859385f7e0b637deeab283ef83829", async() => {
                BeginContext(321, 86, true);
                WriteLiteral("\r\n    <meta name=\"viewport\" content=\"width=device-width\" />\r\n    <title>Line</title>\r\n");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(414, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(416, 187, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5b95b769bfd760d859385f7e0b637deeab283ef85103", async() => {
                BeginContext(422, 174, true);
                WriteLiteral("\r\n    <div class=\"box-body\">\r\n\r\n        <div class=\"chart-container\">\r\n            <canvas id=\"chart\" style=\"width:100%; height:500px\"></canvas>\r\n        </div>\r\n    </div>\r\n");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(603, 389, true);
            WriteLiteral(@"
</html>
<script src=""https://cdnjs.cloudflare.com/ajax/libs/Chart.js/2.7.2/Chart.bundle.min.js""></script>
<script src=""https://code.jquery.com/jquery-3.3.1.min.js""></script>

<script type=""text/javascript"">

        $(function () {
    var chartName = ""chart"";
        var ctx = document.getElementById(chartName).getContext('2d');
        var data = {
                labels: ");
            EndContext();
            BeginContext(993, 17, false);
#line 34 "C:\Users\YL\source\repos\WebCrawler_1\WebCrawler_1\Views\Home\Chart.cshtml"
                   Write(Html.Raw(XLabels));

#line default
#line hidden
            EndContext();
            BeginContext(1010, 1415, true);
            WriteLiteral(@",
                datasets: [{
                    label: ""Xbox Chart"",
                    backgroundColor: [
                        'rgba(255, 99, 132, 0.2)',
                        'rgba(54, 162, 235, 0.2)',
                        'rgba(255, 206, 86, 0.2)',
                        'rgba(75, 192, 192, 0.2)',
                        'rgba(153, 102, 255, 0.2)',
                        'rgba(255, 159, 64, 0.2)',
                        'rgba(255, 0, 0)',
                        'rgba(0, 255, 0)',
                        'rgba(0, 0, 255)',
                        'rgba(192, 192, 192)',
                        'rgba(255, 255, 0)',
                        'rgba(255, 0, 255)'
                    ],
                    borderColor: [
                        'rgba(255,99,132,1)',
                        'rgba(54, 162, 235, 1)',
                        'rgba(255, 206, 86, 1)',
                        'rgba(75, 192, 192, 1)',
                        'rgba(153, 102, 255, 1)',
                 ");
            WriteLiteral(@"       'rgba(255, 159, 64, 1)',
                        'rgba(255, 0, 0)',
                        'rgba(0, 255, 0)',
                        'rgba(0, 0, 255)',
                        'rgba(192, 192, 192)',
                        'rgba(255, 255, 0)',
                        'rgba(255, 0, 255)'
                    ],
                    borderWidth: 1,
                    data: ");
            EndContext();
            BeginContext(2426, 17, false);
#line 66 "C:\Users\YL\source\repos\WebCrawler_1\WebCrawler_1\Views\Home\Chart.cshtml"
                     Write(Html.Raw(YValues));

#line default
#line hidden
            EndContext();
            BeginContext(2443, 990, true);
            WriteLiteral(@"
    }]
            };

var options = {
                maintainAspectRatio: false,
                scales: {
                    yAxes: [{
                        ticks: {
                            min: 0,
                            beginAtZero: true
                        },
                        gridLines: {
                            display: true,
                            color: ""rgba(255,99,164,0.2)""
                        }
}],
                    xAxes: [{
                        ticks: {
                            min: 0,
                            beginAtZero: true
                        },
                        gridLines: {
                            display: false
                        }
                    }]
                }
            };

       var myChart = new  Chart(ctx, {
                options: options,
                data: data,
                type:'line'

            });
        });
</script>  ");
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