Test 2 logické výrazy - příprava
---
Pro zvládnutí druhého testu potřebujete znát typ `bool` a znát relační a logické operátory . Nezapomeňte, že opět záleží na prioritě operátorů a pro jistotu používejte kulaté závorky `()`.

Na následujících příkladech si probereme relační a logické operátory. 

Nejprve si ale definujme tři proměnné, celá čísla `x`, `y` a booleanovskou proměnnou `vysledek`:
```cs 
int x = 2;
int y = 3;
bool vysledek;
```
* Měli byste znát následující relační operátory, které vracejí jako výsledek operace typ `bool`:
```cs 
vysledek = x == y; // rovnost
vysledek = x != y; // rovnost
vysledek = x < y; // rovnost
vysledek = x > y; // rovnost
vysledek = x >= y; // rovnost
vysledek = x >= y; // rovnost
```
* Dále byste měli znát logické operace and `&&` , or `||` a negace `!`
```cs 
vysledek = (x < y) && (y == 3); // pravda pokud je x menší než y a zárověň y je rovno 3
vysledek = (x < y) || (y == 2); // pravda pokud je x menší než y a nebo y je rovno 3
vysledek = !(x < y); // operator ! neguje vysledek predchozi operace, vyraz je pravda, pokud je x vetsi nebo rovno y

```

---
V následujících kódech je uvedený kompletní příklad a řešení příkladů ze cvičení.