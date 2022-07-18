using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tess_React_ASPnet.DAL.Interfaces;
using Test_React_ASPnet.Domain.Entity;

namespace Tess_React_ASPnet.DAL.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _db;

        public UserRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public Task<bool> Create(User entity)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> Delete(User entity)
        {
            throw new System.NotImplementedException();
        }

        #region FindAll
        public async Task<ICollection<User>> FindAll()
        {
            return await _db.Users.ToListAsync();
        }
        #endregion

        public Task<User> FindById(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> Save()
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> Update(User entity)
        {
            throw new System.NotImplementedException();
        }
        
    }
}
