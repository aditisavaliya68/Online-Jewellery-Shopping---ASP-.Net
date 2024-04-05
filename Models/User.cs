using System;
using System.Collections.Generic;

namespace Gemify.Models;

public partial class User
{
    public int UserId { get; set; }

    public string? Username { get; set; }

    public string? Mobile { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }
}
