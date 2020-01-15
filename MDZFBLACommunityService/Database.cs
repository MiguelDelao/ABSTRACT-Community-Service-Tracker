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
        public void Lite(Person pep)
        {
            using (var db = new LiteDatabase("..\\MyData.db"))
            {
                // Get customer collection
                var people = db.GetCollection<Person>("People");
                people.Insert(pep);

                // Create your new customer instance



            }
        }
    }
}
