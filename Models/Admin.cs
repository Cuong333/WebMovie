using System;
using System.Collections.Generic;

namespace WebMovie.Models;

public partial class Admin
{
    public int AdminId { get; set; }

    public string? AdminName { get; set; }

    public string? PassWord { get; set; }
}
