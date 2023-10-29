using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommercialForum.Models
{
    public class Order
    {
        public int IdOrder { get; set; }
        public int IdClient { get; set; }
        public string Date { get; set; }
        public string IsConcluded { get; set; }
        public float TotalCost { get; set; }
        public int IdBasket { get; set; }
    }
}
