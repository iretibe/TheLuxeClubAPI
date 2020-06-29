using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using TheLuxe.Data;
using TheLuxe.Entity;
using TheLuxe.Helper;
using TheLuxe.Model;
using TheLuxe.Model.ProductCategoryGroup;
using TheLuxe.RepositoryInterface;

namespace TheLuxe.Repository
{
    public class CategoryGroupRepo : ICategoryGroupRepo
    {
        private TheLuxeClubContext _context;

        public CategoryGroupRepo(TheLuxeClubContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task AddCategoryGroupAsync(string CategoryGroupName)
        {
            _context.Database.OpenConnection();
            using (DbCommand cmdObj = _context.Database.GetDbConnection().CreateCommand())
            {
                cmdObj.CommandText = "uspInsertCategoryGroup";
                cmdObj.CommandType = CommandType.StoredProcedure;
                cmdObj.Parameters.Add(new SqlParameter("@CategoryGroupName", CategoryGroupName));

                await cmdObj.ExecuteScalarAsync();
            }
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public async Task DeleteCategoryGroupAsync(tblCategoryGroup entity)
        {
            _context.Database.OpenConnection();
            using (DbCommand cmdObj = _context.Database.GetDbConnection().CreateCommand())
            {
                cmdObj.CommandText = "uspDeleteCategoryGroup";
                cmdObj.CommandType = CommandType.StoredProcedure;
                cmdObj.Parameters.Add(new SqlParameter("@CategoryGroupID", entity.CategoryGroupID));

                await cmdObj.ExecuteScalarAsync();
            }
        }

        public async Task<IEnumerable<uspSelectCategoryGroup>> GetCategoryGroupAsync()
        {
            List<uspSelectCategoryGroup> lst;
            _context.Database.OpenConnection();
            using (DbCommand cmdObj = _context.Database.GetDbConnection().CreateCommand())
            {
                cmdObj.CommandText = "uspSelectCategoryGroup";
                cmdObj.CommandType = CommandType.StoredProcedure;

                using (var drObj = await cmdObj.ExecuteReaderAsync())
                {
                    lst = drObj.MapToList<uspSelectCategoryGroup>();
                }
            }
            return lst;
        }

        public tblCategoryGroup GetProductCategoryGroup(int ProductCategoryGroupId)
        {
            return _context.tblCategoryGroup.FirstOrDefault(c => c.CategoryGroupID == ProductCategoryGroupId);
        }

        public Task<IEnumerable<uspSelectShiftReportByCategoryGroup>> GetShiftReportByCategoryGroupAsync(int ShiftID)
        {
            throw new NotImplementedException();
        }

        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }

        public async Task UpdateCategoryGroupAsync(int CategoryGroupID, string CategoryGroupName)
        {
            _context.Database.OpenConnection();
            using (DbCommand cmdObj = _context.Database.GetDbConnection().CreateCommand())
            {
                cmdObj.CommandText = "uspUpdateCategoryGroup";
                cmdObj.CommandType = CommandType.StoredProcedure;
                cmdObj.Parameters.Add(new SqlParameter("@CategoryGroupID", CategoryGroupID));
                cmdObj.Parameters.Add(new SqlParameter("@CategoryGroupName", CategoryGroupName));

                await cmdObj.ExecuteScalarAsync();
            }
        }
    }
}
