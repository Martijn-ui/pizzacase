using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace client
{
    class bestelling
    {
        private string naam;
        private string adress;
        private string postcodeenstad;
        private DateTime datumtijd = DateTime.Now;
        private string naampizza;
        private int sumpizza;
        private int sumtoppings;
     
        private List<string> topping = new List<string>();
        pizza pizza = new pizza();

        public string Naam
        {
            get { return naam; }
            set { naam = value; }
        }

        public string Adress
        {
            get
            { return adress; }
            set { adress = value; }
        }

        public string Postcodeenstad
        {
            get
            { return postcodeenstad; }
            set { postcodeenstad = value; }
        }

        public DateTime Datumtijd
        {
            get{ return datumtijd; }
        }

        public string Naampizza
        {
            get { return naampizza; }
            set 
            { 
                naampizza = value;
                pizza.Naampizza = value;
            }
            
    }

        public int Sumpizza
        {
            get { return sumpizza; }
            set { sumpizza = value; }
        }

        public int Sumtoppings
        {
            get { return sumtoppings; }
            set { sumtoppings = value; }
        }
        
        public void addtopping(string naamtopping)
        {
            topping.Add(naamtopping);
            pizza.addtopping(naamtopping);
        }
        public List<string> Topping
        {
            get { return topping; }
        }


    }

}       
    

