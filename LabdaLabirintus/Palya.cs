using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabdaLabirintus
{
    public static class Palya
    {
        public static Mezo[,] palya = new Mezo[8, 8];
        public static void PalyaLegeneralasa()
        {
            palya = new Mezo[8, 8];

            palya[0, 0] = FJB();
            palya[1, 0] = FB();
            palya[2, 0] = FL();
            palya[3, 0] = FJ();
            palya[4, 0] = FB();
            palya[5, 0] = F();
            palya[6, 0] = FJL();

            palya[0, 1] = B();
            palya[1, 1] = N();
            palya[2, 1] = F();
            palya[3, 1] = N();
            palya[4, 1] = N();
            palya[5, 1] = N();
            palya[6, 1] = FJ();

            palya[0, 2] = B();
            palya[1, 2] = L();
            palya[2, 2] = J();
            palya[3, 2] = B();
            palya[4, 2] = N();
            palya[5, 2] = J();
            palya[6, 2] = BJ();

            palya[0, 3] = B();
            palya[1, 3] = F();
            palya[2, 3] = N();
            palya[3, 3] = LJ();
            palya[4, 3] = BJ();
            palya[5, 3] = B();
            palya[6, 3] = LJ();

            palya[0, 4] = LB();
            palya[1, 4] = N();
            palya[2, 4] = N();
            palya[3, 4] = F();
            palya[4, 4] = L();
            palya[5, 4] = N();
            palya[6, 4] = FJ();

            palya[0, 5] = FB();
            palya[1, 5] = J();
            palya[2, 5] = LBJ();
            palya[3, 5] = B();
            palya[4, 5] = F();
            palya[5, 5] = N();
            palya[6, 5] = J();

            palya[0, 6] = LB();
            palya[1, 6] = L();
            palya[2, 6] = FL();
            palya[3, 6] = LJ();
            palya[4, 6] = LB();
            palya[5, 6] = LJ();
            palya[6, 6] = LBJ();
        }

        public static void Print()
        {
            StringBuilder sb = new StringBuilder();
            for (int sor = 0; sor < 7; sor++)
            {
                for (int oszlop = 0; oszlop < 7; oszlop++)
                {
                    if (palya[oszlop, sor].FalFent)
                    {
                        sb.Append("████");
                    }
                    else
                    {
                        sb.Append("██  ");
                    }
                }
                sb.Append("██\n");
                for (int oszlop = 0; oszlop < 7; oszlop++)
                {
                    if (palya[oszlop, sor].FalBalra)
                    {
                        sb.Append("██  ");
                    }
                    else
                    {
                        sb.Append("    ");
                    }
                }
                sb.Append("██\n");
            }
            sb.Append("██████████████████████████████\n");
            Console.WriteLine(sb.ToString());
        }

        #region PalyaElemeinekGenerátorai
        private static Mezo N()
        {
            return new Mezo(false, false, false, false);
        }

        private static Mezo F()
        {
            return new Mezo(true, false, false, false);
        }
        private static Mezo J()
        {
            return new Mezo(false, true, false, false);
        }
        private static Mezo L()
        {
            return new Mezo(false, false, false, true);
        }
        private static Mezo B()
        {
            return new Mezo(false, false, true, false);
        }

        private static Mezo FJ()
        {
            return new Mezo(true, true, false, false);
        }
        private static Mezo FB()
        {
            return new Mezo(true, false, true, false);
        }
        private static Mezo FL()
        {
            return new Mezo(true, false, false, true);
        }
        private static Mezo LJ()
        {
            return new Mezo(false, true, false, true);
        }
        private static Mezo LB()
        {
            return new Mezo(false, false, true, true);
        }
        private static Mezo BJ()
        {
            return new Mezo(false, true, true, false);
        }

        private static Mezo FJB()
        {
            return new Mezo(true, true, true, false);
        }
        private static Mezo FJL()
        {
            return new Mezo(true, true, false, true);
        }
        private static Mezo FBL()
        {
            return new Mezo(true, false, true, true);
        }
        private static Mezo LBJ()
        {
            return new Mezo(false, true, true, true);
        }
        #endregion
    }

     public class Mezo
    {
        public Mezo(bool falFent, bool falJobbra, bool falBalra, bool falLent)
        {
            this.FalBalra = falBalra;
            this.FalJobbra = falJobbra;
            this.FalFent = falFent;
            this.FalLent = falLent;
        }

        public bool FalFent;
        public bool FalLent;
        public bool FalBalra;
        public bool FalJobbra;
    }
}
