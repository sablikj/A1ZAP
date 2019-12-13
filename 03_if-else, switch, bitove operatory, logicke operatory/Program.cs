using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp_03
{
    class Program
    {
        static void Main(string[] args)
        {

            //bitový součin a součet
            bool pravda = (5 > 1) & (1 < 5);
            bool nepravda = (5 > 1) & (1 < 0);
            bool pravda2 = (5 > 1) | (1 < 0);
            bool nepravda2 = (5 < 1) | (1 < 0) | (5 < 4);

            Console.WriteLine(pravda);
            Console.WriteLine(nepravda);
            Console.WriteLine(pravda2);
            Console.WriteLine(nepravda2);
            Console.WriteLine(String.Empty);


            //logický AND a OR
            bool pravdaLogicka = (5 > 1) && (1 < 5);
            bool nepravdaLogicka = (5 > 1) && (1 < 0);
            bool pravda2Logicka = (5 > 1) || (1 < 0);
            bool nepravda2Logicka = (5 < 1) || (1 < 0) || (5 < 4);

            Console.WriteLine(pravdaLogicka);
            Console.WriteLine(nepravdaLogicka);
            Console.WriteLine(pravda2Logicka);
            Console.WriteLine(nepravda2Logicka);
            Console.WriteLine(String.Empty);




            //logický AND vs. bitový součin - aneb co je lepší pro vyhodnocení více podmínek?
            int x = 0;
            int y = 40;
            if (x != 0 && y / x >= 0)
            {
                Console.WriteLine("logický AND je true");
            }
            else
            {
                //pro podmínky je samozřejmě lepší logický AND, viz info v řetězci
                Console.Write("u logického AND se vykonají pouze příkazy do vyhodnocení prvního false nebo do konce celé podmínky (bráno z leva do prava), pak skončí s vyhodnocováním;");
                Console.Write(" tzn. dělení nulou (y / x) se neprovede, protože je až na druhém místě za podmínkou, jejíž výsledek je false.");
                Console.WriteLine(" Tento způsob také zaručí, že se nemusí zbytečně vyhodnocovat další podmínky, pokud už je jasné, že celková podmínka (ne)bude platit - ušetří se výpočetní čas.");
                //logický OR funguje obdobně, jen vykonává příkazy do vyhodnocení prvního true nebo do konce celé podmínky (opět bráno z leva do prava).
            }

            Console.WriteLine(String.Empty);
            Console.WriteLine("při použití bitového součinu zde dojde k vyjímce, pokud je x == 0");
            //pokud je x == 0, tak dojde k vyjímce (tento kód je nastaven, aby k ní došlo, a to kvůli ukázce, jak se chová bitový součin v příkazu if oproti logickému AND)
            if (x != 0 & y / x >= 0)
            {
                Console.WriteLine("u bitového součinu se vykonají všechny příkazy - funguje spíše jako matematický operátor; tzn. dělení nulou (y / x) se zde provede bez ohledu na to, kde je umístěno.");
            }
            else
            {
                Console.WriteLine("bitový součin je false");
            }
            Console.WriteLine(String.Empty);




            //switch použitý na hodnotu
            switch (y)
            {
                case 10:

                    Console.WriteLine("y je 10");
                    break;

                case 40:

                    Console.WriteLine("y je 40");
                    break;

                default:

                    Console.WriteLine("y neni 10 ani 40, ale něco jiného");
                    break;
            }
            Console.WriteLine(String.Empty);



            //switch použitý na řetězec
            string retezec = "co je to?";
            switch (retezec)
            {
                case "nevím":

                    Console.WriteLine("nevím co to je");
                    break;

                case "co je to?":

                    Console.WriteLine("je to ono");
                    break;

                default:

                    Console.WriteLine("něco úplně jiné");
                    break;
            }
            Console.WriteLine(String.Empty);




            Console.ReadKey(true);

        }
    }
}
