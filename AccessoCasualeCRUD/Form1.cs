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
            AggFile(p, sp, lunghezzaRecord);
        }

        //funzioni di servizio
        public static string Record(prodotto p, string sp, int l)
        {
            //stabiliamo una lunghezza fissa per ogni record
            return (p.nome + sp + p.prezzo + sp + p.quantita + sp + p.c).PadRight(l - 4) + "##";

        }

        public void AggFile(prodotto p, string sp, int l)
        {
            AggProd(Record(p, sp, l), nomefile);
        }

        public static void AggProd(string riga, string nomefile)
        {
            var oStream = new FileStream(nomefile, FileMode.Append, FileAccess.Write, FileShare.Read);
            StreamWriter sw = new StreamWriter(oStream);
            sw.WriteLine(riga);
            sw.Close();
        }
    }
}