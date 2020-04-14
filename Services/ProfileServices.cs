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
                ProfileId = _userId,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                UserName = model.UserName
            };

            _context.Profiles.Add(entity);
            return _context.SaveChanges() == 1;
        }
        //Test to ensure the id exist if not they are redirected to index.
        public bool GetByIdTest(string id)
        {
            var entity = _context.Profiles.Find(id);
            if (entity == null)
                return false;

            return true;
        }
        //Get By Id
        public ProfileDetail GetById(string id)
        {
            var entity = _context.Profiles.Find(id);
            var model = new ProfileDetail
            {
                ProfileId = _userId,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                UserName = entity.UserName,
                Email = entity.Email,
            };

            return model;
        }

        public bool ProfileEdit(ProfileUpdate model)
        {
            var query =
                _context
                .Profiles
                .Single(j => j.ProfileId == model.ProfileId);

            query.ProfileId = model.ProfileId;
            query.UserName = model.UserName;
            query.FirstName = model.FirstName;
            query.LastName = model.LastName;
            query.Email = model.Email;

            return _context.SaveChanges() == 1;
        }

        //A User can not delete their profile but they can delete their entire account.
        public bool DeleteAccount(string id)
        {
            var entity = _context.Users.Find(id);

            if (entity == null)
                return false;

           _context.Users.Remove(entity);

            return _context.SaveChanges() == 1;

        }

    }
}
