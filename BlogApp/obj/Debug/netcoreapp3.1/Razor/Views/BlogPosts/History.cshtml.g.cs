#pragma checksum "C:\Users\Acer\OneDrive\Desktop\BlogApp\BlogApp\Views\BlogPosts\History.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "424a62e224349fe228b95d58452ab1d959e3bad2345800e9bac256585953f48f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_BlogPosts_History), @"mvc.1.0.view", @"/Views/BlogPosts/History.cshtml")]
namespace AspNetCore
{
    #line hidden
    using global::System;
    using global::System.Collections.Generic;
    using global::System.Linq;
    using global::System.Threading.Tasks;
    using global::Microsoft.AspNetCore.Mvc;
    using global::Microsoft.AspNetCore.Mvc.Rendering;
    using global::Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\Acer\OneDrive\Desktop\BlogApp\BlogApp\Views\_ViewImports.cshtml"
using BlogApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Acer\OneDrive\Desktop\BlogApp\BlogApp\Views\_ViewImports.cshtml"
using BlogApp.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"Sha256", @"424a62e224349fe228b95d58452ab1d959e3bad2345800e9bac256585953f48f", @"/Views/BlogPosts/History.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"Sha256", @"2a2107e3875ee376763b7a1d7ec3392a23aa5d4c6baccc027f02693d1979a127", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_BlogPosts_History : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<BlogApp.ViewModels.BlogHistoryViewModel>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\Acer\OneDrive\Desktop\BlogApp\BlogApp\Views\BlogPosts\History.cshtml"
  
    ViewBag.Title = "Blog Posts History";
    Layout = "~/Views/Shared/_Admin.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("<h2>");
#nullable restore
#line 6 "C:\Users\Acer\OneDrive\Desktop\BlogApp\BlogApp\Views\BlogPosts\History.cshtml"
Write(Model.BlogPost.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n\r\n<div class=\"row\">\r\n    <div class=\"col-md-8\">\r\n        <div class=\"card mb-3\">\r\n            <div class=\"card-body\">\r\n                <p>");
#nullable restore
#line 12 "C:\Users\Acer\OneDrive\Desktop\BlogApp\BlogApp\Views\BlogPosts\History.cshtml"
              Write(Html.Raw(Model.BlogPost.Body));

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                <p><small class=\"text-muted\">Author: ");
#nullable restore
#line 13 "C:\Users\Acer\OneDrive\Desktop\BlogApp\BlogApp\Views\BlogPosts\History.cshtml"
                                                Write(Model.BlogPost.Author.UserName);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</small></p>
            </div>
        </div>
    </div>
    <div class=""col-md-4"">
        <!-- Placeholder for images or other additional content -->
    </div>
</div>
<hr />
<h3>Edited Histories</h3>
<table class=""table table-condensed table-bordered"" id=""blogList"">
    <thead>
        <tr>
            <th>
                Original Title
            </th>
            <th>
               Original Body
            </th>
            <th>
               Original Timestamp
            </th>
            <th>
                Edited Title
            </th>
            <th>
                Edited Body
            </th>
            <th>
                Edited Timestamp
            </th>
        </tr>
    </thead>

    <tbody>
");
#nullable restore
#line 48 "C:\Users\Acer\OneDrive\Desktop\BlogApp\BlogApp\Views\BlogPosts\History.cshtml"
         foreach (var item in Model.BlogPostEditHistory)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td>\r\n                    ");
#nullable restore
#line 52 "C:\Users\Acer\OneDrive\Desktop\BlogApp\BlogApp\Views\BlogPosts\History.cshtml"
               Write(item.OriginalTitle);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 55 "C:\Users\Acer\OneDrive\Desktop\BlogApp\BlogApp\Views\BlogPosts\History.cshtml"
               Write(item.OriginalBody);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                   ");
#nullable restore
#line 58 "C:\Users\Acer\OneDrive\Desktop\BlogApp\BlogApp\Views\BlogPosts\History.cshtml"
              Write(item.OriginalTimestamp);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 61 "C:\Users\Acer\OneDrive\Desktop\BlogApp\BlogApp\Views\BlogPosts\History.cshtml"
               Write(item.EditedTitle);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 64 "C:\Users\Acer\OneDrive\Desktop\BlogApp\BlogApp\Views\BlogPosts\History.cshtml"
               Write(item.EditedBody);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 67 "C:\Users\Acer\OneDrive\Desktop\BlogApp\BlogApp\Views\BlogPosts\History.cshtml"
               Write(item.EditedTimestamp);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td> \r\n            </tr>\r\n");
#nullable restore
#line 70 "C:\Users\Acer\OneDrive\Desktop\BlogApp\BlogApp\Views\BlogPosts\History.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n\r\n<script>\r\n    $(\"#blogList\").DataTable({});\r\n</script>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<BlogApp.ViewModels.BlogHistoryViewModel> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591