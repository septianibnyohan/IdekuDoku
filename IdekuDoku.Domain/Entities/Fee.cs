using System;
using System.Collections.Generic;

namespace IdekuDoku.Domain.Entities;

public partial class Fee
{
    public int FeeId { get; set; }

    public int? PaymentMethodId { get; set; }

    public decimal? MinAmount { get; set; }

    public decimal? MaxAmount { get; set; }

    public decimal? FeePercentage { get; set; }

    public decimal? FeeFixed { get; set; }

    public virtual PaymentMethod? PaymentMethod { get; set; }
}
