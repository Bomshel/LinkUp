#pragma checksum "C:\Users\Acer\OneDrive\Desktop\BlogApp\BlogApp\Views\Home\ReadBlog.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "45c3908fdcc6c294db1fc27a018d058157d1b71e963ba02b1470e12a45d2cb13"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_ReadBlog), @"mvc.1.0.view", @"/Views/Home/ReadBlog.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"Sha256", @"45c3908fdcc6c294db1fc27a018d058157d1b71e963ba02b1470e12a45d2cb13", @"/Views/Home/ReadBlog.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"Sha256", @"2a2107e3875ee376763b7a1d7ec3392a23aa5d4c6baccc027f02693d1979a127", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Home_ReadBlog : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<BlogApp.Models.BlogPost>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("commentForm"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "AddComment", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/jquery/dist/jquery.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\Acer\OneDrive\Desktop\BlogApp\BlogApp\Views\Home\ReadBlog.cshtml"
  
    ViewBag.Title = "Read Blog";
    int upvoteWeightage = 2;
    int downvoteWeightage = -1;
    int commentWeightage = 1;

    int upvotes = Model.Reactions.Count(r => r.IsUpvote);
    int downvotes = Model.Reactions.Count(r => !r.IsUpvote);
    int commentsCount = Model.Comments.Count;

    int popularityScore = (upvoteWeightage * upvotes) + (downvoteWeightage * downvotes) + (commentWeightage * commentsCount);

#line default
#line hidden
#nullable disable
            WriteLiteral("<link rel=\"stylesheet\" href=\"https://maxcdn.bootstrapcdn.com/font-awesome/4.4.0/css/font-awesome.min.css\" />\r\n<div class=\"col-md-12\">\r\n    <div class=\"card mb-6\">\r\n        <div class=\"card-body\">\r\n            <h5 class=\"card-title\">");
#nullable restore
#line 18 "C:\Users\Acer\OneDrive\Desktop\BlogApp\BlogApp\Views\Home\ReadBlog.cshtml"
                              Write(Model.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n            <img");
            BeginWriteAttribute("src", " src=\"", 733, "\"", 756, 1);
#nullable restore
#line 19 "C:\Users\Acer\OneDrive\Desktop\BlogApp\BlogApp\Views\Home\ReadBlog.cshtml"
WriteAttributeValue("", 739, Model.ImagePaths, 739, 17, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"img-fluid\" alt=\"Blog Image\">\r\n            <p class=\"card-text\">\r\n                ");
#nullable restore
#line 21 "C:\Users\Acer\OneDrive\Desktop\BlogApp\BlogApp\Views\Home\ReadBlog.cshtml"
           Write(Html.Raw(Model.Body));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </p>\r\n            <p class=\"card-text\"><small class=\"text-muted\">Author: ");
#nullable restore
#line 23 "C:\Users\Acer\OneDrive\Desktop\BlogApp\BlogApp\Views\Home\ReadBlog.cshtml"
                                                              Write(Model.Author.UserName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</small></p>\r\n            <p class=\"card-text\"><small class=\"text-muted\">Created: ");
#nullable restore
#line 24 "C:\Users\Acer\OneDrive\Desktop\BlogApp\BlogApp\Views\Home\ReadBlog.cshtml"
                                                               Write(Model.CreatedAt.ToString("yyyy-MM-dd HH:mm"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</small></p>\r\n            <p class=\"card-text\"><small class=\"text-muted\">Popularity Score: ");
#nullable restore
#line 25 "C:\Users\Acer\OneDrive\Desktop\BlogApp\BlogApp\Views\Home\ReadBlog.cshtml"
                                                                        Write(popularityScore);

#line default
#line hidden
#nullable disable
            WriteLiteral("</small></p>\r\n\r\n            <!-- Reaction Buttons -->\r\n            <!-- Reaction Buttons -->\r\n            <div class=\"reaction-buttons\">\r\n                <button class=\"btn btn-outline-primary upvote-btn\" data-post-id=\"");
#nullable restore
#line 30 "C:\Users\Acer\OneDrive\Desktop\BlogApp\BlogApp\Views\Home\ReadBlog.cshtml"
                                                                            Write(Model.BlogPostId);

#line default
#line hidden
#nullable disable
            WriteLiteral("\"><i class=\"fa fa-heart\"></i>  (<span id=\"upVote\">");
#nullable restore
#line 30 "C:\Users\Acer\OneDrive\Desktop\BlogApp\BlogApp\Views\Home\ReadBlog.cshtml"
                                                                                                                                               Write(Model.Reactions.Where(x => x.IsUpvote).Count());

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>)</button>\r\n                <button class=\"btn btn-outline-danger downvote-btn\" data-post-id=\"");
#nullable restore
#line 31 "C:\Users\Acer\OneDrive\Desktop\BlogApp\BlogApp\Views\Home\ReadBlog.cshtml"
                                                                             Write(Model.BlogPostId);

