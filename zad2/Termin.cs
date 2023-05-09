using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zad2
{
    public class Termin
    {
        private Datum datumOd;
        private Datum datumDo;

        public Termin(Datum datumOd, Datum datumDo)
        {
            int rez = Datum.Uporedi(datumOd, datumDo);
            if(rez != 1)
            {
                this.datumOd = datumOd;
                this.datumDo = datumDo;
            }
            else
            {
                throw new ArgumentException();
            }
        }
        public override string ToString()
        {
            return datumOd.ToString() + " - " + datumDo.ToString();
        }

        public bool PreklapaSeSa(Termin termin)
        {
            if (Datum.Uporedi(termin.datumOd, datumOd) == 0 &&
                Datum.Uporedi(termin.datumDo, datumDo) == 0)
                return true;

            if(Datum.Uporedi(datumDo, termin.datumOd) == 1 &&
                Datum.Uporedi(datumDo, termin.datumDo) == -1)
                return true;

            if (Datum.Uporedi(datumOd, termin.datumOd) == 1 &&
                Datum.Uporedi(datumOd, termin.datumDo) == -1)
                return true;

            return false;
        }

        public static int Uporedi(Termin termin1, Termin termin2)
        {
            return Datum.Uporedi(termin1.datumOd, termin2.datumOd);
        }
    }
}
