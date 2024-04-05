using System;
using System.Collections.Generic;

namespace Gemify.Models;

public partial class Category
{
    public int CategoryId { get; set; }

    public string? Name { get; set; }

    public string? ImageUrl { get; set; }
}
