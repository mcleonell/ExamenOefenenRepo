using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenOefenen
{
    class Vraag
    {
        //ExamenOefenen.dbo.vragen (vraagID, vraagstuk, antwoord, vakID)
        #region vars
        static int vraagCounter = 0;
        public static int VraagCounter { get { return vraagCounter; } set { vraagCounter = value; } }
        public static Vraag CurrentVraag { get; set; }
        public int VraagID { get; set; }
        public string Vraagstuk { get; set; }
        public string Antwoord { get; set; }
        public int VakID { get; set; }
        #endregion
        #region methods
        #region bool
        public static bool DoesntExist(string _vraag, int _vakID)
        {
            Database db = new Database();
            if (db.Exists("vragen", "vraagstuk", _vraag.ToLower(), "vakID", _vakID))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        #endregion
        #region void
        public static void Create(string _vraagstuk, string _antwoord, int _currentVakID)
        {
            Database.Insert("vragen", "vraagstuk", "antwoord", "vakID", _vraagstuk.ToLower(), _antwoord, _currentVakID);
        }
        public static void Delete(int _vraagID)
        {
            Database.Delete("vragen", "vraagID = " + _vraagID);
        }
        #endregion
        #endregion




    }
}
