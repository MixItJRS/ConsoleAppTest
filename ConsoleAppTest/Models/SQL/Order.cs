using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppTest.Models.SQL
{
    internal class Order
    {
        public int Id { get; set; }
        public int No { get; set; }
        public DateOnly RegDate { get; set; }
        public decimal Sum { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}
