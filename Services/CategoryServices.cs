using Data;
using Models.CategoryModels;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CategoryServices
    {
        public bool CreateCategory(CategoryCreate model)
        {
            Category entity = new Category
            {
                CategoryName = model.CategoryName,
                CategoryDiscription = model.CategoryDiscription
            };

            using (var context = new ApplicationDbContext())
            {
                context.Categories.Add(entity);
                return context.SaveChanges() == 1;
            }
        }

        public IEnumerable<CategoryDetail> GetCategories()
        {
            using (var context = new ApplicationDbContext())
            {
                var query =
                context.Categories
                    .Where(j => j.CategoryId == j.CategoryId)
                    .Select(j => new CategoryDetail
                    {
                        CategoryId = j.CategoryId,
                        CategoryName = j.CategoryName,
                        CategoryDiscription = j.CategoryDiscription
                    });
                return query.ToArray();
            }
        }

        public bool GetByIdTest(int id)
        {
            using (var context = new ApplicationDbContext())
            {
                var entity = context.Categories.Find(id);

                if (entity == null)
                    return false;

                return true;
            }
        }
        public CategoryDetail GetById(int id)
        {
            using(var context = new ApplicationDbContext())
            {
                var entity = context.Categories.Find(id);

                if (entity == null)
                    return null;
                var detail = new CategoryDetail
                {
                    CategoryId = entity.CategoryId,
                    CategoryName = entity.CategoryName,
                    CategoryDiscription = entity.CategoryDiscription
                };

                return detail;

            }
        }

        public bool UpdateCategory(CategoryUpdate model)
        {
            using (var context = new ApplicationDbContext())
            {
                var entity =
                    context
                    .Categories
                    .Single(j => j.CategoryId == model.CategoryId);

                entity.CategoryId = model.CategoryId;
                entity.CategoryName = model.CategoryName;
                entity.CategoryDiscription = model.CategoryDiscription;
                return context.SaveChanges() == 1;
            }
        }
        
        public bool DeleteCategory(int id)
        {
            using (var context = new ApplicationDbContext())
            {
                var content = context.Categories.Find(id);
                context.Categories.Remove(content);
                return context.SaveChanges() == 1;
            }
        }
    }
}
