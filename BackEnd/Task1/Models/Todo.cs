using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Task1.Models;

public partial class Todos
{
    
    public Guid Id { get; set; }

    public string? TaskName { get; set; }

    public string? TaskStatus { get; set; }

    public string? Note { get; set; }

    public string? PriorityFlag { get; set; }

    public DateTime? Due { get; set; }
}
