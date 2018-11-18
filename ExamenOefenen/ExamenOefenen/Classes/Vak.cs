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
        #region vars
        public static Vak CurrentVak { get; set; }
        public int VakID { get; set; }
        public string VakNaam { get; set; }
        public string VakBeschrijving { get; set; }
        public int UserID { get; set; }
        #endregion
        #region methods
        #region bool
        public static bool DoesntExist(string _vakNaam, int _userID)
        {
            Database db = new Database();
            if (db.ExistsAllCase("vakken", "vakNaam", _vakNaam , "userID", _userID))
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
        #endregion
        #region void
        public static void Create(string _vakNaam, string _vakBeschrijving, int _currentUserID)
        {
            Database.Insert("vakken", "vakNaam", "vakBeschrijving", "userID", _vakNaam, _vakBeschrijving, _currentUserID);
        }
        public static void Delete(int _vakID)
        {
            Vak vak = new Vak();
            foreach(Vraag vraag in vak.Vragen(_vakID))
            {
                Vraag.Delete(vraag.VraagID);
            }
            Database.Delete("vakken", "vakID = " + _vakID);
        }
        #endregion
        #endregion
    }
}
