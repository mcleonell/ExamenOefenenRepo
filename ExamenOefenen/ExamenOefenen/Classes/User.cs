using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenOefenen
{
    class User
    {
        public static bool LoggedIn = false;

        public int UserID { get; private set; }
        public string Username { get; private set; }

        public static bool DoesntExist(string _username)
        {
            Database db = new Database();
            if(db.Exists("users", "username", _username.ToLower()))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static void CreateUser(string _username)
        {
            Database db = new Database();
            db.AddToColumn("users", "username", _username.ToLower());
        }

        public static List<User> GetUserList()
        {
            List<User> users = new List<User>();

            Database db = new Database();

            List<int> userIDList()
            {
                List<int> userIDs = new List<int>();
                foreach (var userId in db.GetColumn("users", "userID", " 1 = 1 "))
                {
                    userIDs.Add((int)userId);
                }
                return userIDs;
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

            for (int i = 0; i < userIDList().Count; i++)
            {
                User u = new User();
                u.UserID = userIDList()[i];
                u.Username = usernameList()[i];
                users.Add(u);
            }

            return users;
        }

        public List<Vak> Vakken(int _currentUserID)
        {
            List<Vak> vakken = new List<Vak>();

            Database db = new Database();

            string equation = "userID = " + _currentUserID.ToString();

            for (int i = 0; i < db.GetColumn("vakken", "vakID", equation).Count; i++)
            {

                Vak v = new Vak();

                v.VakID = (int)db.GetColumn("vakken", "vakID", equation)[i];
                v.VakNaam = db.GetColumn("vakken", "vaknaam", equation)[i].ToString();
                v.VakBeschrijving = db.GetColumn("vakken", "vakbeschrijving", equation)[i].ToString();

                vakken.Add(v);
            }

            return vakken;
        }
    }
}
