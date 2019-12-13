Vyzkoušete si následující příklady naprogramovat sami a ověřte vaše řešení se vzorovým řešením. V reálných programech používáme většinou cyklus **for** pokud známe předem počet opakování, cyklus **while** pokud předem neznáme počet opakování a cyklus **do-while** pokud neznáme počet opakování, ale chceme cyklus provést minimálně jednou. V některých následujících příkladech používáme cyklus *while* jen pro procvičení a v produkčním kódu bychom použili ve většině případů cyklus *for*.

## Výpis posloupnosti
Pomocí cyklu while a poté cyklu for vypište následující posloupnosti:
  - **0,1,2,3,4** Nejprve definujeme iterační proměnnou a inicializujeme ji na hodnotu *0* příkazem ```int i = 0;``` poté otestujeme zda platí podmínka ```i < 5``` a pokud platí tak vypíšeme hodnotu proměnné *i* na konzoli a pak zvýšíme její hodnotu o *1* pomocí operátoru inkrementace  ```++i```. Pokud podmínka neplatí, tak se cyklus ukončí. Po inkrementaci se celý cyklus opakuje a znovu začíná testem podmínky. 

    ```c#
    int i = 0;
    while (i < 5)
    {
        Console.WriteLine(i);
        ++i;
    }
    ```
    ```c#
    for (int i = 0; i < 5; i++)
    {
       Console.WriteLine(i);
    }
    ```
    
  - **10,11,12,13,14** Příklad je podobný jako předcházející, jen teď inicializujeme *i* na hodnotu *10* a cyklus se opakuje dokud platí podmínka ```i < 15```.
    ```c#
    int i = 10;
    while (i < 15)
    {
        Console.WriteLine(i);
        ++i;
    }
    ```
    ```c#
    for (int i = 10; i < 15; i++)
    {
       Console.WriteLine(i);
    }
    ```

  - **100,99,98,97,96** Ne vždy musíme v cyklu iterační proměnnou inkrementovat, tentokrát ji naopak snižujeme o *1* pomocí operátoru dekrementace ```--i``` a to tak dlouho, dokud platí že ```i > 95```.
    ```c#
    int i = 100;
    while (i > 95)
    {
        Console.WriteLine(i);
        --i;
    }
    ``` 
    ```c#
    for (int i = 100; i > 95; i--)
    {
       Console.WriteLine(i);
    }
    ```
  - **10,100,1000,10000,100000** v tomto případě místo zvýšení o *1*, vynásobníme iterační proměnnou číslem *10* ```i = i * 10```, nebo můžeme využít zkrácený zápis ```i *= 10```. Podmínka je tentokrát na menší rovno kvůli lepší přehlednosti ```i <= 100000```
    ```c#
    int i = 10;
    while (i <= 100000)
    {
        Console.WriteLine(i);
        i *= 10;
    }
    ``` 
    ```c#
    for (int i = 10; i <= 100000; i *= 10)
    {
       Console.WriteLine(i);
    }
    ```
  - **256,128,64,32,16** příklad je prakticky stejný jako předchozí, jen tentokrát proměnnou dělíme číslem *2* pomocí výrazu ```i /= 2``` dokud je hodnota proměnné větší nebo rovna *16*.
    ```c#
    int i = 256;
    while (i >= 16)
    {
        Console.WriteLine(i);
        i /= 2;
    }  
    ``` 
    ```c#
    for (int i = 256; i >= 16; i /= 2)
    {
        Console.WriteLine(i);
    }
    ```
