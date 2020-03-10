using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDZFBLACommunityService
{

    /* This object holds all the information for a single person, 
     * including each individual hour and their event.
     */
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
        




        public override string ToString()
        {
            return (FirstName + " " + LastName +  ", Grade: " + Grade +  ", " + SumHours + " Hours");
        }

        //adds an hour class to the hour array 
        public void AddHours(Hours h)
        {
            AllHours.Add(h);
            SumHours = AllHours.Sum(Hours => Hours.Hour);
        }

        //removes the hour object from the hour array
        public void RemoveHours(Hours h)
        {
            AllHours.Remove(h);
            SumHours = AllHours.Sum(Hours => Hours.Hour);
        }


    }
}
