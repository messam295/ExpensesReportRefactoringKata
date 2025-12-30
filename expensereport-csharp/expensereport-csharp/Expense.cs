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
        
        public bool IsOverBudget() =>
            IsBreakfastOverBudget() || IsDinnerOverBudget();
        
        private bool IsBreakfastOverBudget()
        {
            return type == ExpenseType.Breakfast && amount > 1000;
        }

        private bool IsDinnerOverBudget()
        {
            return type == ExpenseType.Dinner && amount > 5000;
        }
    }
}