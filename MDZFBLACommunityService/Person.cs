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
        public double SumHours { get; set; }
        public List<Hours> AllHours { get; set; }
        public Person()
        {
            FirstName = null;
            LastName = null;
            ID = 0;
            Grade = 0;
        }

        public Person(string fir,string las,int grad,Hours h)
        {
            AllHours = new List<Hours>();
            FirstName = fir;
            LastName = las;
            ID = Database.GenerateID();
            Grade = grad;
            AllHours.Add(h);
            SumHours = AllHours.Sum(Hours => Hours.Hour);

        }

        public Person(string fir, string las, int grad)
        {
            AllHours = new List<Hours>();
            FirstName = fir;
            LastName = las;
            ID = Database.GenerateID();
            Grade = grad;
            SumHours = AllHours.Sum(Hours => Hours.Hour);

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
            
        }
        public Person(string fir, string las, int grad, double hour)
        {
            FirstName = fir;
            LastName = las;
            Grade = grad;
            
        }
        public override string ToString()
        {
            return (FirstName + " " + LastName +  ", Grade: " + Grade +  ", " + SumHours + " Hours");
        }


        public void AddHours(Hours h)
        {
            AllHours.Add(h);
            SumHours = AllHours.Sum(Hours => Hours.Hour);
        }
        public void RemoveHours(Hours h)
        {
            AllHours.Remove(h);
            SumHours = AllHours.Sum(Hours => Hours.Hour);
        }


    }
}
