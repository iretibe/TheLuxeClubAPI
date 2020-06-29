using System.Collections.Generic;
using System.Threading.Tasks;
using TheLuxe.Entity;
using TheLuxe.Model;
using TheLuxe.Model.ProductCategoryGroup;

namespace TheLuxe.RepositoryInterface
{
    public interface ICategoryGroupRepo
    {
        Task DeleteCategoryGroupAsync(tblCategoryGroup entity);
        Task AddCategoryGroupAsync(string CategoryGroupName);
        Task<IEnumerable<uspSelectCategoryGroup>> GetCategoryGroupAsync();
        Task<IEnumerable<uspSelectShiftReportByCategoryGroup>> GetShiftReportByCategoryGroupAsync(int ShiftID);
        Task UpdateCategoryGroupAsync(int CategoryGroupID, string CategoryGroupName);
        tblCategoryGroup GetProductCategoryGroup(int ProductCategoryGroupId);
        bool Save();
        void Commit();
    }
}
