using System.ComponentModel.DataAnnotations;

namespace NGWSite.Models
{
    public class OrderItem
    {
       public int OrderItemId {get;set;}
       [Required]
       public Product Product {get;set;}
       [Required]
       public int Quality {get;set;}
       public int ProductId {get;set;}

    }
}