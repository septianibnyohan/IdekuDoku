using System;
using System.Collections.Generic;

namespace IdekuDoku.Domain.Entities;

public partial class SetupConfigurationCc
{
    public int Id { get; set; }

    public string? MerchantName { get; set; }

    public string? ClientId { get; set; }

    public string? SharedKey { get; set; }

    public string? Environment { get; set; }
}
