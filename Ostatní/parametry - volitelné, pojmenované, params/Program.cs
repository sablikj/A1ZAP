using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace parametry___volitelné__pojmenované__params
{
    class Program
    {
        static void Main(string[] args)
        {

            //volitelné (nepovinné) parametry
            Console.WriteLine("Použití volitelných (nepovinných) parametrů.\n");
            Console.WriteLine("Nejdříve v konstruktoru:");




            //vytvoření objektu student
            //když najedete myší na konstruktor, všiměte si, že poslední parametr je v hranatých závorkách a má přiřazenou hodnotu - takto jsou označeny volitelné parametry
            Student student = new Student("Pan Student", "S Nastaveným Věkem", 21);
            //zde volitelný parametr vynecháme (bude ve výchozím stavu nastaven na hodnotu 19)
            Student studentka = new Student("Slečna Studentová", "S Výchozím Věkem");

            //výpis informací o studentovi a studentce (pozn. \t v textu znamená použití tabulátoru, takže se text odsadí, jako byste zmáčkli klávesu TAB)
            Console.WriteLine($"{student.Jmeno}\t\t {student.Prijmeni}\t {student.Vek}");
            Console.WriteLine($"{studentka.Jmeno}\t {studentka.Prijmeni}\t {studentka.Vek}");
            Console.WriteLine(String.Empty);
            Console.WriteLine(String.Empty);




            Console.WriteLine("Použití metody SetStudentInformation\n");
            Console.WriteLine("S volitelnými parametry:");
            //v této metodě máme volitelné všechny parametry, takže můžeme zadat jen jeden nebo dokonce žádný (což by v tomto případě mělo jen ten efekt, že by se v metodě otestovaly parametry na null, takže by to bylo zbytečné plýtvání výpočetním časem)
            //od verze C# 7.1 je možné provést tento zápis s "default" jakožto příkazu pro použití výchozích hodnot (zde jsme chtěli nastavit pouze věk a s prázdným zápisem u prvních dvou parametrů bychom neuspěli)
            student.SetStudentInformation(default, default, 20);
            Console.WriteLine("S použitím \"default\" jako hodnoty parametru (C# 7.1 a vyšší)");
            Console.WriteLine($"{student.Jmeno}\t\t {student.Prijmeni}\t {student.Vek}");
            Console.WriteLine(String.Empty);

            //druhý (elegantnější) případ jak nastavit volitelné parametry (pokud je jich více) je pomocí pojmenovaných parametrů. Zde si zápisem jména parametru (dle definice metody), za kterou následuje ':' nastavíme na konkrétní hodnotu jen ten parametr (nebo ty parametry), který potřebujeme
            studentka.SetStudentInformation(vek: 20);
            studentka.SetStudentInformation(prijmeni: "Se Změněným Věkem");
            student.SetStudentInformation(vek: 30, prijmeni: "Zestarlý");
            //použití metody jen s jedním volitelným parametrem (specifikovaného pomocí atributu [Optional])
            student.SetStudentInformation("Pan Student II");
            Console.WriteLine("S použitím pojmenovaných parametrů");
            Console.WriteLine($"{studentka.Jmeno}\t {studentka.Prijmeni}\t {studentka.Vek}");
            Console.WriteLine($"{student.Jmeno}\t\t {student.Prijmeni}\t\t {student.Vek}");
            Console.WriteLine(String.Empty);




            //od C# 7.2 je možné to všechno takto namixovat, předtím nebylo možné nastavit jen hodnotu (nepojmenovaný parametr) na pozici za již uvedeným pojmenovaným parametrem napřímo (v tomto případě za parametrem "prijmeni"), ale musel se opět specifikovat pojmenovaný parametr
            //toto je zde spíše jen pro informaci, v podstatě není moc důvod to takto používat; právě naopak, je to spíše naškodu, že se to dá udělat takto mixovaně/nejednotně/chaoticky.
            Console.WriteLine("S použitím default, pojmenovaného parametru, i fixní pozice nepojmenovaného parametru ZA pojmenovaným parametrem (C# 7.2)");
            student.SetStudentInformation(default, prijmeni: "Ještě Více Starý", 40);
            Console.WriteLine(String.Empty);

            //Navíc je nutné mixování použít v seřazeném tvaru - ve chvíli, kdy prohodíme prijmeni a jmeno, dojde k chybě CS8323 "Pojmenovaný argument prijmeni se používá mimo pozici, je ale následovaný nepojmenovaným argumentem."
            //student.SetStudentInformation(prijmeni: "A Znovu Mladý", jmeno: "Omlazený", 20);

            //Následující příkaz bylo možné použít i před verzí 7.2, zde se totiž všechny nepojmenované proměnné zadávají před pojmenovanými
            Console.WriteLine("Použití nepojmenovaných parametrů PŘED pojmenovanými bylo možné i před verzí 7.2");
            studentka.SetStudentInformation("Slečna Studentová II", vek: 21, prijmeni: "Starší");

            Console.WriteLine($"{student.Jmeno}\t\t {student.Prijmeni}\t {student.Vek}");
            Console.WriteLine($"{studentka.Jmeno}\t {studentka.Prijmeni}\t\t\t {studentka.Vek}");
            Console.WriteLine(String.Empty);
            Console.WriteLine(String.Empty);





            Console.WriteLine("Použití modifikátoru params\n");

            uint vypocetSumyVeku = Student.VypocetSumyVekuStudentu();
            Console.WriteLine($"Suma věku studentů bez specifikovaného parametru: {vypocetSumyVeku}");

            //v případě použití modifikátoru params, můžeme hodnoty zadávat jako samostatné jednotky bez deklarace pole (to se vytvoří až v metodě)
            vypocetSumyVeku = Student.VypocetSumyVekuStudentu(student.Vek, studentka.Vek);
            Console.WriteLine($"Suma věku studentů se specifikovanými parametry (součet věku dvou definovaných studentů): {vypocetSumyVeku}");
            vypocetSumyVeku = Student.VypocetSumyVekuStudentu(student.Vek, studentka.Vek, 10, 15, 35, 48, 12, 48);
            Console.WriteLine($"Suma věku studentů se specifikovanými parametry (+součet s natvrdo vloženými hodnotami): {vypocetSumyVeku}");

            //samozřejmě by to šlo natvrdo specifikovat jako pole bytů
            vypocetSumyVeku = Student.VypocetSumyVekuStudentu(new byte[] { student.Vek, studentka.Vek, 10, 15, 35, 48, 12, 48 });
            Console.WriteLine($"Suma věku studentů se specifikovanými parametry (+součet s natvrdo vloženými hodnotami): {vypocetSumyVeku}");





            Console.ReadKey(true);

        }
    }
}
