#pragma checksum "/home/youssefc/RiderProjects/TouristiqueMvc/TouristiqueMvc/Views/Sites/Site.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c889abb13575e25bd2553839c70b0c91756e3c5f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Sites_Site), @"mvc.1.0.view", @"/Views/Sites/Site.cshtml")]
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
#line 1 "/home/youssefc/RiderProjects/TouristiqueMvc/TouristiqueMvc/Views/_ViewImports.cshtml"
using TouristiqueMvc;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "/home/youssefc/RiderProjects/TouristiqueMvc/TouristiqueMvc/Views/_ViewImports.cshtml"
using TouristiqueMvc.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c889abb13575e25bd2553839c70b0c91756e3c5f", @"/Views/Sites/Site.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5ded2f3bcdee91697e22255c70e662f43e867ab1", @"/Views/_ViewImports.cshtml")]
    public class Views_Sites_Site : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<TouristiqueDbContext.models.Site>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n");
#nullable restore
#line 3 "/home/youssefc/RiderProjects/TouristiqueMvc/TouristiqueMvc/Views/Sites/Site.cshtml"
  
    ViewData["Title"] = @Model.Nom;

#line default
#line hidden
#nullable disable
            WriteLiteral("\n<p>");
#nullable restore
#line 7 "/home/youssefc/RiderProjects/TouristiqueMvc/TouristiqueMvc/Views/Sites/Site.cshtml"
Write(Model.Nom);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<TouristiqueDbContext.models.Site> Html { get; private set; }
    }
}
#pragma warning restore 1591
