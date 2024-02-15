using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TodoApplication.Models;

public partial class User
{
    public int Id { get; set; }

    public string? UserName { get; set; }

    [Required(ErrorMessage = "Email is required.")]
    [EmailAddress(ErrorMessage = "Invalid email format.")]
    public string Email { get; set; } = null!;

    [Required(ErrorMessage = "Password is required.")]
    [MinLength(6, ErrorMessage = "Password must be at least 6 characters long.")]
   
    public string Password { get; set; } = null!;

    public virtual ICollection<Category> Categories { get; set; } = new List<Category>();

    public virtual ICollection<TaskDetail> TaskDetails { get; set; } = new List<TaskDetail>();
}
