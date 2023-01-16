using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OP.Newshore.Domain.Entities
{
    public class Fligth
    {
        public string Origin { get; set; }
        public string Destination { get; set; }
        public double Price { get; set; }
        public virtual Transport Transport { get; set; }
    }
}
