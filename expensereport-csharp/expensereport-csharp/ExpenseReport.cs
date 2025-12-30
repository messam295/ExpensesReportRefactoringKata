using System;
using System.Collections.Generic;

namespace expensereport_csharp;

public class ExpenseReport
{
    public void PrintReport(List<Expense> expenses)
    {
        int total = 0;
        int mealExpenses = 0;

        Console.WriteLine("Expenses " + DateTime.Now);
            
        foreach (Expense expense in expenses)
        {
            if (expense.type == ExpenseType.Dinner || expense.type == ExpenseType.Breakfast)
            {
                mealExpenses += expense.amount;
            }

            String expenseName = "";
            expenseName = GetExpenseName(expense, expenseName);

            String mealOverExpensesMarker =
                expense.type == ExpenseType.Dinner && expense.amount > 5000 ||
                expense.type == ExpenseType.Breakfast && expense.amount > 1000
                    ? "X"
                    : " ";

            Console.WriteLine(expenseName + "\t" + expense.amount + "\t" + mealOverExpensesMarker);

            total += expense.amount;
        }

        Console.WriteLine("Meal expenses: " + mealExpenses);
        Console.WriteLine("Total expenses: " + total);
    }

    private string GetExpenseName(Expense expense, string expenseName)
    {
        switch (expense.type)
        {
            case ExpenseType.Dinner:
                expenseName = "Dinner";
                break;
            case ExpenseType.Breakfast:
                expenseName = "Breakfast";
                break;
            case ExpenseType.Car_Rental:
                expenseName = "Car Rental";
                break;
        }

        return expenseName;
    }
}