using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace client
{
    interface Visitable
    {
        //Visitor geeft het object mee zodat de correcte operations toegepast kunnen worden op het goede objecttype.
        public int accept(Visitor visitor);

    }
}