#line default
#line hidden
#nullable disable
            WriteLiteral("\"><i class=\"fa fa-thumbs-down\"></i>  (<span id=\"downVote\">");
#nullable restore
#line 31 "C:\Users\Acer\OneDrive\Desktop\BlogApp\BlogApp\Views\Home\ReadBlog.cshtml"
                                                                                                                                                        Write(Model.Reactions.Where(x => x.IsUpvote == false).Count());

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>)</button>\r\n            </div>\r\n            <!-- Comment Section -->\r\n            <div class=\"comment-section\">\r\n\r\n                <ul class=\"list-group\">\r\n");
#nullable restore
#line 37 "C:\Users\Acer\OneDrive\Desktop\BlogApp\BlogApp\Views\Home\ReadBlog.cshtml"
                     if (Model.Comments != null)
                    {
                        if (Model.Comments.Count > 0)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <h6>Comments</h6>\r\n");
#nullable restore
#line 42 "C:\Users\Acer\OneDrive\Desktop\BlogApp\BlogApp\Views\Home\ReadBlog.cshtml"
                            foreach (var comment in Model.Comments.Where(x => !x.IsDeleted))
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <li class=\"list-group-item comment-content\">\r\n                                    <span class=\"comment-span\">");
#nullable restore
#line 45 "C:\Users\Acer\OneDrive\Desktop\BlogApp\BlogApp\Views\Home\ReadBlog.cshtml"
                                                          Write(comment.Content);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                                    <div>\r\n                                        <small class=\"text-muted\">By: ");
#nullable restore
#line 47 "C:\Users\Acer\OneDrive\Desktop\BlogApp\BlogApp\Views\Home\ReadBlog.cshtml"
                                                                 Write(comment.Author.UserName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</small>\r\n");
#nullable restore
#line 48 "C:\Users\Acer\OneDrive\Desktop\BlogApp\BlogApp\Views\Home\ReadBlog.cshtml"
                                         if (User.Identity.IsAuthenticated && comment.AuthorId == User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value)
                                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                            <i class=\"fa fa-pencil text-primary edit-comment-btn\" style=\"cursor:pointer\" data-toggle=\"modal\" data-target=\"#editCommentModal\" data-comment-id=\"");
#nullable restore
#line 50 "C:\Users\Acer\OneDrive\Desktop\BlogApp\BlogApp\Views\Home\ReadBlog.cshtml"
                                                                                                                                                                                         Write(comment.CommentId);

#line default
#line hidden
#nullable disable
            WriteLiteral("\"></i>\r\n                                            <i class=\"fa fa-trash text-danger delete-comment-btn\" style=\"cursor:pointer\" data-comment-id=\"");
#nullable restore
#line 51 "C:\Users\Acer\OneDrive\Desktop\BlogApp\BlogApp\Views\Home\ReadBlog.cshtml"
                                                                                                                                     Write(comment.CommentId);

#line default
#line hidden
#nullable disable
            WriteLiteral("\"></i>\r\n");
