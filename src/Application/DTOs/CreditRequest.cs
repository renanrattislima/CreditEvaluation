namespace Application.DTOs
{
    using System;
    using Application.DTOs.Enums;

    /// <summary>
    /// Request to evaluate a credit line.
    /// </summary>
    public class CreditRequest
    {
        /// <summary>
        ///  Value requested on the credit.
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// The type of credit requested.
        /// </summary>
        public CreditType CreditType { get; set; }

        /// <summary>
        /// The number of installments that the credit will be paid.
        /// </summary>
        public int InstallmentCount { get; set; }

        /// <summary>
        /// Date of the first due date.
        /// </summary>
        public DateTime FirstDueDate { get; set; }
    }
}
