namespace Presentation.Models.Request
{
    using System;
    using Application.DTOs.Enums;

    public class LoanRequest
    {
        public Guid ClientId { get; set; }

        public CreditType CreditType { get; set; }

        public decimal TotalAmount { get; set; }

        public int InstallmentsQuantity { get; set; }

        public DateTime LastDueDate { get; set; }
    }
}
