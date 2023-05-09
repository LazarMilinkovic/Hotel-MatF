using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

namespace zad2
{
    public class Datum
    {
        private int dan;
        private int mesec;

        public Datum(int dan, int mesec)
        {
            
        }
        public Datum(string datum)
        {
            var niz = ProveraZaDatum(datum);
            if (niz == null)
                throw new ArgumentException
                    
                    ();
            this.dan = int.Parse(niz[0]);
            this.mesec = int.Parse(niz[1]);
        }
        
        private string[] ProveraZaDatum(string datum)
        {
            string[] niz = null;
            int dan = 0;
            int mesec = 0;

            if(datum == null)
            {
                return null;
            }
            if (datum.Contains('/'))
            {
                niz = datum.Split('/');
                try
                {
                    dan = int.Parse(niz[0]);
                    mesec = int.Parse(niz[1]);
                }
                catch (Exception)
                {
                    return null;
                }
                if((mesec >= 1 && mesec <= 12) || (dan >= 1 && dan <= 31))
                {
                    return niz;
                }
                return null;
            }
            return null;
        }

        public static int Uporedi(Datum datum1, Datum datum2)
        {
            if (datum1.mesec > datum2.mesec)
                return 1;
            if (datum1.mesec < datum2.mesec)
                return -1;
            if(datum1.mesec == datum2.mesec)
            {
                if(datum1.dan > datum2.dan)
                    return 1;
                if(datum1.dan < datum2.dan)
                    return -1;
                if (datum1.dan == datum2.dan)
                    return 0;
            }

            return 0;
        }

        public override string ToString()
        {
            return dan + "/" + mesec;
        }
    }
}
