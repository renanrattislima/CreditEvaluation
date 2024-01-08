namespace Application.Services
{
    using System;
    using System.Threading.Tasks;
    using Application.DTOs;
    using Application.Interfaces;
    using Application.Mappers;
    using Domain.Interfaces;

    /// <summary>
    /// Credit Processor Layer.
    /// </summary>
    public class CreditProcessor : ICreditProcessor
    {
        private readonly ICreditManager creditManager;

        public CreditProcessor(ICreditManager creditManager)
        {
            if (creditManager is null)
            {
                throw new ArgumentNullException(nameof(creditManager));
            }

            this.creditManager = creditManager;
        }

        public async Task<CreditResponse> ProcessCreditAsync(CreditRequest request)
        {
            if (request is null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            var result = await this.creditManager.ProcessCreditAsync(request.ToDomain());

            return result.ToApplication();
        }
    }
}
