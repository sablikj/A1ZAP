using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09_tridy_a_gettery_settery_vlastnosti
{
    class Student_BezZapouzdření
    {

        public string jmeno;
        public byte vek;
        public bool plnolety;


        public Student_BezZapouzdření(string jmeno, byte vek)
        {
            this.jmeno = jmeno;
            this.vek = vek;

            //jednoduchý zápis if else na jeden řádek. Přirozenými slovy výraz znamená: je věk větší nebo rovno 18 ? pokud ano vlož do proměnné true, ale pokud ne : vlož false
            this.plnolety = vek >= Vek.Plnoletost ? true : false;
        }

    }
}
