using BasicAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TeendokLista.API.Repositories
{
    public class TesztFelhasznaloRepository : IUserService
    {
        public Task<bool> Authenticate(string username, string password)
        {
            if (username == "Bence" && password == "jelszo")
            {
                return Task.FromResult(true);
            }
            return Task.FromResult(false);
        }

        public Task<string> GetIdentifier(string username)
        {
            return Task.FromResult("Bence");
        }

        public Task<string> GetRole(string username)
        {
            return Task.FromResult("Adminisztrátor");
        }
    }
}
