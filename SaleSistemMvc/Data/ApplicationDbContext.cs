using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SaleSistemMvc.Models;

namespace SaleSistemMvc.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<UserAccount> UserAccount { get; set; } = default!;

        public DbSet<Product> Product { get; set; } = default!;
        public DbSet<SaleSistemMvc.Models.Sale> Sale { get; set; } = default!;
    }
}
