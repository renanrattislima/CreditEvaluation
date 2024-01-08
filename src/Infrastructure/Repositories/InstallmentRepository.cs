namespace Infrastructure.Repositories
{
    using Domain.Interfaces;
    using Domain.Models;

    public class InstallmentRepository : GenericRepository<Installment>, IInstallmentRepository
    {
        public InstallmentRepository(DbContextClass dbContext) : base(dbContext)
        {

        }
    }
}
