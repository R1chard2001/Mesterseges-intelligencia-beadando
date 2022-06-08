using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using LabdaLabirintus;
using System.Drawing;

namespace LabdaLabirintusUnitTeszt
{
    [TestClass]
    public class LabdaLabirintusUnitTeszt
    {
        [TestMethod]
        public void ZsakutcaTeszt()
        {
            Palya.PalyaLegeneralasa();
            Backtrack bt = new Backtrack();
            Allapot.KezdoX = 0;
            Allapot.KezdoY = 0;
            List<Allapot> ut = bt.Keres(20);

            Assert.AreEqual(0, ut.Count);
        }

        [TestMethod]
        public void ZsakutcatesztOperatorokkal()
        {
            Palya.PalyaLegeneralasa();
            Allapot jelenlegiA = new Allapot();
            jelenlegiA.Hely.X = 0;
            jelenlegiA.Hely.Y = 4;
            Csucs jelenlegiC = new Csucs(jelenlegiA, null);
            Csucs vartCsucs = jelenlegiC;
            
            List<Operator> operatorok = new List<Operator>()
            {
                new Operator(Irany.FEL),
                new Operator(Irany.JOBBRA),
                new Operator(Irany.LE),
                new Operator(Irany.BALRA)
            };
            if (operatorok[0].AlkalmazhatoE(jelenlegiA))
            {
                Allapot ujAllapot = operatorok[0].Alkalmaz(jelenlegiC.Allapot);
                jelenlegiC = new Csucs(ujAllapot, jelenlegiC);
            }
            while (true)
            {
                if (jelenlegiC.OperatorIndex >= operatorok.Count)
                {
                    jelenlegiC = jelenlegiC.Szulo;
                    break;
                }
                Operator op = operatorok[jelenlegiC.OperatorIndex++];
                if (op.AlkalmazhatoE(jelenlegiC.Allapot))
                {
                    Allapot ujAllapot = operatorok[0].Alkalmaz(jelenlegiC.Allapot);
                    Csucs ujCsucs = new Csucs(ujAllapot, jelenlegiC);
                    if (!ujCsucs.Korfigyeles())
                    {
                        jelenlegiC = ujCsucs;
                    }
                }
            }
            Assert.AreEqual(vartCsucs, jelenlegiC);
        }

        [TestMethod]
        public void RemenytelenHelyzet()
        {
            Palya.palya = new Mezo[1, 1];
            Palya.palya[0, 0] = new Mezo(true, true, true, true);
            Allapot.KezdoX = 0;
            Allapot.KezdoY = 0;
            Backtrack bt = new Backtrack();
            List<Allapot> ut = bt.Keres(20);

            Assert.AreEqual(0, ut.Count);
        }

        [TestMethod]
        public void RemenytelenHelyzet1()
        {
            Palya.palya = new Mezo[1, 1];
            Palya.palya[0, 0] = new Mezo(true, true, true, true);
            Allapot.KezdoX = 0;
            Allapot.KezdoY = 0;
            Allapot allapot = new Allapot();

            List<Operator> operatorok = new List<Operator>()
            {
                new Operator(Irany.FEL),
                new Operator(Irany.JOBBRA),
                new Operator(Irany.LE),
                new Operator(Irany.BALRA)
            };

            foreach (Operator op in operatorok)
            {
                Assert.AreEqual(false, op.AlkalmazhatoE(allapot));
            }
        }
    }
}
