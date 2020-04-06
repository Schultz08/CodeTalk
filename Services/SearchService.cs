using Data;
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
        private readonly ApplicationDbContext _context;
        public delegate IEnumerable<MasterList> GetResults(string str);

        public IEnumerable<MasterList> SearchProfile(string str)
        {

            var query =
                _context
                .Profiles
                .Where(e => e.UserName.Contains(str))
                .Select(profile => new MasterList
                {
                    ProfileId = profile.ProfileId,
                    UserName = profile.UserName,
                    PostCount = profile.UserRating.Count
                });

            return query.ToArray();
        }

        public IEnumerable<MasterList> SearchCategory(string str)
        {
            var query =
                _context
                .Categories
                .Where(e => e.CategoryName.Contains(str))
                .Select(category => new MasterList
                {
                    CategoryId = category.CategoryId,
                    CategoryName = category.CategoryName,
                    CategoryDiscription = category.CategoryDiscription
                });
            return query.ToArray();
        }
        public IEnumerable<MasterList> SearchExample(string str)
        {
            var query =
                _context
                .CodeExamples
                .Where(e => e.Title.Contains(str))
                .Select(example => new MasterList
                {
                    CodeExampleId = example.CodeExampleId,
                    ProfileId = example.ProfileId,
                    CategoryId = example.CategoryId,
                    UserName = example.Profile.UserName,
                    ExampleTitle = example.Title,
                    ExampleDiscription = example.ExampleDiscription,
                    InitialPost = example.InitialPost,
                    EditedPost = example.EditedPost
                }).ToArray();
            return query;
        }


        public IEnumerable<MasterList> AdvanceSearch(string str, SearchFilter model)
        {
            GetResults list = null;
            if (model.SearchProfile == true)
            {
                list += SearchProfile;
            }
            if (model.SearchCodeExample == true)
            {
                list += SearchExample;
            }
            if (model.SearchCategory == true)
            {
                list += SearchCategory;
            }

            return list(str);
        }
        public IEnumerable<MasterList> GetSearch(string str)
        {
            GetResults list = null;
                list += SearchProfile;

                list += SearchExample;

                list += SearchCategory;
            return list(str);
        }


    }
}
