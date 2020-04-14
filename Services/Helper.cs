using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Services
{
    public static class HtmlPostExtensions
    {
        //Limits characters that a post will show and makes sure the last word is compleat before ending the snippet.
        public static IHtmlString Post25(this HtmlHelper helper, string postContent)
        {
            string postStr = postContent;
            if (postStr.Length > 25)
            {
                postStr = postStr.Substring(0, 25);
                if (postStr != string.Empty)
                {
                    string newPostStr = postContent;
                    int maxString = 25;
                    while (!char.IsWhiteSpace(postContent[maxString]))
                    {
                        maxString++;
                        newPostStr = postContent.Substring(0, maxString);
                    }
                    return MvcHtmlString.Create(newPostStr);
                }
            }
            return MvcHtmlString.Create(postStr);
        }
    }


}
