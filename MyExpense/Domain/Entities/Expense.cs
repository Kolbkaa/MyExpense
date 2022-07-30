namespace Domain.Entities
{
    public class Expense
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public Account Account { get; set; }
    }
}