using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenOefenen
{
    class User
    {
        //ExamenOefenen.dbo.vakken (userID, username)
        #region vars
        public static User CurrentUser { get; set; }
        public static bool LoggedIn = false;
        public int UserID { get; set; }
        public string Username { get; set; }
        #endregion
        #region methods
        #region bool
        public static bool DoesntExist(string _username)
        {
            Database db = new Database();
            if (db.ExistsAllCase("users", "username", _username))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        #endregion
        #region List
        public static List<User> AllUsers()
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
        public List<Vak> Vakken()
        {
            List<Vak> vakken = new List<Vak>();

            Database db = new Database();

            string equation = "userID = " + CurrentUser.UserID.ToString() + " ORDER BY vakID";

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
        #endregion
        #region void
        public static void Create(string _username)
        {
            Database.Insert("users", "username", _username);
        }
        public static void Delete(int _userID)
        {
            foreach (Vak vak in User.CurrentUser.Vakken())
            {
                Vak.Delete(vak.VakID);
            }
            Database.Delete("users", "userID = " + _userID);
        }
        #endregion
        #endregion
    }
}
