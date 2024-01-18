using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterimProject.Services
{
    public class UserAuthenticationService : IUserAuthenticationService
    {
        private readonly InProjectDBContext _projectDBContext;
        public UserAuthenticationService(InProjectDBContext projectDBContext)
        {
            this._projectDBContext = projectDBContext;
        }

        public bool ValidateUser(string username, string password)
        {
            var user = this._projectDBContext.SiteAdmins.SingleOrDefault(user => user.UserName.Equals(username) && user.Password.Equals(password));
            if (user == null)
                return false;
            return true;
        }
    }
}