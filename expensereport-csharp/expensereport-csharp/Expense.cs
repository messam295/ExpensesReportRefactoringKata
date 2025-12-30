namespace expensereport_csharp
{
    public class Expense
    {
        public ExpenseType type;
        public int amount;
        
        public string GetExpenseName() =>
            type switch
            {
                ExpenseType.Dinner => "Dinner",
                ExpenseType.Breakfast => "Breakfast",
                ExpenseType.Car_Rental => "Car Rental",
                _ => ""
            };
        
        public bool IsMeal() =>
            type == ExpenseType.Dinner || type == ExpenseType.Breakfast;
    }
}