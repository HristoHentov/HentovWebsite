using System.Web.Mvc;
using System.Web.Routing;

namespace HentovWebsite.Web.Helpers
{
    public static class HtmlHelperExtensions
    {
        public static MvcHtmlString PortfolioImage(this HtmlHelper helper, string imgSource, string alt)
        {
            string body = "<div class=\"col-md-4 col-sm-6 padding-right-zero\">" +
                          $"<div class=\"portfolio-box design\"><img src = \"{imgSource}\" alt=\"{alt}\" class=\"img-responsive\"></div>" +
                          "</div>";

            return new MvcHtmlString(body);
        }

        public static MvcHtmlString ServiceDescription(this HtmlHelper helper, string icon, string title, string description)
        {
            string body = "<div class=\"col-md-6 wow fadeInRight delay-02s\">" +
                          "<div class=\"icon\">" +
                          $"<i class=\"{icon}\"></i>" +
                          "</div>" +
                          "<div class=\"icon-text\">" +
                          $"<h3 class=\"txt-tl\">{title}</h3>" +
                          $"<p class=\"txt-para\">{description}</p>" +
                          "</div></div>";
            return new MvcHtmlString(body);
        }

        public static MvcHtmlString Image(this HtmlHelper helper, string url, string altText,string width, string height, object htmlAttributes)
        {
            TagBuilder builder = new TagBuilder("img");
            builder.Attributes.Add("src", url);
            builder.Attributes.Add("alt", altText);
            builder.Attributes.Add("width", width);
            builder.Attributes.Add("height", height);
            builder.MergeAttributes(new RouteValueDictionary(htmlAttributes));
            return MvcHtmlString.Create(builder.ToString(TagRenderMode.Normal));
        }
    }
}