

using System.ComponentModel.DataAnnotations;

namespace TodoApplication.Models;

public partial class Category
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Category name is required.")]
    public string CategoryName { get; set; } = null!;

    public int? UserId { get; set; }

    public virtual ICollection<TaskDetail> TaskDetails { get; set; } = new List<TaskDetail>();

    public virtual User? User { get; set; }
}
