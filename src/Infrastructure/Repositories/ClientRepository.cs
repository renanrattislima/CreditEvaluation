namespace Infrastructure.Repositories
{
    using Domain.Interfaces;
    using Domain.Models;
    using Microsoft.EntityFrameworkCore;

    public class ClientRepository : GenericRepository<Client>, IClientRepository
    {
        public ClientRepository(DbContextClass dbContext) : base(dbContext)
        {
        }

        public async Task<bool> GetByCpfAsync(string cpf)
        {
            return await this._dbContext.Clients.AnyAsync(x => x.CPF == cpf);
        }

        public async Task<IEnumerable<Client>> GetAllWithRelationships()
        {
            return await this._dbContext.Clients.Include(c => c.Loans)
                 .ThenInclude(f => f.Installments).ToListAsync();
        }

        public async Task<Client> GetByIdWithRelationships(Guid id)
        {
            return await this._dbContext.Clients
             .Where(c => c.Id == id)
             .Include(c => c.Loans)
                 .ThenInclude(f => f.Installments)
             .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Client>> GetClientsInSPWithMoreThan60PercentPaidAsync()
        {
            return await this._dbContext.Clients
                .FromSqlRaw(
                    @"SELECT C.Name, C.CPF
                  FROM Clients C
                  INNER JOIN Financings F ON C.Id = F.ClientId
                  WHERE C.UF = 'SP'
                    AND (SELECT COUNT(*) FROM Installments P WHERE P.FinancingId = F.Id AND P.PaymentDate IS NOT NULL) /
                        (SELECT COUNT(*) FROM Installments P WHERE P.FinancingId = F.Id) > 0.6")
                .ToListAsync();
        }

        public async Task<IEnumerable<Client>> GetFirstFourClientsWithOldInstallmentsAsync()
        {
            return await this._dbContext.Clients
                .FromSqlRaw(
                    @"SELECT TOP 4 C.Name, C.CPF
                          FROM Clients C
                          INNER JOIN Financings F ON C.Id = F.ClientId
                          INNER JOIN Installments P ON F.Id = P.FinancingId
                          WHERE P.DueDate > GETDATE() AND P.PaymentDate IS NULL AND DATEDIFF(day, P.DueDate, GETDATE()) > 5")
                .ToListAsync();
        }
    }
}
