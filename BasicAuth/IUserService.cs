using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicAuth
{
    public interface IUserService
    {
        Task<bool> Authenticate(string username, string password);
        Task<string> GetRole(string username);
        Task<string> GetIdentifier(string username);
    }
}
