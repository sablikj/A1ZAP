Vyzkoušejte si následující příklady naprogramovat sami a ověřte vaše řešení se vzorovým řešením. Nejprve je lepší odladit program bez vstupu od uživatele a teprve poté dodělat vstup například z konzole. 

## Obsah a obvod obrazců
  - **Čtverec** Nejprve definujeme proměnnou typu *double*, tedy desetinné číslo, s názvem *delkaStrany* a poté definujeme proměnné *obvod* a *obsah*, opět typu *double*, kterým hned při inicializaci přiřadíme hodnoty pomocí výrazů pro výpočet obvodu a obsahu. Numerickou konstantu typu *double* je dobré zapisovat vždy včetně desetinné tečky, tedy například 5.0 místo jen 5. V tomto případě jde ale jen o doporučení, kód jde přeložit správně v obou případech, jen v některých případech by překladač mohl vyhodnotit výraz *(2/3)* jako celé číslo a například při dělení zaukrouhlovat dolů, místo *(2.0/3.0)* což vyhodnotí jako desetinné číslo.
    ```c#
    double delkaStrany = 5.0;

    double obvod = 4.0 * delkaStrany;
    double obsah = delkaStrany * delkaStrany;
    ```
  - **Obdélník** Postupujeme stejně jako u čtverce, ale tentokrát máme rozměry definované pomocí dvou proměnných *delka* a *sirka*.
    ```c#
    double sirka = 2.0;
    double delka = 3.0;
    
    double obvod = 2 * (delka + sirka);
    double obsah = delka * sirka;
    ```
  - **Kruh** Kód je obdobný jako předcházející, ale tentokrát budeme potřebovat hodnotu konstanty **PI**, která je definovaná ve třídě *Math* jako konstanta **Math.PI**. Pro druhou mocninu v obsahu nemusíme používat žádnou metodu, a je vhodnější a rychlejší použít jednoduše výraz *polomer * polomer*;
    ```c#
    double polomer = 3.0;
    
    double obvod = 2.0 * Math.PI * polomer;
    double obsah = Math.PI * polomer * polomer;
    ```
  - **Trojúhelník** zadaný délkami stran s využitím [Heronova vzorce](https://cs.wikipedia.org/wiki/Heronův_vzorec). Tentokát musíme využít metody **Math.Sqrt** pro druhou odmocninu;
    ```c#
    double a = 4;
    double b = 13;
    double c = 15;

    double obvod = a + b + c;

    double s = obvod / 2;
    double obsah = Math.Sqrt(s * (s - a) * (s - b) * (s - c));
    ```
## BMI Index
  - Vytvořte program pro výpočet hodnoty [BMI Indexu](https://cs.wikipedia.org/wiki/Index_tělesné_hmotnosti).
    ```c#
    double hmotnost = 75;
    double vyska = 1.87;

    double BMI = hmotnost / (vyska * vyska);
    ```
## Splátka hypotéky
  - Vytvořte program pro výpočet výše [splátky hypotéky](http://www.aristoteles.cz/matematika/financni_matematika/hypoteka-vypocet.php). Tentokrát už pro výpočet mocniny v^n musíme musíme použít metodu **Math.Pow(v, n)**.
    ```c#
    int pocetLetSplaceni = 20;
    double rocniUrokProcenta = 2;
    double D = 1000000; // dluh

    int n = pocetLetSplaceni * 12; // pocet mesicu splaceni
    double i = rocniUrokProcenta / (12 * 100); // desetinne cislo

    double v = 1 / (1 + i);
    double splatka = (i * D) / (1 - Math.Pow(v, n));
    ```