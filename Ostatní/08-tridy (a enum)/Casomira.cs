using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08_tridy__a_enum_
{
    /// <summary>
    /// Implementace časomíry pro měření výpočetní náročnosti úseků kódu
    /// </summary>
    //možnosti viditelnosti/přístupu jsou u třídy (class) public a internal (internal se nastavuje defaultně)
    public class Casomira
    {
        //v případě vnořených tříd je možné použít i private, protected atd.
        //private class vnorenaTrida
        //{
        //}

        /// <summary>
        /// Počáteční čas, kdy se spustila časomíra
        /// </summary>
        //(když neuvedete viditelnost (resp. přístupový modifikátor), tak je defaultně na private)
        DateTime pocatecniCas;

        /// <summary>
        /// Celkový uplynulý čas od spuštění časomíry po její zastavení
        /// </summary>
        TimeSpan uplynulyCas;

        /// <summary>
        /// Zvolená jednotka, ve které se čas zobrazuje (viz. výčtový typ CasovaJednotka)
        /// </summary>
        public CasovaJednotka casovaJednotka;


        //2. varianta vyžaduje odpoznámkování konstruktoru a překryté metody ToString

        ///// <summary>
        ///// konstruktor, který donutí programátora zadat parameter pro časovou jednotku
        ///// </summary>
        ///// <param name="casovaJednotka">časová jednotka časomíry</param>
        //public Casomira(CasovaJednotka casovaJednotka)
        //{
        //    this.casovaJednotka = casovaJednotka;
        //}

        ///// <summary>
        ///// metoda, která překrývá (override) původní implementaci metody ToString v základní třídě System.Object, která se implicitně vždy dědí (i když ji nezadáme)
        ///// </summary>
        ///// <returns>vrací kompletní zápis uplynulého času s informací Dny, Hodiny, Minuty, Sekundy, a Milisekundy</returns>
        //public override string ToString()
        //{
        //    return uplynulyCas.Days + " Dny, " + uplynulyCas.Hours + " Hodiny, " + uplynulyCas.Minutes + " Minuty, " + uplynulyCas.Seconds + " Sekundy, " + uplynulyCas.Milliseconds + " Milisekundy.";
        //}


        /// <summary>
        /// Spouští časomíru, vnitřně si uloží instanci třídy obsahující datum a čas v době spuštění
        /// </summary>
        public void Spustit()
        {
            this.pocatecniCas = DateTime.Now;
        }


        /// <summary>
        /// Zastaví časomíru tím, že zjistí aktuální datum a čas a prostě jej odečte od počátečního času
        /// </summary>
        /// <exception cref="System.Exception">Pokud nebyla časomíra spuštěna, nemůže být zastavena, tzn. pro správný chod je nutné nejprve zavolat metodu Spustit() nebo použít patřičný konstruktor, jinak bude mít členská proměnná pocatecniCas výchozí hodnoty (dle struktury DateTime)</exception>
        public void Zastavit()
        {
            //zde se testuje, zda hodnotový typ (v tomto případě struktura) má nastaveny defaultní hodnoty - pokud ne, provede se výpočet uplynulé doby
            if (this.pocatecniCas != default(DateTime))
                this.uplynulyCas = DateTime.Now - this.pocatecniCas;
            else
                throw new Exception("Nelze zastavit časomíru, pokud nebyla spuštěna!");
        }


        /// <summary>
        /// Metoda, která vrátí uplynulý čas, dle zadané jednotky, pokud zadaná není, vygeneruje se vyjímka
        /// </summary>
        /// <exception cref="System.Exception">Zvolená varianta časové jednotky nebyla v kódu ošetřena</exception>
        /// <returns>Vrací čas dle zadané časové jednotky. Hhodnota je s desetinnými čísly.</returns>
        public double GetUplynulyCas()
        {
            if (this.casovaJednotka == CasovaJednotka.milisekundy)
            { 
                return this.uplynulyCas.TotalMilliseconds;
            }
            else if (this.casovaJednotka == CasovaJednotka.sekundy)
            {
                return this.uplynulyCas.TotalSeconds;
            }
            else if (this.casovaJednotka == CasovaJednotka.minuty)
            {
                return this.uplynulyCas.TotalMinutes;
            }
            else if (this.casovaJednotka == CasovaJednotka.hodiny)
            {
                return this.uplynulyCas.TotalHours;
            }
            else if (this.casovaJednotka == CasovaJednotka.dny)
            {
                return this.uplynulyCas.TotalDays;
            }
            //pozn. vzhledem k tomu, že enum je hodnotový typ, tak u něj bude vždy nějaká výchozí hodnota (první v pořadí v definici enumu, v našem případě milisekundy),
            //else se tedy provede jen tehdy pokud programátor přídá a používá jiný enum, než je v této metodě ošetřen
            else
            {
                throw new Exception("Členská proměnná \"casovaJednotka\" nebyla nastavena!");
            }
        }

    }
}
