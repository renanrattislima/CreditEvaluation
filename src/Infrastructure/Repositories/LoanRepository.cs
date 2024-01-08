namespace Infrastructure.Repositories
{
    using Domain.Interfaces;
    using Domain.Models;

    public class LoanRepository : GenericRepository<Loan>, ILoanRepository
    {
        public LoanRepository(DbContextClass dbContext) : base(dbContext)
        {

        }
    }
}
