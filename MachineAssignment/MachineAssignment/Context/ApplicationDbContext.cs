using MachineAssignment.Models;
using MachineAssignment.Models.Dto;
using Microsoft.EntityFrameworkCore;

namespace MachineAssignment.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<LoginUserDto>()
            .HasNoKey()
            .ToView("Login");
        }

        public DbSet<Category> tbl_mstCategory { get; set; }
        public DbSet<Products> tbl_Products { get; set; }
        public DbSet<Employees> tbl_Employees { get; set; }
        public DbSet<MachineAssignment.Models.Dto.LoginUserDto>? LoginUserDto { get; set; }

    }
}
