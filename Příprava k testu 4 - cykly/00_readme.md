Test 4 cykly - příprava
---
Pro zvládnutí druhého testu potřebujete znát příkazy `goto`, `while`,  `do-while` a `for`. A dále ukončení cyklu pomocí `break` a přeskočení zbytku cyklu pomocí `continue`

Na následujících příkladech si probereme jednotlivé příkazy. 

* S pomocí příkazu `goto` můžeme přeskočit na libovolný řádek. Tento příkaz se používá spíše vyjímečně.
```cs 
    int i = 0;
label:
    Console.WriteLine(i);
    ++i;
    if (i < 10) goto label;
```
* S použitím příkazu `while` můžeme cyklus zpřehlednit. Cyklus while se používá většinou pokud neznáme předem počet opakování. Když počet opakování známe, tak použijeme spíše příkaz `for`.
```cs 
int i = 0;
while (i < 10)
{
    Console.WriteLine(i);
    ++i;
}
```
* Příkaz `do-while` používáme, pokud nevíme předem počet opakování a chceme aby se cyklus provedl alespoň jednou. Příkaz `Console.ReadKey(true).Key` čeká na stisk klávesy a nemusíme přitom zadávate enter.
```cs 
int n = 0;
do
{
    if (Console.ReadKey(true).Key == ConsoleKey.Spacebar)
    {
        ++n;
    }
} while (n < 3);
```
* Příkaz `for` používáme většinou, pokud předem známe počet opakování.

```cs 
for (int i = 0; i < 10; i++)
{
    Console.WriteLine(i);
}
```
* Provádění cyklu můžeme ukončit pomocí příkazu `break`. V následujícím příkazu výpis ukončíme po stiknutí klávesy `Escape`.

```cs 
Console.WriteLine("Stiskni klavesu Escape pro ukonceni vypisu");
Console.WriteLine("Stiskni libovolnou klavesu jinou klavesu nez Escape pro nove cislo");
            
for (int i = 0; i < 10; i++)
{
    if(Console.ReadKey(true).Key == ConsoleKey.Escape)
    {
        break;
    }
    Console.WriteLine(i);
}

Console.WriteLine("konec vypisu");
```
* Zbytek příkazů ve složeném příkazu cyklu můžeme přeskočit pomocí příkazu `continue`. V následujícím příkazu výpis přeskočíme stiskem klávesy `backspace`.

```cs 
for (int i = 0; i < 10; i++)
{
    if(Console.ReadKey(true).Key == ConsoleKey.Spacebar)
    {
        continue;
    }
    Console.WriteLine(i);
}

Console.WriteLine("konec vypisu");
```
---
V následujících kódech je uvedený kompletní příklad a řešení příkladů ze cvičení.