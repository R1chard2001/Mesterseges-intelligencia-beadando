using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabdaLabirintus
{
    class Allapot
    {
        public Point Hely;
        private static Point cel = new Point(2, 5);

        public Allapot()
        {
            Hely = new Point(4, 1);
        }

        public bool CellallapotE()
        {
            return Hely.Equals(cel);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for (int sor = 0; sor < 7; sor++)
            {
                for (int oszlop = 0; oszlop < 7; oszlop++)
                {
                    if (Palya.palya[oszlop, sor].FalFent)
                    {
                        sb.Append("████");
                    }
                    else if ((sor - 1 >= 0 && Palya.palya[oszlop, sor - 1].FalBalra) || (oszlop - 1 >= 0 && Palya.palya[oszlop - 1, sor].FalFent))
                    {
                        sb.Append("██  ");
                    }
                    else
                    {
                        sb.Append("    ");
                    }
                }
                sb.Append("██\n");
                for (int oszlop = 0; oszlop < 7; oszlop++)
                {
                    if (Palya.palya[oszlop, sor].FalBalra)
                    {
                        sb.Append("██");
                    }
                    else
                    {
                        sb.Append("  ");
                    }

                    if (Hely.X == oszlop && Hely.Y == sor)
                    {
                        sb.Append("()");
                    }
                    else if (cel.X == oszlop && cel.Y == sor)
                    {
                        sb.Append("|►");
                    }
                    else
                    {
                        sb.Append("  ");
                    }
                }
                sb.Append("██\n");
            }
            sb.Append("██████████████████████████████");
            return sb.ToString();
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Allapot)) return false;
            Allapot masik = (Allapot) obj;
            return masik.Hely.X == this.Hely.X && masik.Hely.Y == this.Hely.Y;
        }
    }
}
