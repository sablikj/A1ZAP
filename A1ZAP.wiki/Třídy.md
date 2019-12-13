Vyzkoušete si následující příklady naprogramovat sami a ověřte vaše řešení se vzorovým řešením.

### **Vytvořte třídu pro kruh**
Třída bude mít *poloměr*,*parametrický konstruktor s poloměrem* a metody, které vrátí *obvod* a *obsah*. Dále vytvořte ukázkový kód použití třídy kruh:
- definujte proměnnou *k1* typu *Kruh*
- vytvořte kód který vypíše obsah a obvod proměnné kruhu *k1*
- definujte proměnnou *o2* typu Kruh a kód, který porovná, zda má kruh *k1* stejný poloměr jako kruh *k2*.

Vytvoříme čtyři různé varianty (bez zapouzdření, s Getterem a Setterem, s Property a s Auto-Implemented Property). V reálném kódu se ale vždy používají fieldy zapouzdřené, tedy skryté pomocí klíčového slova *private* nebo *protected*. Public mohou být jen Property. Gettery a settery se v jazyce C# nepoužívají, protože jazyk nabízí zjednodušený zápis pomocí Property. Ale například jazyk Java Property nemá a tam nam nezbývá nic jiného, než gettery a settery používat.

1. Varianta **Bez zapouzdření** - poloměr je *public field*
    ```c#
    class Kruh
    {
        public double polomer;

        public Kruh(double polomer)
        {
            this.polomer = polomer;
        }

        public double Obvod()
        {
            double obvod = 2.0 * Math.PI * polomer;
            return obvod;
        }

        public double Obsah()
        {
            double obsah = Math.PI * polomer * polomer;
            return obsah;
        }
    }
    ```
    Použití:

    ```c#
    static void Main(string[] args)
    {
        Kruh k1 = new Kruh(1.0);
        double obvod = k1.Obvod();            
        double obsah = k1.Obsah();
        Console.WriteLine($"Kruh ma polomer {k1.polomer}, obvod {obvod} a obsah {obsah}");   

        Kruh k2 = new Kruh(3.0);

        k1.polomer = 3.0;
        if(k1.polomer == k2.polomer)
        {
            Console.WriteLine("kruh k1 a k2 ma stejny polomer");
        }  
    }
    ```
2. **Se zapouzdřením a s využitím Getteru a Setteru** - poloměr je private. 

    Pomocí klíčového slova **private** skryjeme field *polomer* a přistupujeme k němu pomocí metod *GetPolomer* a *SetPolomer*. Metodu *SetPolomer* použiji i v konstruktoru a všude tam, kde chci přistupovat k fieldu *polomer*.

    ```c#
    class Kruh
    {
        private double polomer;

        public Kruh(double polomer)
        {
            SetPolomer(polomer);
        }

        public double GetPolomer()
        {
            return polomer;
        }

        public void SetPolomer(double polomer)
        {
            this.polomer = polomer;
        }

        public double Obvod()
        {
            double obvod = 2.0 * Math.PI * polomer;
            return obvod;
        }

        public double Obsah()
        {
            double obsah = Math.PI * polomer * polomer;
            return obsah;
        }
    }
    ```
    Použití:
    ```c#
    static void Main(string[] args)
    {
        Kruh k1 = new Kruh(1.0);
        double obvod = k1.Obvod();            
        double obsah = k1.Obsah();
        Console.WriteLine($"Kruh ma polomer {k1.GetPolomer()}, obvod {obvod} a obsah {obsah}");   

        Kruh k2 = new Kruh(3.0);

        k1.SetPolomer(3.0);
        if(k1.GetPolomer() == k2.GetPolomer())
        {
            Console.WriteLine("kruh k1 a k2 ma stejny polomer");
        }  
    }
    ```
