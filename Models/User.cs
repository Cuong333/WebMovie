using System;
using System.Collections.Generic;

namespace WebMovie.Models;

public partial class User
{
    public int UsersId { get; set; }

    public string? UserName { get; set; }

    public string? PassWord { get; set; }

    public string? Email { get; set; }

    public string? Address { get; set; }
}
