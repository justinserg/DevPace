namespace DevPace.Core.Entities
{
    public class Customer: IEntityBase<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CompanyName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}
