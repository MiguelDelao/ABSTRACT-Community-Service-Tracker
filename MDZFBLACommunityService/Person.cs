using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDZFBLACommunityService
{

    //Person class holds all info for the student
    class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int ID { get; set; }
        public int Grade { get; set; }
        public double Hours { get; set; }
        public DateTime Time { get; set; }

        public Person()
        {
            FirstName = null;
            LastName = null;
            ID = 0;
            Grade = 0;
            Hours = 0;


        }

        public Person(string a, string b, int c, int d, double e, DateTime f)
        {
            FirstName = a;
            LastName = b;
            ID = c;
            Grade = d;
            Hours = e;
            Time = f;
        }
        public Person(string a, string b, int c, int d, double e)
        {
            FirstName = a;
            LastName = b;
            ID = c;
            Grade = d;
            Hours = e;
            Time = DateTime.Now;
        }

    }
}
