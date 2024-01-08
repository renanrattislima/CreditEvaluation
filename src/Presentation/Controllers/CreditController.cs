namespace CreditEvaluation.Controllers
{
    using Application.Interfaces;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Presentation.Mappers;
    using Presentation.Models.Request;
    using Presentation.Models.Response;

    [ApiController]
    [Route("api/credit")]
    public class CreditController : ControllerBase
    {
        private readonly ICreditProcessor creditProcessor;

        /// <summary>
        /// Initializes a new instance of the <see cref="CreditController"/> class.
        /// </summary>
        /// <param name="creditProcessor">Credit Processor Interface.</param>
        public CreditController(ICreditProcessor creditProcessor)
        {
            this.creditProcessor = creditProcessor;
        }

        /// <summary>
        /// Evaluate a credit request based on Amount, Credit Type, Installment Count and Due Date.
        /// </summary>
        /// <param name="request">Credit request model.</param>
        /// <returns>Credit Reponse (Status, Total Amount and Total Fees).</returns>
        [HttpPost("process")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Application.DTOs.CreditResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<CreditResponse> ProcessCredit([FromBody] CreditRequest request)
        {
            var response = this.creditProcessor.ProcessCreditAsync(request.ToApplication());

            return this.Ok(response.Result);
        }
    }
}
