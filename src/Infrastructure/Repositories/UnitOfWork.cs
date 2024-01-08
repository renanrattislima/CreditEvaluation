namespace Infrastructure.Repositories
{
    using Domain.Interfaces;

    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContextClass _dbContext;

        public IClientRepository Clients { get; }

        public ILoanRepository Loans { get; }

        public IInstallmentRepository Installments { get; }

        public UnitOfWork(DbContextClass dbContext,
                            IClientRepository clientRepository,
                            ILoanRepository loanRepository,
                            IInstallmentRepository installmentRepository)
        {
            _dbContext = dbContext;
            Clients = clientRepository;
            Loans = loanRepository;
            Installments = installmentRepository;
        }

        public int Save()
        {
            return _dbContext.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _dbContext.Dispose();
            }
        }

    }
}
