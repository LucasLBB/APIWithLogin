using System.Collections.Generic;
using System.Linq;
using Login.Models;
using Login.Repositories.Interfaces;

namespace Login.Repositories
{
    public class UserRepository : IUserRepository
    {

        public readonly AppSetingsDBContext _context;

        public UserRepository(AppSetingsDBContext context)
        { 

            _context = context;
        
        }

        public async Task<User?> GetUserAsync(string email, string password)
        {
            var user = _context.Users.Where(x => x.Email.ToLower() == email.ToLower() && x.Password == password).FirstOrDefault();

            if(user == null)
            {
                return null;
            }
            return user;
        }
    }
}
