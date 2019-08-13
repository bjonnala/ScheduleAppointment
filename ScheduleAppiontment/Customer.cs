using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleAppiontment
{
    public class Customer
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public List<Car> Cars { get; set; }

        public Customer(string name, string phone, string address)
        {
            Cars = new List<Car>();
            Name = name;
            Phone = phone;
            Address = address;
        }
    }
}
