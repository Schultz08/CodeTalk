using Data;
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
        public bool CreateExample(ExampleCreate model)
        {
            using(var context = new ApplicationDbContext())
            {
                var entity = new CodeExample
                {
                    CodeExampleId = model.CodeExampleId,
                    CategoryId = model.CategoryId,
                    ProfileId = model.ProfileId,
                    ExampleCode = model.ExampleCode,
                    ExampleDiscription = model.ExampleDiscription,
                    InitialPost = DateTime.UtcNow
                };

                context.CodeExamples.Add(entity);
                return context.SaveChanges() == 1;
            }
        }

        public ExampleDetail GetById (int id)
        {
            using(var context = new ApplicationDbContext())
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
                        ExampleCode = entity.ExampleCode,
                        ExampleDiscription = entity.ExampleDiscription,
                        AverageRating = entity.AverageRating,
                        InitialPost = entity.InitialPost,
                        EditedPost = entity.EditedPost

                    };
            }
        }
    }
}
