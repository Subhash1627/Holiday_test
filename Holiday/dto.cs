using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Holiday
{

    public class Flight
    {
        public int id { get; set; }
        public string airline { get; set; }
        public string from { get; set; }
        public string to { get; set; }
        public double price { get; set; }
        public DateTime departure_date { get; set; }
    }
    public class Hotel
    {
        public int id { get; set; }
        public string name { get; set; }
        public DateTime arrival_date { get; set; }
        public double price_per_night { get; set; }
        public List<string> local_airports { get; set; }
        public int nights { get; set; }
    }
}
