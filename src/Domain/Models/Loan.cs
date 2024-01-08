﻿namespace Domain.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text.Json.Serialization;
    using Domain.Models.Enums;

    public class Loan
    {
        public Guid Id { get; set; }

        public Guid ClientId { get; set; }

        public CreditType CreditType { get; set; }

        public decimal TotalAmount { get; set; }

        public int InstallmentsQuantity { get; set; }

        public DateTime LastDueDate { get; set; }

        [JsonIgnore]
        public Client Client { get; set; }

        public List<Installment> Installments { get; set; }
    }
}
