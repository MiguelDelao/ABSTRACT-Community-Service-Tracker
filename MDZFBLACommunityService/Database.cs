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
        /*
        *This class provides all the interaction with the database.
        *The database is NoSQL and document oriented. The library used is LiteDB.
        *LiteDB is a lightweight MongoDB based package, 
        *but is provides all functions needed for the scope of this project.
        *The Database file is stored under Mydata.db
        */
        public Database()
        {

        }

        //Inserts the Person class into the database
        public static void Insert(Person pep)
        {
            using (var db = new LiteDatabase("..\\MyData.db"))
            {
                // Get customer collection, creates one if it doesn't exist
                var people = db.GetCollection<Person>("People");
                people.Insert(pep);               
            }
            
        }

        //If existing person object is changed, this will update it in the database
        public static void Update(Person pep)
        {
            using (var db = new LiteDatabase("..\\MyData.db"))
            {
                var col = db.GetCollection<Person>("people");
                Console.Out.WriteLine(pep.ID);
                col.Update(pep);
            }
        }

        //removes person from the database
        public static bool Remove(int pepid)
        {
            using (var db = new LiteDatabase("..\\MyData.db"))
            {
                var coll = db.GetCollection<Person>("people");
                
                return (coll.Delete(pepid));

            }
        }
        //creates a unique ID for the creation of a new person

        public static int GenerateID()
        {
            Random rand = new Random();
            int randomNumber = rand.Next(1999, 9999);
            using (var db = new LiteDatabase("..\\MyData.db"))
            {
                //checks database for a 
                var coll = db.GetCollection<Person>("people");
                bool x = coll.Exists(Query.Contains("ID", string.Concat(randomNumber)));
                if (x == true)
                {
                    randomNumber = GenerateID();
                }
            }
            return randomNumber;
        }

        //returns list of people from the database
        public static List<Person> People()
        {
            using (var db = new LiteDatabase("..\\MyData.db"))
            {
                List<Person> people = new List<Person>();
                var coll = db.GetCollection<Person>("people");
                
                foreach (Person x in coll.FindAll())
                {
                    people.Add(x);
                }
                return people;
                
            }
        }


        //returns person by ID from database
        public static Person FindByID(int id)
        {
            using (var db = new LiteDatabase("..\\MyData.db"))
            {
                var coll = db.GetCollection<Person>("people");
                Person getter = coll
.FindById(id);
                return getter;
            }

        }

        //returns person by first and last name
        public static Person FindByName(string fnam, string lnam)
        {
            using (var db = new LiteDatabase("..\\mydata.db"))
            {
                var coll = db.GetCollection<Person>("people");
                foreach (Person x in coll.FindAll())
                {
                    if (x.FirstName == fnam && x.LastName == lnam) return x;
                }

                return null;

            }
        }

        //returns list of first and last names 
        public static List<string> Names()
        {
            var pep = People();
            var names = new List<string>();
            foreach(Person x in pep)
            {
                names.Add(x.FirstName + " " + x.LastName);
            }
            return names;
        }



    }
}
