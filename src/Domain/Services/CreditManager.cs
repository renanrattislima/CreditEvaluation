namespace Domain.Services
{
    using System;
    using System.Threading.Tasks;
    using Domain.Interfaces;
    using Domain.Models;
    using Domain.Models.Enums;

    public class CreditManager : ICreditManager
    {
        public Task<CreditResponse> ProcessCreditAsync(CreditRequest request)
        {
            // Perform validations
            if (request.Amount > 1000000)
            {
                return Task.FromResult(new CreditResponse { Status = "Denied", TotalAmount = 0, TotalFees = 0 });
            }

            if (request.InstallmentCount < 5 || request.InstallmentCount > 72)
            {
                return Task.FromResult(new CreditResponse { Status = "Denied", TotalAmount = 0, TotalFees = 0 });
            }

            if (request.CreditType == CreditType.Business && request.Amount < 15000)
            {
                return Task.FromResult(new CreditResponse { Status = "Denied", TotalAmount = 0, TotalFees = 0 });
            }

            DateTime minDueDate = DateTime.Now.AddDays(15);
            DateTime maxDueDate = DateTime.Now.AddDays(40);

            if (request.FirstDueDate < minDueDate || request.FirstDueDate > maxDueDate)
            {
                return Task.FromResult(new CreditResponse { Status = "Denied", TotalAmount = 0, TotalFees = 0 });
            }

            // Calculate Fees
            decimal FeeRate = this.GetFeeRate(request.CreditType);
            decimal FeeAmount = request.Amount * FeeRate / 100;
            decimal totalAmountWithFees = request.Amount + FeeAmount;

            // Return results
            return Task.FromResult(
                new CreditResponse
                {
                    Status = "Approved",
                    TotalAmount = totalAmountWithFees,
                    TotalFees = FeeAmount,
                });
        }

        private decimal GetFeeRate(CreditType creditType)
        {
            switch (creditType)
            {
                case CreditType.Direct:
                    return 2;
                case CreditType.PayRoll:
                    return 1;
                case CreditType.Business:
                    return 5;
                case CreditType.Personal:
                    return 3;
                case CreditType.RealEstate:
                    return 9;
                default:
                    return 0;
            }
        }
    }
}
