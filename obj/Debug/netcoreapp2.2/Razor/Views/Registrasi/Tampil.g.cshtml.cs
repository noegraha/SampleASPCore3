#pragma checksum "C:\Users\ASUS\source\repos\SampleASPCore2\Views\Registrasi\Tampil.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7686cd5f0c180edb0b33ce8da90ca7efff66d9eb"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Registrasi_Tampil), @"mvc.1.0.view", @"/Views/Registrasi/Tampil.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Registrasi/Tampil.cshtml", typeof(AspNetCore.Views_Registrasi_Tampil))]
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
#line 1 "C:\Users\ASUS\source\repos\SampleASPCore2\Views\_ViewImports.cshtml"
using SampleASPCore2;

#line default
#line hidden
#line 2 "C:\Users\ASUS\source\repos\SampleASPCore2\Views\_ViewImports.cshtml"
using SampleASPCore2.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7686cd5f0c180edb0b33ce8da90ca7efff66d9eb", @"/Views/Registrasi/Tampil.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"01e117a07a5689cfa2656902252d805cd52183bd", @"/Views/_ViewImports.cshtml")]
    public class Views_Registrasi_Tampil : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 2 "C:\Users\ASUS\source\repos\SampleASPCore2\Views\Registrasi\Tampil.cshtml"
  
    ViewData["Title"] = "Tampil";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
            BeginContext(91, 37, true);
            WriteLiteral("\r\n<h1>Tampil</h1>\r\n\r\n<p>\r\n    Nama : ");
            EndContext();
            BeginContext(129, 15, false);
#line 10 "C:\Users\ASUS\source\repos\SampleASPCore2\Views\Registrasi\Tampil.cshtml"
      Write(Model.Firstname);

#line default
#line hidden
            EndContext();
            BeginContext(144, 1, true);
            WriteLiteral(" ");
            EndContext();
            BeginContext(146, 14, false);
#line 10 "C:\Users\ASUS\source\repos\SampleASPCore2\Views\Registrasi\Tampil.cshtml"
                       Write(Model.Lastname);

#line default
#line hidden
            EndContext();
            BeginContext(160, 15, true);
            WriteLiteral("\r\n    Alamat : ");
            EndContext();
            BeginContext(176, 13, false);
#line 11 "C:\Users\ASUS\source\repos\SampleASPCore2\Views\Registrasi\Tampil.cshtml"
        Write(Model.Address);

#line default
#line hidden
            EndContext();
            BeginContext(189, 13, true);
            WriteLiteral("\r\n    Telp : ");
            EndContext();
            BeginContext(203, 10, false);
#line 12 "C:\Users\ASUS\source\repos\SampleASPCore2\Views\Registrasi\Tampil.cshtml"
      Write(Model.Telp);

#line default
#line hidden
            EndContext();
            BeginContext(213, 10, true);
            WriteLiteral("\r\n</p>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
