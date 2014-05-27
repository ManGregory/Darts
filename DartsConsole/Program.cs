using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DartsConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new DartsContext())
            {
                var user = new User {Name = "asdf", Email = "asff"};
                var team = new Team {Name = "asdfasdf"};
                //var rule = new Rule {Name = "501", Description = "Exactly 501"};
                
                db.Users.Add(user);
                db.Teams.Add(team);
                db.SaveChanges();

                var users = from u in db.Users
                    select u;
                var teams = from t in db.Teams
                    select t;
                Console.WriteLine("users:");
                foreach (var u in users)
                {
                    Console.WriteLine("{0}, {1}", u.Name, u.Email);
                }
                Console.WriteLine("teams:");
                foreach (var t in teams)
                {
                    Console.WriteLine("{0}", t.Name);
                }
                Console.ReadLine();
            }
        }
    }    
}
