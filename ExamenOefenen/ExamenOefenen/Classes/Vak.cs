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
        public int vakID;
        string vaknaam;
        string vakbeschrijving;
        int userID;

        public int VakID { get; set; }
        public string VakNaam { get { return vaknaam; } set { vaknaam = value; } }
        public string VakBeschrijving { get { return vakbeschrijving; } set { vakbeschrijving = value; } }
        public int UserID { get { return userID; } set { userID = value; } }

        public int currentUserID;
        public List<Vak> CurrentUserVakken(int _userID) {

            currentUserID = _userID;

            List<Vak> vakken = new List<Vak>();

            Database db = new Database();

            for (int i = 0; i < db.GetColumn("vakken", "vakID", "userID = " + _userID.ToString()).Count; i++)
            {
                int vakIDTemp = (int)db.GetColumn("vakken", "vakID", "userID = " + _userID.ToString())[i];
                string vaknaamTemp = db.GetColumn("vakken", "vaknaam", "userID = " + _userID.ToString())[i].ToString();
                string vakbeschrijvingTemp = db.GetColumn("vakken", "vakbeschrijving", "userID = " + _userID.ToString())[i].ToString();
                
                vakken.Add(new Vak() { vakID = vakIDTemp, vaknaam = vaknaamTemp, vakbeschrijving = vakbeschrijvingTemp });
            }

            return vakken;
        }

        /// <summary>
        /// Fills CurrentUserVakIdList, CurrentUserVakNaamList, CurrentUserVakBeschrijvingList with vakdata from selected user
        /// </summary>
        /// <param name="_userID">Int to select currentUserID</param>
        public Vak()
        {
        }

        public void CreateVak()
        {
            // TODO - Make this add vak to datebase
        }
    }
}