#nullable restore
#line 52 "C:\Users\Acer\OneDrive\Desktop\BlogApp\BlogApp\Views\Home\ReadBlog.cshtml"
                                        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                    </div>
                                    <div class=""comment-reaction"">
                                        <!-- Reaction icons -->
                                        <i class=""fa fa-thumbs-up text-success upvote-btn-comment"" style=""cursor:pointer"" data-post-id=""");
#nullable restore
#line 56 "C:\Users\Acer\OneDrive\Desktop\BlogApp\BlogApp\Views\Home\ReadBlog.cshtml"
                                                                                                                                   Write(comment.CommentId);

#line default
#line hidden
#nullable disable
            WriteLiteral("\"></i> <span class=\"commentUpVote\">");
#nullable restore
#line 56 "C:\Users\Acer\OneDrive\Desktop\BlogApp\BlogApp\Views\Home\ReadBlog.cshtml"
                                                                                                                                                                                        Write(comment.CommentReaction.Where(x => x.IsUpvote).Count());

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                                        <i class=\"fa fa-thumbs-down text-danger downvote-btn-comment\" style=\"cursor:pointer\" data-post-id=\"");
#nullable restore
#line 57 "C:\Users\Acer\OneDrive\Desktop\BlogApp\BlogApp\Views\Home\ReadBlog.cshtml"
                                                                                                                                      Write(comment.CommentId);

#line default
#line hidden
#nullable disable
            WriteLiteral("\"></i> <span class=\"commentdownVote\">");
#nullable restore
#line 57 "C:\Users\Acer\OneDrive\Desktop\BlogApp\BlogApp\Views\Home\ReadBlog.cshtml"
                                                                                                                                                                                             Write(comment.CommentReaction.Where(x => !x.IsUpvote).Count());

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                                    </div>\r\n                                </li>\r\n");
#nullable restore
#line 60 "C:\Users\Acer\OneDrive\Desktop\BlogApp\BlogApp\Views\Home\ReadBlog.cshtml"
                            }
                        }
                        else
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                           <span>No comments</span>\r\n");
#nullable restore
#line 65 "C:\Users\Acer\OneDrive\Desktop\BlogApp\BlogApp\Views\Home\ReadBlog.cshtml"
                        }
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </ul>\r\n                <br />\r\n                <!-- Comment Form -->\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "45c3908fdcc6c294db1fc27a018d058157d1b71e963ba02b1470e12a45d2cb1316295", async() => {
                WriteLiteral("\r\n                    <div class=\"form-group\">\r\n                        <textarea class=\"form-control\" name=\"comment\" rows=\"3\" placeholder=\"Leave a comment\", required></textarea>\r\n                        <input type=\"hidden\" name=\"id\"");
                BeginWriteAttribute("value", " value=\"", 4627, "\"", 4652, 1);
#nullable restore
#line 74 "C:\Users\Acer\OneDrive\Desktop\BlogApp\BlogApp\Views\Home\ReadBlog.cshtml"
WriteAttributeValue("", 4635, Model.BlogPostId, 4635, 17, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\r\n                    </div>\r\n                    <button type=\"submit\" class=\"btn btn-primary\">Comment</button>\r\n                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
            </div>
        </div>
    </div>
</div>
<!-- Edit Comment Modal -->
<div class=""modal fade"" id=""editCommentModal"" tabindex=""-1"" role=""dialog"" aria-labelledby=""editCommentModalLabel"" aria-hidden=""true"">
    <div class=""modal-dialog"" role=""document"">
        <div class=""modal-content"">
            <div class=""modal-header"">
                <h5 class=""modal-title"" id=""editCommentModalLabel"">Edit Comment</h5>
                <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                    <span aria-hidden=""true"">&times;</span>
                </button>
            </div>
            <div class=""modal-body"">
                <textarea id=""editCommentTextarea"" class=""form-control"" rows=""4""></textarea>
                <input type=""hidden"" id=""editCommentId"" />
            </div>
            <div class=""modal-footer"">
                <button type=""button"" class=""btn btn-secondary"" data-dismiss=""modal"">Close</button>
                <button type=""button");
            WriteLiteral("\" class=\"btn btn-primary\" id=\"saveEditedCommentBtn\">Save changes</button>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "45c3908fdcc6c294db1fc27a018d058157d1b71e963ba02b1470e12a45d2cb1320264", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n<script>\r\n    var isAuthenticated = ");
#nullable restore
#line 106 "C:\Users\Acer\OneDrive\Desktop\BlogApp\BlogApp\Views\Home\ReadBlog.cshtml"
                     Write(User.Identity.IsAuthenticated.ToString().ToLower());

#line default
#line hidden
#nullable disable
            WriteLiteral(@"; // Pass authentication status to JavaScript

    $(document).ready(function () {
        $('.upvote-btn, .downvote-btn').click(function () {
            if (!isAuthenticated) {
                alert('Please log in to vote.');
                return;
            }

            var postId = $(this).data('post-id');
            var isUpvote = $(this).hasClass('upvote-btn');

            $.ajax({
                type: ""POST"",
                url: ""/Home/AddReaction"",
                data: { id: postId, isUpvote: isUpvote },
                success: function (response) {
                    if (response === ""success"") {
                        // Update UI, e.g., increase upvote/downvote count
                        var countElement = isUpvote ? $('#upVote') : $('#downVote');
                        var count = parseInt(countElement.text());
                        countElement.text(count + 1);
                    } else {
                        alert('Failed to add reaction.');
       ");
            WriteLiteral(@"             }
                },
                error: function () {
                    alert('Failed to add reaction.');
                }
            });
        });

        $('#commentForm').submit(function (e) {
            e.preventDefault(); // Prevent default form submission

            if (!isAuthenticated) {
                alert('Please log in to comment.');
                return;
            }

            var formData = $(this).serialize(); // Serialize form data
            $.ajax({
                type: ""POST"",
                url: ""/Home/AddComment"",
                data: formData,
                success: function (response) {
                    alert('Comment added successfully.');
                    location.reload();
                },
                error: function () {
                    alert('Failed to add comment.');
                }
            });
        });

        $('.upvote-btn-comment, .downvote-btn-comment').click(function () {
      ");
            WriteLiteral(@"      if (!isAuthenticated) {
                alert('Please log in to vote.');
                return;
            }

            var postId = $(this).data('post-id');
            var isUpvote = $(this).hasClass('upvote-btn-comment');
            var countElement = isUpvote ? $(this).siblings('.commentUpVote') : $(this).siblings('.commentdownVote');

            var count = parseInt(countElement.text());
            $.ajax({
                type: ""POST"",
                url: ""/Home/AddCommentReaction"",
                data: { id: postId, isUpvote: isUpvote },
                success: function (response) {
                    if (response === ""success"") {
                        countElement.text(count + 1);
                    } else {
                        alert('Failed to add reaction.');
                    }
                },
                error: function () {
                    alert('Failed to add reaction.');
                }
            });
        });

        // Edi");
            WriteLiteral(@"t Comment


    });

    $(document).on(""click"", "".edit-comment-btn"", function () {
        debugger;
        var commentId = $(this).data(""comment-id"");
        var commentContent = $(this).closest("".comment-content"").find("".comment-span"").text().trim();
        $(""#editCommentId"").val(commentId);
        $(""#editCommentTextarea"").val(commentContent);
    });

    $(""#saveEditedCommentBtn"").click(function () {
        var commentId = $(""#editCommentId"").val();
        var editedContent = $(""#editCommentTextarea"").val();

        $.ajax({
            url: ""/Home/UpdateComment"",
            method: ""POST"",
            data: {
                commentId: commentId,
                editedContent: editedContent
            },
            success: function (data) {
                if (data.success) {
                    // Update the comment content in the UI
                    $(""#editCommentModal"").modal(""hide"");
                    location.reload();
                    // Refresh t");
            WriteLiteral(@"he page or update the comment content in the UI
                } else {
                    alert(""Failed to update comment."");
                }
            },
            error: function () {
                alert(""Failed to update comment."");
            }
        });
    });

    $('.delete-comment-btn').click(function () {
        var commentId = $(this).data('comment-id');
        var commentContent = $(this).data('comment-content');
        var deleteConfirmation = confirm('Are you sure you want to delete this comment?\n\n' + commentContent);

        if (deleteConfirmation) {
            $.ajax({
                url: '/Home/DeleteComment',
                method: 'POST',
                data: { commentId: commentId },
                success: function (response) {
                    if (response.success) {
                        // Remove the comment from the UI
                        $('#comment-' + commentId).remove();
                        alert('Comment deleted succe");
            WriteLiteral(@"ssfully.');
                    } else {
                        alert('Failed to delete the comment.');
                    }
                },
                error: function (xhr, status, error) {
                    alert('Failed to delete the comment: ' + error);
                }
            });
        }
    });

</script>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<BlogApp.Models.BlogPost> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
