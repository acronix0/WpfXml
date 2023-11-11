using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace helloapp.Models
{
    public class Agent
    {

        public int AgentId { get; set; }
        public string Name { get; set; }
        public decimal CommissionPercentage { get; set; }
        public decimal TotalSalesAmount { get; set; }
    }
}
