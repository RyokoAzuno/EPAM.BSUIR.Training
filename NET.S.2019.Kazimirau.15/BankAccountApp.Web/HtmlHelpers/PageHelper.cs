using BankAccountApp.Web.Models;
using System;
using System.Text;
using System.Web.Mvc;

namespace BankAccountApp.Web.HtmlHelpers
{
    public static class PageHelper
    {
        public static MvcHtmlString PageLinks(this HtmlHelper helper, PagingInfo pagingInfo, Func<int, string> pageUrl, string css)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 1; i <= pagingInfo.TotalPages; i++)
            {
                TagBuilder a = new TagBuilder("a");
                a.MergeAttribute("href", pageUrl(i));
                a.InnerHtml = i.ToString();
                if (i == pagingInfo.CurrentPage)
                {
                    a.AddCssClass("selected");
                    a.AddCssClass("btn-primary");
                }

                a.AddCssClass(css);
                sb.Append(a.ToString());
            }

            return MvcHtmlString.Create(sb.ToString());
        }
    }
}