using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_pretypovani_a_konverze
{
    class Program
    {
        static void Main(string[] args)
        {

            short x = 0;
            sbyte y = -44;
            //převede se datový typ short a sbyte na vyšší datový typ integer aniž by se cokoliv stalo nebo zobrazilo
            int z = x;
            z = y;


            int a = 2000000000;
            //přetypování nějak převede integer na short - při přetečení/podtečení bude short 'b' mít jinou hodnotu - v tomto případě "-27648"
            short b = (short)a;
            //Convert vyhodí vyjimku, protože hodnota integeru 'a' je příliš vysoká pro datový typ short 'b'
            b = Convert.ToInt16(a);

            decimal c = 1.0196498498484191189489499797m;
            //přetypování to nějak převede - v tomto případě ořeže na menší počet desetinných míst
            double d = (double)c;
            //V tomto případě udělá Convert úplně to samé jako přetypování, tj. ořeže hodnotu na double, ale vzhledem k vyšší možné maximální hodnotě doublu nezáleží na samotné velikosti hodnoty, ale jen její přesnosti na počet míst (float 7; double 15-16; decimal 28-29)
            d = Convert.ToDouble(c);

            //do doublu 'd' dáme příliš vysokou hodnotu, která nemůže být uložena v decimalu
            d = 4684616186141464456446164646665465465464646456456456546456654654645654645645645645645645645645646.165498498489119841984949;
            //přetypování nějak převede double na integer - při přetečení/podtečení bude int 'i' mít jinou hodnotu - v tomto případě "-2147483648"
            int i = (int)d;
            //přetypování nějak převede double na float - při přetečení/podtečení bude float 'f' mít jinou hodnotu - v tomto případě "Infinity" (nekonečno)
            float f = (float)d;
            //decimal to má u přetypování trochu jinak - přetypování to tentokrát nepřevede, ale vyhodí vyjimku, protože hodnota doublu 'd' je příliš vysoká pro datový typ decimal 'c'
            c = (decimal)d;
            //Convert vyhodí vyjimku, protože hodnota doublu 'd' je příliš vysoká pro datový typ decimal 'c'
            c = Convert.ToDecimal(d);

            double.Parse(a.ToString());

        }
    }
}
