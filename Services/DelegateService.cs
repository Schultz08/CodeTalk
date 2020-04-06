using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;

namespace Services
{
    public class DelegateService
    {
        private readonly ApplicationDbContext _context;
        public delegate DelegateService GetuserId(int userId);

        public DelegateService(string userId)
        {
            _context = new ApplicationDbContext();
            

        }


    }
}
