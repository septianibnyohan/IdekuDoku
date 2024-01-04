using System;
using System.Collections.Generic;

namespace IdekuDoku.Domain.Entities;

public partial class Transaction1
{
    public int TransactionId { get; set; }

    public decimal Amount { get; set; }

    public int? PaymentMethodId { get; set; }

    public DateTime Timestamp { get; set; }

    public virtual PaymentMethod? PaymentMethod { get; set; }
}
