using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabdaLabirintus
{
    class Backtrack
    {
        private List<Operator> operatorok = new List<Operator>();
        public Backtrack()
        {
            operatorok.Add(new Operator(Irany.FEL));
            operatorok.Add(new Operator(Irany.LE));
            operatorok.Add(new Operator(Irany.JOBBRA));
            operatorok.Add(new Operator(Irany.BALRA));
        }

        public List<Allapot> Keres(int MelysegiKorlát = 100)
        {
            Csucs legjobbMegoldas = null;
            Csucs jelenlegiCsucs = new Csucs(new Allapot(), null);
            while (jelenlegiCsucs != null)
            {
                if (jelenlegiCsucs.OperatorIndex >= operatorok.Count || jelenlegiCsucs.Melyseg > MelysegiKorlát)
                {
                    jelenlegiCsucs = jelenlegiCsucs.Szulo;
                    continue;
                }
                if (jelenlegiCsucs.Allapot.CellallapotE())
                {
                    legjobbMegoldas = jelenlegiCsucs;
                    MelysegiKorlát = jelenlegiCsucs.Melyseg;
                    jelenlegiCsucs = jelenlegiCsucs.Szulo;
                    continue;
                }
                Operator kivalasztOperator = operatorok[jelenlegiCsucs.OperatorIndex];
                jelenlegiCsucs.OperatorIndex++;
                if (kivalasztOperator.AlkalmazhatoE(jelenlegiCsucs.Allapot))
                {
                    Csucs ujCsucs = new Csucs(kivalasztOperator.Alkalmaz(jelenlegiCsucs.Allapot), jelenlegiCsucs);
                    if (ujCsucs.Korfigyeles())
                    {
                        jelenlegiCsucs = ujCsucs;
                    }
                }
            }

            List<Allapot> legjobbUt = new List<Allapot>();
            while (legjobbMegoldas != null)
            {
                legjobbUt.Insert(0, legjobbMegoldas.Allapot);
                legjobbMegoldas = legjobbMegoldas.Szulo;
            }
            return legjobbUt;
        }
    }
}
