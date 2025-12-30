using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using expensereport_csharp;
using Xunit;

namespace Tests;

public class Tests
{
    [Theory]
    [ClassData(typeof(TestDataGenerator))]
    public void Test(List<Expense> expenses, List<string> expectedLines)
    {
        var report = new ExpenseReport();

        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);

        // Act
        report.PrintReport(expenses);

        // Assert
        var output = stringWriter.ToString();

        foreach (var line in expectedLines)
        {
            Assert.Contains(line, output);
        }
    }
}


public class TestDataGenerator : IEnumerable<object[]>
{
    private readonly IEnumerable<object[]> _data = GetTestData();

    public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    private static IEnumerable<object[]> GetTestData()
    {
        yield return Case1();
        yield return Case2();
        yield return Case3();
    }

    private static object[] Case1()
    {
        var expenses = new List<Expense>();
        var expected = new List<string>()
        {
            "Meal expenses: 0",
            "Total expenses: 0"
        };
        
        return 
        [
            expenses,
            expected
        ];
    }

    private static object[] Case2()
    {
        var expenses = new List<Expense>
        {
            new() { type = ExpenseType.Breakfast, amount = 1000 },
            new() { type = ExpenseType.Dinner, amount = 5000 },
            new() { type = ExpenseType.Car_Rental, amount = 2000 },
        };

        var expected = new List<string>
        {
            "Dinner\t5000\t",
            "Breakfast\t1000\t",
            "Car Rental\t2000\t",
            "Meal expenses: 6000",
            "Total expenses: 8000"
        };

        return 
        [
            expenses,
            expected
        ];
    }
    
    private static object[] Case3()
    {
        var expenses = new List<Expense>
        {
            new() { type = ExpenseType.Breakfast, amount = 1001 },
            new() { type = ExpenseType.Dinner, amount = 5001 },
            new() { type = ExpenseType.Car_Rental, amount = 2000 },
        };
        
        var expected = new List<string>
        {
            "Dinner\t5001\tX",
            "Breakfast\t1001\tX",
            "Car Rental\t2000\t",
            "Meal expenses: 6002",
            "Total expenses: 8002"
        };

        return 
        [
            expenses,
            expected
        ];
    }
}