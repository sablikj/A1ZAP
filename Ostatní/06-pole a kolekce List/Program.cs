using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_pole_a_kolekce_List
{
    class Program
    {
        static void Main(string[] args)
        {



            //deklarace pole
            double[] poleSDesetinnymiCisly;
            poleSDesetinnymiCisly = new double[5] { 10.45, 20.78, 30.34, 40.12, 50.10 };
            //poleSDesetinnymiCisly = { 10.45, 20.78, 30.34, 40.12, 50.10 };    //po alokaci pole jiz nebude mozne nastavit tímto způsobem hodnoty

            Console.WriteLine("Výpis prvků v poli pomocí cyklu foreach: ");
            //příkaz foreach je speciálním tvar příkazu for - doslova znamená pro každý prvek v poli/kolekci vykonej následující příkazy
            //prvni část v závorkách je definice každého jednoho prvku (abychom se na něj mohli v každé iteraci odkazovat)
            //druhá část říká, že každý prvek pochází z daného pole/kolekce - znamená to tedy, že počet iterací bude vždy stejný jako počet prvků v poli/kolekci
            foreach (double cislo in poleSDesetinnymiCisly)
            {
                Console.WriteLine(cislo);
            }

            Console.WriteLine(String.Empty);
            Console.WriteLine("Výpis prvků v poli pomocí cyklu for: ");
            //výpis pomocí cyklu for je klasika - atribut Length určuje délku pole
            for (int i = 0; i < poleSDesetinnymiCisly.Length; ++i)
            {
                Console.WriteLine(poleSDesetinnymiCisly[i]);
            }



            Console.WriteLine(String.Empty);
            Console.WriteLine("Pozor na kopie referenci: ");
            //kopie reference na pole
            double[] pseudoKopiePole = poleSDesetinnymiCisly;
            //opravdova kopie pole, stejné hodnoty, ale jiná reference v paměti
            double[] opravdovaKopie = new double[poleSDesetinnymiCisly.Length];
            //druha hodnota v metodě CopyTo určuje od kterého indexu v cílovém poli se mají hodnoty ze zdrojového pole začít vkládat
            poleSDesetinnymiCisly.CopyTo(opravdovaKopie, 0);

            //protoze se nekopiruji hodnoty, ale jen reference, tak podminka plati (reference se rovnají)
            if (poleSDesetinnymiCisly == pseudoKopiePole)
            {
                Console.WriteLine("Reference u poleSDesetinnymiCisly a pseudoKopiePole je stejná, tzn. obsahují odkaz na stejné místo v paměti.");
            }
            //protoze se netestuji hodnoty, ale jen reference, tak podminka plati (reference se NErovnají)
            if (poleSDesetinnymiCisly != opravdovaKopie)
            {
                Console.WriteLine("Reference u poleSDesetinnymiCisly a novePole není stejná, ale o hodnotách nám to nic neříká.");
            }






            //Generická kolekce List
            Console.WriteLine(String.Empty);
            Console.WriteLine("Generické kolekce umožňují dynamickou alokaci velikosti (přidávání, odebírání, vkládání prvků)");
            Console.WriteLine("Výpis prvků ve zkopírované kolekci List pomocí cyklu foreach: ");
            //konverze fixního pole na kolekci List, resp. na dynamické pole
            List<double> dynamickePole = poleSDesetinnymiCisly.ToList();
            foreach (double cislo in dynamickePole)
            {
                Console.WriteLine(cislo);
            }



            //deklarace nového Listu
            List<double> deklaraceNovehoListu = new List<double>();
            //přidání čísla po jednom
            deklaraceNovehoListu.Add(20);
            deklaraceNovehoListu.Add(30);
            deklaraceNovehoListu.Add(40);
            //přidání celé řady čísel
            deklaraceNovehoListu.AddRange(new List<double>() { 50, 60, 70, 80, 90, 100 });

            //vložení čísel na index 3 (stejně jako AddRange by zde šel použít i InsertRange)
            deklaraceNovehoListu.Insert(3, 100);
            deklaraceNovehoListu.Insert(3, 200);
            deklaraceNovehoListu.Insert(3, 300);

            //mazání čísel v kolekci
            deklaraceNovehoListu.RemoveAt(11);  //smaže prvek na 11. indexu
            deklaraceNovehoListu.Remove(60); //smaže prvek, který má hodnotu 60 (pokud je takových prvků víc, bere se jen ten v pořadí první, pokud tam není žádná, nic se nesmaže)


            Console.WriteLine(String.Empty);
            Console.WriteLine("Výpis prvků v nově vytvořené kolekci List pomocí cyklu for: ");
            //výpis pomocí cyklu for pro kolekce - atribut Count určuje délku Listu (nikoli Length jako u pole)
            for (int i = 0; i < deklaraceNovehoListu.Count; ++i)
            {
                Console.WriteLine(deklaraceNovehoListu[i]);
            }



            Console.WriteLine(String.Empty);
            Console.WriteLine("Výpis prvků v nově vytvořené kolekci List pomocí cyklu foreach + zkouška přidání, vkládání a smazání: ");
            try
            {
                //foreach si nejprve vybere všechny prvky z kolekce a prochází je jednu po druhé - pokud dojde k úpravě procházené kolekce, tj. smazání, přidání nebo vložení položky, vygeneruje se výjimka
                foreach (double cislo in deklaraceNovehoListu)
                {
                    Console.WriteLine(cislo);

                    //na každém následujícím řádku by došlo k vyjímce - samozřejmě zde dojde k vyjímce vždy u prvního příkazu a skočí se do catch, kde se vypíše chyba, ale po postupném zapoznámkování by byl výsledek stejný pro druhý, třetí a čtvrtý následující příkaz
                    deklaraceNovehoListu.Remove(cislo); //smazání prvku procházené kolekce nelze provést ve foreach
                    deklaraceNovehoListu.RemoveAt(8);   //ani mazání na specifickém indexu nefunguje
                    deklaraceNovehoListu.Add(1000);     //ani přidání nelze provést ve foreach
                    deklaraceNovehoListu.Insert(1, 2000);   //a vkládání už vůbec ne
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Došlo k chybě: " + ex.Message);
            }







            //dvourozměrné pole
            int[,] matice = new int[2, 3];

            //počet řádků matice je v první dimenzi na indexu 0
            int vyska = matice.GetLength(0);
            //počet sloupců matice je v druhé dimenzi na indexu 1
            int sirka = matice.GetLength(1);

            int k = 1;
            //projde všechny řádky
            for (int i = 0; i < vyska; i++)
            {
                //projde všechny sloupce v daném řádku
                for (int j = 0; j < sirka; j++)
                {
                    //přiřadí hodnotu 'k' na řádek 'i' a sloupec 'j'
                    matice[i, j] = k;
                    ++k;
                }
            }
            Console.WriteLine(String.Empty);
            Console.WriteLine("Výpis prvků ve dvourozměrném poli: ");
            //projde všechny řádky
            for (int i = 0; i < vyska; i++)
            {
                //projde všechny sloupce v daném řádku
                for (int j = 0; j < sirka; j++)
                {
                    //vypíše hodnotu na řádku 'i' a sloupci 'j'
                    Console.Write(matice[i, j] + "\t");
                }
                Console.WriteLine(String.Empty);
            }





            //vicerozměrne pole
            Console.WriteLine(String.Empty);
            Console.WriteLine("Výpis prvků v pětirozměrném poli: ");
            //takto nejak by se daly deklarovat pěti a případně i vícerozměrné pole
            int[,,,,] viceRozmeru = new int[2, 3, 1, 3, 2] { { { { { 7, 8 }, { 10, 20 }, { 30, 40 } } }, { { { 80, 100 }, { 200, 300 }, { 400, 500 } } }, { { { 600, 700 }, { 800, 900 }, { 1000, 21 } } } }, { { { { 12, 213 }, { 786, 876 }, { 786, 786 } } }, { { { 786, 786 }, { 786, 45 }, { 123, 3212 } } }, { { { 12, 12 }, { 12, 12 }, { 12, 12 } } } } };
            
            for (int i = 0; i < viceRozmeru.GetLength(0); i++)
            {
                for (int j = 0; j < viceRozmeru.GetLength(1); j++)
                {
                    for (k = 0; k < viceRozmeru.GetLength(2); k++)
                    {
                        for (int l = 0; l < viceRozmeru.GetLength(3); l++)
                        {
                            for (int m = 0; m < viceRozmeru.GetLength(4); m++)
                            {
                                //vypíše hodnotu na indexech 'i', 'j', 'k', 'l', 'm'
                                Console.Write(viceRozmeru[i, j, k, l, m] + "\t");
                            }
                            Console.WriteLine(String.Empty);
                        }

                        if (k == viceRozmeru.GetLength(2) - 1)
                        {
                            Console.WriteLine("Vzpoura aplikace: Nebudu to vypisovat všechno!");
                            //diky prikazu goto lze vyskocit z velke serie smycek bez pouziti prikazu break a podminek v kazdem samostatnem cyklu. Nicméně, příkaz goto by mel byt využíván citlivě a ojediněle kvůli přehlednosti - zde to vyjímečně přehlednosti prospěje, ale představte si serii příkazu goto, které skáčou sem a tam (tzv. "chaos goto")
                            goto VyskoceniZeVsechForu;
                        }
                    }
                }
            }
        VyskoceniZeVsechForu:



            Console.ReadKey(true);
        }
    }
}
