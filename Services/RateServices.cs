using Data;
using Models.RateModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class RateServices
    {
        public bool CreateRating(RateCreate model)
        {
            var entity = new Rate
            {
                RateId = model.RateId,
                ProfileId = model.ProfileId,
                CodeExampleId = model.CodeExampleId,
                MyRating = model.MyRating,
                Review = model.Review

            };
            using(var context = new ApplicationDbContext())
            {
                context.Ratings.Add(entity);
                return context.SaveChanges() == 1;
            }
        }
    }
}
