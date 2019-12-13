using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09_tridy_a_gettery_settery_vlastnosti
{
    class Program
    {
        static void Main(string[] args)
        {
            //student bez zapouzdření - přístup napřímo k public atributům
            Student_BezZapouzdření student_BezZapouzdření = new Student_BezZapouzdření("Ogar A.", 15);
            Console.WriteLine(InfoOPlnoletosti(student_BezZapouzdření.jmeno, student_BezZapouzdření.vek, student_BezZapouzdření.plnolety));
            //můžeme změnit napřímo věk, ale plnoletost se nám nezmění - museli bychom vše měnit ručně
            student_BezZapouzdření.vek = 21;
            Console.WriteLine(InfoOPlnoletosti(student_BezZapouzdření.jmeno, student_BezZapouzdření.vek, student_BezZapouzdření.plnolety));

            Console.WriteLine(String.Empty);
            Console.WriteLine(String.Empty);




            //student s gettery a settery - přístup pomocí metod Get... a Set...
            Student_Getter_Setter student_Getter_Setter = new Student_Getter_Setter("Pan B.", 51);
            Console.WriteLine(InfoOPlnoletosti(student_Getter_Setter.GetJmeno(), student_Getter_Setter.GetVek(), student_Getter_Setter.GetPlnolety()));
            //můžeme změnit věk a v metodě se otestuje, zda je plnoletý
            student_Getter_Setter.SetVek(14);
            Console.WriteLine(InfoOPlnoletosti(student_Getter_Setter.GetJmeno(), student_Getter_Setter.GetVek(), student_Getter_Setter.GetPlnolety()));

            Console.WriteLine(String.Empty);
            Console.WriteLine(String.Empty);




            //student s vlastností (property a auto-implemented property) - přístup přímo jako by to byly atributy (nicméně můžete si všimnout, že nyní jsou označeny klíčem a nikoli modrým obdelníkem)
            Student_Property student_Property = new Student_Property("Slečna C.", 20);
            Console.WriteLine(InfoOPlnoletosti(student_Property.Jmeno, student_Property.Vek, student_Property.Plnolety));
            //můžeme změnit věk a ve vlastnosti set se otestuje, zda je plnoletá (stejně jako v metodě)
            student_Property.Vek = 22;
            Console.WriteLine(InfoOPlnoletosti(student_Property.Jmeno, student_Property.Vek, student_Property.Plnolety));

            Console.WriteLine(String.Empty);
            Console.WriteLine(String.Empty);



            Console.ReadKey(true);
        }

        private static string InfoOPlnoletosti(string jmeno, byte vek, bool plnolety)
        {
            if (plnolety)
            {
                return jmeno + " je plnolet(ý/á)! " + vek + " let.";
            }
            else
            {
                return jmeno + " NENÍ plnolet(ý/á)! Nenalévat digitální alkohol! " + vek + " let.";
            }
        }
    }
}
