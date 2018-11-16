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

        int vraagID;
        string vraagstuk;
        string antwoord;
        int vakID;

        public int VraagID { get { return vraagID; } set { vraagID = value; } }
        public string Vraagstuk { get { return vraagstuk; } set { vraagstuk = value; } }
        public string Antwoord { get { return antwoord; } set { antwoord = value; } }
        public int VakID { get { return vakID; } set { vakID = value; } }

        public static void CreateVraag(string _vraagstuk, string _antwoord, int _currentVakID)
        {
            Database db = new Database();
            db.AddToColumn("vragen", "vraagstuk", "antwoord", "vakID", _vraagstuk, _antwoord, _currentVakID);
        }
    }
}
