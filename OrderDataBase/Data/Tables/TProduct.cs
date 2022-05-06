using System.ComponentModel.DataAnnotations.Schema;

namespace OrderDataBase.Data.Tables
{
    [Table("Product")]
    public class TProduct
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public string Title { get; set; }
        public int Amount { get; set; }
        public decimal Price { get; set; }

    }
}
