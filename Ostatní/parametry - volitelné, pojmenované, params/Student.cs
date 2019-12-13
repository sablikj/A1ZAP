using System.Runtime.InteropServices;

namespace parametry___volitelné__pojmenované__params
{
    class Student
    {

        private string jmeno;
        public string Jmeno
        {
            get
            {
                return this.jmeno;
            }
        }

        private string prijmeni;
        public string Prijmeni
        {
            get
            {
                return this.prijmeni;
            }
        }

        private byte vek;
        public byte Vek
        {
            get
            {
                return this.vek;
            }
        }



        //nepovinný/volitelný parametr v metodách/konstruktorech
        //do konstruktoru stejně jako do kterékoliv metody můžeme dát nepovinný (volitelný) parametr tím, že nastavíme jeho výchozí hodnotu (v tomto případě "vek" na hodnotu 19)
        //volitelné parametry musí být vždy na konci za všemi povinnými parametry. Jinými slovy: parametry, které nemají uvedenou žádnou výchozí hodnotu musí být uvedeny vlevo a parametry se specifikovanou výchozí hodnotou na pravé straně
        //př. pokud bychom do prvního parametru "jmeno" nastavili na null (nebo na jakýkoliv konstantní string) došlo by k chybě kompilátoru č. CS1737 "Volitelné parametry musí následovat po všech povinných parametrech"
        public Student(string jmeno /*= "neznamé"*/, string prijmeni, byte vek = 19)
        {
            this.jmeno = jmeno;
            this.prijmeni = prijmeni;
            this.vek = vek;
        }



        //pro nastavení všech informací použijeme volitelné parametry, s tím, že se informace ve studentovi přepíší jen pokud je v nich něco nastaveno
        //tato metoda je také v metodě Main využita pro představení tzv. pojmenovaných parametrů, díky kterým nemusíme zapisovat všechny volitelné parametry za sebou, ale v pořadí, jaké si zvolíme
        //(všimněte si také použití Nullable (viz minulá ukázka) parametru "vek" pro zjištění, zda byla tato hodnota nastavena, nebo ne)
        public void SetStudentInformation(string jmeno = null, string prijmeni = null, byte? vek = null)
        {
            //pokud bylo jméno nastaveno, přepiš jej
            if (jmeno != null)
            {
                this.jmeno = jmeno;
            }

            //pokud bylo přijmení nastaveno, přepiš jej
            if (prijmeni != null)
            {
                this.prijmeni = prijmeni;
            }

            //pokud byl věk nastaven, přepiš jej
            if (vek != null)
            {
                this.vek = vek.Value;
            }

        }


        //volitelné parametry můžeme také specifikovat tzv. atributem (neplést s atributy/členskými proměnnými/daty ve třídách!)
        //tyto atributy se zapisují do hranatých závorek před datový typ - v tomto případě se jedná o Optional v namespace "System.Runtime.InteropServices", které není ve výchozím stavu používáno, takže je nutné specifikovat, že jej používáme pomocí "using" na začátek tohoto souboru.
        public void SetStudentInformation([Optional] string jmeno)
        {
            //vzhledem k tomu, že by zde mohlo dojít k nejednoznačnosti (je zde stejný název metody jako výše, jen je zde jiný počet parametrů, přičemž ten první parametr je stejného typu (tzv. přetěžování metody)),
            //tak je nutné při volání metody stejného jména vložit další parametr, jinak by se volala v této metodě ta samá metoda pořád dokola rekurzivně (=zacyklení a vyhození vyjímky System.StackOverflowException)
            //s použitím dalšího parametru se ale specifikuje, že se má volat metoda uvedená výše (se třemi volitelnými parametry)
            this.SetStudentInformation(jmeno, default);
        }



        //klíčové slovo "params"
        //params může být použit pouze u posledního parametru metody
        //params musí být deklarován jako pole
        //params slouží pro předání proměnného počtu parametrů stejného typu
        //parametr označený jako "params" nemusí být specifikován
        //pomocí params tedy můžeme uvést, že je možné na poslední místo v metodě vkládat datové typy (v našem případě byte) oddělené čárkou
        //tzn. že zde definujeme pole a jako pole jej můžeme také používat, ale při volání je možné jen specifikovat parametry oddělené čárkou bez vytvoření instance pole bytů, a to až do námi zvolené velikosti (nebo možností paměti)
        //vzhledem k tomu, že by zde mohlo dojít k nejednoznačnosti a tím i menší přehlednosti, je zde metoda pro jistotu přejmenována
        public static uint VypocetSumyVekuStudentu(params byte[] vek)
        {
            //pole můžeme využívat tak, jak jsme zvyklí
            uint sumaVeku = 0;
            for (uint i = 0; i < vek.Length; ++i)
            {
                sumaVeku += vek[i];
            }
            return sumaVeku;
        }


    }
}
