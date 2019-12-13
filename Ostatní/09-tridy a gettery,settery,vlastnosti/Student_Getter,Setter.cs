using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09_tridy_a_gettery_settery_vlastnosti
{
    class Student_Getter_Setter
    {

        private string jmeno;
        private byte vek;
        private bool plnolety;


        public Student_Getter_Setter(string jmeno, byte vek)
        {
            this.jmeno = jmeno;
            this.vek = vek;

            //jednoduchý zápis if else na jeden řádek. Přirozenými slovy výraz znamená: je věk větší nebo rovno 18 ? pokud ano vlož do proměnné true, ale pokud ne : vlož false
            this.plnolety = vek >= Vek.Plnoletost ? true : false;
        }


        //Pro přístup k private fieldům se často používají speciální public metody začínající slovem Get nebo Set, které slouží k přístupu k prvkům z vnějšku třídy.
        //Tyto metody nazýváme gettery a settery.
        //Pomocí getterů a setterů se snažíme skrýt (často i do budoucna) konkrétní implementaci.
        //Počítáme tedy s tím, že v budoucnu můžeme například přidat ověření, že jméno není prázdný řetězec, nebo logování změn.
        public byte GetVek()
        {
            return vek;
        }

        public string GetJmeno()
        {
            return jmeno;
        }

        public bool GetPlnolety()
        {
            return plnolety;
        }

        /// <summary>
        /// nastaví věk a zároveň vypočítá, zda je osoba plnoletá (nastaví také atribut plnolety)
        /// </summary>
        /// <param name="vek"></param>
        public void SetVek(byte vek)
        {
            this.vek = vek;
            this.plnolety = vek >= Vek.Plnoletost ? true : false;
        }

        public void SetJmeno(string jmeno)
        {
            this.jmeno = jmeno;
        }

        //plnoletost by neměla být přímo nastavitelná, takže setter neimplementujeme
        //public void SetPlnolety(bool plnolety)
        //{
        //    this.plnolety = plnolety;
        //}


    }
}
