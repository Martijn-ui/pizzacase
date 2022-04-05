using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace client
{
    interface Visitor
    {
        //Visitor interface zodat je meerdere visitmethodes aan kan maken en ervoor zorgen dat method overloading toegepast kan worden indien nodig.
        //Method overloading hebben wij niet nodig, maar het kan dus wel. Je moet gewoon een nieuwe Visit methode maken met de parameters van de klasse, dus zou bijvoorbeeld pizza pizza kunnen zijn.
        public int Visit(bestelling bestelling);
    }
}
