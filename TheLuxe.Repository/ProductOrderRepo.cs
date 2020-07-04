using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Threading.Tasks;
using TheLuxe.Data;
using TheLuxe.Helper;
using TheLuxe.Model.ProductOrder;
using TheLuxe.RepositoryInterface;

namespace TheLuxe.Repository
{
    public class ProductOrderRepo : IProductOrderRepo
    {
        private TheLuxeClubContext _context;

        public ProductOrderRepo(TheLuxeClubContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<uspSelectProductOrderWithShift>> GetProductOrderWithShiftAsync(int FromShiftID, 
            int ToShiftID, int ProductID, int UserID, int ProductCategoryID, int OrderStatusID, int CustomerID, 
            int ProductCategoryLocationID, int CategoryGroupID, int CompanyLocationID)
        {
            List<uspSelectProductOrderWithShift> lst;
            _context.Database.OpenConnection();
            using (DbCommand cmdObj = _context.Database.GetDbConnection().CreateCommand())
            {
                cmdObj.CommandText = "uspSelectProductOrderWithShift";
                cmdObj.CommandType = CommandType.StoredProcedure;
                cmdObj.Parameters.Add(new SqlParameter("@FromShiftID", FromShiftID));
                cmdObj.Parameters.Add(new SqlParameter("@ToShiftID", ToShiftID));
                cmdObj.Parameters.Add(new SqlParameter("@ProductID", ProductID));
                cmdObj.Parameters.Add(new SqlParameter("@UserID", UserID));
                cmdObj.Parameters.Add(new SqlParameter("@ProductCategoryID", ProductCategoryID));
                cmdObj.Parameters.Add(new SqlParameter("@OrderStatusID", OrderStatusID));
                cmdObj.Parameters.Add(new SqlParameter("@CustomerID", CustomerID));
                cmdObj.Parameters.Add(new SqlParameter("@ProductCategoryLocationID", ProductCategoryLocationID));
                cmdObj.Parameters.Add(new SqlParameter("@CategoryGroupID", CategoryGroupID));
                cmdObj.Parameters.Add(new SqlParameter("@CompanyLocationID", CompanyLocationID));

                using (var drObj = await cmdObj.ExecuteReaderAsync())
                {
                    lst = drObj.MapToList<uspSelectProductOrderWithShift>();
                }
            }
            return lst;
        }
    }
}
