namespace Domain.Entities
{
    public class Customer
    {
        public string Name { get; set; }
        public string CompanyName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public Customer()
        {
            Name = string.Empty;
            CompanyName = string.Empty;
            Phone = string.Empty;  
            Email = string.Empty;
        }
    }
}
