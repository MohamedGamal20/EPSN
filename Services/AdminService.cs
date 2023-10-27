using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EPSN.Services
{
        public interface IAdminService
        {
            bool Login(string Email, string Password);
            bool ChangePassword(string Email, string Password);
            bool ForgotPassword(String Email);
        }
        public class AdminServive : IAdminService
        {
            public static CoursesDBEntities Context { get; set; }
            public AdminServive()
            {
                Context = new CoursesDBEntities();
            }

            public bool Login(string Email, string Password)
            {
               return Context.Admins.Where(a => a.E_mail == Email && a.Password == Password).Any();
            }
            public bool ChangePassword(string Email, string Password)
            {
                throw new NotImplementedException();
            }

            public bool ForgotPassword(string Email)
            {
                throw new NotImplementedException();
            }

        }
}