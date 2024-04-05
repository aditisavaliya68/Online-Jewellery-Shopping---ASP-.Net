using System;
using System.Collections.Generic;

namespace Gemify.Models;

public partial class Product
{
    public int ProductId { get; set; }

    public string? Name { get; set; }

    public decimal? Price { get; set; }

    

    public string? ImageUrl { get; set; } 

   
}
