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
            lunghezzaRecord = 50;
            sp = ";";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        //funzioni di servizio
        public static string Record(prodotto p, string sp)
        {

            return (p.nome + sp + p.prezzo + sp + p.quantita + sp + p.c).PadRight(50) + "##";

        }

    }
}
