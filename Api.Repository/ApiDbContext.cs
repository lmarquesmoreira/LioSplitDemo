using Api.Domain;
using Microsoft.EntityFrameworkCore;

namespace Api.Repository
{
    public class ApiDbContext : DbContext
    {
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Seller> Sellers { get; set; }
        public DbSet<SellerTransaction> SellerTransactions { get; set; }

        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
        {
        }
    }
}
