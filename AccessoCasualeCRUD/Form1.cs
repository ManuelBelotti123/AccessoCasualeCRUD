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
            public int prezzo;
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

        //funzioni di servizio
        public static string Record(prodotto p, string sp, int lunghezzaRecord)
        {
            //stabiliamo una lunghezza fissa per ogni record
            return (p.nome + sp + p.prezzo + sp + p.quantita + sp + p.c).PadRight(lunghezzaRecord - 4) + "##";

        }

        public void AggFile(prodotto p, string sp, int lunghezzaRecord)
        {
            byte[] prod = Encoding.ASCII.GetBytes(Record(p, sp, lunghezzaRecord));
            var file = new FileStream(nomefile, FileMode.Append, FileAccess.Write);
            file.Write(prod, 0, prod.Length);
        }
    }
}