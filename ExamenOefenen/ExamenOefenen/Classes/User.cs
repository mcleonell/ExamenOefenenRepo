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
        string username;
        public string Username
        {
            get
            {
                return username;
            }
            set
            {
                username = value;
            }
        }


        // TODO - Als alles van vakken werkt moeten de lijst van vakken per userID hierin geladen worden 
        public List<Vak> Vakken { get; set; }
        #endregion

        public List<string> UsernameList()
        {
            Database db = new Database();
            List<string> usernameList = new List<string>();

            foreach (var item in db.GetColumn("users", "username"))
            {
                usernameList.Add(item.ToString());
            }
            
            return usernameList;
        }

        public void CreateUser(string _input)
        {
            Database db = new Database();
            db.AddToColumn("users","username", _input);
        }
    }
}
