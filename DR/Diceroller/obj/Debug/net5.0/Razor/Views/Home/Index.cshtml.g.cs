#pragma checksum "D:\Ebash\DR\Diceroller\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "267864b351319d02bae9dc71ac930a092c433384"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
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
#line 1 "D:\Ebash\DR\Diceroller\Views\_ViewImports.cshtml"
using Diceroller;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Ebash\DR\Diceroller\Views\_ViewImports.cshtml"
using Diceroller.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"267864b351319d02bae9dc71ac930a092c433384", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5f78bd8b9af355da8855c7b069c47da04c07145a", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<DiceValues>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "POST", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString("/Home/Roll"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "D:\Ebash\DR\Diceroller\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Home Page";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"text-center\">\r\n    <h1 class=\"display-4\">Анохин Максим</h1>\r\n    <p>Кидалка кубиков, собранная на <a href=\"https://docs.microsoft.com/aspnet/core\">ASP.NET Core</a>.</p>\r\n    <label>");
#nullable restore
#line 9 "D:\Ebash\DR\Diceroller\Views\Home\Index.cshtml"
      Write(ViewData["roller"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</label>\r\n    <Table style=\"font-size: 3vw; margin: auto; width: 100%;\"> \r\n        <tr>\r\n");
#nullable restore
#line 12 "D:\Ebash\DR\Diceroller\Views\Home\Index.cshtml"
              
                double Counter = 0;
                double J = 0;
                double Ji = 0;
                    foreach (int siir in Model.Result)
                {

                    Counter++;
                    J = (Counter + Ji) % 2 ;
                        if (J != 1)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <td style=\"border: 2px solid gray; color: red; width: 9%\">");
#nullable restore
#line 23 "D:\Ebash\DR\Diceroller\Views\Home\Index.cshtml"
                                                                             Write(siir);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
#nullable restore
#line 24 "D:\Ebash\DR\Diceroller\Views\Home\Index.cshtml"
                    }
                    else
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <td style=\"border: 2px solid gray;  width: 9%\">");
#nullable restore
#line 27 "D:\Ebash\DR\Diceroller\Views\Home\Index.cshtml"
                                                                  Write(siir);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
#nullable restore
#line 28 "D:\Ebash\DR\Diceroller\Views\Home\Index.cshtml"
                    }
                    if (Counter > 9)
                    {
                        Counter -= 10;
                        Ji++;

#line default
#line hidden
#nullable disable
            WriteLiteral("                    ");
            WriteLiteral("</tr><tr>\r\n");
#nullable restore
#line 34 "D:\Ebash\DR\Diceroller\Views\Home\Index.cshtml"
                    }
                }
            

#line default
#line hidden
#nullable disable
            WriteLiteral("        </tr>\r\n    </Table>\r\n    <p>");
#nullable restore
#line 39 "D:\Ebash\DR\Diceroller\Views\Home\Index.cshtml"
  Write(Model.Shas);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n    <p>");
#nullable restore
#line 40 "D:\Ebash\DR\Diceroller\Views\Home\Index.cshtml"
  Write(Model.Avg);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "267864b351319d02bae9dc71ac930a092c4333846836", async() => {
                WriteLiteral("\r\n        <div style=\"margin: 0 0 10px 0;\">\r\n            <p>Количество кубиков</p>\r\n            <input type=\"number\" max=\"999\" min=\"1\" maxlength=\"3\"");
                BeginWriteAttribute("value", " value=\"", 1460, "\"", 1476, 1);
#nullable restore
#line 44 "D:\Ebash\DR\Diceroller\Views\Home\Index.cshtml"
WriteAttributeValue("", 1468, Model.Q, 1468, 8, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" name=\"Q\">\r\n        </div>\r\n        <div style=\"margin: 0 0 10px 0;\">\r\n            <p>Количество граней</p>\r\n            <input type=\"number\" max=\"999\" min=\"2\" maxlength=\"3\"");
                BeginWriteAttribute("value", " value=\"", 1650, "\"", 1666, 1);
#nullable restore
#line 48 "D:\Ebash\DR\Diceroller\Views\Home\Index.cshtml"
WriteAttributeValue("", 1658, Model.E, 1658, 8, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" name=\"E\">\r\n        </div>\r\n        <div style=\"margin: 0 0 10px 0;\">\r\n            <p>Имя игрока</p>\r\n            <input type=\"text\"");
                BeginWriteAttribute("value", " value=\"", 1799, "\"", 1820, 1);
#nullable restore
#line 52 "D:\Ebash\DR\Diceroller\Views\Home\Index.cshtml"
WriteAttributeValue("", 1807, Model.Player, 1807, 13, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" maxlength=\"16\" name=\"Igrok\">\r\n        </div>\r\n        <div style=\"margin: 0 0 10px 0;\">\r\n            <input type=\"submit\" value=\"Бросок\">\r\n        </div>\r\n    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<DiceValues> Html { get; private set; }
    }
}
#pragma warning restore 1591
