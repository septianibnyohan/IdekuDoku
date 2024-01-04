using System;
using System.Collections.Generic;

namespace IdekuDoku.Domain.Entities;

public partial class TransactionCc
{
    public int Id { get; set; }

    public string? InvoiceNumber { get; set; }

    public decimal? Amount { get; set; }

    public string? Status { get; set; }

    public string? UrlPaymentPage { get; set; }
}
