#pragma checksum "C:\Users\Назар\source\repos\WebApplication10bbb\WebApplication10bbb\Pages\About.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7ca154ccc6768b88aa5042ffd553b860b3cd2247"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(WebApplication10bbb.Pages.Pages_About), @"mvc.1.0.razor-page", @"/Pages/About.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure.RazorPageAttribute(@"/Pages/About.cshtml", typeof(WebApplication10bbb.Pages.Pages_About), null)]
namespace WebApplication10bbb.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "C:\Users\Назар\source\repos\WebApplication10bbb\WebApplication10bbb\Pages\_ViewImports.cshtml"
using WebApplication10bbb;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7ca154ccc6768b88aa5042ffd553b860b3cd2247", @"/Pages/About.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c7574fb0b770ffe3232d9eed76f92d8294fbb019", @"/Pages/_ViewImports.cshtml")]
    public class Pages_About : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
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
#line 3 "C:\Users\Назар\source\repos\WebApplication10bbb\WebApplication10bbb\Pages\About.cshtml"
  
    ViewData["Title"] = "About";

#line default
#line hidden
            BeginContext(67, 1884, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "53756f8091b44e23a3b002c6a20a3434", async() => {
                BeginContext(73, 1871, true);
                WriteLiteral(@"
    <meta charset=""utf-8"" />
    <title>Pacman</title>
    <style>
        * {
            outline: 0px dotted purple;
        }

        div {
            margin: 0px;
            vertical-align:top;
        }

        .pacman {
            width: 20px;
            height: 20px;
            background-image: url('images/pacman3.png');
            display: inline-block;
        }

        .wall {
            width: 20px;
            height: 20px;
            background-image: url('images/wall2.png');
            display: inline-block;
        }

        .world {
            background-color: #181819;
            width:560px;
            flex: 50%;
        }

        .coin {
            width: 20px;
            height: 20px;
            background-image: url('images/coin2.png');
            display: inline-block;
        }

        .ground {
            width: 20px;
            height: 20px;
            /*background-image: url('images/bg2.png');*/
            displa");
                WriteLiteral(@"y: inline-block;
        }

        .ground2 {
            width: 20px;
            height: 20px;
            background-color: red;
            /*background-image: url('images/bg2.png');*/
            display: inline-block;
        }

        .ghost1 {
            width: 20px;
            height: 20px;
            background-image: url('images/blinky.png');
            display: inline-block;
        }

        .ghost2 {
            width: 20px;
            height: 20px;
            background-image: url('images/pinky.png');
            display: inline-block;

        }
        .ghost3 {
            width: 20px;
            height: 20px;
            background-image: url('images/clyde.png');
            display: inline-block;
        }

        .column {
            flex: 50%;
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
            BeginContext(1951, 4, true);
            WriteLiteral("\r\n\r\n");
            EndContext();
            BeginContext(1955, 12094, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8bf9a1608c8a4456a07862ac566c1afa", async() => {
                BeginContext(1961, 12081, true);
                WriteLiteral(@"

    <div>
        <div id=""world"" class=""world"">

        </div>

        <div class=""column"">
            <text>Реєстрація</text>
            <input id=""login_reg"" type=""text"" placeholder=""Логін"">
            <input id=""password_reg"" type=""password"" placeholder=""Пароль"">
            <input id=""password2_reg"" type=""password"" placeholder=""Повторіть пароль"">
            <button id=""register"">Зареєструватись</button>
            <br />
            <br />
            <br />
            <br />
            <text>Авторизація</text>
            <input id=""login_sign"" type=""text"" placeholder=""Логін"">
            <input id=""password_sign"" type=""password"" placeholder=""Пароль"">
            <button id=""login_in"">Увійти</button>
        </div>

    </div>
    <div>
        <button id=""sendBtn"" >Start game</button>
        <button id=""pause_btn"">Pause</button>
    </div>

    <div>
        <textarea id=""text_field1""></textarea>

        <textarea id=""text_field2""></textarea>
        <texta");
                WriteLiteral(@"rea id=""text_field3""></textarea>

        <textarea id=""text_field4""></textarea>
        <textarea id=""text_field5""></textarea>
        <textarea id=""QWERTYY""></textarea>
        <textarea id=""text_field6""></textarea>
    </div>

    <script src=""js/signalr.min.js""></script>

    <script>
            //1 = <div class=""wal""></div>
            //3 = <div class=""ground""></div>            
            //2 = <div class=""coin""></div>
            //5 = <div class=""pacman""></div>
            //6 = <div class=""ghost1""></div>
        pacman = {
            x: 1,
            y: 1
        }

        current_pacman = {
            x:1,
            y:1
        }

        current_ghost = {
            x: 8,
            y: 21,
            previos:""coin""
        }

        current_pinky = {
            x: 29,
            y: 26,
            previos: ""coin""
        }

        current_clyde = {
            x: 29,
            y: 1,
            previos: ""coin""
        }

        new_pacm");
                WriteLiteral(@"an = {
            x: 0,
            y: 0
        }


        let hubUrl = 'https://localhost:44379/stocks';
        const hubConnection = new signalR.HubConnectionBuilder()
            .withUrl(hubUrl)
            .configureLogging(signalR.LogLevel.Information)
            .build();

        var map = [
            [1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1],
            [1, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 1, 1, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 1],
            [1, 2, 1, 1, 1, 1, 2, 1, 1, 1, 1, 1, 2, 1, 1, 2, 1, 1, 1, 1, 1, 2, 1, 1, 1, 1, 2, 1],
            [1, 2, 1, 1, 1, 1, 2, 1, 1, 1, 1, 1, 2, 1, 1, 2, 1, 1, 1, 1, 1, 2, 1, 1, 1, 1, 2, 1],
            [1, 2, 1, 1, 1, 1, 2, 1, 1, 1, 1, 1, 2, 1, 1, 2, 1, 1, 1, 1, 1, 2, 1, 1, 1, 1, 2, 1],
            [1, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 1],
            [1, 2, 1, 1, 1, 1, 2, 1, 1, 2, 1, 1, 1, 1, 1, 1, 1, 1, 2, 1, 1, 2, 1, 1, 1, 1, 2, 1],
            ");
                WriteLiteral(@"[1, 2, 1, 1, 1, 1, 2, 1, 1, 2, 1, 1, 1, 1, 1, 1, 1, 1, 2, 1, 1, 2, 1, 1, 1, 1, 2, 1],
            [1, 2, 2, 2, 2, 2, 2, 1, 1, 2, 2, 2, 2, 1, 1, 2, 2, 2, 2, 1, 1, 2, 2, 2, 2, 2, 2, 1],
            [1, 1, 1, 1, 1, 1, 2, 1, 1, 1, 1, 1, 2, 1, 1, 2, 1, 1, 1, 1, 1, 2, 1, 1, 1, 1, 1, 1],
            [4, 4, 4, 4, 4, 1, 2, 1, 1, 1, 1, 1, 2, 1, 1, 2, 1, 1, 1, 1, 1, 2, 1, 4, 4, 4, 4, 4],
            [4, 4, 4, 4, 4, 1, 2, 1, 1, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 1, 1, 2, 1, 4, 4, 4, 4, 4],
            [4, 4, 4, 4, 4, 1, 2, 1, 1, 2, 1, 1, 1, 1, 1, 1, 1, 1, 2, 1, 1, 2, 1, 4, 4, 4, 4, 4],
            [1, 1, 1, 1, 1, 1, 2, 1, 1, 2, 1, 4, 4, 4, 4, 4, 4, 1, 2, 1, 1, 2, 1, 1, 1, 1, 1, 1],
            [4, 4, 4, 4, 4, 4, 2, 4, 4, 2, 1, 4, 4, 4, 4, 4, 4, 1, 2, 4, 4, 2, 4, 4, 4, 4, 4, 4],
            [1, 1, 1, 1, 1, 1, 2, 1, 1, 2, 1, 4, 4, 4, 4, 4, 4, 1, 2, 1, 1, 2, 1, 1, 1, 1, 1, 1],
            [4, 4, 4, 4, 4, 1, 2, 1, 1, 2, 1, 1, 1, 1, 1, 1, 1, 1, 2, 1, 1, 2, 1, 4, 4, 4, 4, 4],
            [4, 4, 4, 4, 4, 1, 2, 1, 1, 4, 4, ");
                WriteLiteral(@"4, 4, 4, 4, 4, 4, 4, 4, 1, 1, 2, 1, 4, 4, 4, 4, 4],
            [4, 4, 4, 4, 4, 1, 2, 1, 1, 2, 1, 1, 1, 1, 1, 1, 1, 1, 2, 1, 1, 2, 1, 4, 4, 4, 4, 4],
            [1, 1, 1, 1, 1, 1, 2, 1, 1, 2, 1, 1, 1, 1, 1, 1, 1, 1, 2, 1, 1, 2, 1, 1, 1, 1, 1, 1],
            [1, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 1, 1, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 1],
            [1, 2, 1, 1, 1, 1, 2, 1, 1, 1, 1, 1, 2, 1, 1, 2, 1, 1, 1, 1, 1, 2, 1, 1, 1, 1, 2, 1],
            [1, 2, 1, 1, 1, 1, 2, 1, 1, 1, 1, 1, 2, 1, 1, 2, 1, 1, 1, 1, 1, 2, 1, 1, 1, 1, 2, 1],
            [1, 2, 2, 2, 1, 1, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 1, 1, 2, 2, 2, 1],
            [1, 1, 1, 2, 1, 1, 2, 1, 1, 2, 1, 1, 1, 1, 1, 1, 1, 1, 2, 1, 1, 2, 1, 1, 2, 1, 1, 1],
            [1, 1, 1, 2, 1, 1, 2, 1, 1, 2, 1, 1, 1, 1, 1, 1, 1, 1, 2, 1, 1, 2, 1, 1, 2, 1, 1, 1],
            [1, 2, 2, 2, 2, 2, 2, 1, 1, 2, 2, 2, 2, 1, 1, 2, 2, 2, 2, 1, 1, 2, 2, 2, 2, 2, 2, 1],
            [1, 2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 1, 1, 2, 1, 1, 1, 1, 1, 1, 1");
                WriteLiteral(@", 1, 1, 1, 2, 1],
            [1, 2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 1, 1, 2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 1],
            [1, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 1],
            [1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1],

        ];

        document.getElementById(""register"").addEventListener(""click"", function (e) {

            var xhr = new XMLHttpRequest();

            xhr.open(""POST"", 'https://localhost:44379/api/Users', true)
            xhr.setRequestHeader('Content-type', 'application/json; charset=utf-8');
            xhr.setRequestHeader('UserName', document.querySelector('#login_reg').value);
            xhr.setRequestHeader('UserPassword', document.querySelector('#password_reg').value);

            xhr.send();

            xhr.onload = function () {
                document.getElementById(""register"").textContent = xhr.status;
            }

        });

        document.getElementBy");
                WriteLiteral(@"Id(""login_in"").addEventListener(""click"", function (e) {

            var xhr = new XMLHttpRequest();
            
            xhr.open(""GET"", 'https://localhost:44379/api/Users', true)
            xhr.setRequestHeader('Content-type', 'application/json; charset=utf-8');
            xhr.setRequestHeader('UserName', document.querySelector('#login_sign').value);
            xhr.setRequestHeader('UserPassword', document.querySelector('#password_sign').value);

            xhr.send();

            xhr.onload = function () {
                let send_btn = document.getElementById(""login_in"");
                send_btn.textContent = xhr.status;
            }

        });


        var el = document.getElementById('world');

        function drawWorld() {
            el.innerHTML = '';
            for (var y = 0; y < map.length; y = y + 1) {
                for (var x = 0; x < map[y].length; x = x + 1) {
                    if (map[y][x] === 1) {
                        el.innerHTML += '<div id");
                WriteLiteral(@"=""' + y + ""o"" + x + '"" class=""wall""></div>';
                    }
                    else if (map[y][x] === 2) {
                        el.innerHTML += '<div id=""' + y + ""o"" + x + '"" class=""coin""></div>';
                    }
                    else if (map[y][x] === 3) {
                        el.innerHTML += '<div id=""' + y + ""o"" + x + '"" ground=""wall""></div>';
                    }
                    else if (map[y][x] === 4) {
                        el.innerHTML += '<div id=""' + y + ""o"" + x + '"" class=""ground""></div>';
                    }
                    else if (map[y][x] === 5) {
                        el.innerHTML += '<div id=""' + y + ""o"" + x + '"" class=""pacman""></div>';
                    }
                    else if (map[y][x] === 6) {
                        el.innerHTML += '<div id=""' + y + ""o"" + x + '"" class=""ghost1""></div>';
                    }
                }
                el.innerHTML += ""<br>"";
            }
        }
                 

        dra");
                WriteLiteral(@"wWorld();
        document.onkeydown = function (event) {

            if (event.keyCode === 37) {

                hubConnection.invoke(""MovePacmen"", 4);

            }
            else if (event.keyCode === 38) {

                hubConnection.invoke(""MovePacmen"", 8);

            }
            else if (event.keyCode === 39) {

                hubConnection.invoke(""MovePacmen"", 6);

            }
            else if (event.keyCode === 40) {

                hubConnection.invoke(""MovePacmen"", 2);

            }

        };
        
      
        hubConnection.on(""ChangeBlinkyPosition"", function (blinkiX, blinkiY) {

            let blinkyposX = document.getElementById(current_ghost.x.toString() + ""o"" + current_ghost.y.toString());
            blinkyposX.className = current_ghost.previos;



            let blinkyposY = document.getElementById(blinkiX.toString() + ""o"" + blinkiY.toString());
            current_ghost.previos = blinkyposY.className.toString();
            bl");
                WriteLiteral(@"inkyposY.className = ""ghost1"";

            current_ghost.x = blinkiX;
            current_ghost.y = blinkiY;

        });
        
        hubConnection.on(""ChangeClydePosition"", function (clydeX, clydeY) {

            let clydeposX = document.getElementById(current_clyde.x.toString() + ""o"" + current_clyde.y.toString());
            clydeposX.className = ""ground"";
            
            let clydeposY = document.getElementById(clydeX.toString() + ""o"" + clydeY.toString());
            clydeposY.className = ""ghost3"";

            current_clyde.x = clydeX;
            current_clyde.y = clydeY;

        });

        hubConnection.on(""ChangePinkyPosition"", function (pinkyX, pinkyY) {

            let pinkyposX = document.getElementById(current_pinky.x.toString() + ""o"" + current_pinky.y.toString());
            pinkyposX.className = ""ground"";

            let pinkyposY = document.getElementById(pinkyX.toString() + ""o"" + pinkyY.toString());
            pinkyposY.className = ""ghost2"";

");
                WriteLiteral(@"            current_pinky.x = pinkyX;
            current_pinky.y = pinkyY;

        });

        hubConnection.on(""ChangePacmanPosition"", function (pacman_x, pacman_y, score) {

            let firstElem4 = document.getElementById(current_pacman.x.toString() + ""o"" + current_pacman.y.toString());
            firstElem4.className = ""ground"";
           

            let firstElem3 = document.getElementById(pacman_x.toString() + ""o"" + pacman_y.toString());
            firstElem3.className = ""pacman"";
                
            current_pacman.x = pacman_x;
            current_pacman.y = pacman_y;

            let qwerty1 = document.getElementById(""text_field1"");
            let qwerty2 = document.getElementById(""text_field2"");

            qwerty1.textContent = 'Score ';
            qwerty2.textContent = score;

        });
        
        hubConnection.on(""SEND"", function (possitionX) {


            let qwerty123 = document.getElementById(""text_field6"");
            qwerty123.te");
                WriteLiteral(@"xtContent = possitionX;
            //let yyx = document.getElementById(""text_field5"");
            //yyx.textContent = possitionY;  


        });

        var p = true;

        hubConnection.start();

        document.getElementById(""sendBtn"").addEventListener(""click"", function (e) {
            hubConnection.invoke(""StartGame"");
        });

        document.getElementById(""pause_btn"").addEventListener(""click"", function (e) {
            if (p) {
                p = false;
                document.getElementById(""pause_btn"").textContent = ""Unpause"";
            }
            else {
                p = true;
                document.getElementById(""pause_btn"").textContent = ""Pause"";
            }
            hubConnection.invoke(""Pause"");
        });

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
            BeginContext(14049, 2, true);
            WriteLiteral("\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<AboutModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<AboutModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<AboutModel>)PageContext?.ViewData;
        public AboutModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591