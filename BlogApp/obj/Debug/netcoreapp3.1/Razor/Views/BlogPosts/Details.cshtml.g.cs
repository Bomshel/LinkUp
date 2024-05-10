#pragma checksum "C:\Users\Acer\OneDrive\Desktop\BlogApp\BlogApp\Views\BlogPosts\Details.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "4c5540020dc38fc6189aaf993c33c9845efa72f18532da33bfa6e8d986c0d11f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_BlogPosts_Details), @"mvc.1.0.view", @"/Views/BlogPosts/Details.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"Sha256", @"4c5540020dc38fc6189aaf993c33c9845efa72f18532da33bfa6e8d986c0d11f", @"/Views/BlogPosts/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"Sha256", @"2a2107e3875ee376763b7a1d7ec3392a23aa5d4c6baccc027f02693d1979a127", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_BlogPosts_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<BlogApp.ViewModels.BlogDetailsCommentHistoryViewModel>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\Acer\OneDrive\Desktop\BlogApp\BlogApp\Views\BlogPosts\Details.cshtml"
  
    ViewBag.Title = "Blog Post Details";
    Layout = "~/Views/Shared/_Admin.cshtml"; 

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h2></h2>\r\n\r\n<div class=\"row\">\r\n    <div class=\"col-md-12 box box-primary\">\r\n        <div class=\"box-header with-border\">\r\n            <h3 class=\"box-title\">");
#nullable restore
#line 13 "C:\Users\Acer\OneDrive\Desktop\BlogApp\BlogApp\Views\BlogPosts\Details.cshtml"
                             Write(Model.BlogPost.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n        </div>\r\n        <div");
            BeginWriteAttribute("class", " class=\"", 375, "\"", 383, 0);
            EndWriteAttribute();
            WriteLiteral(">\r\n            <div class=\"card-body \">\r\n                <img");
            BeginWriteAttribute("src", " src=\"", 445, "\"", 477, 1);
#nullable restore
#line 17 "C:\Users\Acer\OneDrive\Desktop\BlogApp\BlogApp\Views\BlogPosts\Details.cshtml"
WriteAttributeValue("", 451, Model.BlogPost.ImagePaths, 451, 26, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"img-fluid\" height=\"200\" width=\"200\" alt=\"Blog Image\">\r\n                <p>");
#nullable restore
#line 18 "C:\Users\Acer\OneDrive\Desktop\BlogApp\BlogApp\Views\BlogPosts\Details.cshtml"
              Write(Html.Raw(Model.BlogPost.Body));

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                <p><small class=\"text-muted\">Author: ");
#nullable restore
#line 19 "C:\Users\Acer\OneDrive\Desktop\BlogApp\BlogApp\Views\BlogPosts\Details.cshtml"
                                                Write(Model.BlogPost.Author.UserName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</small></p>\r\n                <p><small class=\"text-muted\">Created: ");
#nullable restore
#line 20 "C:\Users\Acer\OneDrive\Desktop\BlogApp\BlogApp\Views\BlogPosts\Details.cshtml"
                                                 Write(Model.BlogPost.CreatedAt.ToString("yyyy-MM-dd HH:mm"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</small></p>\r\n");
#nullable restore
#line 21 "C:\Users\Acer\OneDrive\Desktop\BlogApp\BlogApp\Views\BlogPosts\Details.cshtml"
                 if (Model.BlogPost.UpdatedAt.HasValue)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <p><small class=\"text-muted\">Updated: ");
#nullable restore
#line 23 "C:\Users\Acer\OneDrive\Desktop\BlogApp\BlogApp\Views\BlogPosts\Details.cshtml"
                                                     Write(Model.BlogPost.UpdatedAt.Value.ToString("yyyy-MM-dd HH:mm"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</small></p>\r\n");
#nullable restore
#line 24 "C:\Users\Acer\OneDrive\Desktop\BlogApp\BlogApp\Views\BlogPosts\Details.cshtml"
                } 

#line default
#line hidden
#nullable disable
            WriteLiteral("            </div>\r\n        </div>\r\n    </div>\r\n    <div class=\"col-md-4\">\r\n        <!-- Placeholder for images or other additional content -->\r\n    </div>\r\n</div>\r\n\r\n<h3>Comments</h3>\r\n");
#nullable restore
#line 34 "C:\Users\Acer\OneDrive\Desktop\BlogApp\BlogApp\Views\BlogPosts\Details.cshtml"
 if (Model.BlogPost.Comments.Any())
{
    foreach (var comment in Model.BlogPost.Comments)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"box box-primary\">\r\n            <div class=\"card-body\">\r\n                <p>");
#nullable restore
#line 40 "C:\Users\Acer\OneDrive\Desktop\BlogApp\BlogApp\Views\BlogPosts\Details.cshtml"
              Write(comment.Content);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                <p><small class=\"text-muted\">Author: ");
#nullable restore
#line 41 "C:\Users\Acer\OneDrive\Desktop\BlogApp\BlogApp\Views\BlogPosts\Details.cshtml"
                                                Write(comment.Author.UserName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</small></p>\r\n                <p><small class=\"text-muted\">Posted: ");
#nullable restore
#line 42 "C:\Users\Acer\OneDrive\Desktop\BlogApp\BlogApp\Views\BlogPosts\Details.cshtml"
                                                Write(comment.CreatedAt.ToString("yyyy-MM-dd HH:mm"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</small></p>
                <h5><u>Comment History</u></h5>
                <table class=""table"" width=""100%"">
                    <tr>
                        <th>
                            Original Comment
                        </th>
                        <th>
                            Edited Comment
                        </th>
                    </tr>
");
#nullable restore
#line 53 "C:\Users\Acer\OneDrive\Desktop\BlogApp\BlogApp\Views\BlogPosts\Details.cshtml"
                     foreach(var comm in Model.CommentEditHistory.Where(x=>x.CommentId==comment.CommentId)){

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <tr>\r\n                            <td>\r\n                                ");
#nullable restore
#line 56 "C:\Users\Acer\OneDrive\Desktop\BlogApp\BlogApp\Views\BlogPosts\Details.cshtml"
                           Write(comm.OriginalContent);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </td>\r\n                            <td>\r\n                                ");
#nullable restore
#line 59 "C:\Users\Acer\OneDrive\Desktop\BlogApp\BlogApp\Views\BlogPosts\Details.cshtml"
                           Write(comm.EditedContent);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </td>\r\n                        </tr>\r\n");
#nullable restore
#line 62 "C:\Users\Acer\OneDrive\Desktop\BlogApp\BlogApp\Views\BlogPosts\Details.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </table>\r\n            </div>\r\n        </div>\r\n");
#nullable restore
#line 66 "C:\Users\Acer\OneDrive\Desktop\BlogApp\BlogApp\Views\BlogPosts\Details.cshtml"
    }
}
else
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <p>No comments yet.</p>\r\n");
#nullable restore
#line 71 "C:\Users\Acer\OneDrive\Desktop\BlogApp\BlogApp\Views\BlogPosts\Details.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<BlogApp.ViewModels.BlogDetailsCommentHistoryViewModel> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591