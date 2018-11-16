using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenOefenen
{
    class UserObjectTest
    {
        public int UserID { get; private set; }
        public string Username { get; private set; }

        public UserObjectTest()
        {

        }

        public UserObjectTest(int userID)
        {
            UserID = userID;
        }

        public string GetUser()
        {
            Database db = new Database();
            return db.GetColumn("users","username","userID = " + UserID).ToString();
        }

        public List<UserObjectTest> GetUserList()
        {
            List<UserObjectTest> users = new List<UserObjectTest>();

            Database db = new Database();

            List<int> userIDList()
            {
                List<string> userIDs = new List<string>();
                foreach (var userId in db.GetColumn("users", "userID", " 1 = 1 "))
                {
                    usernames.Add((int)userId);
                }
                return usernames;
            }
            List<string> usernameList()
            {
                List<string> usernames = new List<string>();
                foreach (var username in db.GetColumn("users", "userName", " 1 = 1 "))
                {
                    usernames.Add(username.ToString());
                }
                return usernames;
            }
            
            for (int i = 0; i < db.GetColumn("users","userID"," 1 = 1 ").Count(); i++)
            {
                UserObjectTest u = new UserObjectTest();
                u.UserID = userIDList[i];
                u.Username = usernameList[i];
                users.Add(u);
            }
               
            return users;
        }
    }
}
