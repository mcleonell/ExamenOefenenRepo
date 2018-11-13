using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenOefenen
{
    class User
    {
        #region vars
        Database db = new Database();
        string username;
        public string Username { get { return username; } set { username = value; } }
        public List<Vak> Vakken { get; set; }
        #endregion

        public List<string> UsernameList()
        {
            List<string> usernameList = new List<string>();

            foreach (var item in db.GetColumn("users", "username"))
            {
                usernameList.Add(item.ToString());
            }
            
            return usernameList;
        }

        public void CreateUser(string _input)
        {
            db.AddToColumn("users","username", _input);
        }
    }
}
