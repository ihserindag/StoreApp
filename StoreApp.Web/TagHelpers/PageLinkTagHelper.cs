using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Razor.TagHelpers;
using StoreApp.Web.Models;

namespace StoreApp.Web.TagHelpers
{
    [HtmlTargetElement("div", Attributes = "page-model")]
    public class PageLinkTagHelper : TagHelper
    {
        private readonly IUrlHelperFactory _urlHelperFactory;

        public PageLinkTagHelper(IUrlHelperFactory urlHelperFactory)
        {
            _urlHelperFactory = urlHelperFactory;
        }

        [Microsoft.AspNetCore.Mvc.ViewFeatures.ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext? ViewContext { get; set; }

        public PageInfo? PageModel { get; set; }
        public string? PageAction { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (ViewContext == null || PageModel == null || string.IsNullOrWhiteSpace(PageAction))
            {
                return;
            }

            IUrlHelper urlHelper = _urlHelperFactory.GetUrlHelper(ViewContext);

            for (int i = 1; i <= PageModel.TotalPages; i++)
            {
                TagBuilder link = new TagBuilder("a");
                link.AddCssClass("btn");
                link.AddCssClass(i == PageModel.CurrentPage ? "btn-primary" : "btn-outline-primary");
                link.Attributes["href"] = urlHelper.Action(PageAction, new { page = i }) ?? "#";
                link.InnerHtml.Append(i.ToString());
                output.Content.AppendHtml(link);
            }
        }
    }
}
