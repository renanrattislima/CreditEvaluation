﻿namespace Application.DTOs
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Cliente model.
    /// </summary>
    public class Client
    {
        public Guid Id { get; set; }

        public string CPF { get; set; }

        public string Name { get; set; }

        public string UF { get; set; }

        public string Cellphone { get; set; }

        public List<Loan> Loans { get; set; }
    }
}
