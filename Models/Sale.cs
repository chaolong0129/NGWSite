namespace NGWSite.Models
{
    public class Sale
    {
        public int SaleId {get;set;}   
        public Order Order {get;set;}
        public decimal Amount {get;set;}
    }
}