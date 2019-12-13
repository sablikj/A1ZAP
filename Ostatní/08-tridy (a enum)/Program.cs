using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08_tridy__a_enum_
{
    class Program
    {
        static void Main(string[] args)
        {

            //1. varianta příkladu je pro možnost bez definování konstruktorů a bez nastavování atributů/členských proměnných
            //2. varianta příkladu funguje po odpoznámkování konstruktoru a překryté metody ToString, a zapoznámkování použití instance pomocí implicitní varianty bezparametrického konstruktoru

            //1. varianta vytvoří instanci objektu třídy Casomira s voláním defaultního konstruktoru. Ten je vytvořen implicitně a jednotlivé atributy objektu nastaví na defaultní hodnoty, nebo reference (null)
            //Pozor! Implicitně se konstruktor vytváří jen tehdy, pokud programátor nedefinoval alespoň jeden konstruktor ve třídě explicitně - v takovém případě by již tento kód implicitně nefungoval a musel by se prázdný konstruktor také doprogramovat!
            Casomira casomira = new Casomira();

            //2. varianta zadává v konstruktoru časovou jednotku v minutách
            //Casomira casomira = new Casomira(CasovaJednotka.sekundy);

            Console.WriteLine("Chroustám výpočet, prosím čekejte...");
            //spustíme časomíru
            casomira.Spustit();
            for (ulong i = 0; i < 1000000000; i++)
            {
                //jen cyklíme, nic víc
            }
            //zastavíme časomíru a uvnitř se vypočítá uplynulý čas
            casomira.Zastavit();
            Console.Write("Dochroustal jsem, výsledný čas je: ");
            //pomocí metody GetUplynulyCas získáme hodnotu času s patřičnou jednotkou, která byla nastavena jako defaultní hodnota výčtového typu (ta první v pořadí - v našem případě milisekundy (toto platí jen pro 1. variantu příkladu, u 2. je výčtový typ explicitně nastaven pomocí konstruktoru)). Jednotku lze samozřejmě případně přímo změnit, protože má viditelnost public.
            Console.WriteLine(casomira.GetUplynulyCas() + " " + casomira.casovaJednotka.ToString());
            
            //použití metod, které se implicitně zdědily ze třídy Object
            Console.WriteLine("\nMetoda GetType  třídy Casomira vrátí: " + casomira.GetType());

            //1. variant příkladu zobrazí to samé, co metoda GetType (použije metodu s rodičovské třídy Object)
            //2. varianta příkladu již použije překrytou metodu ToString ze třídy Casomira
            Console.WriteLine("Metoda ToString třídy Casomira vrátí: " + casomira.ToString());


            Console.ReadKey(true);
        }
    }
}
