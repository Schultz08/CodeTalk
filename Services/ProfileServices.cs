using Data;
using Models.ProfileModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ProfileServices
    {
        private readonly ApplicationDbContext _context;
        private readonly string _userId;

        public ProfileServices(string userId)
        {
            _context = new ApplicationDbContext();
            _userId = userId;
        }

        //Post
        public bool CreateProfile(ProfileCreate model)
        {
            Profile entity = new Profile
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                UserName = model.UserName
            };

            _context.Profiles.Add(entity);
            return _context.SaveChanges() == 1;
        }
        //Get By Id
        public ProfileDetail GetByID(string id)
        {
           var entity = _context.Profiles.Find(id);
            if (entity == null)
                return null;
            var model = new ProfileDetail
            {
                ProfileId = entity.ProfileId,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                UserName = entity.UserName,
                Email = entity.Email,
                AverageRating = entity.AverageRating
            };

            return model;
        }


    }
}
