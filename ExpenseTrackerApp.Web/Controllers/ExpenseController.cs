using ExpenseTrackerApp.Database.AppDbContextModels;
using ExpenseTrackerApp.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ExpenseTrackerApp.Web.Controllers
{
    public class ExpenseController : Controller
    {
        private readonly ExpenseService _expenseService;

        public ExpenseController(ExpenseService expenseService)
        {
            _expenseService = expenseService;
        }

        public IActionResult Index()
        {
            var expenses = _expenseService.GetAllExpenses();
            return View(expenses);
        }

        public IActionResult Create()
        {
            ViewBag.Categories = new SelectList(_expenseService.GetCategories(), "Id", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult Create(Expense expense)
        {
            if (ModelState.IsValid)
            {
                _expenseService.AddExpense(expense);
                return RedirectToAction(nameof(Index));
            }
            return View(expense);
        }
    }
}
