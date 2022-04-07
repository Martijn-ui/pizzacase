using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace client
{
    //in deze class bestelling kun je de bestelling die gemaakt is terug vinden
    //er word hier vooral gebruikt van get set omdat je later deze informatie weer wilt gebruiken
    //maar voor de list topping word er gebruikt gemaakt van een method addtopping want dit kon niet met een set
    class bestelling : Visitable
    {
        private string naam;
        private string adress;
        private string postcodeenstad;
        private DateTime datumtijd = DateTime.Now;
        private string naampizza;
        public int sumpizza;
        public int sumtoppings;
     
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
        //Visitable plaatst de accept method in de bestelling class zodat indien nodig method overloading toegepast kan worden.
        //Dit kan gebeuren als je meerdere visit methodes heb voor verschillende klassen bijvoorbeeld.
        public int accept(Visitor visitor)
        {
            return visitor.Visit(this);
        }
    }
}       
    

