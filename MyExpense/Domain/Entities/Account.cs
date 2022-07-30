namespace Domain.Entities
{
    public class Account
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<Expense> Expenses { get; set; }
    }
}