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
        public Hours Hours { get; set; }
        public Person()
        {
            FirstName = null;
            LastName = null;
            ID = 0;
            Grade = 0;
            Hours = new Hours();


        }
       

        public Person(string a, string b, int c, int d, double e, DateTime f)
        {
            FirstName = a;
            LastName = b;
            ID = c;
            Grade = d;
            

        }
        public Person(string fir, string las, int i, int grad, double hour,string even)
        {
            FirstName = fir;
            LastName = las;
            ID = i;
            Grade = grad;
            Hours = new Hours();
            Hours.AddEvent(hour, even);
            
        }
        public Person(string fir, string las, int grad, double hour)
        {
            FirstName = fir;
            LastName = las;
            Grade = grad;
            
        }
        public override string ToString()
        {
            return (FirstName + LastName + ID + Grade );
        }
    }
}
