using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabdaLabirintus
{
    class Csucs
    {
        public Allapot Allapot;
        public int OperatorIndex;
        public Csucs Szulo;
        public int Melyseg;

        public Csucs(Allapot allapot, Csucs szulo)
        {
            this.Allapot = allapot;
            this.Szulo = szulo;
            if (szulo == null)
            {
                Melyseg = 0;
            }
            else
            {
                Melyseg = szulo.Melyseg + 1;
            }
            OperatorIndex = 0;
        }

        public bool Korfigyeles()
        {
            Csucs jelenlegi = this;
            while (jelenlegi != null)
            {
                if (jelenlegi.Equals(this)) return true;
                jelenlegi = jelenlegi.Szulo;
            }
            return false;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Csucs)) return false;
            Csucs masik = (Csucs) obj;
            return this.Allapot.Equals(masik.Allapot);
        }
    }
}
