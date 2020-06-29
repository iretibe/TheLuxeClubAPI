using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TheLuxe.RepositoryInterface
{
    public interface IShiftRepo
    {
        Task CheckIfShiftHasBeenEndedAsync(int ShiftID);
    }
}
