using System;
using System.Collections.Generic;

namespace WebMovie.Models;

public partial class Actor
{
    public int ActorId { get; set; }

    public string? ActorName { get; set; }

    public DateOnly? Dob { get; set; }

    public string? Nationaly { get; set; }
}
