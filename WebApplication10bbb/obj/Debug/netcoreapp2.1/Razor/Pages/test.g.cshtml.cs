#pragma checksum "C:\Users\Назар\source\repos\WebApplication10bbb\WebApplication10bbb\Pages\test.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "57a2d6d231f818d0f9f1cc971413bad6fd02f20a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Pages_test), @"mvc.1.0.razor-page", @"/Pages/test.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure.RazorPageAttribute(@"/Pages/test.cshtml", typeof(AspNetCore.Pages_test), null)]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"57a2d6d231f818d0f9f1cc971413bad6fd02f20a", @"/Pages/test.cshtml")]
    public class Pages_test : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
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
            BeginContext(63, 29, true);
            WriteLiteral("\r\n<!DOCTYPE html>\r\n\r\n<html>\r\n");
            EndContext();
            BeginContext(92, 3791, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "75aa3a07ff684881a2c974b08c40ddb2", async() => {
                BeginContext(98, 3778, true);
                WriteLiteral(@"
    <meta name=""viewport"" content=""width=device-width"" />
    <title>test</title>

    <style>


        #myContainer {
            width: 224px;
            height: 248px;
            background-image: url('images/background.png');
            /*position: relative;*/
            position: absolute;
            left: 50%;
            top: 50%;
            margin: 0 auto;
        }

        #pacman {
            width: 8px;
            /*top: 8px;
            left: 8px;*/
            height: 8px;
            position: absolute;
            background-color: yellow;
        }

        #blinky {
            top: 112px;
            left: 92px;
            width: 8px;
            height: 8px;
            position: absolute;
            background-color: red;
        }

        #inky {
            top: 112px;
            left: 92px;
            width: 8px;
            height: 8px;
            position: absolute;
            background-color: deepskyblue;
        }

    ");
                WriteLiteral(@"    #pinky {
            width: 8px;
            top: 112px;
            left: 108px;
            height: 8px;
            position: absolute;
            background-color: pink;
        }

        #clyde {
            width: 8px;
            top: 112px;
            left: 124px;
            height: 8px;
            position: absolute;
            background-color: darkorange;
        }

        .coin {
            width: 2px;
            height: 2px;
            position: absolute;
            background-color: lawngreen;
        }

        .ground {
            width: 2px;
            height: 2px;
            position: absolute;
            background-color: transparent;
        }

        .energizer {
            width: 4px;
            height: 4px;
            position: absolute;
            background-color: mediumblue;
        }
    </style>
  
    <style>
        /* Important styles */
        .nav {
            text-align: center;
        }

            .na");
                WriteLiteral(@"v ul, .nav li, .nav a {
                display: inline-block;
                *display: inline;
                zoom: 1;
            }

        /* Fancy aesthetic styling */
        .nav {
            font: 14px sans-serif;
            margin: 20px 0;
        }

            .nav ul {
                background: #333;
                border-radius: 5px;
                box-shadow: 0 0 5px rgba(0,0,0,0.5);
                margin: 0;
                overflow: hidden;
                padding: 0;
            }

            .nav a {
                background-color: #555555;
                background-image: -webkit-gradient(linear, left top, left bottom, from(#555555), to(#333333));
                background-image: -webkit-linear-gradient(top, #555555, #333333);
                background-image: -moz-linear-gradient(top, #555555, #333333);
                background-image: -o-linear-gradient(top, #555555, #333333);
                background-image: linear-gradient(to bottom, #555555, #");
                WriteLiteral(@"333333);
                color: #f1f1f1;
                padding: 10px 15px;
                text-decoration: none;
            }

                .nav a:hover {
                    background-color: #444444;
                    background-image: -webkit-gradient(linear, left top, left bottom, from(#444444), to(#333333));
                    background-image: -webkit-linear-gradient(top, #444444, #333333);
                    background-image: -moz-linear-gradient(top, #444444, #333333);
                    background-image: -o-linear-gradient(top, #444444, #333333);
                    background-image: linear-gradient(to bottom, #444444, #333333);
                }
    </style>

");
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
            BeginContext(3883, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(3885, 4916, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5433e58559294f6b90e71dd4887c10f5", async() => {
                BeginContext(3891, 4903, true);
                WriteLiteral(@"
    <div class=""nav"">
        <div>
            <div id=""pacman""></div>
        </div>
        <ul>
            
            <li>
                <a href=""#"">Home</a>
            </li>
            <li>
                <a href=""#"">Products</a>
            </li>
            <li>
                <a href=""#"">Services</a>
            </li>
            <li>
                <a href=""#"">About</a>
            </li>
            <li>
                <a href=""#"">Contact</a>
            </li>
        </ul>
    </div>

    <script>

        var map = [
            [1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1],
            [1, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 1, 1, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 1],
            [1, 2, 1, 1, 1, 1, 2, 1, 1, 1, 1, 1, 2, 1, 1, 2, 1, 1, 1, 1, 1, 2, 1, 1, 1, 1, 2, 1],
            [1, 3, 1, 1, 1, 1, 2, 1, 1, 1, 1, 1, 2, 1, 1, 2, 1, 1, 1, 1, 1, 2, 1, 1, 1, 1, 3, 1],
            [1, 2, 1, 1, 1, 1, 2, 1, 1, 1, 1, 1, 2, 1,");
                WriteLiteral(@" 1, 2, 1, 1, 1, 1, 1, 2, 1, 1, 1, 1, 2, 1],
            [1, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 1],
            [1, 2, 1, 1, 1, 1, 2, 1, 1, 2, 1, 1, 1, 1, 1, 1, 1, 1, 2, 1, 1, 2, 1, 1, 1, 1, 2, 1],
            [1, 2, 1, 1, 1, 1, 2, 1, 1, 2, 1, 1, 1, 1, 1, 1, 1, 1, 2, 1, 1, 2, 1, 1, 1, 1, 2, 1],
            [1, 2, 2, 2, 2, 2, 2, 1, 1, 2, 2, 2, 2, 1, 1, 2, 2, 2, 2, 1, 1, 2, 2, 2, 2, 2, 2, 1],
            [1, 1, 1, 1, 1, 1, 2, 1, 1, 1, 1, 1, 2, 1, 1, 2, 1, 1, 1, 1, 1, 2, 1, 1, 1, 1, 1, 1],
            [4, 4, 4, 4, 4, 1, 2, 1, 1, 1, 1, 1, 2, 1, 1, 2, 1, 1, 1, 1, 1, 2, 1, 4, 4, 4, 4, 4],
            [4, 4, 4, 4, 4, 1, 2, 1, 1, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 1, 1, 2, 1, 4, 4, 4, 4, 4],
            [4, 4, 4, 4, 4, 1, 2, 1, 1, 2, 1, 1, 1, 1, 1, 1, 1, 1, 2, 1, 1, 2, 1, 4, 4, 4, 4, 4],
            [1, 1, 1, 1, 1, 1, 2, 1, 1, 2, 1, 4, 4, 4, 4, 4, 4, 1, 2, 1, 1, 2, 1, 1, 1, 1, 1, 1],
            [4, 4, 4, 4, 4, 1, 2, 2, 2, 2, 1, 4, 4, 4, 4, 4, 4, 1, 2, 2, 2, 2, 1, 4, 4, ");
                WriteLiteral(@"4, 4, 4],
            [1, 1, 1, 1, 1, 1, 2, 1, 1, 2, 1, 4, 4, 4, 4, 4, 4, 1, 2, 1, 1, 2, 1, 1, 1, 1, 1, 1],
            [4, 4, 4, 4, 4, 1, 2, 1, 1, 2, 1, 1, 1, 1, 1, 1, 1, 1, 2, 1, 1, 2, 1, 4, 4, 4, 4, 4],
            [4, 4, 4, 4, 4, 1, 2, 1, 1, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 1, 1, 2, 1, 4, 4, 4, 4, 4],
            [4, 4, 4, 4, 4, 1, 2, 1, 1, 2, 1, 1, 1, 1, 1, 1, 1, 1, 2, 1, 1, 2, 1, 4, 4, 4, 4, 4],
            [1, 1, 1, 1, 1, 1, 2, 1, 1, 2, 1, 1, 1, 1, 1, 1, 1, 1, 2, 1, 1, 2, 1, 1, 1, 1, 1, 1],
            [1, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 1, 1, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 1],
            [1, 2, 1, 1, 1, 1, 2, 1, 1, 1, 1, 1, 2, 1, 1, 2, 1, 1, 1, 1, 1, 2, 1, 1, 1, 1, 2, 1],
            [1, 2, 1, 1, 1, 1, 2, 1, 1, 1, 1, 1, 2, 1, 1, 2, 1, 1, 1, 1, 1, 2, 1, 1, 1, 1, 2, 1],
            [1, 3, 2, 2, 1, 1, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 1, 1, 2, 2, 3, 1],
            [1, 1, 1, 2, 1, 1, 2, 1, 1, 2, 1, 1, 1, 1, 1, 1, 1, 1, 2, 1, 1, 2, 1, 1, 2, 1, 1, 1],
            [1, 1, 1, 2");
                WriteLiteral(@", 1, 1, 2, 1, 1, 2, 1, 1, 1, 1, 1, 1, 1, 1, 2, 1, 1, 2, 1, 1, 2, 1, 1, 1],
            [1, 2, 2, 2, 2, 2, 2, 1, 1, 2, 2, 2, 2, 1, 1, 2, 2, 2, 2, 1, 1, 2, 2, 2, 2, 2, 2, 1],
            [1, 2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 1, 1, 2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 1],
            [1, 2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 1, 1, 2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 1],
            [1, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 1],
            [1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1],

        ];

        document.getElementById('content_container').style.backgroundSize = ""224px 248px"";

        var el = document.getElementById('content_container');

         function drawWorld() {
        el.innerHTML = '';
        for (var y = 0; y < map.length; y = y + 1) {
            for (var x = 0; x < map[y].length; x = x + 1) {
                if (map[y][x] === 2) {
                    var yy = y * 8 + 3;
                    ");
                WriteLiteral(@"var xx = x * 8 + 3;
                    el.innerHTML += '<div id=""' + y + ""o"" + x + '"" class=""coin"" style=""top:'+ yy + 'px; left:' + xx + 'px""></div>';
                }else if (map[y][x] === 3) {
                    var yy = y * 8 + 2;
                    var xx = x * 8 + 2;
                    el.innerHTML += '<div id=""' + y + ""o"" + x + '"" class=""energizer"" style=""top:' + yy + 'px; left:' + xx + 'px""></div>';
                }
            }
            el.innerHTML += ""<br>"";
        }

        el.innerHTML += '<div id=""pacman""></div>';
        el.innerHTML += '<div id=""blinky""></div>';
        el.innerHTML += '<div id=""pinky""></div>';
        el.innerHTML += '<div id=""clyde""></div>';
        el.innerHTML += '<div id=""inky""></div>';
    }

    drawWorld();

    </script>

");
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
            BeginContext(8801, 15, true);
            WriteLiteral("\r\n\r\n\r\n</html>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<WebApplication10bbb.Pages.testModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<WebApplication10bbb.Pages.testModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<WebApplication10bbb.Pages.testModel>)PageContext?.ViewData;
        public WebApplication10bbb.Pages.testModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591