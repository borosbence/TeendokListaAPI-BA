using BasicAuth;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using TeendokLista.API.Models;

namespace TeendokLista.API.Repositories
{
    public class FelhasznaloRepository : IUserService
    {
        private TeendokContext _context;
        public FelhasznaloRepository(TeendokContext teendokContext)
        {
            _context = teendokContext;
        }

        public async Task<bool> Authenticate(string username, string password)
        {
            // Ezzel a felhasználónévvel létezik e rekord
            var dbUser = await _context.felhasznalok.SingleOrDefaultAsync(x => x.Felhasznalonev.Equals(username));
            if (dbUser != null)
            {
                // Begépelt jelszó titkosítása, ezt el kell menteni az adatbázisba!
                // var passwordHash = BCrypt.Net.BCrypt.HashPassword(password);
                // Jelszó ellenőrzése
                bool verified = BCrypt.Net.BCrypt.Verify(password, dbUser.Jelszo);
                if (verified)
                {
                    return true;
                }
            }
            return false;
        }

        public async Task<string> GetRole(string username)
        {
            var dbUser = await _context.felhasznalok
                .Include(x => x.Szerepkor)
                .SingleOrDefaultAsync(x => x.Felhasznalonev.Equals(username));
            if (dbUser != null)
            {
                return dbUser.Szerepkor.Megnevezes;
            }
            return string.Empty;
        }
    }
}
