namespace Presentation.Mappers
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using Application.Mappers;
    using Domain.Models;
    using Presentation.Models.Request;
    using Presentation.Models.Response;

    [ExcludeFromCodeCoverage]
    public static class LoanMapper
    {

        public static Loan ToDomain(this LoanRequest request)
        {
            if (request is null)
            {
                return null;
            }

            var response = new Loan
            {
                Id = Guid.NewGuid(),
                ClientId = request.ClientId,
                CreditType = request.CreditType.ToDomain(),
                LastDueDate = request.LastDueDate,
                InstallmentsQuantity = request.InstallmentsQuantity,
                TotalAmount = request.TotalAmount,
            };

            return response;
        }

    }
}