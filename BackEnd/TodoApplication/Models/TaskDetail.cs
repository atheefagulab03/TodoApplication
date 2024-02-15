using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TodoApplication.Models;

public partial class TaskDetail
{
    public int Id { get; set; }


    [Required(ErrorMessage = "Task name is required.")]
    public string TaskName { get; set; } = null!;

    public string? TaskStatus { get; set; }

    public string? Note { get; set; }

    public string? PriorityFlag { get; set; }

    public DateOnly? CreatedAt { get; set; }

    public string? Due { get; set; }

    public int? CategoryId { get; set; }

    public int? UserId { get; set; }

    public virtual Category? Category { get; set; }

    public virtual User? User { get; set; }
}
