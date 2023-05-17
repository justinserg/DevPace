namespace Domain.Entities
{
    public class Pagging
    {
        public int Number { get; set; }
        public int Count { get; set; }
        public IEnumerable<Customer> Customers { get; set; }
    }
}
