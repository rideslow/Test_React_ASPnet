using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tess_React_ASPnet.DAL.Interfaces;
using Test_React_ASPnet.Domain.Entity;

namespace Tess_React_ASPnet.DAL.Repositories
{
    public class ToolRepository : IToolRepository
    {
        private readonly ApplicationDbContext _db;

        public ToolRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public Task<bool> Create(Tool entity)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> Delete(Tool entity)
        {
            throw new System.NotImplementedException();
        }

        #region FindAll
        public async Task<ICollection<Tool>> FindAll()
        {
            return await _db.Tools.ToListAsync();
        }
        #endregion

        public Task<Tool> FindById(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> Save()
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> Update(Tool entity)
        {
            throw new System.NotImplementedException();
        }

    }
}
