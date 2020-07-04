using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Threading.Tasks;
using TheLuxe.Data;
using TheLuxe.Helper;
using TheLuxe.Model.ShiftProductStockTaking;
using TheLuxe.RepositoryInterface;

namespace TheLuxe.Repository
{
    public class ShiftProductStockTakingRepo : IShiftProductStockTakingRepo
    {
        private TheLuxeClubContext _context;

        public ShiftProductStockTakingRepo(TheLuxeClubContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async  Task AddShiftProductStockLevelAsync(int ShiftID, int CompanyLocationID)
        {
            _context.Database.OpenConnection();
            using (DbCommand cmdObj = _context.Database.GetDbConnection().CreateCommand())
            {
                cmdObj.CommandText = "uspInsertShiftProductStockLevel";
                cmdObj.CommandType = CommandType.StoredProcedure;
                cmdObj.Parameters.Add(new SqlParameter("@ShiftID", ShiftID));
                cmdObj.Parameters.Add(new SqlParameter("@CompanyLocationID", CompanyLocationID));

                await cmdObj.ExecuteScalarAsync();
            }
        }

        public async Task AddShiftProductStockTakingAsync(int ShiftID)
        {
            _context.Database.OpenConnection();
            using (DbCommand cmdObj = _context.Database.GetDbConnection().CreateCommand())
            {
                cmdObj.CommandText = "uspInsertShiftProductStockTaking";
                cmdObj.CommandType = CommandType.StoredProcedure;
                cmdObj.Parameters.Add(new SqlParameter("@ShiftID", ShiftID));

                await cmdObj.ExecuteScalarAsync();
            }
        }

        public async Task<IEnumerable<uspSelectShiftProductStockTaking>> GetShiftProductStockTaking(int CompanyLocationID, int ShiftID, string ProductName)
        {
            List<uspSelectShiftProductStockTaking> lst;
            _context.Database.OpenConnection();
            using (DbCommand cmdObj = _context.Database.GetDbConnection().CreateCommand())
            {
                cmdObj.CommandText = "uspSelectShiftProductStockTaking";
                cmdObj.CommandType = CommandType.StoredProcedure;
                cmdObj.Parameters.Add(new SqlParameter("@CompanyLocationID", CompanyLocationID));
                cmdObj.Parameters.Add(new SqlParameter("@ShiftID", ShiftID));
                cmdObj.Parameters.Add(new SqlParameter("@ProductName", ProductName));

                using (var drObj = await cmdObj.ExecuteReaderAsync())
                {
                    lst = drObj.MapToList<uspSelectShiftProductStockTaking>();
                }
            }
            return lst;
        }

        public async Task UpdateShiftProductStockLevelAsync(int ShiftID, int CompanyLocationID)
        {
            _context.Database.OpenConnection();
            using (DbCommand cmdObj = _context.Database.GetDbConnection().CreateCommand())
            {
                cmdObj.CommandText = "uspUpdateShiftProductStockLevel";
                cmdObj.CommandType = CommandType.StoredProcedure;
                cmdObj.Parameters.Add(new SqlParameter("@ShiftID", ShiftID));
                cmdObj.Parameters.Add(new SqlParameter("@CompanyLocationID", CompanyLocationID));

                await cmdObj.ExecuteScalarAsync();
            }
        }

        public async Task UpdateShiftProductStockTakingAsync(int ProductID, int PackageID, double StockLevelAfter, 
            int UserID, int CompanyLocationID, int ShiftID, string Remark)
        {
            _context.Database.OpenConnection();
            using (DbCommand cmdObj = _context.Database.GetDbConnection().CreateCommand())
            {
                cmdObj.CommandText = "uspUpdateShiftProductStockTaking";
                cmdObj.CommandType = CommandType.StoredProcedure;
                cmdObj.Parameters.Add(new SqlParameter("@ProductID", ProductID));
                cmdObj.Parameters.Add(new SqlParameter("@PackageID", PackageID));
                cmdObj.Parameters.Add(new SqlParameter("@StockLevelAfter", StockLevelAfter));
                cmdObj.Parameters.Add(new SqlParameter("@UserID", UserID));
                cmdObj.Parameters.Add(new SqlParameter("@CompanyLocationID", CompanyLocationID));
                cmdObj.Parameters.Add(new SqlParameter("@ShiftID", ShiftID));
                cmdObj.Parameters.Add(new SqlParameter("@Remark", Remark));

                await cmdObj.ExecuteScalarAsync();
            }
        }
    }
}
