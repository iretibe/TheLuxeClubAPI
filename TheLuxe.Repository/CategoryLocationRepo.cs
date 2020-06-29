﻿using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Threading.Tasks;
using TheLuxe.Data;
using TheLuxe.Helper;
using TheLuxe.Model;
using TheLuxe.RepositoryInterface;

namespace TheLuxe.Repository
{
    public class CategoryLocationRepo : ICategoryLocationRepo
    {
        private TheLuxeClubContext _context;

        public CategoryLocationRepo(TheLuxeClubContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task AddProductCategoryLocationAsync(string ProductCategoryLocationName, string PrinterName)
        {
            _context.Database.OpenConnection();
            using (DbCommand cmdObj = _context.Database.GetDbConnection().CreateCommand())
            {
                cmdObj.CommandText = "uspInsertProductCategoryLocation";
                cmdObj.CommandType = CommandType.StoredProcedure;
                cmdObj.Parameters.Add(new SqlParameter("@ProductCategoryLocationName", ProductCategoryLocationName));
                cmdObj.Parameters.Add(new SqlParameter("@PrinterName", PrinterName));

                await cmdObj.ExecuteScalarAsync();
            }
        }

        public async Task CheckProductCategoryLocationInOrderAsync(int OrderID, int ProductCategoryLocationID, int ComputerLocationID)
        {
            _context.Database.OpenConnection();
            using (DbCommand cmdObj = _context.Database.GetDbConnection().CreateCommand())
            {
                cmdObj.CommandText = "uspCheckProductCategoryLocationInOrder";
                cmdObj.CommandType = CommandType.StoredProcedure;
                cmdObj.Parameters.Add(new SqlParameter("@OrderID", OrderID));
                cmdObj.Parameters.Add(new SqlParameter("@ProductCategoryLocationID", ProductCategoryLocationID));
                cmdObj.Parameters.Add(new SqlParameter("@ComputerLocationID", ComputerLocationID));

                await cmdObj.ExecuteScalarAsync();
            }
        }

        public async Task DeleteProductCategoryLocationAsync(int ProductCategoryLocationID)
        {
            _context.Database.OpenConnection();
            using (DbCommand cmdObj = _context.Database.GetDbConnection().CreateCommand())
            {
                cmdObj.CommandText = "uspDeleteProductCategoryLocation";
                cmdObj.CommandType = CommandType.StoredProcedure;
                cmdObj.Parameters.Add(new SqlParameter("@ProductCategoryLocationID", ProductCategoryLocationID));

                await cmdObj.ExecuteScalarAsync();
            }
        }

        public async Task<IEnumerable<uspSelectNoOfProductCategoryLocation>> GetNoOfProductCategoryLocationAsync()
        {
            List<uspSelectNoOfProductCategoryLocation> lst;
            _context.Database.OpenConnection();
            using (DbCommand cmdObj = _context.Database.GetDbConnection().CreateCommand())
            {
                cmdObj.CommandText = "uspSelectNoOfProductCategoryLocation";
                cmdObj.CommandType = CommandType.StoredProcedure;

                using (var drObj = await cmdObj.ExecuteReaderAsync())
                {
                    lst = drObj.MapToList<uspSelectNoOfProductCategoryLocation>();
                }
            }
            return lst;
        }

        public async Task<IEnumerable<uspSelectProductCategoryLocation>> GetProductCategoryLocationAsync()
        {
            List<uspSelectProductCategoryLocation> lst;
            _context.Database.OpenConnection();
            using (DbCommand cmdObj = _context.Database.GetDbConnection().CreateCommand())
            {
                cmdObj.CommandText = "uspSelectProductCategoryLocation";
                cmdObj.CommandType = CommandType.StoredProcedure;

                using (var drObj = await cmdObj.ExecuteReaderAsync())
                {
                    lst = drObj.MapToList<uspSelectProductCategoryLocation>();
                }
            }
            return lst;
        }

        public async Task UpdateProductCategoryLocationAsync(int ProductCategoryLocationID, string ProductCategoryLocationName, string PrinterName)
        {
            _context.Database.OpenConnection();
            using (DbCommand cmdObj = _context.Database.GetDbConnection().CreateCommand())
            {
                cmdObj.CommandText = "uspUpdateProductCategoryLocation";
                cmdObj.CommandType = CommandType.StoredProcedure;
                cmdObj.Parameters.Add(new SqlParameter("@ProductCategoryLocationID", ProductCategoryLocationID));
                cmdObj.Parameters.Add(new SqlParameter("@ProductCategoryLocationName", ProductCategoryLocationName));
                cmdObj.Parameters.Add(new SqlParameter("@PrinterName", PrinterName));

                await cmdObj.ExecuteScalarAsync();
            }
        }
    }
}
