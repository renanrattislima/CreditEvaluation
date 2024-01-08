namespace Application.Interfaces
{
    using System.Threading.Tasks;
    using Application.DTOs;

    public interface ICreditProcessor
    {
        Task<CreditResponse> ProcessCreditAsync(CreditRequest request);
    }
}
