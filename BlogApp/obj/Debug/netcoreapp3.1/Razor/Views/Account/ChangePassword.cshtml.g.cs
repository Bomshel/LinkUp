#pragma checksum "C:\Users\Acer\OneDrive\Desktop\BlogApp\BlogApp\Views\Account\ChangePassword.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "91ef1e3bed4ab61f8682d59d3f8bd34b0049c10d457500d6ddd6d6a6e0fc3ddf"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Account_ChangePassword), @"mvc.1.0.view", @"/Views/Account/ChangePassword.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"Sha256", @"91ef1e3bed4ab61f8682d59d3f8bd34b0049c10d457500d6ddd6d6a6e0fc3ddf", @"/Views/Account/ChangePassword.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"Sha256", @"2a2107e3875ee376763b7a1d7ec3392a23aa5d4c6baccc027f02693d1979a127", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Account_ChangePassword : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<BlogApp.ViewModels.ChangePasswordViewModel>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\Acer\OneDrive\Desktop\BlogApp\BlogApp\Views\Account\ChangePassword.cshtml"
  
    Layout = "~/Views/Shared/_Admin.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""container"">
    <div class=""row justify-content-center"">
        <div class=""col-md-6"">
            <div class=""card"">
                <div class=""card-header bg-primary text-white"">
                    <h3 class=""mb-0"">Change Password</h3>
                </div>
                <div class=""card-body"">
");
#nullable restore
#line 14 "C:\Users\Acer\OneDrive\Desktop\BlogApp\BlogApp\Views\Account\ChangePassword.cshtml"
                     using (Html.BeginForm("ChangePassword", "Account", FormMethod.Post, new { @class = "form-horizontal", role = "form" }))
                    {
                        

#line default
#line hidden
#nullable disable
#nullable restore
#line 16 "C:\Users\Acer\OneDrive\Desktop\BlogApp\BlogApp\Views\Account\ChangePassword.cshtml"
                   Write(Html.AntiForgeryToken());

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                        <div class=""form-group"">
                            <label for=""OldPassword"">Current Password</label>
                            <input type=""password"" class=""form-control"" id=""OldPassword"" name=""OldPassword"" required>
                        </div>
                        <div class=""form-group"">
                            <label for=""NewPassword"">New Password</label>
                            <input type=""password"" class=""form-control"" id=""NewPassword"" name=""NewPassword"" required>
                        </div>
                        <div class=""form-group"">
                            <label for=""ConfirmPassword"">Confirm New Password</label>
                            <input type=""password"" class=""form-control"" id=""ConfirmPassword"" name=""ConfirmPassword"" required>
                        </div>
                        <button type=""submit"" class=""btn btn-primary"">Change Password</button>
");
#nullable restore
#line 31 "C:\Users\Acer\OneDrive\Desktop\BlogApp\BlogApp\Views\Account\ChangePassword.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                </div>
            </div>
        </div>
    </div>
</div>

<script>
    $(document).ready(function () {
        var message = $(""#Message"").val();
        if (message != """") {
            $.toaster(message, 'Success', 'success');
        }
    })
</script>
");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<BlogApp.ViewModels.ChangePasswordViewModel> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
