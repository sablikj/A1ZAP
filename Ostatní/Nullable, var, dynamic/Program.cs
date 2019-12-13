using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nullable__var__dynamic
{
    class Program
    {
        static void Main(string[] args)
        {

            //generická struktura Nullable nám umožňuje používat null i pro hodnotové typy (int, bool, double, struct, enum atd.)
            //tento typ lze tedy inicializovat/změnit na null a je možné ho zapsat jednodušeji s '?' za názvem hodnotového typu
            //Nullable<double> zadaneCislo = null;
            double? zadaneCislo = null;
            Console.WriteLine("datový typ Nullable:");
            Console.WriteLine(String.Empty);

            //obsahuje dvě vlastnosti (property), první z nich zjišťuje, zda je uložena nějaká hodnota, nebo je null (samozřejmě by bylo možné toto udělat napřímo jako "zadaneCislo == null")
            while (zadaneCislo.HasValue == false)
            //while (zadaneCislo == null)
            {
                //pokud není zadano číslo opakuje smyčku

                Console.WriteLine("Zadejte průměr: ");
                string vstupniRetezec = Console.ReadLine();
                try
                {
                    //zkusime prevest na double, pokud dojde k vyjímce, tak v proměnné bude stále null
                    zadaneCislo = Convert.ToDouble(vstupniRetezec);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                Console.WriteLine(String.Empty);
            }
            //druhá vlastnost nám vrací hodnotu proměnné, pokud není nastavena na null, jinak dojde k vyjímce
            //zadaneCislo = null;
            double vysledekVzorce = 2 * Math.PI * zadaneCislo.Value;
            //pokud chceme vždy získat hodnotu bez vyjímky můžeme použít metodu GetValueOrDefault nebo operator ??
            vysledekVzorce = Math.PI * zadaneCislo.GetValueOrDefault();
            vysledekVzorce = Math.PI * zadaneCislo ?? -100.00;

            Console.WriteLine("Výsledný obvod je: " + vysledekVzorce);
            Console.WriteLine(String.Empty);



            //Nullable nelze klasicky porovnat na větší nebo menší, pokud je null - v tomto kódu se provede else
            zadaneCislo = null;
            if (zadaneCislo < vysledekVzorce)
                Console.WriteLine("zadaneCislo < vysledekVzorce");
            else if (zadaneCislo > vysledekVzorce)
                Console.WriteLine("zadaneCislo > vysledekVzorce");
            else if (zadaneCislo == vysledekVzorce)
                Console.WriteLine("zadaneCislo == vysledekVzorce");
            else
                Console.WriteLine("Nelze porovnat s null");
            Console.WriteLine(String.Empty);



            //pomocí pomocných metod ve statické třídě Nullable lze tento problém obejít, i když je proměnná null. V takovém případě se bere null jako nižší hodnota
            zadaneCislo = null;
            if (Nullable.Compare<double>(zadaneCislo, vysledekVzorce) < 0)
                Console.WriteLine("zadaneCislo < vysledekVzorce");
            else if (Nullable.Compare<double>(zadaneCislo, vysledekVzorce) > 0)
                Console.WriteLine("zadaneCislo > vysledekVzorce");
            else
                Console.WriteLine("zadaneCislo = vysledekVzorce");
            Console.WriteLine(String.Empty);
            Console.WriteLine(String.Empty);
            Console.WriteLine(String.Empty);



            //Shrnutí:
            //Nullable typ může být použit jen s hodnotovými typy
            //Vlastnost "Value" vyhodí vyjímku "InvalidOperationException" pokud bude hodnota null; jinak vrátí uloženou hodnotu v proměnné
            //Vlastnost "HasValue" vrátí "true", pokud je v proměnné uložena hodnota daného typu jinak (při null) vrátí false
            //S nulovým typem lze bezpečně použít pouze operátory "==" a "!=". Pro porovnání velikosti ('<' a '>') je bezpečnější použít metody ve statické třídě Nullable
            //Nelze použít vnořené nulové typy, např. "Nullable<Nullable<int>> i" zobrazí chybu (generickým typem totiž musí být hodnotový typ, který nemůže obsahovat null, který ale Nullable obsahovat může)








            //var - neboli implicitní datový typ lokální proměnné může být definován jen v metodách jakožto (překvapivě) lokální proměnná. (takže samozřejmě NELZE deklarovat atribut datového typu "var" ve třídě/struktuře)
            //Kompilátor vydedukuje datový typ podle hodnoty na pravé straně tohoto typu - var musí být tedy deklarován a inicializován ve stejnou dobu.
            //běžně se používá:
            //jako lokální proměnná ve funkci (opět překvapivě)
            //ve for/foreach smyčkách
            //pro anonymní typy
            //v using výrazech
            //V dotazových (query) výrazech LINQ



            //lokální proměnná, kompilátor si sám zjistí typ a našeptávač kódu díky tomu funguje v pořádku
            var cisloSDesetinnouCarkou = 10.001;
            var znak = 'a';
            Console.WriteLine("Lokální proměnné var:");
            Console.WriteLine(String.Empty);
            Console.WriteLine(cisloSDesetinnouCarkou + " typu: " + cisloSDesetinnouCarkou.GetType());
            Console.WriteLine(znak + " typu: " + znak.GetType());
            Console.WriteLine(String.Empty);
            //lokální proměnná var ve smyčce - pozor není možné za sebou deklarovat více varů, takže výraz "var i = 0, j = 0" by neprošel, i když "int i = 0, j = 0" ano
            for (var i = 0; i < 10; ++i)
            {
                Console.WriteLine(i + " ve for smyčce typu: " + i.GetType());
            }
            Console.WriteLine(String.Empty);
            Console.WriteLine(String.Empty);
            Console.WriteLine(String.Empty);





            //anonymní typ je referenčním typem a mohli bychom ho vytvořit následujícím způsobem (lze vytvořit i anonymní typ uvnitř anonymního typu, ale to zde není uvedeno)
            //deklaruje se pomocí var a instance se provádí klíčovým slovem new
            var anonymniTyp = new
            {
                retezec = "tydny",
                cislo = 2,
                pravdaNeboNe = true,
                datumACas = DateTime.Now,
                objekt = new object()
            };

            //hodnoty anonymního datového typu už nezměnímě, smíme je pouze číst
            //anonymniTyp.cislo = 5446;
            Console.WriteLine("Anonymní typ:");
            Console.WriteLine(String.Empty);
            Console.WriteLine($"{anonymniTyp.cislo} {anonymniTyp.retezec} do konce semestru? {anonymniTyp.pravdaNeboNe}");
            Console.WriteLine(String.Empty);


            //anonymní typ se většinou používá v LINQ dotazech při výběru jen některých položek např. ze seznamu.
            //V takovém případě neexistuje datový typ a my si samozřejmě jen kvůli tomu jednomu dotazu nebudeme vytvářet speciální (co když je potřeba vybrat jen některé, ale vždy různé kombinace údajů na 20 různých místech - to bychom z vytváření zešíleli a zbytečně bychom si zaplevelili kód).
            IList<Student> seznamStudentu = new List<Student>() {
                        new Student() { ID = 1, Jmeno = "Sheldon" , Vek = 11 },
                        new Student() { ID = 2, Jmeno = "Propadák" , Vek = 40  },
                        new Student() { ID = 3, Jmeno = "Agilní důchodce", Vek = 87 },
                        new Student() { ID = 4, Jmeno = "Slečna A",  Vek = 24 },
                        new Student() { ID = 5, Jmeno = "Rektorovo dítě XY",  Vek = 2 }
                    };

            //pomocí LINQ vybereme jen údaje, které 
            var studenti = from s in seznamStudentu
                               select new
                               {
                                   StudentVek = s.Vek,
                                   StudentJmeno = s.Jmeno
                               };
            //ve smyčce foreach sice nevíme jak se anonymní typ nazývá, ale to ani nemusíme, protože pomocí var problém vyřešíme
            foreach(var student in studenti)
            {
                Console.WriteLine("Jméno: " + student.StudentJmeno + " věk: " + student.StudentVek);
            }
            Console.WriteLine(String.Empty);
            Console.WriteLine(String.Empty);
            Console.WriteLine(String.Empty);









            //dynamický typ je neznámý kompilátoru, vyřeší se až při běhu aplikace.
            //při použití nefunguje našeptáveč kódu ani ochrana před chybným zadáním jména metody, vlastnosti apod., v důsledku nemožnosti kompilátoru toto předem určit - takže pozor na vyjímky
            Console.WriteLine("Dynamický typ:");
            Console.WriteLine(String.Empty);
            dynamic dynamickaPromenna = 100;
            Console.WriteLine(dynamickaPromenna);
            dynamickaPromenna = "Měníme dynamickou proměnnou a vše je OK. Troufneme si i na třídu!";
            Console.WriteLine(dynamickaPromenna);
            dynamickaPromenna = new Student() { ID = 9999, Jmeno = "Zed", Vek = 35 };
            Console.WriteLine(dynamickaPromenna);
            //našeptávání nefunguje, takže musíme kopírovat - při špatném zadání dojde k vyjímce RuntimeBinderException: Volání je nejednoznačné mezi následujícími metodami nebo vlastnostmi ...
            Console.WriteLine(dynamickaPromenna.ID);
            Console.WriteLine(dynamickaPromenna.Jmeno);
            Console.WriteLine(dynamickaPromenna.Vek);
            Console.WriteLine(String.Empty);

            //narozdíl od var může být dynamic použita i bez inicializace a poté se nějak nastaví až ve větvení - v tomto případě to bude buď ulong nebo string dle podmínky
            dynamic dynamickaPromenna2;
            //pomocí klíčového slova "is" se ptáme, zda je dynamický typ třídou "Student" - vrátí se výsledek typu boolean (true/false)
            //dynamickaPromenna = null;
            if (dynamickaPromenna is Student)
            {
                dynamickaPromenna2 = 10000000000000000000;
            }
            else
            {
                dynamickaPromenna2 = "Toto by teď nemělo nikdy nastat, ale kompilátor to neví, protože se testuje dynamická proměnná!";
            }
            Console.WriteLine(dynamickaPromenna2 + "    typu: " + dynamickaPromenna2.GetType().ToString());
            Console.WriteLine(String.Empty);



            Console.WriteLine("Dynamickou proměnnou uvedenou jako vstupní parametr metody je také možné vytvořit:");
            Student.VypisNeco("vypsání řetězce");
            Student.VypisNeco(10);
            Student.VypisNeco(-1231.12646);
            Student.VypisNeco(studenti.ElementAt(0));
            Console.WriteLine(String.Empty);
            Console.WriteLine(String.Empty);
            Console.WriteLine(String.Empty);





            Console.ReadKey(true);
        }
    }



    public class Student
    {
        public int ID { get; set; }
        public string Jmeno { get; set; }
        public int Vek { get; set; }


        //dynamický vstupní parametr akceptuje jakýkoliv datový typ, třídu apod.
        public static void VypisNeco(dynamic neco)
        {
            Console.WriteLine(neco + "     typu: " + neco.GetType().ToString());
        }
    }
}