## Výpis posloupnosti s podmínkou 
Pomocí cyklu for vypište na terminál následující posloupnosti:
  - **lichá čísla z intervalu 10 až 100** 
      - První možností je využití modulo operátoru, kdy lichá čísla mají zbytek po celočíselném dělění číslem *2* roven *1*, výraz ```i % 2 == 1``` tedy musí být pravdivý.
        ```c#
        for (int i = 10; i < 101; ++i)
        {
            if (i % 2 == 1)
            {
               Console.WriteLine(i);
            }
        }
        ```
      - Druhou možností je začít iteraci od čísla *11* a přičítat při každé iteraci číslo *2*.
        ```c#
        for (int i = 11; i < 101; i += 2)
        {
            Console.WriteLine(i);
        }
        ```
  - **sudá čísla z intervalu 10 až 100** 
      - Řešení je stejné jako u lichých čísel, kdy sudá čísla mají zbytek po celočíselném dělění číselm *2* roven 0, výraz ```i % 2 == 0``` tedy musí být pravdivý.
        ```c#
        for (int i = 10; i < 101; ++i)
        {
            if (i % 2 == 0)
            {
               Console.WriteLine(i);
            }
        }
        ```
      - Druhou možností je začít iteraci od čísla *10* a přičítat při každé iteraci číslo *2*.
        ```c#
        for (int i = 10; i < 101; i += 2)
        {
            Console.WriteLine(i);
        }
        ```
     
  - **čísla dělitelná 3 nebo 5 z intervalu 10 až 100** Číslo je dělitelné *třemi* pokud je zbytek po celočíselném dělění *třemi* roven *0* což zapíšeme výrazem ```i % 3 == 0``` a analogicky číslo je dělitelné *pěti*, pokud je zbytek po celočíselném dělění *pěti* roven *0* čemuž odpovídá výraz ```i % 5 == 0```. Pokud chceme zapsat podmínku že je číslo buď dělitelné *pěti* *nebo* dělitelné *třemi*, tak použijeme booleanovský výraz ```(i % 3 == 0) || (i % 5 == 0)```.
    ```c#
    for (int i = 10; i < 101; ++i)
    {
        if ((i % 3 == 0) || (i % 5 == 0))
        {
            Console.WriteLine(i);
        }
    }
    ```
##  Faktorial
  - S pomocí cyklu bez využití knihovních metod vytvořte výpočet [faktoriálu](https://cs.wikipedia.org/wiki/Faktoriál). Nejprve si definujeme pomocnou proměnnou *f* kterou inicializujeme na hodnotu *1* a poté ji postupně násobíme hodnotami *2* až *n*. Výraz ```f *= i``` je zkrácený zápis výrazu ```f = f * i```

    ```c#
    int n = 5;
    int f = 1;
    for (int i = 2; i <= n; i++)
    {
        f *= i;
    }
    ```
##  Mocnina
  - S pomocí cyklu bez využití knihovních metod vytvořte výpočet mocniny *x^y*, kdy exponent *y* i mocněnec *x* jsou celá čísla.  Nejprve si definujeme pomocnou proměnnou *mocnina* kterou inicializujeme na hodnotu proměnné *x* a poté ji postupně násobíme (y - 1)krát proměnnou *x* pomocí příkazu ```mocnina *= x;```. V běžném kódu bychom ale vlastní implementaci nevytvářeli a použili metodu *Math.Pow*.

    ```c#
    int x = 2;
    int y = 8;
    int mocnina = x;
    for (int i = 1; i < y; i++)
    {
        mocnina *= x;
    }
    ```
##  Splátkový kalendář
  - S využitím vzorce pro výpočet [splátky hypotéky](http://www.aristoteles.cz/matematika/financni_matematika/hypoteka-vypocet.php) vytvořte splátkový kalendář po měsících, kde uvedete aktuální výši dluhu, výši úroku a výši úmoru (splátka - úrok), tedy částky o kterou snížíte každý měsíc svůj dluh. Zápis ```{aktualniDluh,12:F2}``` se používá v [Interpolated Strings](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/interpolated-strings) a znamená že *aktualniDluh* bude zarovnaný na délku 12 znaků vpravo a bude mít dvě desetinná místa.
    ```c#
    int pocetLet = 20;
    double rocniSazbaProcenta = 2;
    double pocatecniDluh = 1000000; // dluh

    int pocetMesicu = pocetLet * 12; // pocet mesicu splaceni
    double mesicniSazba = rocniSazbaProcenta / (12 * 100); // desetinne cislo

    double v = 1 / (1 + mesicniSazba);
    double splatka = (mesicniSazba * pocatecniDluh) / (1 - Math.Pow(v, pocetMesicu));

    Console.WriteLine("Dluh            Úrok       Úmor");

    double aktualniDluh = pocatecniDluh;

    for (int i = 0; i <= pocetMesicu; i++)
    {
        double urok = mesicniSazba * aktualniDluh;
        double umor = splatka - urok;

        Console.WriteLine($"{aktualniDluh,12:F2} {urok,10:F2} {umor,10:F2} ");

        aktualniDluh -= umor;
    }       
    ```

