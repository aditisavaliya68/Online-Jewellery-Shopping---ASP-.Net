using System;
using System.Collections.Generic;

namespace Gemify.Models;

public partial class Order
{
    public int OrderDetailsId { get; set; }

    public string? OrderNo { get; set; }

    public int? ProductId { get; set; }

    public int? Quantity { get; set; }

    public int? UserId { get; set; }

    public int? PaymentId { get; set; }
}
