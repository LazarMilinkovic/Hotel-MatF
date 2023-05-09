using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zad2
{
    public class Gost
    {
        private string imePrezime;
        private int budzet;
        private bool premium;

        public Gost(string imePrezime, int budzet, bool premium)
        {
            if (imePrezime == null) throw new ArgumentNullException();
            if (!imePrezime.Contains(' ')) throw new ArgumentException();

            this.imePrezime = imePrezime;
            this.budzet = budzet;
            this.premium = premium;
        }

        public string ImePrezime
        {
            get
            {
                return imePrezime;
            }
        }
        public int Budzet
        {
            get
            {
                return budzet;
            }
        }
        public bool Premium
        {
            get
            {
                return premium;
            }
        }

        public override string ToString()
        {
            if (premium)
            {
                return imePrezime + "*, " + budzet;
            }

            return imePrezime + ", " + budzet;
        }
    }
}
