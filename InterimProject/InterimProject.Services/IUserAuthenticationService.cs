using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterimProject.Services
{
    public interface IUserAuthenticationService
    {
        bool ValidateUser(string username, string password);
    }
}
