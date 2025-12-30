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
            String mealOverExpensesMarker = expense.IsOverBudget() ? "X" : " ";
            
            Console.WriteLine(expense.GetExpenseName() + "\t" + expense.amount + "\t" + mealOverExpensesMarker);
        }

        Console.WriteLine("Meal expenses: " + CalculateMealExpenses(expenses));
        Console.WriteLine("Total expenses: " + expenses.Sum(e => e.amount));
    }
    
    private int CalculateMealExpenses(List<Expense> expenses)
    {
        return expenses
            .Where(e => e.IsMeal())
            .Sum(e => e.amount);
    }
}