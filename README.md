# 🌟 **Expense Tracker Application**

This is an ASP.NET Core MVC-based application for tracking personal expenses. It supports functionalities such as managing expenses, viewing categories, and assigning expenses to specific users.

---

## 🏗️ **Project Structure**

The application is structured using a **Database First** approach and separates logic into distinct layers:

1. **📂 Database Project**:  
   - Contains database models generated from the existing database using EF Core's Database First approach.  
   - Includes the `AppDbContext` for managing database interactions.

2. **💻 Domain Project**:  
   - Contains the business logic and DTOs.  
   - `ExpenseService` handles expense-related operations, including fetching expenses and categories.

3. **🖥️ Presentation Layer**:  
   - Implements controllers and Razor views (`cshtml` files) for user interactions.

---

## 🔑 **Key Features**

### 💵 Expense Management  
- **Get All Expenses**: Fetches a list of all recorded expenses.  
- **Get User-Specific Expenses**: Filters expenses by user ID.  
- **Add Expense**: Adds a new expense to the database.  

### 🗂️ Category Management  
- Fetches all available categories for expenses.  

---

## 🛠️ **Technology Stack**

- **📚 Framework**: ASP.NET Core MVC  
- **💾 Database**: SQL Server (Entity Framework Core, Database First)  
- **✅ Testing**: xUnit with InMemory Database for unit tests  
- **💻 Languages**: C#, Razor (cshtml)  

---

## ⚙️ **Service Layer: ExpenseService**

The `ExpenseService` class provides business logic for managing expenses:

### ✨ Methods
1. **`GetAllExpenses()`**: Returns all expenses ordered by date (most recent first).  
2. **`GetExpensesByUser(int userId)`**: Fetches expenses for a specific user.  
3. **`AddExpense(Expense expense)`**: Adds a new expense to the database.  
4. **`GetCategories()`**: Returns all available expense categories.  

---

## 🧪 **Unit Tests**

The application uses **xUnit** for unit testing. EF Core's **InMemoryDatabase** is utilized for testing the database operations.

### 📋 Example Test Cases
1. **Get All Expenses**: Verifies that all expenses are returned from the database.  
2. **Get Expenses By User**: Ensures only user-specific expenses are fetched.  
3. **Add Expense**: Confirms that an expense is correctly added to the database.  
4. **Get Categories**: Verifies the retrieval of all categories.  

---