using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderDataBase.Data.Tables
{
    [Table("Order")]
    public class TOrder
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Number { get; set; }
        public string Customer { get; set; }
    }
}
