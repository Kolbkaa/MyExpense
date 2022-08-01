namespace Domain.Entities
{
    public class Operation
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Value { get; set; }
        public DateTime Date { get; set; }
        public Account Account { get; set; }
    }
}