using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08_tridy__a_enum_
{
    //možnosti viditelnosti/přístupu jsou u výčtového typu (enum) public a internal (internal se nastavuje defaultně)
    public enum CasovaJednotka
    {
        milisekundy,
        sekundy,
        minuty,
        hodiny,
        dny
    }
}
