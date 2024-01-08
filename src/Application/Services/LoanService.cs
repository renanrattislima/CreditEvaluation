namespace Application.Services
{
    using System;
    using System.Collections.Generic;
    using System.Numerics;
    using System.Threading.Tasks;
    using Application.Interfaces;
    using Application.Mappers;
    using Domain.Interfaces;
    using Domain.Models;

    public class LoanService : ILoanService
    {
        public IUnitOfWork _unitOfWork;
        public ICreditManager _creditManger;

        public LoanService(IUnitOfWork unitOfWork, ICreditManager creditManger)
        {
            _unitOfWork = unitOfWork;
            _creditManger = creditManger;
        }

        public async Task<bool> CreateLoan(Loan loan)
        {
            if (loan != null)
            {

                // Validate on credit service with this Loan is approved 
                var creditEvaluation = await _creditManger.ProcessCreditAsync(
                    new CreditRequest
                    {
                        Amount = loan.TotalAmount,
                        FirstDueDate = DateTime.UtcNow.AddDays(31),
                        CreditType = loan.CreditType,
                        InstallmentCount = loan.InstallmentsQuantity,
                    });

                if (creditEvaluation.Status == "Denied")
                {
                    return false;
                }
                else
                {
                    loan.TotalAmount = creditEvaluation.TotalAmount;

                    await this._unitOfWork.Loans.Add(loan);

                    for (int i = 0; i < loan.InstallmentsQuantity; i++)
                    {
                        Installment installment = new Installment
                        {
                            Id = Guid.NewGuid(),
                            LoanId = loan.Id,
                            InstallmentAmount = Math.Abs(loan.TotalAmount / loan.InstallmentsQuantity),
                            InstallmentNumber = i + 1,
                            DueDate = DateTime.Now.AddMonths(i + 1),
                        };

                        await this._unitOfWork.Installments.Add(installment);
                    }

                    var result = this._unitOfWork.Save();

                    return result > 0;
                }


            }

            return false;
        }

        public async Task<IEnumerable<Loan>> GetAllLoans()
        {
            var LoanList = await _unitOfWork.Loans.GetAll();
            return LoanList;
        }

        public async Task<Loan> GetLoanById(Guid LoanId)
        {
            if (LoanId != null)
            {
                var Loan = await _unitOfWork.Loans.GetById(LoanId);
                if (Loan != null)
                {
                    return Loan;
                }
            }
            return null;
        }

    }
}
