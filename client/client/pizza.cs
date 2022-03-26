using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace client
{
    class pizza
    {
        private int prijspizza;
        private string naampizza;
        private List<string> topping = new List<string>();

        public void addtopping(string naamtopping)
        {
            topping.Add(naamtopping);
        }
        public List<string> Topping
        {
            get { return topping; }
        }
        public string Naampizza
        {
            get { return naampizza; }
            set { naampizza = value; }
        }

        public int Prijspizza
        {
            get { return prijspizza; }
            set { prijspizza = value; }
        }
    }
}
