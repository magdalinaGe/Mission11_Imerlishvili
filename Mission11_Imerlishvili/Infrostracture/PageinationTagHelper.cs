using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Mission11_Imerlishvili.Models.ViewModels;

namespace Mission11_Imerlishvili.Infrostracture
{
    [HtmlTargetElement("div", Attributes = "page-model")]
    public class PageinationTagHelper : TagHelper
    {

        private IUrlHelperFactory urlHelperFactory;

        public PageinationTagHelper(IUrlHelperFactory temp)
        {
            this.urlHelperFactory = temp;
        }
        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext? ViewContext { get; set; }
        public string? PageAction { get; set; }
        public PageinationInfo PageModel { get; set; }

        public bool PageClassEnabled { get; set; } = false;
        public string PageClass { get; set; } = String.Empty;
        public string PageClassNormal { get; set; } = String.Empty;
        public string PageClassSelected { get; set; } = String.Empty;



        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            // Check if ViewContext and PageModel are not null
            if (ViewContext != null && PageModel != null)
            {
                // Get an instance of IUrlHelper using IUrlHelperFactory
                IUrlHelper urlHelper = urlHelperFactory.GetUrlHelper(ViewContext);

                // Create a new <div> tag builder
                TagBuilder result = new TagBuilder("div");

                // Loop through each page and create a pagination link
                for (int i = 1; i <= PageModel.TotalNumPages; i++)
                {
                    // Create an <a> tag builder for the pagination link
                    TagBuilder tag = new TagBuilder("a");

                    // Set the href attribute for the link using the action method and page number
                    tag.Attributes["href"] = urlHelper.Action(PageAction, new { pageNum = i });

                    // Add CSS classes if PageClassEnabled is true
                    if (PageClassEnabled)
                    {
                        tag.AddCssClass(PageClass);
                        tag.AddCssClass(i == PageModel.CurrentPage ? PageClassSelected : PageClassNormal);
                    }

                    // Set the inner text of the link to the page number
                    tag.InnerHtml.Append(i.ToString());

                    // Append the link to the result <div>
                    result.InnerHtml.AppendHtml(tag);
                }

                // Append the generated pagination links to the output content
                output.Content.AppendHtml(result.InnerHtml);
            }
        }

    }
}
