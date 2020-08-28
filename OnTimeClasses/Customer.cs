namespace OnTimeClasses
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string Contact { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string CompanyUrl { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public bool IsEditing { get; set; } = false;
    }
}

