using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace serverapplication
{
    class Bestelling
    {

        //hier maak je een private list aan en hierin word straks de bestelling in opgeslagen
        private List<string> bestelling = new List<string>();
        
        //deze methode add de meegegeven string naamtopping in die list bestelling
        public void addbestelling(string naamtopping)
        {
            bestelling.Add(naamtopping);
        }
        //deze methode laate de list bestelling zien
        public List<string> ShowBestelling()
        {
            return bestelling;
        }



    }

}


