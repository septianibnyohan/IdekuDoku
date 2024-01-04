using System;
using System.Collections.Generic;

namespace IdekuDoku.Domain.Entities;

public partial class PaymentMethod
{
    public int MethodId { get; set; }

    public string MethodName { get; set; } = null!;

    public string? Description { get; set; }

    public bool? IsActive { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual ICollection<Fee> Fees { get; } = new List<Fee>();

    public virtual ICollection<Transaction1> Transaction1s { get; } = new List<Transaction1>();
}
