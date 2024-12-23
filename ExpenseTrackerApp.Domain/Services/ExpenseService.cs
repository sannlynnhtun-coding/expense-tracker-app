using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpenseTrackerApp.Database.AppDbContextModels;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTrackerApp.Domain.Services
{
    public class ExpenseService
    {
        private readonly AppDbContext _context;

        public ExpenseService(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Expense> GetExpensesByUser(int userId)
        {
            return _context.Expenses.Where(e => e.UserId == userId).ToList();
        }

        public void AddExpense(Expense expense)
        {
            _context.Expenses.Add(expense);
            _context.SaveChanges();
        }

        public IEnumerable<Expense> GetAllExpenses()
        {
            return _context.Expenses
                .Include(x => x.Category)
                .OrderByDescending(e => e.Date)
                .ToList();
        }

        public IEnumerable<Category> GetCategories()
        {
            return _context.Categories
                .OrderBy(c => c.Name)
                .ToList();
        }
    }
}
