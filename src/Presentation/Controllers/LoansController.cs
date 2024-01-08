namespace CreditEvaluation.Controllers
{
    using System;
    using System.Threading.Tasks;
    using Application.Interfaces;
    using Microsoft.AspNetCore.Mvc;
    using Presentation.Mappers;
    using Presentation.Models.Request;

    [Route("api/[controller]")]
    [ApiController]
    public class LoansController : ControllerBase
    {
        public readonly ILoanService _LoanService;
        public readonly IClientService _ClientService;

        /// <summary>
        /// Initializes a new instance of the <see cref="LoansController"/> class.
        /// </summary>
        /// <param name="loanService">Loan Service Interface.</param>
        /// <param name="clientService">Client Service Interface.</param>
        public LoansController(ILoanService loanService, IClientService clientService)
        {
            _LoanService = loanService;
            _ClientService = clientService;
        }

        /// <summary>
        /// Get the list of Loan.
        /// </summary>
        /// <returns>List of All Loans</returns>
        [HttpGet]
        public async Task<IActionResult> GetLoanList()
        {
            var loanDetailsList = await this._LoanService.GetAllLoans();

            return loanDetailsList != null
                ? this.Ok(loanDetailsList)
                : this.NotFound();
        }

        /// <summary>
        /// Get Loan by id.
        /// </summary>
        /// <param name="loanId">Identifier of the Loan.</param>
        /// <returns>Loan.</returns>
        [HttpGet("{LoanId}")]
        public async Task<IActionResult> GetLoanById(Guid loanId)
        {
            var loanDetailsList = await this._LoanService.GetLoanById(loanId);

            return loanDetailsList != null
                ? this.Ok(loanDetailsList)
                : this.NotFound();
        }

        /// <summary>
        /// Add a new Loan
        /// </summary>
        /// <param name="loanRequest">Loan request model (Credit Type,Total Amount, InstallmentsQuantity and LastDueDate)</param>
        /// <returns>bool.</returns>
        [HttpPost]
        public async Task<IActionResult> CreateLoan(LoanRequest loanRequest)
        {

            var clientExists = await _ClientService.GetClientById(loanRequest.ClientId);

            if (clientExists == null)
            {
                return this.BadRequest("Client does not exists on database");
            }

            var isLoanCreated = await _LoanService.CreateLoan(loanRequest.ToDomain());

            return isLoanCreated
                ? this.Ok(isLoanCreated)
                : this.BadRequest();
        }
    }
}
