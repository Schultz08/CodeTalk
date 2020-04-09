using Data;
using Models.CategoryModels;
using Models.CodeExampleModels;
using Models.ProfileModels;
using Models.Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class SearchService
    {
        public delegate void GetResults(string str);
        private readonly List<Object> _result = new List<Object>();

        public void SearchProfile(string str)
        {
            using(var context = new ApplicationDbContext())
            {

            var query =
                context
                .Profiles
                .Where(e => e.UserName.Contains(str))
                .Select(profile => new ProfileDetail
                {
                    ProfileId = profile.ProfileId,
                    UserName = profile.UserName,
                }).ToList();

            _result.Add(query);
            }
        }

        public void SearchCategory(string str)
        {
            using (var context = new ApplicationDbContext())
            {

            var query =
                context
                .Categories
                .Where(e => e.CategoryName.Contains(str))
                .Select(category => new CategoryDetail
                {
                    CategoryId = category.CategoryId,
                    CategoryName = category.CategoryName,
                    CategoryDiscription = category.CategoryDiscription
                }).ToList();

            _result.Add(query);

            }
        }
        public void SearchExample(string str)
        {
            using (var context = new ApplicationDbContext())
            {

            var query =
                context
                .CodeExamples
                .Where(e => e.Title.Contains(str))
                .Select(example => new ExampleDetail
                {
                    CodeExampleId = example.CodeExampleId,
                    ProfileId = example.ProfileId,
                    CategoryId = example.CategoryId,
                    UserName = example.Profile.UserName,
                    Title = example.Title,
                    ExampleDiscription = example.ExampleDiscription,
                    InitialPost = example.InitialPost,
                    EditedPost = example.EditedPost
                }).ToList();

            _result.Add(query);
            }
        }


        public List<Object> AdvanceSearch(SearchFilter model)
        {
            GetResults list = null;
            if (model.SearchProfile == true)
            {
                list += SearchProfile;
            }
            if (model.SearchCategory == true)
            {
                list += SearchCategory;
            }
            if (model.SearchCodeExample == true)
            {
                list += SearchExample;
            }
            list.Invoke(model.SearchRequest);

            return _result;

        }
       /* public IEnumerable<MasterList> GetSearch(SearchString str)
        {
            GetResults list = null;
                list += SearchExample;

            return list(str.SearchRequest);
        }*/


    }
}
