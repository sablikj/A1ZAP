Vyzkoušete si následující příklady naprogramovat sami a ověřte vaše řešení se vzorovým řešením. V reálných programech používáme většinou metody z knihovny LINQ jako je *Max()*, *Sum()* a *Average()*.

## Studenti
Vytvořte třídu reprezentující studenta se jménem a počtem bodů z testu. Dále definujte dynamické pole studentů a incializujte jej tak aby v něm byly čtyři instance studentů. Vypište jména a body všech studentů na terminál. Dále spočítejte průměrný počet bodů studentů v poli a napište kód, který najde a vypíše jméno a body studenta s nejvyšším počtem bodů.
  - Nejprve nadefinujeme třídu rezprezentující studenta se jménem a počtem bodů z testu.
    ```c#
    class Student
    {
        public string Jmeno { get; set; }
        public double Body { get; set; }

        public Student(string jmeno, double body)
        {
            Jmeno = jmeno;
            Body = body;
        }
    }
    ```

  - Poté nadefinujeme dynamické pole studentů a inicializujeme jej s pomoc čtyř instancí studentů (objektů bez jména)

    ```c#
    List<Student> studenti = new List<Student>()
    {
        new Student("Jirka", 85),
        new Student("Barbora", 90),
        new Student("Karel", 40),
        new Student("Jana", 70)
    };
    ```
  - Jména a body studentů můžeme vypsat pomocí nejčastěji používaných cyklů *for* nebo *foreach*. Pokud chceme vypsat všechny studenty, tak použijeme většinou *foreach*.
    ```c#
    foreach(Student student in studenti)
    {
        System.Console.WriteLine($"{student.Jmeno} {student.Body}");
    }
    ```
    Výpis pomocí cyklu *for* by vypadal takto. Všimněte si, že délku dynamického pole *List* získáváme pomocí property **Count** tedy ```studenti.Count``` a ne pomocí property *Length* jako u obyčejného pole.
    ```c#
    for(int i = 0; i < studenti.Count; i++)
    {
        Student student = studenti[i];
        Console.WriteLine($"{student.Jmeno} {student.Body}");        
    }
    ```
  - Pro určení průměrných bodů studentů nejprve určíme sumu bodů a poté spočítáme průměr. Nejprve, tedy definujeme pomocnou proměnnou *sum* a v cyklu *foreach* k ní postupně přičítáme body jednotlivých studentů v poli *studenti*. Nakonec určíme průměr tak, že podělíme sumu bodů počtem studentů ```studenti.Count```

    ```c#
    double sum = 0.0;
    foreach(Student student in studenti)
    {
        sum += student.Body;
    }

    double prumer = sum / studenti.Count;
    ```
    Alternativně můžeme použít metodu knihovny *LINQ* a *lambda epression*, ale toto řešení probereme až v příštím semestru. 
    ```c#
    double sum = studenti.Sum(student => student.Body);
    ```

- Pro určení studenta s nejvyšším počtem bodů si nejdříve definuji proměnnou *nejlepsi* a přiřadím jí referenci na prvního studenta v dynamickém poli, kterou můžu získat pomocí metody *First*  ```studenti.First()```, alternativně je možné použít výraz ```studenti[0]```. Dále procházím všechny studenty pomocí cyklu *foraech* a pokud najdu studenta s vyším počtem bodů, než má student v proměnné *nejlepší* tak přiřadím proměnné nejlepší referenci na aktuálního studenta. Nakonec po skončení cyklu vypíšu hodnoty nejlepšího studenta.

    ```c#
    Student nejlepsi = studenti.First();
    foreach(Student student in studenti)
    {
        if(student.Body > nejlepsi.Body)
        {
            nejlepsi = student;
        }
    }

    System.Console.WriteLine($"{nejlepsi.Jmeno} {nejlepsi.Body}");
    ```