namespace Domain.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Domain.Models;

    public interface IClientRepository : IGenericRepository<Client>
    {
        Task<IEnumerable<Client>> GetAllWithRelationships();

        Task<bool> GetByCpfAsync(string cpf);

        Task<Client> GetByIdWithRelationships(Guid id);

        Task<IEnumerable<Client>> GetClientsInSPWithMoreThan60PercentPaidAsync();

        Task<IEnumerable<Client>> GetFirstFourClientsWithOldInstallmentsAsync();
    }
}
