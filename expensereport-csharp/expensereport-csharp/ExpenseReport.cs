using System;
using System.Collections.Generic;
using System.Linq;

namespace expensereport_csharp;

public class ExpenseReport
{
    public void PrintReport(List<Expense> expenses)
    {
        int mealExpenses = 0;

        Console.WriteLine("Expenses " + DateTime.Now);
            
        foreach (Expense expense in expenses)
        {
            if (expense.IsMeal())
            {
                mealExpenses += expense.amount;
            }

            String mealOverExpensesMarker =
                expense.type == ExpenseType.Dinner && expense.amount > 5000 ||
                expense.type == ExpenseType.Breakfast && expense.amount > 1000
                    ? "X"
                    : " ";
            
            Console.WriteLine(expense.GetExpenseName() + "\t" + expense.amount + "\t" + mealOverExpensesMarker);
        }

        Console.WriteLine("Meal expenses: " + mealExpenses);
        Console.WriteLine("Total expenses: " + expenses.Sum(e => e.amount));
    }
}