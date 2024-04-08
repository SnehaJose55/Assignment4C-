using System;
using System.Collections.Generic;

namespace Assignment4.Models.Entities;

public partial class TransactionHistory
{
    public int TransactionId { get; set; }

    public int AccountId { get; set; }

    public DateTime? TransactionDate { get; set; }

    public decimal? Amount { get; set; }

    public string? Description { get; set; }
}
