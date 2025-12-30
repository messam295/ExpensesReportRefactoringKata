using System;
using System.Collections.Generic;
using System.Linq;

namespace expensereport_csharp;

public class ExpenseReport
{
    const string MealOverExpensesMarker = "X";
    
    public void PrintReport(List<Expense> expenses)
    {

        Console.WriteLine("Expenses " + DateTime.Now);
            
        foreach (Expense expense in expenses)
        {
            var lineText = expense.GetExpenseName() + "\t" + expense.amount + "\t";

            if (expense.IsOverBudget())
                lineText += MealOverExpensesMarker;
            
            Console.WriteLine(lineText);
        }

        Console.WriteLine("Meal expenses: " + CalculateMealExpenses(expenses));
        Console.WriteLine("Total expenses: " + CalculateTotal(expenses));
    }

    private int CalculateTotal(List<Expense> expenses)
    {
        return expenses.Sum(e => e.amount);
    }

    private int CalculateMealExpenses(List<Expense> expenses)
    {
        return expenses
            .Where(e => e.IsMeal())
            .Sum(e => e.amount);
    }
}