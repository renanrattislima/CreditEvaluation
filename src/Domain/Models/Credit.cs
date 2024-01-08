using System;
using Domain.Models.Enums;

namespace Domain.Models
{
    /// <summary>
    /// Credit Object.
    /// </summary>
    public class Credit
    {
        public decimal Value { get; private set; }

        public CreditType Type { get; private set; }

        public int NumberOfParcels { get; private set; }

        public DateTime DueDate { get; private set; }
    }
}
