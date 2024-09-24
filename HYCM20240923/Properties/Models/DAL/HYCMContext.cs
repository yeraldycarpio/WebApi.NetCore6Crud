using HYCM20240923.Properties.Models.EN;
using Microsoft.EntityFrameworkCore;

namespace HYCM20240923.Properties.Models.DAL
{
    public class HYCMContext: DbContext
    {
        public HYCMContext(DbContextOptions<HYCMContext> options) : base(options)
        {
        }

        public DbSet<ProductHYCM> ProductsHYCM { get; set; }
    }
}

