namespace Services.Customer.Model
{
    public class Customer : EntityBase
    {
        public string CustomerName { get; set; }
        public string TaxOffice { get; set; }
        public int TaxNumber { get; set; }
        public string Adress { get; set; }
        
    }
}
