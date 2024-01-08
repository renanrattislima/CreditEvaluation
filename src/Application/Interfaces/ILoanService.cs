namespace Application.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Domain.Models;

    public interface ILoanService
    {
        Task<bool> CreateLoan(Loan LoanDetails);

        Task<IEnumerable<Loan>> GetAllLoans();

        Task<Loan> GetLoanById(Guid LoanId);
    }
}
