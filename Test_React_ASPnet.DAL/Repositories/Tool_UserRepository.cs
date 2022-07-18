using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tess_React_ASPnet.DAL.Interfaces;
using Test_React_ASPnet.Domain.Entity;

namespace Tess_React_ASPnet.DAL.Repositories
{
    public class Tool_UserRepository : ITool_UserRepository
    {
        private readonly ApplicationDbContext _db;

        public Tool_UserRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        #region Create
        public async Task<bool> Create(Tool_User entity)
        {
            await _db.Tool_User.AddAsync(entity);
            return await Save();
        }
        #endregion

        #region Delete
        public async Task<bool> Delete(Tool_User entity)
        {
            _db.Tool_User.Remove(entity);
            return await Save();
        }
        #endregion

        #region FindAll
        public async Task<ICollection<Tool_User>> FindAll()
        {
            return await _db.Tool_User
                .Include(x => x.Tool)
                .Include(x => x.User)
                .ToListAsync();
        }
        #endregion

        #region FindById
        public async Task<Tool_User> FindById(int id)
        {
            return await _db.Tool_User
                .FirstOrDefaultAsync(x => x.Id == id);
        }
        #endregion

        #region Save
        public async Task<bool> Save()
        {
            return await _db.SaveChangesAsync() > 0;
        }
        #endregion

        #region Update
        public async Task<bool> Update(Tool_User entity)
        {
            _db.Tool_User.Update(entity);
            return await Save();
        }
        #endregion

        #region GetTool_UserGroupByToolId
        public async Task<ICollection<Tool_User>> GetTool_UserGroupByToolId()
        {
            return await _db.Tool_User
                .GroupBy(x => x.Tool_id)
                .Select(y => new Tool_User
                {
                    Tool_id = y.Key,
                    CountTools = y.Sum(dt => dt.CountTools)
                })
                .ToListAsync();
        }
        #endregion
    }
}
