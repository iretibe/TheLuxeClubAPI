using System;
using TheLuxe.Data;
using TheLuxe.RepositoryInterface;

namespace TheLuxe.Repository
{
    public class ProductProtocolRepo : IProductProtocolRepo
    {
        private TheLuxeClubContext _context;

        public ProductProtocolRepo(TheLuxeClubContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
    }
}
