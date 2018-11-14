using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenOefenen
{
    class User
    {
        //ExamenOefenen.dbo.users (userID, username)

        #region vars
        int userID;
        string username;

        public int UserID { get { return userID; } set { userID = value; } }
        public string Username{ get { return username;} set { username = value; } }
        
        // TODO - Als alles van vakken werkt moeten de lijst van vakken per userID hierin geladen worden 
        #endregion

        

        public static List<User> UserList()
        {
            Database db = new Database();
            List<User> userList = new List<User>();

            for (int i = 0; i < db.GetColumn("users","userID"," 1 = 1").Count; i++)
            {
                int userIDTemp = (int)db.GetColumn("users", "userID", " 1 = 1" )[i];
                string usernameTemp = db.GetColumn("users", "username", "1 = 1")[i].ToString();

                userList.Add(new User() { userID = userIDTemp, username = usernameTemp });
            }

            return userList;
        }

        public void CreateUser(string _input)
        {
            Database db = new Database();
            db.AddToColumn("users","username", _input);
        }
    }
}
