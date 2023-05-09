using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zad2
{
    public abstract class Soba
    {
        private int brojSobe;
        private int strukturaSobe;
        private int cena;
        private Dictionary<Termin, Gost> zauzece;

        public Soba(int brojSobe, int strukturaSobe, int cena)
        {
            this.brojSobe = brojSobe;
            this.strukturaSobe = strukturaSobe;
            this.cena = cena;
            zauzece = new Dictionary<Termin, Gost>();
        }

        public int BrojSobe{ get { return brojSobe; } }
        public int StrukturaSobe { get { return strukturaSobe; } }
        public int Cena { get { return cena; } }
        public Dictionary<Termin, Gost> Zauzece { get { return zauzece; } }

        public abstract bool Smesti(Termin termin, Gost gost);
        public override string ToString()
        {
            var s = new StringBuilder();

            s.Append(brojSobe).Append(", ").Append(strukturaSobe).Append(", ").Append(cena)
                .Append("dinara").Append('\n');

            foreach (var item in zauzece)
            {
                s.Append("-> ").Append(item.Key).Append(", ").Append(item.Value).Append('\n');
            }

            return s.ToString();
        }
    }
}
