using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_struktury__a_metody_
{
    //definice struktury Bod3D.
    //přestože se struktura chová jako hodnotový typ, lze do ní v C# vložit i konstruktory a metody + viditelnosti metod a členských proměnných
    //nemělo by se jednat o rozsáhlé struktury, protože se ukládají na zásobník, který je koncipován na ukládání lokálních proměnných a není vhodný pro rozsáhlá data
    //i když je uložení na zásobník rychlejší než na haldu, je nutné si pamatovat, že např. v parametrech funkcí se předávají kopie struktur a nikoliv jen reference, což u rozměrných struktur nakonec způsobí větší prodlevu - i když toto se dá částečně obejít použitím ref před vstupním parametrem
    struct Bod3D
    {
        public int x;
        public int y;
        public int z;

        //readonly znamená, že po prvotním nastavení (v konstruktoru) již nebude možné tuto proměnnou měnit, ale půjde jen získat/přečíst její hodnotu
        //private znamená, že se lze přímo na hodnotu dostat jen pomocí metody ve struktuře - dělá se např. v případech, kdy se ještě před vrácení/nastavení hodnoty musí něco otestovat/nastavit apod.
        private readonly string ident;

        ////je možné mít i strukturu ve struktuře (při použití je potřeba odpoznámkovat nastavení proměnné bod v konstruktoru)
        //public Bod bod;


        //konstruktor má stejné jméno jako struktura/třída
        //v konstruktoru musí být všechny členské proměnné ve struktuře přiřazené, pokud nejsou nepůjde kód přeložit
        public Bod3D(int x, int y, int z)
        {
            //slovo "this" (doslova toto/tato) určuje aktuální strukturu/třídu, ve které se konstruktor/metoda/členská-proměnná nachází
            //v aktuálním případě by se "this.x = x;" dalo přeložit jako "v této struktuře (tj. Bod3D) nastav členskou proměnnou 'x' na hodnotu vstupního parametru 'x'"
            //odlišení pomocí "this" je v tomto případě nutné, protože proměnné mají stejný název - jinak je možné napsat jen název členské proměnné, např. "ident" nemá v konstruktoru žádný jiný ekvivalent, takže je možné ho psát bez "this" (přesto se doporučuje this napsat pro lepší čitelnost a okamžitou informaci, že se jedná o členskou proměnnou nebo metodu)
            this.x = x;
            this.y = y;
            this.z = z;

            //použití statické metody v konstruktoru - statická metoda se používá zapsáním jména struktury/třídy a poté jejím jménem
            ident = Bod3D.RandomString(10);

            //pro nestatickou metodu
            //v případě použití nestatické metody se v konstruktoru při přiřazování identu rovnou z metody zobrazí chyba - nestatické metody je možné ve strukturách použít až když jsou nastaveny všechny členské proměnné, protože i v těchto metodách na ně můžete přístupovat a číst je
            //kompilátor nerozpozná, že tato metoda nijak neoperuje s členskými proměnnými a jen vrací string - pokud nevěříte, zapoznámkujte předchozí přiřazení do ident a nechte jen ten poslední
            ////ident = String.Empty;   //pokud by bylo potřeba použít nestatickou metodu, je nutné první přiřadit všem členským proměnným nějakou hodnotu, např. prázdný string
            //ident = this.RandomStringNestatic(10);


            ////vytvoření bodu struktury Bod (při použití je potřeba odpoznámkovat proměnnou bod před konstruktorem)
            //bod = new Bod();
        }



        //generování stringu o zadané délce přes náhodný generátor čísel (Random)
        //všiměte si, že se jedná o metodu statickou s viditelností private (jen pro použití ve struktuře)
        private static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            Random random = new Random();
            return new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
        }

        //jedná se o metodu nestatickou - nelze ji použít bez vytvoření instance struktury
        //a také private (jen pro použití ve struktuře)
        private string RandomStringNestatic(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            Random random = new Random();
            return new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
        }

        //následující řádky jsou dokumentací metody - vytvoříte je tak, že třikrát zadáte '/' před metodou, třídou apod. Jen u případných vyjímek musíte dopsat/zkopírovat element exception. Poté by se vám všechny informace zobrazily v prohlížeči objektů
        /// <summary>
        /// vrátí hodnotu ident, pokud byla nastavena ; viditelnost je public (použití i mimo strukturu, samozřejmě jen pokud existuje instance této struktury)
        /// </summary>
        /// <exception cref="System.Exception">Identifikátor vertexu je prázdný</exception>
        /// <returns>string - vrací členskou proměnnou Ident</returns>
        public string GetIdent()
        {
            if (this.ident != null && this.ident != String.Empty)
                return this.ident;
            else
                //pokud je ident nastaven na null (tzn. není inicializován a nemá žádnou referenci na string) anebo je inicializován na prázdný řetězec, vyhodí se výjimka
                //this.ident = "nový identifikátor nelze zapsat, protože je \"readonly\"";
                throw new Exception("Identifikátor vertexu je prázdný! Hážu výjimku...");
        }
    }
}
