using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDZFBLACommunityService
{
    class Hours
    {
        public double Hour { get; set; }
        public DateTime Date { get; set; }
        public string Event { get; set; }
        public Hours()
        {
            Hour = 0;
            Date = DateTime.Now;
            Event = "none";
        }
        public Hours(double h,DateTime d, string e)
        {
            Hour = h;
            Date = d;
            Event = e;
        }
        public override string ToString()
        {
            return (Hour + " Hours at " + Event + " on " + Date);
        }









    }
}
