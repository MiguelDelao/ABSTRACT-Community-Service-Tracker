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
        private string FirstName { get; set; }
        private string LastName { get; set; }
        private int ID { get; set; }
        private int Grade { get; set; }
        private double[] Hours { get; set; }
        private DateTime Time { get; set; }

        public Person()
        {
            FirstName = null;
            LastName = null;
            ID = 0;
            Grade = 0;
            Hours = null;


        }

        public Person(string a, string b, int c, int d, double[] e, DateTime f)
        {
            FirstName = a;
            LastName = b;
            ID = c;
            Grade = d;
            Hours = e;
            Time = f;
        }

    }
}
