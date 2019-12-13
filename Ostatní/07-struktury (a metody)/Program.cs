using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_struktury__a_metody_
{
    class Program
    {
        static void Main(string[] args)
        {


            //vytvoření b1 struktury Bod (viz. soubor Bod.cs) - není nutné volat defaultní konstruktor s prázdnými parametry
            //protože se jedná o hodnotový typ a nikoli referenci, lze ji deklarovat a hodnoty nastavit přímo až poté
            Bod b1;
            b1.x = 2;
            b1.y = 3;
            //vzhledem k tomu, že má "zapovězenáProměnná" viditelnost "private" není možné se na ni dostat zvenčí
            //b1.zapovězenáProměnná = 0;

            Console.WriteLine("x, y ve struktuře \"Bod\": " + b1.x + ", " + b1.y);
            Console.WriteLine("\n");    //2 krát zařádkuje naprázdno - jednou pomocí zástupného zápisu \n a podruhé funkcí WriteLine





            //u struktury Bod3D pokud nepoužijeme konstruktor, není možné používat metody struktury (např. GetIdent) a také by se nenastaví členská proměnná ident (viz implementace konstruktoru v souboru Bod3D.cs)
            Bod3D vertex;
            vertex.x = 10;
            vertex.y = 20;
            vertex.z = 30;

            //zde ještě na metodu nemůžeme, protože nebyl zavolán konstruktor struktury Bod3D
            //vertex.GetIdent();

            //zde bychom se na statickou metodu ve struktuře nedostali, protože má nastavenou viditelnost private - pokud bychom ji tedy chtěli použít museli bychom změnit viditelnost na public
            //string generovanyString = Bod3D.RandomString(10);

            Console.WriteLine("x, y, z ve struktuře \"Bod3D\" - zadáno bez konstruktoru: " + vertex.x + ", " + vertex.y + ", " + vertex.z);
            Console.WriteLine("\n");    //2 krát zařádkuje naprázdno - jednou pomocí zástupného zápisu \n a podruhé funkcí WriteLine



            vertex = new Bod3D(40, 50, 60);
            Console.WriteLine("x, y, z ve struktuře \"Bod3D\" - zadáno s konstruktorem: " + vertex.x + ", " + vertex.y + ", " + vertex.z);
            Console.WriteLine("Nyní se již na metodu GetIdent dostaneme: ident = \"" + vertex.GetIdent() + "\"");
            Console.WriteLine("\n");    //2 krát zařádkuje naprázdno - jednou pomocí zástupného zápisu \n a podruhé funkcí WriteLine


            //Při použití defaultního konstruktoru lze používat metody, ale pokud v konstruktoru nastavujete něco, co defaultně nastaveno nebude (v našem případě ident), může dojít k problémům
            //v našem případě dojde k problému při volání metody GetIdent, kde se testuje, zda je ident nastaven. Pokud nastaven není vyhodí se vyjímka.
            //házení vyjímek se provádí pomocí throw viz soubor Bod3D.cs v metodě GetIdent. Ošetřovat vyjímky jsme se už naučili (try-catch)
            vertex = new Bod3D();
            Console.WriteLine("x, y, z ve struktuře \"Bod3D\" - zadáno s defaultním (prázdným) konstruktorem: " + vertex.x + ", " + vertex.y + ", " + vertex.z);
            try
            { 
                Console.WriteLine("Nyní se již na metodu GetIdent dostaneme, ale hodí se nám v ní vyjímka, takže jdeme do catch: ident = \"" + vertex.GetIdent() + "\"");
            }
            catch (Exception ex)
            {
                //zobrazení zprávy, kterou hážeme ve vyjímce
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("\n");    //2 krát zařádkuje naprázdno - jednou pomocí zástupného zápisu \n a podruhé funkcí WriteLine



            //při předání struktury se v metodě hodnoty v paměti zkopírují
            ZměnaXYZ(vertex);
            Console.WriteLine("x, y, z ve struktuře \"Bod3D\" - Po zavolání metody ZměnaXYZ: " + vertex.x + ", " + vertex.y + ", " + vertex.z);
            Console.WriteLine("Nedošlo ke změně! (Proč, sí šarpe, proč?!) Protože se u vstupního parametru do metody kopíruje celá struktura.");
            Console.WriteLine("\n");    //2 krát zařádkuje naprázdno - jednou pomocí zástupného zápisu \n a podruhé funkcí WriteLine


            //předání pomocí ref umožňuje změnu v původní vstupní proměnné (bez kopírování - předává se reference)
            ZměnaXYZ(ref vertex);
            Console.WriteLine("x, y, z ve struktuře \"Bod3D\" - Po zavolání metody ZměnaXYZ s ref: " + vertex.x + ", " + vertex.y + ", " + vertex.z);
            Console.WriteLine("Díky použití \'ref\' došlo ke změně původních hodnot.");
            Console.WriteLine("\n");    //2 krát zařádkuje naprázdno - jednou pomocí zástupného zápisu \n a podruhé funkcí WriteLine




            List<Bod3D> a = new List<Bod3D>();
            a.Add(vertex);

            //pozor na práci se strukturami v Listu, pro zápis zde nelze přistupovat rovnou k jednotlivým částem ve struktuře, protože se vrací kopie hodnotového typu (struktura) a ne reference na strukturu v Listu
            //tzn. nastavit napřímo členskou proměnnou ve struktuře nelze - zobrazí se chyba CS1612 "Vrácenou hodnotu List<Bod3D>.this[int] nejde změnit, protože se nejedná o proměnnou."
            //a[0].x = 400000;

            //pro vyřešení je nutné nejdříve zkopírovat strukturu do lokální proměnné, změnit členskou proměnnou a poté nahradit strukturu na indexu Listu
            Bod3D c = a[0];
            c.x = 400000;
            a[0] = c;
            Console.WriteLine(vertex.x);
            Console.WriteLine(a[0].x);  //tento zápis pro čtení proměnné nicméně projde, protože se nic nepřiřazuje (hodnotu jen čteme)




            Console.ReadKey(true);

        }


        //metoda změní hodnoty zkopírované struktury, ale nic nezmění ve struktuře původní
        public static void ZměnaXYZ(Bod3D bod3D)
        {
            bod3D.x = 1;
            bod3D.y = 2;
            bod3D.z = 3;
        }

        //metoda změní hodnoty originální struktury, jejiž místo v paměti je odkazováno pomocí magického vstupně/výstupně parametrického slůvka 'ref'
        public static void ZměnaXYZ(ref Bod3D bod3D)
        {
            bod3D.x = 100;
            bod3D.y = 200;
            bod3D.z = 300;
        }

    }
}
