﻿using Data;
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
            using (var context = new ApplicationDbContext())
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

        public void SearchCategoryByName(string str)
        {
            using (var context = new ApplicationDbContext())
            {

                var query =
                    context
                    .Categories
                    .Where(e => e.CategoryName.Contains(str))
                    .Select(e => new CategoryDetail
                    {
                        CategoryId = e.CategoryId,
                        CategoryName = e.CategoryName,
                        CategoryDescription = e.CategoryDescription
                    }).ToList();

                _result.Add(query);
            }
        }
        public void SearchExampleByTitle(string str)
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
                        CategoryName = example.Category.CategoryName,
                        UserName = example.Profile.UserName,
                        Title = example.Title,
                        ExampleDescription = example.ExampleDescription,
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
                list += SearchCategoryByName;
            }
            if (model.SearchCodeExample == true)
            {
                list += SearchExampleByTitle;
            }
            list.Invoke(model.SearchRequest);

            return _result;
        }



        //Temp Data quick fix
        public Category QuickFix(string str)
        {
            using (var context = new ApplicationDbContext())
            {
                Category query = null;

                try
                {
                    query =
                    context
                    .Categories
                    .Single(e => e.CategoryName.Contains(str));
                    return query;
                }
                catch
                {
                    return null;
                }
            }
        }
    }
}
