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
        string vakNaam;
        string beschrijving;
        int userID;

        public int VakID { get { return vakID; } set { vakID = value; } }
        public string VakNaam { get { return vakNaam; } set { vakNaam = value; } }
        public string VakBeschrijving { get { return beschrijving; } set { beschrijving = value; } }
        public int UserID { get { return userID; } set { userID = value; } }

        public List<Vraag> Vragen(int _currentVakID)
        {

            List<Vraag> vragen = new List<Vraag>();

            Database db = new Database();

            string equation = "vakID = " + _currentVakID.ToString();

            for (int i = 0; i < db.GetColumn("vragen", "vraagID", equation).Count; i++)
            {

                Vraag v = new Vraag();

                v.VraagID = (int)db.GetColumn("vragen", "vraagID", equation)[i];
                v.Vraagstuk = db.GetColumn("vragen", "vraagstuk", equation)[i].ToString();
                v.Antwoord = db.GetColumn("vragen", "antwoord", equation)[i].ToString();

                vragen.Add(v);
            }

            return vragen;
        }
        
        public static void CreateVak(string _vakNaam, string _vakBeschrijving, int _currentUserID)
        {
            Database db = new Database();
            db.AddToColumn("vakken", "vakNaam", "vakBeschrijving", "userID", _vakNaam, _vakBeschrijving, _currentUserID);
        }
    }
}
