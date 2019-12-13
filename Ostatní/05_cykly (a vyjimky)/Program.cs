using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_cykly__a_vyjimky_
{
    class Program
    {
        static void Main(string[] args)
        {


            //cyklus while se opakuje zatímco je splněna podmínka - v tomto případě pokud nebylo zadáno číslo
            bool zadanoCislo = false;
            float cisloDesetinne = 0;
            while (zadanoCislo == false)
            {
                Console.WriteLine("Zadejte číslo: ");
                string retezecSMoznymCislem = Console.ReadLine();

                //použití třídy Convert a ošetření možných vyjímek, které mohou nastat
                try
                {
                    cisloDesetinne = Convert.ToSingle(retezecSMoznymCislem);
                    //pokud se nepovede převod v předchozím řádku, dojde k výjimce a následující řádek se už neprovede
                    zadanoCislo = true;
                    break;
                }
                //pokud dojde k vyjímce při převodu řetězce na číslo, zachytí se jedna z následujících vyjímek (chyb). Detaily o každé metodě a jejich vyjímkách lze nalézt v Prohlížeči objektů (Object View) v menu Zobrazit (View) anebo najetím myši nad jméno metody
                catch (FormatException exFormat)
                {
                    Console.WriteLine("Zadaná hodnota není ve správném formátu! Zpráva z vyjímky: " + exFormat.Message);
                    Console.WriteLine(String.Empty);
                    continue;
                }
                catch (OverflowException exOverflow)
                {
                    Console.WriteLine("Zadaná hodnota reprezentuje číslo, které je menší než " + Single.MinValue + " nebo větší než " + Single.MaxValue + "! Zpráva z vyjímky: " + exOverflow.Message);
                    Console.WriteLine(String.Empty);
                    continue;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Neznámá chyba při převodu řetězce na číslo! - Zadaný řetězec nelze převést! Zpráva z vyjímky: " + ex.Message);
                    Console.WriteLine(String.Empty);
                    continue;
                }


                //Pokud jsou odpoznámkovány všechny break a continue příkazy výše, pak se už následující část kódu v tomto cyklu while neprovede. Buď dojde k vyskočení z cyklu (break) nebo k pokračování v cyklu zase od začátku (continue). Visual Studio by mělo také zahlásit varování o nedosažitelnosti kódu.


                //Použití metody TryParse - tato metoda zkusí převést string na číslo, a když uspěje, tak vrátí true a vstupně/výstupní (out) proměnná float (Single) bude nastavena na danou hodnotu. Když neuspěje, tak se vrátí false a v proměnné typu float (Single) bude 0.
                //Rozdíl oproti předchozímu je, že nevíme jaká chyba přesně nastala a zkoušení (try), zda se konverze převede je zde přímo implementováno. Toto řešení lze použít jen pro převod z řetězce! Pro převod z jiných datových typů se používá Convert!.
                if (Single.TryParse(retezecSMoznymCislem, out cisloDesetinne) == true)
                {
                    zadanoCislo = true;
                    //break;
                }
                else
                {
                    Console.WriteLine("Chyba při převodu řetězce na číslo! - Zadaný řetězec nelze převést!");
                    Console.WriteLine(String.Empty);
                    //continue;
                }

            }
            Console.WriteLine(String.Empty);
            Console.WriteLine(zadanoCislo);
            Console.WriteLine("Zadané desetinné číslo je: " + cisloDesetinne);





            //cyklus do-while se provede alespoň jednou. Takže i přesto, že podmínka ve while není splněna, přičtení se provede
            int cislo = 5;
            Console.WriteLine(String.Empty);
            Console.WriteLine(String.Empty);
            Console.WriteLine("Číslo pro do-while na začátku je: " + cislo);
            do
            {
                cislo += 15;
            } while (cislo <= 0);
            Console.WriteLine("Číslo pro do-while na konci je: " + cislo);





            //cyklus for má tři části oddělené středníkem:
            //v první části se deklarují lokální proměnné a inicializují se (nepovinná část, pokud proměnné již existují a jsou jim přiřazeny hodnoty)
            //v druhé části je testována podmínka - pokud platí, cyklus se provede
            //v třetí části se provede nastavení proměnných po každé iteraci (po provedení celého kódu v těle cyklu) dle zadaného vzorce (taktéž nepovinná část, ovšem v takovém případě by for cyklus degeneroval na pouhý while cyklus)
            //V první a třetí části lze proměnné oddělit čárkami
            Console.WriteLine(String.Empty);
            Console.WriteLine(String.Empty);
            Console.WriteLine("For cyklus (1): ");
            for (uint i = 1, j = 2;   i < 10000 && j <= 5000;   ++i, j = j * 50)
            {
                Console.WriteLine("i = " + i);
                Console.WriteLine("j = " + j);
                Console.WriteLine(String.Empty);
            }


            //V první části for cyklu není možné deklarovat různé datové typy více proměnných. Lze to obejít tím, že se deklarují ještě před for cyklem. V takovém případě ale budou tyto proměnné existovat i dále v programu a nejenom uvnitř for cyklu!
            uint i2, j2;
            int k2;
            Console.WriteLine(String.Empty);
            Console.WriteLine("For cyklus (2): ");
            //zde pozor na inkrementační kulišárnu s proměnnou i2 - nejdříve se i2 použije ve vzorci pro výpočet j2, a následně se inkrementuje o 1. (To jsou zmatky, co?)
            //Lepší by bylo to zapsat názorněji: "j2 = i2 * 50, i2++". Takto se sice ve výsledku provede to samé, ale je to více přehledné.
            for (i2 = 1, j2 = 0, k2 = -200;   i2 < 10000 && j2 <= 5000 && k2 <= 0;   j2 = i2++ * 50, k2 += 50)
            {
                Console.WriteLine("i2 = " + i2);
                Console.WriteLine("j2 = " + j2);
                Console.WriteLine("k2 = " + k2);
                Console.WriteLine(String.Empty);
            }





            Console.WriteLine(String.Empty);
            Console.WriteLine(String.Empty);
            Console.WriteLine(String.Empty);
            Console.WriteLine("Prosím, pokračujte stisknutím libovolné klávesy...");
            Console.ReadKey(true);

        }
    }
}
