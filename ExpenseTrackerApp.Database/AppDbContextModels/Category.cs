using System;
using System.Collections.Generic;

namespace ExpenseTrackerApp.Database.AppDbContextModels;

public partial class Category
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public virtual ICollection<Expense> Expenses { get; set; } = new List<Expense>();
}
