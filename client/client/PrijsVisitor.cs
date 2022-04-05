using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace client
{
    class PrijsVisitor : Visitor
    {
        //Berekent de prijs van de bestelling op basis van de hoeveelheid pizza's en hoeveelheid toppings.
        //Je ziet de visit methode met parameters die overeenkomen uit Visitor, zo werkt method overloading.
        public int Visit(bestelling bestelling)
        {
            return bestelling.sumpizza * 10 + bestelling.sumtoppings * 2;
        }
    }
}
