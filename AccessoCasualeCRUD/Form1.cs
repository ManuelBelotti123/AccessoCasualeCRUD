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
            AggProd(Record(p, sp, lunghezzaRecord), nomefile);
        }

        private void cancella_Click(object sender, EventArgs e)
        {
            Cancella(nome.Text, nomefile, sp, lunghezzaRecord);
        }

        private void modifica_Click(object sender, EventArgs e)
        {
            Modifica(nome.Text, nomemod.Text, float.Parse(prezzomod.Text), int.Parse(quantitamod.Text), nomefile, sp, lunghezzaRecord);
        }

        private void recdato_Click(object sender, EventArgs e)
        {
            RecuperaDato(nome.Text, nomefile, sp, lunghezzaRecord);
        }

        private void ricomp_Click(object sender, EventArgs e)
        {
            Ricompatta(nomefile, sp, lunghezzaRecord);
        }

        private void leggi_Click(object sender, EventArgs e)
        {
            Visualizza(nomefile, sp, lunghezzaRecord);
        }

        //funzioni di servizio
        public string Record(prodotto p, string sp, int l)
        {
            //stabiliamo una lunghezza fissa per ogni record
            return (p.nome + sp + p.prezzo + sp + p.quantita + sp + p.c).PadRight(l - 4) + "##\r\n";

        }

        public void AggProd(string riga, string nomefile)
        {
            var oStream = new FileStream(nomefile, FileMode.Append, FileAccess.Write, FileShare.Read);
            BinaryWriter writer = new BinaryWriter(oStream);
            char[] linea = riga.ToCharArray();
            writer.Write(linea);
            writer.Close();
            oStream.Close();
        }

        public prodotto RecOrCancLog(string prodottostringa, string sp, int c)
        {
            prodotto p;
            string[] div = prodottostringa.Split(sp[0]);
            p.nome = div[0];
            p.prezzo = float.Parse(div[1]);
            p.quantita = int.Parse(div[2]);
            p.c = c;
            return p;
        }

        public prodotto ModProd(string prodottostringa, string nome, float prezzo, int quantita, string sp)
        {
            prodotto p;
            string[] div = prodottostringa.Split(sp[0]);
            p.nome = nome;
            p.prezzo = prezzo;
            p.quantita = quantita;
            p.c = 1;
            return p;
        }

        public void Cancella(string ricerca, string nomefile, string sp, int l)
        {
            prodotto p;
            string line;
            byte[] br;
            var file = new FileStream(nomefile, FileMode.Open, FileAccess.ReadWrite);
            BinaryReader reader = new BinaryReader(file);
            BinaryWriter writer = new BinaryWriter(file);
            file.Seek(0, SeekOrigin.Begin);
            while (file.Position < file.Length)
            {
                br = reader.ReadBytes(l);
                line = Encoding.ASCII.GetString(br, 0, br.Length);
                string[] div = line.Split(sp[0]);
                if (div[0] == ricerca)
                {
                    p = RecOrCancLog(line, sp, 0);
                    line = Record(p, sp, l);
                    file.Seek(-l, SeekOrigin.Current);
                    char[] linea = line.ToCharArray();
                    writer.Write(linea);
                }
            }
            reader.Close();
            writer.Close();
            file.Close();
        }

        public void Modifica(string ricerca, string nome, float prezzo, int quantita, string nomefile, string sp, int l)
        {
            prodotto p;
            string line;
            byte[] br;
            var file = new FileStream(nomefile, FileMode.Open, FileAccess.ReadWrite);
            BinaryReader reader = new BinaryReader(file);
            BinaryWriter writer = new BinaryWriter(file);
            file.Seek(0, SeekOrigin.Begin);
            while (file.Position < file.Length)
            {
                br = reader.ReadBytes(l);
                line = Encoding.ASCII.GetString(br, 0, br.Length);
                string[] div = line.Split(sp[0]);
                if (div[0] == ricerca)
                {
                    p = ModProd(line, nome, prezzo, quantita, sp);
                    line = Record(p, sp, l);
                    file.Seek(-l, SeekOrigin.Current);
                    char[] linea = line.ToCharArray();
                    writer.Write(linea);
                }
            }
            reader.Close();
            writer.Close();
            file.Close();
        }

        public void RecuperaDato(string ricerca, string nomefile, string sp, int l)
        {
            prodotto p;
            string line;
            byte[] br;
            var file = new FileStream(nomefile, FileMode.Open, FileAccess.ReadWrite);
            BinaryReader reader = new BinaryReader(file);
            BinaryWriter writer = new BinaryWriter(file);
            file.Seek(0, SeekOrigin.Begin);
            while (file.Position < file.Length)
            {
                br = reader.ReadBytes(l);
                line = Encoding.ASCII.GetString(br, 0, br.Length);
                string[] div = line.Split(sp[0]);
                if (div[0] == ricerca)
                {
                    p = RecOrCancLog(line, sp, 1);
                    line = Record(p, sp, l);
                    file.Seek(-l, SeekOrigin.Current);
                    char[] linea = line.ToCharArray();
                    writer.Write(linea);
                }
            }
            reader.Close();
            writer.Close();
            file.Close();
        }

        public void Ricompatta(string nomefile, string sp, int l)
        {
            prodotto p;
            string line;
            byte[] br;
            var file = new FileStream(nomefile, FileMode.Open, FileAccess.ReadWrite);
            var appoggio = new FileStream("appoggio.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            BinaryReader reader = new BinaryReader(file);
            BinaryWriter writer = new BinaryWriter(appoggio);
            file.Seek(0, SeekOrigin.Begin);
            appoggio.SetLength(0);
            while (file.Position < file.Length)
            {
                br = reader.ReadBytes(l);
                line = Encoding.ASCII.GetString(br, 0, br.Length);
                string[] div = line.Split(sp[0]);
                string c = div[3];
                if (c[0] != '0')
                {
                    writer.Write(br);
                }
            }
            file.SetLength(0);
            appoggio.Position = 0;
            appoggio.CopyTo(file);
            reader.Close();
            writer.Close();
            file.Close();
            appoggio.Close();
        }

        public void Visualizza(string nomefile, string sp, int l)
        {
            listView1.Items.Clear();
            prodotto p;
            string line;
            byte[] br;
            var file = new FileStream(nomefile, FileMode.Open, FileAccess.ReadWrite);
            BinaryReader reader = new BinaryReader(file);
            file.Seek(l, SeekOrigin.Begin);
            while (file.Position < file.Length)
            {
                br = reader.ReadBytes(l);
                line = Encoding.ASCII.GetString(br, 0, br.Length);
                string[] div = line.Split(sp[0]);
                if (true)
                {
                    listView1.Items.Add(line);
                }
            }
            reader.Close();
            file.Close();
        }
    }
}