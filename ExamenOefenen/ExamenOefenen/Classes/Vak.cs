using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenOefenen
{
    class Vak
    {
        string vaknaam;
        string vakbeschrijving;

        public string VakNaam { get { return vaknaam; } set { vaknaam = value; } }
        public string Vakbeschrijving { get { return vakbeschrijving; } set { vakbeschrijving = value; } }

        public List<Vraag> Vragen { get; set; }

        Vak()
        {

        }
    }
}