3. **Se zapouzdřením a s využitím Property** - poloměr bude Property 

    S pomocí property můžeme zápis Getteru a Setteru zjednodušit. Privátní field (backing field) začíná dle jmenné konvence podtržítkem, například _polomer, tak abychom ho snadněji v kódu poznali a nepoužívali ho přímo. Vlastní název property začíná dle jmenné konvence vždy velkým písmenem.

    ```c#
    class Kruh
    {
        private double _polomer;

        public double Polomer
        {
            get
            {
                return _polomer;
            }
            set
            {
                _polomer = value;
            }
        }

        public Kruh(double polomer)
        {
            Polomer = polomer;
        }

        public double Obvod()
        {
            double obvod = 2.0 * Math.PI * Polomer;
            return obvod;
        }

        public double Obsah()
        {
            double obsah = Math.PI * Polomer * Polomer;
            return obsah;
        }
    }
    ```
    V kódu potom přistupujeme k property jako k fieldům, ale poznáme je tak, že dle jmenné konvence začíná jejich název velkým písmenem:
    ```c#
    static void Main(string[] args)
    {
        Kruh k1 = new Kruh(1.0);
        double obvod = k1.Obvod();            
        double obsah = k1.Obsah();
        Console.WriteLine($"Kruh ma polomer {k1.Polomer}, obvod {obvod} a obsah {obsah}");   

        Kruh k2 = new Kruh(3.0);

        k1.Polomer = 3.0;
        if(k1.Polomer == k2.Polomer)
        {
            Console.WriteLine("kruh k1 a k2 ma stejny polomer");
        }  
    }
    ```
4. **Se zapouzdřením a s využitím Auto-Implemented Property** - poloměr bude Auto-Implemented Property 

    Zapouzdření používáme proto, že chceme do budoucna přidat do getteru nebo setteru nějaký kód, například logování změn. Pokud ale zatím jen přistupujeme k *backing fieldu*, můžeme použít Auto-Implemented Property, což je zjednodušený zápis Property. A až budeme chtít v budoucnu nějaký kód do get nebo set části přidat, tak ji rozepíšeme z Auto-Implemented property na plnou Property. Auto-Implemented Property budeme v kódu používat nejčastěji.

    ```c#
    class Kruh
    {
        public double Polomer { get; set; }

        public Kruh(double polomer)
        {
            Polomer = polomer;
        }

        public double Obvod()
        {
            double obvod = 2.0 * Math.PI * Polomer;
            return obvod;
        }

        public double Obsah()
        {
            double obsah = Math.PI * Polomer * Polomer;
            return obsah;
        }
    }
    ```
    Použití Auto-Implemented Propery je stejné jako u Property:
    ```c#
    static void Main(string[] args)
    {
        Kruh k1 = new Kruh(1.0);
        double obvod = k1.Obvod();            
        double obsah = k1.Obsah();
        Console.WriteLine($"Kruh ma polomer {k1.Polomer}, obvod {obvod} a obsah {obsah}");   

        Kruh k2 = new Kruh(3.0);

        k1.Polomer = 3.0;
        if(k1.Polomer == k2.Polomer)
        {
            Console.WriteLine("kruh k1 a k2 ma stejny polomer");
        }  
    }
    ```
### **Vytvořte třídu pro výpočet splátky [úroku](http://www.aristoteles.cz/matematika/financni_matematika/hypoteka-vypocet.php)** 
Následující řešení je zjednodušené a chybí v něm zapouzdření a možná optimalizace.

- Definice třídy

    ```c#
    class Hypoteka
    {
        public int pocetLetSplaceni = 20;
        public double rocniUrokProcenta = 2;
        public double dluh = 1000000;

        public double VratSplatku()
        {
            int n = pocetLetSplaceni * 12; // pocet mesicu splaceni
            double i = rocniUrokProcenta / (12 * 100); // desetinne cislo

            double v = 1 / (1 + i);
            double splatka = (i * dluh) / (1 - Math.Pow(v, n));

            return splatka;
        }

        public double VratCelkovouCastku()
        {
            double splatka = VratSplatku();
            double castka = splatka * pocetLetSplaceni * 12;

            return castka;
        }
        public Hypoteka(int pocetLetSplaceni, double rocniUrokProcenta, double dluh)
        {
            this.pocetLetSplaceni = pocetLetSplaceni;
            this.rocniUrokProcenta = rocniUrokProcenta;
            this.dluh = dluh;
        }
    }
    ```
- Použití
    ```c#
    static void Main(string[] args)
    {
        Hypoteka hypoteka = new Hypoteka(10, 2, 1000000);
        double splatka = hypoteka.VratSplatku();

        Console.WriteLine($"Kdyz si pujcis {hypoteka.dluh} Kc na {hypoteka.pocetLetSplaceni} let");
        Console.WriteLine($"tak budes mesicne platit {hypoteka.VratSplatku():F2} Kc");
        Console.WriteLine($"Celkem zaplatis {hypoteka.VratCelkovouCastku():F2}");
    }
    ```