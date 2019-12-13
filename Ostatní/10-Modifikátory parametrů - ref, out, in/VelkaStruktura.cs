using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modifikátory_parametrů___ref__out__in
{
    struct VelkaStruktura
    {
        public decimal a, b, c, d, e, f, g, h, i, j, k, l, m, n, o, p, q, r, s, t, u, v, w, x, y, z;
        private int a2;
        public int A2
        {
            get
            {
                return a2;
            }
            set
            {
                if (value > 0)
                    this.a2 = value;
            }
        }
        public int b2, c2, d2, e2, f2, g2, h2, i2, j2, k2, l2, m2, n2, o2, p2, q2, r2, s2, t2, u2, v2, w2, x2, y2, z2;
    }
}
