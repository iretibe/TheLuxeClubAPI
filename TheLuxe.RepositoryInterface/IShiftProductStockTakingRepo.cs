using System.Collections.Generic;
using System.Threading.Tasks;
using TheLuxe.Model.ShiftProductStockTaking;

namespace TheLuxe.RepositoryInterface
{
    public interface IShiftProductStockTakingRepo
    {
        Task AddShiftProductStockLevelAsync(int ShiftID, int CompanyLocationID);
        Task AddShiftProductStockTakingAsync(int ShiftID);
        Task<IEnumerable<uspSelectShiftProductStockTaking>> GetShiftProductStockTaking(int CompanyLocationID, int ShiftID, string ProductName);
        Task UpdateShiftProductStockLevelAsync(int ShiftID, int CompanyLocationID);
        Task UpdateShiftProductStockTakingAsync(int ProductID, int PackageID, double StockLevelAfter, int UserID, int CompanyLocationID, int ShiftID, string Remark);
    }
}
