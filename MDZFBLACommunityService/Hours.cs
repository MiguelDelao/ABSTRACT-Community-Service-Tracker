using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDZFBLACommunityService
{
    class Hours
    {
        public List<double> AllHours { get; set; }
        public List<DateTime> AllDates { get; set; }
        public List<string> TotalEvents { get; set; }
        public Hours()
        {
            AllHours = new List<double>();
            TotalEvents = new List<string>();
            AllDates = new List<DateTime>();
        }
        public void AddEvent(double x, string y)
        {
            AllHours.Add(x);
            TotalEvents.Add(y);
            AllDates.Add(DateTime.Now);
            
        }
        public double TotalHours()
        {
            return AllHours.Sum();
        }

        public override string ToString()
        {
            return string.Concat(AllHours.Sum());
        }

    }
}
