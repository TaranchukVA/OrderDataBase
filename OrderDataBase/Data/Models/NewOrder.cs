using System.Collections.Generic;

namespace OrderDataBase.Data.Models
{
    public class NewOrder
    {
        public string number { get; set; }
        public string customer { get; set; }
        public List<NewProduct> products { get; set; }
    }
}
