namespace Domain.Interfaces
{
    using System;

    public interface IUnitOfWork : IDisposable
    {
        IClientRepository Clients { get; }

        ILoanRepository Loans { get; }

        IInstallmentRepository Installments { get; }

        int Save();
    }
}
