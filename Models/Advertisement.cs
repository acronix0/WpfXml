using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace helloapp.Models
{
    public class Advertisement
    {
        public int AdId { get; set; }
        public int ShowId { get; set; }
        public int CustomerId { get; set; }
        public DateTime Date { get; set; }
        public int DurationInMinutes { get; set; }


       
    }
}
