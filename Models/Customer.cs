using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace helloapp.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string BankingDetails { get; set; }
        public string Phone { get; set; }
        public string ContactPerson { get; set; }
    }
}
