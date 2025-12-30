using System;
using System.Collections.Generic;
using System.Linq;

namespace expensereport_csharp;

public class ExpenseReport
{
    public void PrintReport(List<Expense> expenses)
    {
        Console.WriteLine("Expenses " + DateTime.Now);
            
        foreach (Expense expense in expenses)
        {
            String mealOverExpensesMarker =
                IsBreakfastOverBudget(expense) ||
                IsDinnerOverBudget(expense)
                    ? "X"
                    : " ";
            
            Console.WriteLine(expense.GetExpenseName() + "\t" + expense.amount + "\t" + mealOverExpensesMarker);
        }

        Console.WriteLine("Meal expenses: " + CalculateMealExpenses(expenses));
        Console.WriteLine("Total expenses: " + expenses.Sum(e => e.amount));
    }

    private static bool IsDinnerOverBudget(Expense expense)
    {
        return expense.type == ExpenseType.Breakfast && expense.amount > 1000;
    }

    private static bool IsBreakfastOverBudget(Expense expense)
    {
        return expense.type == ExpenseType.Dinner && expense.amount > 5000;
    }

    private int CalculateMealExpenses(List<Expense> expenses)
    {
        return expenses
            .Where(e => e.IsMeal())
            .Sum(e => e.amount);
    }
}