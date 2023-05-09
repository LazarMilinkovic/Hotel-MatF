using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zad2
{
    public class StandardnaSoba : Soba
    {
        public StandardnaSoba(int brojSobe, int strukturaSobe, int cena) : base(brojSobe, strukturaSobe, cena)
        {
        }

        public override bool Smesti(Termin termin, Gost gost)
        {
            foreach (var item in Zauzece)
            {
                if (item.Key.PreklapaSeSa(termin))
                    return false;
            }
            if (gost.Budzet >= Cena)
            {
                Zauzece.Add(termin, gost);
                return true;
            }

            return false;
        }
        public override string ToString()
        {
            return "Standardna soba " + base.ToString();
        }
    }
}
