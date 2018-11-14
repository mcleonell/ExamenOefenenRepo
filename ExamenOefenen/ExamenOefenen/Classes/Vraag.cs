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
        
        public int currentVakID;
        public List<Vraag> CurrentVakVragen;

        public Vraag(int _vakID)
        {

        }
    }
}
