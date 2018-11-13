using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenOefenen
{
    class Vraag
    {
        string vraagstuk;
        string antwoord;

        public string Vraagstuk { get { return vraagstuk; } set { vraagstuk = value; } }
        public string Antwoord { get { return antwoord; } set { antwoord = value; } }

        Vraag()
        {

        }
    }
}
