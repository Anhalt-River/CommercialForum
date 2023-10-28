using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommercialForum.Models
{
    public class User
    {
        public int Iduser { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string Patronymic { get; set; }
        public string Role { get; set; }
        public string Email { get; set; }
    }
}
