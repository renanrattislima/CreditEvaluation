namespace Application.Mappers
{
    using System.Diagnostics.CodeAnalysis;
    using Application.DTOs;
    using Application.DTOs.Enums;

    [ExcludeFromCodeCoverage]
    public static class CreditMapper
    {
        public static Domain.Models.CreditRequest ToDomain(this CreditRequest request)
        {
            if (request is null)
            {
                return null;
            }

            var aggregateDomain = new Domain.Models.CreditRequest
            {
                Amount = request.Amount,
                FirstDueDate = request.FirstDueDate,
                InstallmentCount = request.InstallmentCount,
                CreditType = request.CreditType.ToDomain(),
            };

            return aggregateDomain;
        }

        public static Domain.Models.Enums.CreditType ToDomain(this CreditType type) => type switch
        {
            CreditType.Direct => Domain.Models.Enums.CreditType.Direct,
            CreditType.PayRoll => Domain.Models.Enums.CreditType.PayRoll,
            CreditType.Business => Domain.Models.Enums.CreditType.Business,
            CreditType.Personal => Domain.Models.Enums.CreditType.Personal,
            CreditType.RealEstate => Domain.Models.Enums.CreditType.RealEstate,
            _ => Domain.Models.Enums.CreditType.Direct,
        };

        public static CreditRequest ToDomain(Domain.Models.CreditRequest request)
        {
            if (request is null)
            {
                return null;
            }

            var aggregateDomain = new CreditRequest
            {
                Amount = request.Amount,
                FirstDueDate = request.FirstDueDate,
                InstallmentCount = request.InstallmentCount,
                CreditType = request.CreditType.ToApplication(),
            };

            return aggregateDomain;
        }

        public static CreditType ToApplication(this Domain.Models.Enums.CreditType type) => type switch
        {
            Domain.Models.Enums.CreditType.Direct => CreditType.Direct,
            Domain.Models.Enums.CreditType.PayRoll => CreditType.PayRoll,
            Domain.Models.Enums.CreditType.Business => CreditType.Business,
            Domain.Models.Enums.CreditType.Personal => CreditType.Personal,
            Domain.Models.Enums.CreditType.RealEstate => CreditType.RealEstate,
            _ => CreditType.Direct,
        };

        public static Domain.Models.CreditResponse ToDomain(this CreditResponse creditResponse)
        {
            if (creditResponse is null)
            {
                return null;
            }

            var response = new Domain.Models.CreditResponse
            {
                Status = creditResponse.Status,
                TotalAmount = creditResponse.TotalAmount,
                TotalFees = creditResponse.TotalFees,
            };

            return response;
        }

        public static CreditResponse ToApplication(this Domain.Models.CreditResponse creditResponse)
        {
            if (creditResponse is null)
            {
                return null;
            }

            var response = new CreditResponse
            {
                Status = creditResponse.Status,
                TotalAmount = creditResponse.TotalAmount,
                TotalFees = creditResponse.TotalFees,
            };

            return response;
        }
    }
}