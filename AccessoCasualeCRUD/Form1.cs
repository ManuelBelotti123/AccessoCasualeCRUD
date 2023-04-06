using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccessoCasualeCRUD
{
    public partial class Form1 : Form
    {

        public struct prodotto
        {
            public string nome;
            public float prezzo;
            public int quantita;
            public int c;
        }

        prodotto p;
        string nomefile;
        int lunghezzaRecord;
        string sp;

        public Form1()
        {
            InitializeComponent();
            //inizializzazioni
            nomefile = "prodotti.txt";
            lunghezzaRecord = 54;
            sp = ";";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void aggiungi_Click(object sender, EventArgs e)
        {
            p.nome = nome.Text;
            p.prezzo = float.Parse(prezzo.Text);
            p.quantita = int.Parse(quantita.Text);
            p.c = 1;
            AggFile(p, sp, lunghezzaRecord);
        }

        private void cancella_Click(object sender, EventArgs e)
        {
            string ricerca = nome.Text;
            Cancella(ricerca, nomefile, sp, lunghezzaRecord);
        }

        //funzioni di servizio
        public string Record(prodotto p, string sp, int l)
        {
            //stabiliamo una lunghezza fissa per ogni record
            return (p.nome + sp + p.prezzo + sp + p.quantita + sp + p.c).PadRight(l - 4) + "##";

        }

        public void AggFile(prodotto p, string sp, int l)
        {
            AggProd(Record(p, sp, l), nomefile);
        }

        public void AggProd(string riga, string nomefile)
        {
            var oStream = new FileStream(nomefile, FileMode.Append, FileAccess.Write, FileShare.Read);
            StreamWriter sw = new StreamWriter(oStream);
            sw.WriteLine(riga);
            sw.Close();
        }

        public prodotto LineProd(string prodottostringa, string sp)
        {
            prodotto p;
            String[] div = prodottostringa.Split(sp[0]);
            p.nome = div[0];
            p.prezzo = float.Parse(div[1]);
            p.quantita = int.Parse(div[2]);
            p.c = int.Parse(div[3]);
            return p;
        }

        public void Cancella(string ricerca, string nomefile, string sp, int l)
        {
            prodotto p;
            String line;
            byte[] br;
            var file = new FileStream(nomefile, FileMode.Open, FileAccess.ReadWrite);
            BinaryReader reader = new BinaryReader(file);
            BinaryWriter writer = new BinaryWriter(file);
            file.Seek(0, SeekOrigin.Begin);
            while (file.Position < file.Length)
            {
                br = reader.ReadBytes(l);
                line = Encoding.ASCII.GetString(br, 0, br.Length);
                p = LineProd(line, sp);
                if (p.nome == ricerca)
                {
                    p.c = 0;
                    Record(p, sp, l);
                    file.Seek(-l, SeekOrigin.Current);
                    writer.Write(line);
                }
            }
            file.Close();
        }
    }
}