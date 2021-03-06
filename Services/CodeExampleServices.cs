﻿using Data;
using Models.CodeExampleModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CodeExampleServices
    {
        private readonly string _userId;

        public CodeExampleServices(string userId)
        {
            _userId = userId;
        }

        public bool CreateExample(ExampleCreate model)
        {
            using (var context = new ApplicationDbContext())
            {
                var entity = new CodeExample
                {
                    CodeExampleId = model.CodeExampleId,
                    CategoryId = model.CategoryId,
                    ProfileId = _userId,
                    Title = model.Title,
                    ExampleCode = model.ExampleCode,
                    ExampleDescription = model.ExampleDescription,
                    InitialPost = DateTimeOffset.Now,
                    EditedPost = null
                };

                context.CodeExamples.Add(entity);

                return context.SaveChanges() == 1;
            }
        }

        public bool GetByIdTest(int id)
        {
            using (var context = new ApplicationDbContext())
            {
                var entity =
                     context
                    .CodeExamples
                    .Find(id);
                if (entity == null)
                    return false;

                return true;
            }
        }
        public ExampleDetail GetById(int id)
        {
            using (var context = new ApplicationDbContext())
            {
                var entity =
                    context
                    .CodeExamples
                    .Single(j => j.CodeExampleId == id);

                return
                    new ExampleDetail
                    {
                        CodeExampleId = entity.CodeExampleId,
                        CategoryId = entity.CategoryId,
                        ProfileId = entity.ProfileId,
                        Title = entity.Title,
                        UserName = entity.Profile.UserName,
                        CategoryName = entity.Category.CategoryName,
                        ExampleCode = entity.ExampleCode,
                        ExampleDescription = entity.ExampleDescription,
                        InitialPost = entity.InitialPost,
                        EditedPost = entity.EditedPost

                    };
            }
        }

        public IEnumerable<ExampleDetail> GetAllExamples()
        {
            using (var context = new ApplicationDbContext())
            {
                var query =
                    context
                    .CodeExamples
                    .Where(j => j.CodeExampleId == j.CodeExampleId)
                    .Select
                    (j => new ExampleDetail
                    {
                        CodeExampleId = j.CodeExampleId,
                        ProfileId = j.ProfileId,
                        CategoryId = j.CategoryId,
                        Title = j.Title,
                        UserName = j.Profile.UserName,
                        CategoryName = j.Category.CategoryName,
                        ExampleCode = j.ExampleCode,
                        ExampleDescription = j.ExampleDescription,
                        InitialPost = j.InitialPost,
                        EditedPost = j.EditedPost

                    });

                return query.ToArray();
            }
        }

        public IEnumerable<ExampleDetail> GetAllExamplesByUserId(string id)
        {
            using (var context = new ApplicationDbContext())
            {
                var query =
                    context
                    .CodeExamples
                    .Where(j => j.ProfileId == id)
                    .Select
                    (j => new ExampleDetail
                    {
                        CodeExampleId = j.CodeExampleId,
                        ProfileId = j.ProfileId,
                        CategoryId = j.CategoryId,
                        Title = j.Title,
                        UserName = j.Profile.UserName,
                        CategoryName = j.Category.CategoryName,
                        ExampleCode = j.ExampleCode,
                        ExampleDescription = j.ExampleDescription,
                        InitialPost = j.InitialPost,
                        EditedPost = j.EditedPost

                    });

                return query.ToArray();
            }
        }
        public bool UpdateExample(ExampleUpdate model)
        {
            using (var context = new ApplicationDbContext())
            {
                var entity =
                    context
                    .CodeExamples
                    .Single(j => j.CodeExampleId == model.CodeExampleId);

                entity.CodeExampleId = model.CodeExampleId;
                entity.CategoryId = model.CategoryId;
                entity.ProfileId = model.ProfileId;
                entity.Title = model.Title;
                entity.ExampleCode = model.ExampleCode;
                entity.ExampleDescription = model.ExampleDescription;
                entity.EditedPost = DateTimeOffset.Now;

                return context.SaveChanges() == 1;
            }
        }

        public bool DeleteExample(int id)
        {
            using (var context = new ApplicationDbContext())
            {
                var entity = context.CodeExamples.Single(j => j.CodeExampleId == id);
                if (entity == null)
                    return false;
                var service = new OnDelete();

                context.CodeExamples.Remove(entity);

                return context.SaveChanges() == 1;
            }
        }
    }
}
