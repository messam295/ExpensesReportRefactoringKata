using System;
using System.Collections.Generic;
using System.Linq;

namespace expensereport_csharp;

public class ExpenseReport
{
    const string MealOverExpensesMarker = "X";
    
    public void PrintReport(List<Expense> expenses)
    {
        PrintHeader();
            
        PrintLines(expenses);

        PrintFooter(expenses);
    }

    private void PrintLines(List<Expense> expenses)
    {
        foreach (Expense expense in expenses)
        {
            PrintLine(FormatLineText(expense));
        }
    }

    private static void PrintHeader()
    {
        Console.WriteLine("Expenses " + DateTime.Now);
    }

    private void PrintFooter(List<Expense> expenses)
    {
        Console.WriteLine("Meal expenses: " + CalculateMealExpenses(expenses));
        Console.WriteLine("Total expenses: " + CalculateTotal(expenses));
    }

    private void PrintLine(string lineText)
    {
        Console.WriteLine(lineText);
    }

    private static string FormatLineText(Expense expense)
    {
        var lineText = expense.GetExpenseName() + "\t" + expense.amount + "\t";

        if (expense.IsOverBudget())
            lineText += MealOverExpensesMarker;
        
        return lineText;
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