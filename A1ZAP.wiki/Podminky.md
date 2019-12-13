Vyzkoušete si následující příklady naprogramovat sami a ověřte vaše řešení se vzorovým řešením. Pokud je v kódu uvedeno hledání maxima, zamyslete se, a vytvořte variantu pro hledání minima.

## Větší ze dvou čísel
Pomocí podmíněného příkazu *if* otestujte a vypište hodnotu větší proměnné ze dvou.
* Pomocí booleanovského výrazu ```a > b``` který vrátí *true* pokud je *a* větší než *b* a jinak vrátí false otestujeme, která z proměnných je větší. Tento výraz potom použijeme v podmíněném příkazu ```if(a > b)```, kdy pokud bude výraz pravdivý, tak vypíšeme na konzoli hodnotu proměnné *a* příkazem  ```Console.WriteLine(a);``` a když výraz nebude pravdivý tak použijeme klíčové slovo ```else``` a vypíšeme hodnotu proměnné *b*.

    ```c#
    double a = 3;
    double b = 2;

    if(a > b)
    {
        Console.WriteLine(a);
    }
    else
    {
        Console.WriteLine(b);
    }
    ```

## Modulo
To zda je číslo dělitelné bezezbytku jiným číslem můžeme zjistit pomocí modulo operátoru, což který vrací zbytek po celočíselném dělení, například výraz ``` 8 % 3```, vrátí číslo 2, protože číslo 3 se vejde do čísla 8 beze zbytku dvakrát a *8 - (3 * 2)* je *2*.

* **Sudé číslo** Pomocí operátoru modulo ```x % 2 == 0``` otestujeme, zda je číslo sudé, tedy že číslo je bezezbytku dělitelné dvěma (zbytek po dělení dvěma je nulový).

    ```c#
    int x = 8;
    if(x % 2 == 0)
    {
        System.Console.WriteLine("sude");
    }
    ```
   
* **Líché číslo** Postupujeme stejně jako u sudého čísla, jen zbytek po dělení dvěma musí být roven *1*, výraz v podmínce tedy bude ```x % 2 == 1```.

    ```c#
    int x = 7;
    if(x % 2 == 1)
    {
        System.Console.WriteLine("liche");
    }
    ```
* **Číslo dělitelné beze zbytku 5** Postupujeme stejně jako u sudého čísla, zbytek po dělení *5* musí být roven *0*.

    ```c#
    int x = 5;
    if(x % 5 == 1)
    {
        System.Console.WriteLine("delitelny beze zbytku 5");
    }
    ```
## Maximum ze tří čísel
Vypište hodnotu nejvěšího čísla ze tří čísel. Tento úkol má více různých řešení, my jej vyřešíme čistě pomocí podmínek, potom s využitím pomocné proměnné a nakonec s využitím metody *Max.Math*.

* **Pomocí podmínek** Nejprve zjistíme, zda je *a > b*, pokud ano, tak víme, že *b* nemůže být největší protože je menší než *a*. Pak už nám stačí jen otestovat zda je *a > c* a pokud ano, tak je největší *a* jinak *c*. Pokud neplatí, že je *a > b* tak hodnota *a* není největší a pak už jen porovnáme hodnoty *b* a *c*.

    ```c#
    int a = 1;
    int b = 3;
    int c = 2;

    if(a > b)
    {
        if(a > c)
        {
            Console.WriteLine(a);
        }
        else
        {
            Console.WriteLine(c);
        }        
    } 
    else
    {
        if(b > c)
        {
            Console.WriteLine(b);
        }
        else
        {
            Console.WriteLine(c);
        }
    }
    ```
* **Pomocí pomocné proměnné** Nejprve si definujeme pomocnou proměnnou *pom* a přiřadíme jí hodnotu proměnné *a*. Pokud je pomocná proměnná *pom* menší než *b* tak jí přiřadíme hodnotu proměnné *b* a nakonec, pokud je hodnota pomocné proměnné *pom* menší než *b*, přiřadíme ji hodnotu proměnné *c*.

    ```c#
    int a = 1;
    int b = 3;
    int c = 2;

    int pom = a;

    if(pom < b)
    {
        pom = b;
    }

    if(pom < c)
    {
        pom = c;
    }

    Console.WriteLine(pom);
    ```
* **Pomocí metody *Math.Max*** Nejprve pomocí výrazu ```Math.Max(b, c)``` zjistíme zda má větší hodnotu proměnná *b* nebo *c* a výsledek potom porovnáme s hodnotou proměnné *a*.

    ```c#
    int a = 1;
    int b = 3;
    int c = 2;

    int max = Math.Max(a, Math.Max(b, c));

    Console.WriteLine(max);
    ```