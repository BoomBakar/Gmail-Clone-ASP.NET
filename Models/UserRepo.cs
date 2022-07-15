using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace WebApplication4.Models
{
    public class UserRepo
    {
        //Add user to datebase with the info received from controller
        public static bool addUser(User u)
        {
            if (uniqueEmail(u))
            {
                var db = new MailContext();
                db.Users.Add(u);
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
        // Verifying user credentials
        public static bool verifyUser(User u)
        {
            var db = new MailContext();
            foreach(User user in db.Users)
            {
                if (user.Email == u.Email && user.Password == u.Password)
                    return true;               
            }
            return false;
        }
        //This function converts data in database to a list so i can show it in View easily
        public static bool uniqueEmail(User us)
        {
            HashSet<User> users = new HashSet<User>(new UserComparer());
            bool flag = false;
            string conString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Mail;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection connection = new SqlConnection(conString);
            string query = $"select * from Users";
            connection.Open();
            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                User u = new User();
                u.Name = Convert.ToString(dr[1]);
                u.Email = Convert.ToString(dr[2]);
                u.Password = Convert.ToString(dr[3]);

                users.Add(u);

            }
            connection.Close();
            if(users.Add(us))
                return true;            
            else            
                return false;
            
            

        }
    }
    public class UserComparer : IEqualityComparer<User>
    {
        public bool Equals(User x, User y)
        {
            return x.Email.Equals(y.Email, StringComparison.InvariantCultureIgnoreCase);
        }

        public int GetHashCode(User obj)
        {
            return obj.Email.GetHashCode();
        }
    }
}
