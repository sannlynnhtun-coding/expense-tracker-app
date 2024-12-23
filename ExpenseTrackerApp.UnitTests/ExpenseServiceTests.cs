using ExpenseTrackerApp.Database.AppDbContextModels;
using ExpenseTrackerApp.Domain.Services;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTrackerApp.UnitTests
{
    public class ExpenseServiceTests
    {
        private AppDbContext GetInMemoryDbContext()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "TestExpenseDb")
                .Options;

            return new AppDbContext(options);
        }

        [Fact]
        public void GetAllExpenses_ShouldReturnAllExpenses()
        {
            // Arrange
            var context = GetInMemoryDbContext();

            context.Categories.AddRange(
                new Category { Id = 1, Name = "Food1" },
                new Category { Id = 2, Name = "Travel1" }
            );
            context.SaveChanges();

            context.Expenses.AddRange(
                new Expense { CategoryId = 1, UserId = 1, Amount = 50.00m, Date = new DateOnly(2024, 12, 01) },
                new Expense { CategoryId = 2, UserId = 2, Amount = 120.00m, Date = new DateOnly(2024, 12, 15) }
            );
            context.SaveChanges();

            var service = new ExpenseService(context);

            // Act
            var result = service.GetAllExpenses();

            // Assert
            Assert.Equal(2, result.Count());
        }

        [Fact]
        public void GetExpensesByUser_ShouldReturnExpensesForSpecificUser()
        {
            // Arrange
            var context = GetInMemoryDbContext();
            context.Categories.AddRange(
                new Category { Id = 3, Name = "Food1" },
                new Category { Id = 4, Name = "Travel1" }
            );
            context.SaveChanges();

            context.Expenses.AddRange(
                new Expense { CategoryId = 3, UserId = 1, Amount = 50.00m, Date = new DateOnly(2024, 12, 01) },
                new Expense { CategoryId = 4, UserId = 2, Amount = 120.00m, Date = new DateOnly(2024, 12, 15) },
                new Expense { CategoryId = 1, UserId = 3, Amount = 50.00m, Date = new DateOnly(2024, 12, 15) }
            );
            context.SaveChanges();

            var service = new ExpenseService(context);

            // Act
            var result = service.GetExpensesByUser(3);

            // Assert
            Assert.Single(result);
            Assert.Equal(50.00m, result.First().Amount);
        }

        [Fact]
        public void AddExpense_ShouldAddExpenseToDatabase()
        {
            // Arrange
            var context = GetInMemoryDbContext();
            var service = new ExpenseService(context);

            var newExpense = new Expense
            {
                UserId = 1,
                Amount = 100.00m,
                Date = new DateOnly(2024, 12, 20)
            };

            // Act
            service.AddExpense(newExpense);

            // Assert
            Assert.Equal(1, context.Expenses.Count());
            Assert.Equal(100.00m, context.Expenses.First().Amount);
        }

        [Fact]
        public void GetCategories_ShouldReturnAllCategories()
        {
            // Arrange
            var context = GetInMemoryDbContext();
            context.Categories.AddRange(
                new Category { Name = "Food" },
                new Category { Name = "Travel" }
            );
            context.SaveChanges();

            var service = new ExpenseService(context);

            // Act
            var result = service.GetCategories();

            // Assert
            Assert.Equal(6, result.Count());
            Assert.Contains(result, c => c.Name == "Food");
            Assert.Contains(result, c => c.Name == "Travel");
        }
    }
}