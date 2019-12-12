Test 5 pole - příprava
---
Pro zvládnutí testu potřebujete vědět jak definovat pole, inicializovat ho, přistupovat k jeho prvkům, vytvářet kopii pole a porovnávat hodnoty v poli. 

Na následujících příkladech si probereme jednotlivé příkazy. 

* Typ pole vytvoříme tak, že za typ prvků v poli přidáme `[]`, například pole celých čísel `int` zapíšeme jako `int[]`. Následující příkaz definuje proměnnou typu pole `int[]` a protože pole je referenční typ, tak mu můžeme přiřadit hodnotu `null` což znamená že, nemá ještě přiřazené žádné hodnoty.
```cs 
int[] pole = null;
```
* Paměť pro vlastní hodnoty prvků potom alokujeme pomocí příkazu`new int[3]` kdy hodnota `3` je počet prvků. Proměnná pole potom představuje referenci na zásobníku na data alokované na haldě (pojmy zásobník a halda probereme v dalších přednáškách).
```cs 
pole = new int[3];
```
* Oba příkazy můžeme sloučit do jednoho zápisu:
```cs 
int[] pole = new int[3];
```
* a hodnoty můžeme inicializovat pole pomocí zápisu  `{ 1, 2, 3 }`.

```cs 
int[] pole = new int[3] { 1, 2, 3 };
```
* Předchozí zápis můžeme různým způsobem zkrátit. Všechny následující zápisy mají stejný výsledek:

```cs 
int[] pole1 = new int[3] { 1, 2, 3 };
int[] pole2 = new int[] { 1, 2, 3 };
int[] pole3 = new [] { 1, 2, 3 };
int[] pole4 = { 1, 2, 3 };
```
* Hodnoty prvků poli můžeme vypsat na konzoli s využitím příkazu `string.Join`:

```cs 
Console.WriteLine(string.Join(",", pole));
```
* K jednotlivým prvků poli přistupujeme pomocí hranatých závorek `[]`, kdy index začíná od nuly:

```cs 
int[] pole = new int[3] { 1, 2, 3 };
Console.WriteLine(pole[0]); // prvni prvek
Console.WriteLine(pole[1]); // druhy prvek
Console.WriteLine(pole[2]); // treti prvek
```
* Delku pole zjistíme pomocí property `pole.Length`. Následující příkaz nastaví hodnoty pole na 0,1,2:

```cs 
int[] pole = new int[3];
for (int i = 0; i < pole.Length; i++)
{
    pole[i] = i;
}
```
* Pokud přiřadíme hodnotu pole jinému poli tak předáme referenci na stejné prvky v poli. V následujícím příkazu tedy pole1 i pole2 mají referenci na stejná data:

```cs 
int[] pole1 = new int[3] { 1, 2, 3 };
int[] pole2 = pole1;
pole2[1] = 0;
// pole1 i pole2 budou mit vzdy stejne hodnoty
Console.WriteLine(string.Join(",", pole1));
Console.WriteLine(string.Join(",", pole2));
```
* Pokud chceme vytvorit nezavisle kopie, tak mame nekolik moznosti:
```cs 
int[] original = new int[3] { 1, 2, 3 };

int[] kopie1 = original.ToArray(); // vyzaduje using System.Linq

int[] kopie2 = new int[original.Length];
original.CopyTo(kopie2, 0);

int[] kopie3 = new int[original.Length];
Array.Copy(original, kopie3, original.Length);

original[1] = 0;
// vsechny kopie maji sva data a jsou nezavisle na originalnim poli

Console.WriteLine(string.Join(",", original));
Console.WriteLine(string.Join(",", kopie1));
Console.WriteLine(string.Join(",", kopie2));
Console.WriteLine(string.Join(",", kopie3));
```
---
V následujících kódech je uvedený kompletní příklad a řešení vybraných příkladů ze cvičení.