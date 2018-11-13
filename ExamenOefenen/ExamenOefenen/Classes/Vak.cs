using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenOefenen
{
    class Vak
    {
        //ExamenOefenen.dbo.vakken (vakID, vakNaam, vakBeschrijving, userID)
        int vakID;
        string vaknaam;
        string vakbeschrijving;
        int userID;

        public int VakID { get { return vakID; } set { vakID = value; } }
        public string VakNaam { get { return vaknaam; } set { vaknaam = value; } }
        public string VakBeschrijving { get { return vakbeschrijving; } set { vakbeschrijving = value; } }
        public int UserID { get { return userID; } set { userID = value; } }


        // TODO - Testen ophalen vakken en vakken storen in lijst van vakken
        public List<Vak> VakkenList()
        {
            List<Vak> vakkenList = new List<Vak>();

            for (int i = 0; i < VakIDList().Count(); i++)
            {
                Vak v = new Vak();
                v.vakID = v.VakIDList()[i];
                v.vaknaam = v.VakNaamList()[i];
                v.vakbeschrijving = v.VakBeschrijvingList()[i];
                v.userID = v.UserIDList()[i];
            }

            return vakkenList;
        }

        public List<int> VakIDList()
        {
            Database db = new Database();
            List<int> vakIDList = new List<int>();

            foreach (int vakID in db.GetColumn("vakken", "vakID"))
            {
                vakIDList.Add(vakID);
            }

            return vakIDList;
        }

        public List<string> VakNaamList()
        {
            Database db = new Database();
            List<string> vakNaamList = new List<string>();

            foreach (string vakNaam in db.GetColumn("vakken", "vakNaam"))
            {
                vakNaamList.Add(vakNaam);
            }

            return vakNaamList;
        }

        public List<string> VakBeschrijvingList()
        {
            Database db = new Database();
            List<string> vakBeshcrijvingList = new List<string>();

            foreach (string vakBeschrijving in db.GetColumn("vakken", "vakBeschrijving"))
            {
                vakBeshcrijvingList.Add(vakBeschrijving);
            }

            return vakBeshcrijvingList;
        }

        public List<int> UserIDList()
        {
            Database db = new Database();
            List<int> userIDList = new List<int>();

            foreach (int userID in db.GetColumn("vakken", "userID"))
            {
                userIDList.Add(userID);
            }

            return userIDList;
        }
    }
}
