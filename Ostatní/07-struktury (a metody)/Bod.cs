using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_struktury__a_metody_
{
    //definice struktury Bod (struktura se chová jako hodnotový typ)
    struct Bod
    {
        public int x;
        public int y;
        private uint zapovězenáProměnná;    //vzhledem k tomu, že je viditelnost "private" nebude možné se na proměnnou dostat zvenčí (bylo by možné ji měnit/číst jen vnitřními metodami nebo konstruktorem)
    }
}
