using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiteDB;

namespace MDZFBLACommunityService
{
    class Database
    {

        public Database()
        {

        }
        public static void Insert(Person pep)
        {
            using (var db = new LiteDatabase("..\\MyData.db"))
            {
                // Get customer collection
                var people = db.GetCollection<Person>("People");
                people.Insert(pep);

                // Create your new customer instance



            }
            
        }

        public static int GenerateID()
        {
            Random rand = new Random();
            int randomNumber = rand.Next(1999, 9999);
            using (var db = new LiteDatabase("..\\MyData.db"))
            {
                var coll = db.GetCollection<Person>("people");
                bool x = coll.Exists(Query.Contains("ID", String.Concat(randomNumber)));
                if (x == true)
                {
                    randomNumber = GenerateID();
                }
            }
            return randomNumber;
        }

        public static List<Person> People()
        {
            using (var db = new LiteDatabase("..\\MyData.db"))
            {
                List<Person> people = new List<Person>();
                var unrefined = db.GetCollection<Person>("people");
                foreach (Person x in unrefined.FindAll())
                {
                    people.Add(x);
                }
                return people;
                
            }
        }

        public static void Update(Person pep)
        {
            using (var db = new LiteDatabase("..\\MyData.db"))
            {
                var col = db.GetCollection<Person>("people");
                Console.Out.WriteLine(pep.ID);
                col.Update(pep);
            }
        }
    }
}
