using Data;
using Models.Search;
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
    public class MakeDefaultCat
    {
        public void MakeACate()
        {
            //Temp fix for issue cascade issue
            using (var context = new ApplicationDbContext())
            {
                var dService = new SearchService();

                if (dService.QuickFix("Please") == null)
                {
                    var addDefault = new Category { CategoryName = "Please Re-Select Category", CategoryDescription = "The Category you had Select has been removed." };
                    context.Categories.Add(addDefault);
                    context.SaveChanges();
                }
            }
        }
    }
    public class OnDelete
    {
        public void OnDeleteCategory(int id)
        {
            using (var context = new ApplicationDbContext())
            {
                var dService = new SearchService();

                var defaultCategory = dService.QuickFix("Please");
                if (defaultCategory == null)
                {
                    var service = new MakeDefaultCat();
                    service.MakeACate();
                    defaultCategory = dService.QuickFix("Please");
                }
                var query =
                context
                .CodeExamples
                .Where(e => e.CategoryId == id).ToList();

                foreach (var item in query)
                {
                    item.CategoryId = defaultCategory.CategoryId;
                }
                context.SaveChanges();
            }
        }
    }

}
