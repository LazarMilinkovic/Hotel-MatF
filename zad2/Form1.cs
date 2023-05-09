using System;
using System.IO;

namespace zad2
{
    public partial class Form1 : Form
    {
        string tekst;
        StreamReader sr;
        Hotel hotel;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            sr = new StreamReader("sobe.txt");
            hotel = new Hotel();
        }

        private void ucitajBtn_Click(object sender, EventArgs e)
        {
            string s = sr.ReadLine();
            
            while(s != null)
            {
                var niz = s.Split(',');

                if(niz.Length == 4)
                {
                    hotel.sobe.Add(new PremiumSoba(int.Parse(niz[0]),
                        int.Parse(niz[1]), int.Parse(niz[2])));
                }
                else if(niz.Length == 3)
                {
                    hotel.sobe.Add(new StandardnaSoba(int.Parse(niz[0]),
                        int.Parse(niz[1]), int.Parse(niz[2])));
                }

                s = sr.ReadLine();
            }
            pregledBtn.Enabled = true;
            pronadjiBtn.Enabled = true;
            ucitajBtn.Enabled = false;
        }

        private void ocistiBtn_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
        }

        private void pregledBtn_Click(object sender, EventArgs e)
        {
            foreach (var item in hotel.sobe)
            {
                richTextBox1.AppendText(item.ToString());
                richTextBox1.AppendText("------------------------------------------");
                richTextBox1.AppendText("\n");
            }
        }

        private void pronadjiBtn_Click(object sender, EventArgs e)
        {
            Gost gost;
            Datum DatumOd;
            Datum DatumDo;
            string imePrezime;
            int strukturaSobe;
            int budzet;
            string datumOd;
            string datumDo;
            Termin termin;

            try
            {
                imePrezime = imePrezimeTb.Text;
                strukturaSobe = int.Parse(strukturaSobeTb.Text);
                budzet = int.Parse(budzetTb.Text);
                datumOd = datumOdTb.Text;
                datumDo = datumDoTb.Text;
                gost = new Gost(imePrezime, budzet, premiumCb.Checked);
                DatumOd = new Datum(datumOd);
                DatumDo = new Datum(datumDo);
                termin = new Termin(DatumOd, DatumDo);
            }
            catch (Exception)
            {
                MessageBox.Show("Neispravan usnos!","Greska");
                return;
            }
            foreach (var item in hotel.sobe)
            {
                if(strukturaSobe <= item.StrukturaSobe && item.Smesti(termin, gost))
                {
                    richTextBox1.Text = "Gost: " + imePrezime + ", " + budzet + "\n"
                        + "smesten je u sobi " + item.BrojSobe + "\n"
                        + "u terminu: " + termin.ToString() + "\n";
                    return;
                }
                else
                {
                    richTextBox1.Clear();
                    richTextBox1.Text = "Nije pronadjena odgovarajuca soba.";
                }
            }
        }
    }
}
