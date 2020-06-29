using System.Threading.Tasks;

namespace TheLuxe.RepositoryInterface
{
    public interface ICustomerRepo
    {
        Task CheckIfIsOwnerAsync(int CustomerID);
        Task CheckIfItIsCreditCustomerAsync(int CustomerID);
        Task CheckIfProtocolSetupIsAppliedAsync(int CustomerID);
    }
}
