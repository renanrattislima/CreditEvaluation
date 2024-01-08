namespace Domain.Interfaces
{
    using System.Threading.Tasks;
    using Domain.Models;

    public interface ICreditManager
    {
        Task<CreditResponse> ProcessCreditAsync(CreditRequest request);
    }
}
