using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Configuration;
using System.Text;
using System.Threading.Tasks;

namespace LabdaLabirintus
{
    public enum Irany
    {
        FEL,
        LE,
        JOBBRA,
        BALRA
    }
    public class Operator
    {
        public Irany Merre;

        public Operator(Irany merre)
        {
            this.Merre = merre;
        }

        public bool AlkalmazhatoE(Allapot jelenlegiAllapot)
        {
            int osz = jelenlegiAllapot.Hely.X;
            int sor = jelenlegiAllapot.Hely.Y;
            switch (Merre)
            {
                case Irany.FEL:
                    return !Palya.palya[osz, sor].FalFent;
                case Irany.LE:
                    return !Palya.palya[osz, sor].FalLent;
                case Irany.JOBBRA:
                    return !Palya.palya[osz, sor].FalJobbra;
                case Irany.BALRA:
                    return !Palya.palya[osz, sor].FalBalra;
            }
            return false;
        }

        public Allapot Alkalmaz(Allapot jelenlegiAllapot)
        {
            Allapot ujAllapot = new Allapot();
            ujAllapot.Hely.X = jelenlegiAllapot.Hely.X;
            ujAllapot.Hely.Y = jelenlegiAllapot.Hely.Y;
            int xIrany = 0;
            int yIrany = 0;
            switch (Merre)
            {
                case Irany.FEL:
                    yIrany = -1;
                    break;
                case Irany.LE:
                    yIrany = 1;
                    break;
                case Irany.JOBBRA:
                    xIrany = 1;
                    break;
                case Irany.BALRA:
                    xIrany = -1;
                    break;
            }
            while (this.AlkalmazhatoE(ujAllapot))
            {
                ujAllapot.Hely.X += xIrany;
                ujAllapot.Hely.Y += yIrany;
            }
            return ujAllapot;
        }

        
    }
}
