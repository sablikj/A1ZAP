using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09_tridy_a_gettery_settery_vlastnosti
{
    class Student_Property
    {

        //používání vlastností se dělí na 2 části: 1. je samotný atribut/členská proměnná a 2. je vlastnost (Property), která nahrazuje getter a popř. setter
        private string jmeno;
        //Definice vlastnosti, která je navázána na členskou proměnnou (všimněte si rozdílnost počátečních písmen tj. malé/velké)
        //Platí pravidlo, že metody get a set musí být skoro stejně rychlé jako přímý přístup k fieldu. V property bychom NEměli provádět časově náročné operace jako například přístup k databázi nebo složité výpočty.
		//V kódu se k Property přistupuje stejně jako ke členským proměnným.
        public string Jmeno
        {
            get
            {
                return this.jmeno;
            }
            set
            {
                if (value != null)
                {
                    this.jmeno = value;
                }
            }
        }


        ////kdybychom to chtěli udělat takto napřímo, tak, protože to vypadá jako atribut, tak to určitě nevadí, že? Dokonce ani kompilátor nic nehlásí!
        ////No schválně zkuste odpoznámkovat a spustit....
        ////Cože? Jaký StackOverflowException? No jo, on to totiž není atribut, ale vlastnost, takže tento samotný zápis a ukládání proměnné přímo do vlastnosti neprojde
        ////V podstatě tu dojde k zacyklení - pamatujte, že vlastnost v get nastavuje proměnnou a když nastavuje vlastnost v get sama sebe, tak dojde k nekonečné smyčce! - tj. opět se spustí get sama sebe, která spustí get sama sebe, která spustí get sama sebe atd.)
        ////samozřejmě to samé platí i pro set v tomto tvaru
        //public string Jmeno
        //{
        //    get
        //    {
        //        return this.Jmeno;
        //    }
        //    set
        //    {
        //        if (value != null)
        //        {
        //            this.Jmeno = value;
        //        }
        //    }
        //}




        private byte vek;
        public byte Vek
        {
            get
            {
                return vek;
            }
            set
            {
                vek = value;
                //Ke konstantě ve struktuře Vek teď musíme přistupovat i s použitím namespace, jinak si kompilátor myslí, že jde o vlastnost
                this.Plnolety = vek >= _09_tridy_a_gettery_settery_vlastnosti.Vek.Plnoletost ? true : false;
            }
        }



        //Automaticky implementovaná vlastnost (Auto-Implemented Property) - zde se také používá atribut, nicméně je skrytý a programátor si o něj nemusí dělat starosti, dokud neimplementuje get a set vlastním způsobem
        //Nedochází ke snížení výkonu programu ve srovnání s přímým přístupem.
        public bool Plnolety
        {
            get;
            //pomocí private určíme, že nastavovat plnoletost lze jen uvnitř třídy (lze to i u normální Property)
            private set;
        }


        public Student_Property(string jmeno, byte vek)
        {
            this.Jmeno = jmeno;
            this.Vek = vek;

            //jednoduchý zápis if else na jeden řádek. Přirozenými slovy výraz znamená: je věk větší nebo rovno 18 ? pokud ano vlož do proměnné true, ale pokud ne : vlož false
            this.Plnolety = vek >= _09_tridy_a_gettery_settery_vlastnosti.Vek.Plnoletost ? true : false;
        }

    }
}
