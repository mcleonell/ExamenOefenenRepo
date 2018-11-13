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
        string vaknaam;
        string vakbeschrijving;
        int userID;

        public string VakNaam { get { return vaknaam; } set { vaknaam = value; } }
        public string VakBeschrijving { get { return vakbeschrijving; } set { vakbeschrijving = value; } }
        public int UserID { get { return userID; } set { userID = value; } }

        
        public static List<int> VakIDList()
        {
            Database db = new Database();
            List<int> vakIDList = new List<int>();

            foreach (int vakID in db.GetColumn("vakken", "vakID", "vakID"))
            {
                vakIDList.Add(vakID);
            }

            return vakIDList;
        }
        public static List<string> VakNaamList()
        {
            Database db = new Database();
            List<string> vakNaamList = new List<string>();

            foreach (string vakNaam in db.GetColumn("vakken", "vakNaam", "vakID"))
            {
                vakNaamList.Add(vakNaam);
            }

            return vakNaamList;
        }
        public static List<string> VakBeschrijvingList()
        {
            Database db = new Database();
            List<string> vakBeshcrijvingList = new List<string>();

            foreach (string vakBeschrijving in db.GetColumn("vakken", "vakBeschrijving", "vakID"))
            {
                vakBeshcrijvingList.Add(vakBeschrijving);
            }

            return vakBeshcrijvingList;
        }
        public static List<int> UserIDList()
        {
            Database db = new Database();
            List<int> userIDList = new List<int>();

            foreach (int userID in db.GetColumn("vakken", "userID", "vakID"))
            {
                userIDList.Add(userID);
            }

            return userIDList;
        }

        public int currentUserID;
        public List<int> CurrentUserVakIdList;
        public List<string> CurrentUserVakNaamList;
        public List<string> CurrentUserVakBeschrijvingList;

        /// <summary>
        /// Fills CurrentUserVakIdList, CurrentUserVakNaamList, CurrentUserVakBeschrijvingList with vakdata from selected user
        /// </summary>
        /// <param name="_userID">Int to select currentUserID</param>
        public Vak(int _userID)
        {
            currentUserID = _userID;
            CurrentUserVakIdList = new List<int>();
            CurrentUserVakNaamList = new List<string>();
            CurrentUserVakBeschrijvingList = new List<string>();

            for (int i = 0; i < UserIDList().Count(); i++)
            {
                if (_userID == UserIDList()[i])
                {
                    CurrentUserVakIdList.Add(VakIDList()[i]);
                    CurrentUserVakNaamList.Add(VakNaamList()[i]);
                    CurrentUserVakBeschrijvingList.Add(VakBeschrijvingList()[i]);
                }
            }
        }

        public void CreateVak()
        {
            // TODO - Make this add vak to datebase
        }
    }
}
