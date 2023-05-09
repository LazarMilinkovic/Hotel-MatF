using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zad2
{
    public class PremiumSoba : Soba
    {
        public PremiumSoba(int brojSobe, int strukturaSobe, int cena) : base(brojSobe, strukturaSobe, cena)
        {
        }

        public override bool Smesti(Termin termin, Gost gost)
        {
            foreach (var item in Zauzece)
            {
                if (item.Key.PreklapaSeSa(termin))
                    return false;
            }
            if (gost.Premium && gost.Budzet >= Cena * 0.85)
            {
                Zauzece.Add(termin,gost);
                return true;
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
            return "Premium soba " + base.ToString();
        }
    }
}
