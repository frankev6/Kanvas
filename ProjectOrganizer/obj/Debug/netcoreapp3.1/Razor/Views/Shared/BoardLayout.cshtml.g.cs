#pragma checksum "C:\Dev\ProjectOrganizer\ProjectOrganizer\Views\Shared\BoardLayout.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1b4bd417f1ae110e7ed77085ad368c762e15736b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_BoardLayout), @"mvc.1.0.view", @"/Views/Shared/BoardLayout.cshtml")]
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
#line 1 "C:\Dev\ProjectOrganizer\ProjectOrganizer\Views\_ViewImports.cshtml"
using ProjectOrganizer;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Dev\ProjectOrganizer\ProjectOrganizer\Views\_ViewImports.cshtml"
using ProjectOrganizer.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1b4bd417f1ae110e7ed77085ad368c762e15736b", @"/Views/Shared/BoardLayout.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5aab8a22be7b466fc59f1f9876bb70be96f2f3a8", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_BoardLayout : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ProjectOrganizer.Models.ViewModels.BoardViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/jquery/dist/jquery.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/bootstrap/dist/css/bootstrap.min.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/site.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/BoardStyle.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/bootstrap/dist/js/bootstrap.bundle.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("body"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<!DOCTYPE html>\r\n<html lang=\"en\">\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1b4bd417f1ae110e7ed77085ad368c762e15736b5995", async() => {
                WriteLiteral("\r\n\t<meta charset=\"utf-8\" />\r\n\t<meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\" />\r\n\t<title>");
#nullable restore
#line 7 "C:\Dev\ProjectOrganizer\ProjectOrganizer\Views\Shared\BoardLayout.cshtml"
      Write(ViewData["Title"]);

#line default
#line hidden
#nullable disable
                WriteLiteral(" - ProjectOrganizer</title>\r\n\r\n\t<script>\r\n\t\tvar isPublic = false;\r\n\t\tvar userRole = ");
#nullable restore
#line 11 "C:\Dev\ProjectOrganizer\ProjectOrganizer\Views\Shared\BoardLayout.cshtml"
                   Write((int)Model.ProjectUser.UserRole);

#line default
#line hidden
#nullable disable
                WriteLiteral(";\r\n\t</script>\r\n\r\n\r\n");
#nullable restore
#line 15 "C:\Dev\ProjectOrganizer\ProjectOrganizer\Views\Shared\BoardLayout.cshtml"
     if (@Model.Project.isPublic)
	{

#line default
#line hidden
#nullable disable
                WriteLiteral("\t\t<script>isPublic = true;</script>\r\n");
#nullable restore
#line 18 "C:\Dev\ProjectOrganizer\ProjectOrganizer\Views\Shared\BoardLayout.cshtml"
	}

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n\t");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1b4bd417f1ae110e7ed77085ad368c762e15736b7439", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n\t");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "1b4bd417f1ae110e7ed77085ad368c762e15736b8536", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n\t<script src=\"https://kit.fontawesome.com/180f11b51a.js\" crossorigin=\"anonymous\"></script>\r\n\t");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "1b4bd417f1ae110e7ed77085ad368c762e15736b9811", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n\t");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "1b4bd417f1ae110e7ed77085ad368c762e15736b10987", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
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
            WriteLiteral("\r\n\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1b4bd417f1ae110e7ed77085ad368c762e15736b12878", async() => {
                WriteLiteral("\r\n\r\n\r\n\t<div id=\"board-background\"");
                BeginWriteAttribute("style", " style=\"", 842, "\"", 991, 7);
                WriteAttributeValue("", 850, "background:", 850, 11, true);
#nullable restore
#line 31 "C:\Dev\ProjectOrganizer\ProjectOrganizer\Views\Shared\BoardLayout.cshtml"
WriteAttributeValue(" ", 861, Model.Project.BackgroundC, 862, 26, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue(" ", 888, "no-repeat;background-size:cover;", 889, 33, true);
                WriteAttributeValue(" ", 921, "background-attachment:fixed;", 922, 29, true);
                WriteAttributeValue(" ", 950, "position:fixed;", 951, 16, true);
                WriteAttributeValue(" ", 966, "height:100%;", 967, 13, true);
                WriteAttributeValue(" ", 979, "width:100%;", 980, 12, true);
                EndWriteAttribute();
                WriteLiteral(@"></div>

	<header style=""width: 100%; position: fixed; z-index: 1"">
		<nav class=""navbar shadow foreground-nav"" style="" width:100%"">
			<div class=""container"" style=""margin-left: 0; width: 100%; margin-right: 0; margin-bottom: 0px; padding: 0"">
				<div class=""d-inline"">

					<a class="" mr-sm-2 btn shadow-sm foreground-item-text foreground-item-transparent font-weight-bold"" href=""https://localhost/Kanvas/Dashboard"" style=""cursor: pointer;width: 40px; height:40px;padding-top:2px;padding-left:8px; font-size: 20px;color:#fff""><i class=""fas fa-home""></i></a>
					<div spellcheck=""false"" contenteditable=""true"" class="" my-2 my-sm-0 navbar-brand foreground-item-text editable-Pname"" onkeydown=""if (event.keyCode == 13 || event.keyCode == 27) { $('.editable-Pname').blur(); return false; }""><strong> ");
#nullable restore
#line 39 "C:\Dev\ProjectOrganizer\ProjectOrganizer\Views\Shared\BoardLayout.cshtml"
                                                                                                                                                                                                                                                         Write(Model.Project.Name);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"</strong></div>
					<div class=""share-btn mr-sm-2 btn shadow-sm foreground-item-text foreground-item-transparent font-weight-bold"" style=""cursor: pointer;width: 100px; height:40px; padding-top:8px; font-size: 15px; color:#fff""><i class=""fas fa-lock""></i>    Share</div>
				</div>

			</div>
			<button class=""btn shadow-sm foreground-item-text foreground-item-transparent text-center"" data-toggle=""collapse"" data-target=""#main-menu"" style=""cursor: pointer; width: 40px; height:40px; padding-top: 4px; padding-left: 11px; font-size: 20px;color:#fff""><i class=""fas fa-bars""></i></button>
		</nav>
	</header>


	<!--Project Share Modal-->
	<div class=""modal fade"" id=""ShareModal"" tabindex=""-1"" role=""dialog"">
		<div class=""modal-dialog modal-dialog-centered modal"">
			<div class=""modal-content"">
				<div class=""modal-header"">
					<h5 class=""modal-title text-dark""><i class=""fas fa-lock""></i> Share with users and teams</h5>
					<button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">");
                WriteLiteral(@"
						<span aria-hidden=""true"" class=""text-dark"">&times;</span>
					</button>
				</div>
				<div class=""modal-body align-content-center"" style=""min-height: 400px"">
					<div class=""align-self-center"">

						<div style=""margin-bottom:20px"">
							<input type=""text"" id=""share-adduser-input"" class=""form-control"" placeholder=""Add User..."" />
						</div>
						
						<div class=""user-modal-list"" id=""share-user-list"">

");
#nullable restore
#line 68 "C:\Dev\ProjectOrganizer\ProjectOrganizer\Views\Shared\BoardLayout.cshtml"
                             foreach (var projectuser in Model.Project.ProjectUsers)
							{

#line default
#line hidden
#nullable disable
                WriteLiteral("\t\t\t\t\t\t\t<div");
                BeginWriteAttribute("id", " id=\"", 3365, "\"", 3398, 2);
                WriteAttributeValue("", 3370, "userbox", 3370, 7, true);
#nullable restore
#line 70 "C:\Dev\ProjectOrganizer\ProjectOrganizer\Views\Shared\BoardLayout.cshtml"
WriteAttributeValue("", 3377, projectuser.UserId, 3377, 21, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" class=\"d-flex text-dark justify-content-between user-modal-item\" style=\"margin-bottom:10px\">\r\n\t\t\t\t\t\t\t\t<div class=\"d-flex\">\r\n\r\n\t\t\t\t\t\t\t\t\t<div class=\"small-user-thumnail\">");
#nullable restore
#line 73 "C:\Dev\ProjectOrganizer\ProjectOrganizer\Views\Shared\BoardLayout.cshtml"
                                                                Write(char.ToUpper(projectuser.User.UserName.First()));

#line default
#line hidden
#nullable disable
                WriteLiteral("</div>\r\n\t\t\t\t\t\t\t\t\t<div style=\"margin-top:3px;margin-left:8px\">");
#nullable restore
#line 74 "C:\Dev\ProjectOrganizer\ProjectOrganizer\Views\Shared\BoardLayout.cshtml"
                                                                           Write(projectuser.User.UserName);

#line default
#line hidden
#nullable disable
                WriteLiteral("</div>\r\n\t\t\t\t\t\t\t\t</div>\r\n\r\n");
#nullable restore
#line 77 "C:\Dev\ProjectOrganizer\ProjectOrganizer\Views\Shared\BoardLayout.cshtml"
                                 if (projectuser.UserRole == ProjectOrganizer.Models.WorkspaceModels.ProjectUser.UserRoles.Owner)
								{


#line default
#line hidden
#nullable disable
                WriteLiteral("\t\t\t\t\t\t\t\t\t<div class=\"my-2 my-sm-0\" style=\"margin-top:2px!important;color:#777e94\">");
#nullable restore
#line 80 "C:\Dev\ProjectOrganizer\ProjectOrganizer\Views\Shared\BoardLayout.cshtml"
                                                                                                        Write(projectuser.UserRole);

#line default
#line hidden
#nullable disable
                WriteLiteral("</div>\r\n");
#nullable restore
#line 81 "C:\Dev\ProjectOrganizer\ProjectOrganizer\Views\Shared\BoardLayout.cshtml"
								}
								else
								{
									if (Model.ProjectUser.UserRole == ProjectOrganizer.Models.WorkspaceModels.ProjectUser.UserRoles.Viewer)
									{

#line default
#line hidden
#nullable disable
                WriteLiteral("\t\t\t\t\t\t\t\t\t\t<div class=\"my-2 my-sm-0\" style=\"margin-top:2px!important;color:#777e94\">");
#nullable restore
#line 86 "C:\Dev\ProjectOrganizer\ProjectOrganizer\Views\Shared\BoardLayout.cshtml"
                                                                                                            Write(projectuser.UserRole);

#line default
#line hidden
#nullable disable
                WriteLiteral("</div>\r\n");
#nullable restore
#line 87 "C:\Dev\ProjectOrganizer\ProjectOrganizer\Views\Shared\BoardLayout.cshtml"
									}
									else { 

#line default
#line hidden
#nullable disable
                WriteLiteral("\t\t\t\t\t\t\t\t\t<div class=\"user-dropdown-modal dropdown my-2 my-sm-0\" style=\"margin-top:2px!important; cursor:pointer\">\r\n\t\t\t\t\t\t\t\t\t\t<div role=\"button\" data-toggle=\"dropdown\" aria-haspopup=\"true\" aria-expanded=\"false\">\r\n\t\t\t\t\t\t\t\t\t\t\t<div");
                BeginWriteAttribute("id", " id=\"", 4491, "\"", 4525, 2);
                WriteAttributeValue("", 4496, "dropdown", 4496, 8, true);
#nullable restore
#line 91 "C:\Dev\ProjectOrganizer\ProjectOrganizer\Views\Shared\BoardLayout.cshtml"
WriteAttributeValue("", 4504, projectuser.UserId, 4504, 21, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">");
#nullable restore
#line 91 "C:\Dev\ProjectOrganizer\ProjectOrganizer\Views\Shared\BoardLayout.cshtml"
                                                                               Write(projectuser.UserRole);

#line default
#line hidden
#nullable disable
                WriteLiteral(" <i class=\"fas fa-caret-down\"></i></div>\r\n\r\n\t\t\t\t\t\t\t\t\t\t</div>\r\n\r\n\t\t\t\t\t\t\t\t\t\t<div class=\"dropdown-menu dropdown-menu-right\" aria-labelledby=\"navbarDropdown\">\r\n\t\t\t\t\t\t\t\t\t\t\t<div");
                BeginWriteAttribute("id", " id=\"", 4719, "\"", 4743, 1);
#nullable restore
#line 96 "C:\Dev\ProjectOrganizer\ProjectOrganizer\Views\Shared\BoardLayout.cshtml"
WriteAttributeValue("", 4724, projectuser.UserId, 4724, 19, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" class=\"share-edit-option dropdown-item\">Editor</div>\r\n\t\t\t\t\t\t\t\t\t\t\t<div");
                BeginWriteAttribute("id", " id=\"", 4814, "\"", 4838, 1);
#nullable restore
#line 97 "C:\Dev\ProjectOrganizer\ProjectOrganizer\Views\Shared\BoardLayout.cshtml"
WriteAttributeValue("", 4819, projectuser.UserId, 4819, 19, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" class=\"share-viewer-option dropdown-item\">Viewer</div>\r\n\t\t\t\t\t\t\t\t\t\t\t<div class=\"dropdown-divider\"></div>\r\n\t\t\t\t\t\t\t\t\t\t\t<div");
                BeginWriteAttribute("id", " id=\"", 4960, "\"", 4984, 1);
#nullable restore
#line 99 "C:\Dev\ProjectOrganizer\ProjectOrganizer\Views\Shared\BoardLayout.cshtml"
WriteAttributeValue("", 4965, projectuser.UserId, 4965, 19, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" class=\"share-remove-option dropdown-item\">Remove</div>\r\n\t\t\t\t\t\t\t\t\t\t</div>\r\n\t\t\t\t\t\t\t\t\t</div>\r\n");
#nullable restore
#line 102 "C:\Dev\ProjectOrganizer\ProjectOrganizer\Views\Shared\BoardLayout.cshtml"
									}
								}

#line default
#line hidden
#nullable disable
                WriteLiteral("\t\t\t\t\t\t\t</div>\r\n");
#nullable restore
#line 105 "C:\Dev\ProjectOrganizer\ProjectOrganizer\Views\Shared\BoardLayout.cshtml"
							}

#line default
#line hidden
#nullable disable
                WriteLiteral(@"						</div>

					</div>

				</div>
				<div class=""modal-footer justify-content-center"">

					<div class=""d-inline-flex"">
						<div style=""margin-right:50px"" class=""text-dark"">Make project public (anyone with the link can view): </div>
						<label class=""switch"">
							<input type=""checkbox"" id=""share-public-option"">
							<span class=""slider round""></span>
						</label>
					</div>
				</div>
			</div>
		</div>
	</div>



	<div class=""container"" style=""margin-left: 0; margin-right: 0;  padding-left: 0; padding-right: 0; overflow-x: auto"">
		<main role=""main""");
                BeginWriteAttribute("class", " class=\"", 5721, "\"", 5729, 0);
                EndWriteAttribute();
                WriteLiteral(" style=\"height: 100%\">\r\n\r\n\r\n\r\n\t\t\t");
#nullable restore
#line 132 "C:\Dev\ProjectOrganizer\ProjectOrganizer\Views\Shared\BoardLayout.cshtml"
       Write(RenderBody());

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
		</main>
	</div>

	<style>
		

		

		.foreground-item {
			background: #fff;
		}
		.foreground-item-text {
			border-radius:0;
		}

		.foreground-item-transparent {
			background: #242d47;
			border-radius: 5px;
		}
			.foreground-item-transparent:hover {
				background: #335dff;
			}
		.foreground-nav {
			background: #1a2133;
		}
		.collapse {
			display: block;
			height: 100%;
			overflow: hidden;
		}

	</style>


	<script>
		$(document).on('click', '.share-btn', function () {
			$('#ShareModal').modal('show');
		});

	</script>
	");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1b4bd417f1ae110e7ed77085ad368c762e15736b25131", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n\t");
#nullable restore
#line 174 "C:\Dev\ProjectOrganizer\ProjectOrganizer\Views\Shared\BoardLayout.cshtml"
Write(RenderSection("Scripts", required: false));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</html>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ProjectOrganizer.Models.ViewModels.BoardViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
