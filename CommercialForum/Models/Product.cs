using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace CommercialForum.Models
{
    public class Product
    {
        public int IdProduct { get; set; }
        public string Name { get; set; }
        public double Cost { get; set; }
        public string IsAvailable { get; set; }
        public string DidPut { get; set; }
        public int IdTrader { get; set; }
        public ImageSource Image { get; set; }
    }
}
