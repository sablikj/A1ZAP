using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modifikátory_parametrů___ref__out__in
{
    class Program
    {

        //Modifikátory parametru, klíčové slova ref, out a in způsobí, že argument je předaný jako reference a ne jako hodnota
        //u ref a out se jakákoli změna parametru projeví na původním volaném argumentu
        //u ref a in musí být před voláním metody nastaven původní volaný argument, u out může být, ale nemusí
        //Modifikátory se používají především u hodnotových typů
        //Není nutné používat u referenčních typů (například instance tříd), protože ty se předávají jako reference automaticky
        //Klíčové slovo ref se používá u referenčních typu výjimečně a to pouze pokud chceme měnit referenci samotnou, například vytvořit úplně novou instanci třídy List. Jde prakticky o referenci na referenci (nebo v jazyku C ukazatel na ukazatel).
        //Modifikátor paramteru out také způsobí, že argument je předaný jako reference, ale zároveň má podmínku, že daná proměná bude v metodě inicializována před ukončením metody. out navíc nepracuje s původní hodnotou, ale vyžaduje vlastní nové přiřazení hodnoty (takže nelze do takové proměnné přičítat, odčítat ani z ní číst apod., a to i přesto, že byla před volání metody původní hodnota parametru nastavena)
        //Modifikátor paramteru in také způsobí, že argument je předaný jako reference, ale neumožňuje změnu tohoto argumentu. Použitelné spíše u předávání read-only reference na hodnotové typy (nejlépe struktury). Jedná se o novinku v C# 7.2. Na nižších verzích nelze použít, proto bude potřeba u vašich projektů změnit ve "Vlastnostech projektu -> v nabídce Sestavení -> tlačítko Upřesnit -> Jazyková verze: Nejnovější podverze C# (nejnovější)". C# 7.2 nejspíše pojede jen na Visual Studio 2017 s updaty nejméně po cca prosinci 2017, popř. na budoucích verzích Visual Studia. U předešlé verze VS nemohu potvrdit funkčnost, protože jsem to nezkoušel)

        //Pozor při přetěžování metod - ve chvíli, kdy použijete ref, out, nebo in v nějaké metodě, tak již dále není možné přetěžovat stejnou metodu se stejnými parametry s použitím jiného modifikátoru!

        //Je také potřeba mít na paměti, že vlastnosti (Properties) jsou metody a ne atributy, takže i když k nim přistupujete jako atributům, tak s refem, outem, inem nepochodíte

        //Tyto modifikátory nemohou být použity v Asynchronních metodách, které jsou definovány použitím modifikátoru "async".
        //A dále nemohou být použity v Iteračních metodách, která obsahují tzv. příkaz "yield return" nebo "yield break".


        //bez jakéhokoliv modifikátoru
        static void Metoda(int i)
        {
            ++i;
        }

        //u hodnotových typů klíčovým slovem 'ref' ve vstupních parametrech říkáme, že původní hodnotový typ MŮŽE, ale nemusí být změněn v dané metodě
        static void Metoda(ref int i)
        {
            //změna se provede, jen když je hodnota rovna 0, tzn. nemusí se měnit vždy (ale samozřejmě může)
            if (i == 0)
            {
                ++i;
            }
        }

        //klíčovým slovem 'out' říkáme, že původní hodnotový typ MUSÍ být v metodě nastaven (původní hodnota, která do metody vstupuje ale nastavena být nemusí)
        //V této metodě je přidán parametr "přepínač", protože jen s jedním parametrem int by již vzhledem k předchozímu použití metody s modifikátorem ref nebylo možné metodu přetížit
        //(zkrátka přetížení metody lze jen s jedním modifikátorem parametrů, pro přidání dalšího musíte být kreativnější - např. změnit název metody, nebo přidat vhodný/potřebný parametr)
        static void Metoda(out int i, bool přepínač)
        {
            ////inkrementaci/dekrementaci, přičítání/přinásobení/atd. nelze použít, protože out nepracuje s původní hodnotou, ale vyžaduje vlastní nové přiřazení
            //i++;
            //i *= 10;

            ////ani zkopírování hodnoty do jiné by neprošlo, pokud ještě není přiřazena hodnota i v této metodě
            //int a = i;

            //proměnná i musí být nastavena na nějakou hodnotu v každé možné větvi kódu, aby se zajistilo, že se opravdu nějaká hodnota vrátí
            if (přepínač == true)
            {
                i = 10;
            }
            else
            {
                i = 20;
            }
        }

        //klíčovým slovem 'in' říkáme, že původní typ NEMŮŽE být v metodě změněn (existuje jen ve verzích C# 7.2 nebo vyšší)
        //předává se tedy jen reference, což může být rychlejší při předávání reference u struktur, pokud ji nechceme v metodě měnit
        static bool MetodaJenIn(in int i)
        {
            ////když se do i pokusíme něco přiřadit, zobrazí se chyba
            //i = 1000;

            //v překladu příkaz znamená: Je 'i' větší rovno 0?
            return i >= 0 ? true : false;

        }




        //u referenčního typu (třídy, delegáti apod.) není potřeba klíčové slovo ref
        static void Metoda(List<int> list)
        {
            //přidání/mazání/změna apod. se projeví na původním Listu
            list.Add(100);

            //zde se předá jen reference na List
            List<int> pravaReferenceList = list;
            //zde se předá reference na referenci Listu
            ref List<int> refList = ref list;

            refList.Add(200);

            //hodnotu samotné reference není možné v metodě změnit
            //pokud to nicméně takto uděláte, tak se vytvoří lokální instance třídy List a na puvodní referenci se už nedostaneme, pokud jsme si ji ovšem nezkopírovali klasicky bez ref (viz pravaReferenceList)
            list = new List<int>() { 9, 8, 7 };
            //zde už se přidání projeví jen v lokálním Listu, protože původní byl překryt (samozřejmě pokud bychom se odkázali na pravaReferenceList, stále bychom mohli přidávat prvky)
            list.Add(9000);
            //paradoxně se teď přidá hodnota 300 do lokálního Listu a to i přesto, že jsme nepřiřadili nový list do této reference na referenci, ale jen tu původní (viz deklarace refList)
            refList.Add(300);

            //výpis nového lokálního Listu, refListu, a původního Listu se zkopírovanou referencí
            Console.WriteLine("Výpis nově vytvořeného Listu uvnitř metody bez ref: " + String.Join(", ", refList)); //9, 8, 7, 9000, 300
            Console.WriteLine("Výpis refList uvnitř metody bez ref: " + String.Join(", ", list)); //9, 8, 7, 9000, 300
            Console.WriteLine("Výpis původního Listu s předanou referencí uvnitř metody bez ref: " + String.Join(", ", pravaReferenceList)); // 1, 2, 3, 100, 200
        }


        //zde je reference na referenční typ
        static void Metoda(ref List<int> list)
        {
            //změna původní reference na novou instanci třídy List se projeví i mimo tuto metodu
            list = new List<int>() { 9, 8, 7 };
            list.Add(10000);
            list.Remove(8);
            list[0] = 12;
        }



        static void Main(string[] args)
        {
            

            int i = 0;


            //Předání argumentu klasicky jako hodnotový typ (v metodě se hodnota zkopíruje a pracuje se s lokální proměnnou)
            Metoda(i);
            Console.WriteLine("i = {0}", i); // i = 0


            //Předání argumentu jako reference na hodnotový typ (i je již inicializováno)
            Metoda(ref i);
            Console.WriteLine("i = {0}", i); // i = 1


            //Předání argumentu jako reference s vynucenou inicializací v metodě (inicializace a změny i v předchozím případě nám nic neovlivní)
            Metoda(out i, true);
            Console.WriteLine("i = {0}", i); // i = 10

            //zde x neinicializujeme a vše je v pořádku (při použití out)
            int x;
            Metoda(out x, false);
            Console.WriteLine("x = {0}", x); // x = 20

            //zde y musíme inicializovat
            int y = 5;
            bool vetsiNez0 = MetodaJenIn(in y);
            Console.WriteLine("y = {0} (Je větší než 0? {1})", y, vetsiNez0); // y = 5 (Je větší než 0? True)
            Console.WriteLine("");
            Console.WriteLine("");





            //pomocí ref lze také překopírovat referenci např. na strukturu - modifikátor ref je nutné použít před názvem struktury cílové i té původní (viz dále)

            //vytvoříme velkou strukturu klasickým způsobem
            VelkaStruktura struktura = new VelkaStruktura();
            struktura.A2 = 1000;
            Console.WriteLine("A2 ve struktuře = {0}", struktura.A2);   //1000

            //pro použití ref je nutné, aby byl zavolán konstruktor původní struktury, jinak se bere jako nepřiřazená
            ref VelkaStruktura refStruktury = ref struktura;
            refStruktury.A2 = 2000;
            //výpis hodnoty v původní struktuře, na kterou refStruktura také odkazuje
            Console.WriteLine("A2 v původní struktuře = {0}", struktura.A2);   //2000
            Console.WriteLine("");



            //Pole struktur a ref
            VelkaStruktura[] poleStruktur = new VelkaStruktura[4];

            //pozor zde kopírujeme strukturu a nepředáváme jen referenci
            poleStruktur[0] = refStruktury;
            poleStruktur[0].A2 = 4000;

            //zde samozřejmě také provedeme kopii struktury z pole
            VelkaStruktura kopieZpole = poleStruktur[0];
            kopieZpole.A2 = 5000;

            //důkazy místo slibů
            Console.WriteLine("A2 ve struktuře z pole struktur (kopieZpole) = {0}", kopieZpole.A2);   //5000
            Console.WriteLine("A2 v původní struktuře pole struktur (poleStruktur[0]) = {0}", poleStruktur[0].A2);   //4000
            Console.WriteLine("A2 v původní struktuře (struktura) = {0}", struktura.A2);   //2000
            Console.WriteLine("");

            //pomocí ref dostaneme referenci na prvek z pole struktur a ne kopii
            ref VelkaStruktura refZpole = ref poleStruktur[0];
            refZpole.A2 = 7000;
            //a opět důkaz, že se nám změní i hodnota ve struktuře v poli struktur
            Console.WriteLine("A2 v referencované struktuře z pole struktur (refZpole) = {0}", refZpole.A2);   //7000
            Console.WriteLine("A2 v původní struktuře pole struktur (poleStruktur[0]) = {0}", poleStruktur[0].A2);   //7000
            Console.WriteLine("");
            Console.WriteLine("");





            //ref, out, in pro referenční typy - příklady s Listem
            List<int> data = new List<int>() { 1, 2, 3 };
            Metoda(data);
            Console.WriteLine("Výpis původního Listu po zavolání metody bez ref: " + String.Join(", ", data)); // 1, 2, 3, 100, 200
            Console.WriteLine("");



            //Předání objektu referenčního typu jako reference - s použitím ref dojde ke změně, i když vytvoříme novou instanci Listu
            Metoda(ref data);
            Console.WriteLine("Výpis původního Listu po zavolání metody s ref: " + String.Join(", ", data)); // 12, 7, 10000
            Console.WriteLine("");





            Console.ReadKey(true);
        }
    }
}
