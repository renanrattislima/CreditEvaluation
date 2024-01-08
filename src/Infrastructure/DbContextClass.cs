namespace Infrastructure
{
    using Domain.Models;
    using Domain.Models.Enums;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

    public class DbContextClass : DbContext
    {
        public DbContextClass()
        {
        }

        public DbContextClass(DbContextOptions<DbContextClass> contextOptions) : base(contextOptions)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>()
                .HasKey(c => c.Id);

            modelBuilder.Entity<Loan>()
                .HasKey(f => f.Id);

            modelBuilder.Entity<Loan>()
                .HasOne(f => f.Client)
                .WithMany(c => c.Loans)
                .HasForeignKey(f => f.ClientId);

            modelBuilder.Entity<Installment>()
                .HasKey(i => i.Id);

            modelBuilder.Entity<Installment>()
                .HasOne(i => i.Loan)
                .WithMany(f => f.Installments)
                .HasForeignKey(i => i.LoanId);

            modelBuilder
               .Entity<Loan>()
               .Property(d => d.CreditType)
               .HasConversion(new EnumToStringConverter<CreditType>());

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Client> Clients { get; set; }

        public DbSet<Loan> Loans { get; set; }

        public DbSet<Installment> Installments { get; set; }
    }
}
