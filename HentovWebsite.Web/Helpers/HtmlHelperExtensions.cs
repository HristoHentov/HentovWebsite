using System;
using System.Web.Mvc;

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
    }
}