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
        //dichiarazione variabili
        //struct prodotto
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
            //inserimento dei valori necessari nei campi della struct
            p.nome = nome.Text;
            p.prezzo = float.Parse(prezzo.Text);
            p.quantita = int.Parse(quantita.Text);
            p.c = 1;
            //funzione di aggiunta di un prodotto al file
            AggProd(Record(p, sp, lunghezzaRecord), nomefile);
        }

        private void cancella_Click(object sender, EventArgs e)
        {
            //funzione di cancellazione logica di un prodotto ricercato nel file
            Cancella(nome.Text, nomefile, sp, lunghezzaRecord);
        }

        private void modifica_Click(object sender, EventArgs e)
        {
            //funzione di modifica di un prodotto ricercato nel file
            Modifica(nome.Text, nomemod.Text, float.Parse(prezzomod.Text), int.Parse(quantitamod.Text), nomefile, sp, lunghezzaRecord);
        }

        private void recdato_Click(object sender, EventArgs e)
        {
            //funzione che recupera un dato precedentemente cancellato logicamente
            RecuperaDato(nome.Text, nomefile, sp, lunghezzaRecord);
        }

        private void ricomp_Click(object sender, EventArgs e)
        {
            //funzione che ricompatta il file eliminando fisicamente gli elementi precedentemente cancellati logicamente
            Ricompatta(nomefile, sp, lunghezzaRecord);
        }

        private void leggi_Click(object sender, EventArgs e)
        {
            //trascrizione del contenuto del file sulla listview
            Visualizza(nomefile, sp, lunghezzaRecord);
            //pulisce la listview
            listView1.Items.Clear();
            //dichiarazioni
            string line;
            byte[] br;
            //apertura del file e dello strumento di lettura
            var appoggio = new FileStream("appoggio.txt", FileMode.Open, FileAccess.ReadWrite);
            BinaryReader reader = new BinaryReader(appoggio);
            //fino alla fine del file
            while (appoggio.Position < appoggio.Length)
            {
                //trascrivi in un array di bytes la riga del file
                br = reader.ReadBytes(lunghezzaRecord);
                //conversione in stringa
                line = Encoding.ASCII.GetString(br, 0, br.Length);
                //divisione dei vari campi della stringa
                string[] div = line.Split(sp[0]);
                string c = div[3];
                //se non è cancellato logicamente
                if (c[0] != '0')
                {
                    //trascrive nelle colonne della listview i vari campi
                    ListViewItem Item = new ListViewItem();
                    Item.Text = div[0];
                    Item.SubItems.Add(div[1]);
                    Item.SubItems.Add(div[2]);
                    listView1.Items.Add(Item);
                }
            }
            //chiusura dei flussi
            reader.Close();
            appoggio.Close();
        }

        //funzioni di servizio
        public string Record(prodotto p, string sp, int l)
        {
            //stabiliamo una lunghezza fissa per ogni record
            return (p.nome + sp + p.prezzo + sp + p.quantita + sp + p.c).PadRight(l - 4) + "##\r\n";

        }

        public void AggProd(string riga, string nomefile)
        {
            //apertura del file e dello strumento di scrittura
            var oStream = new FileStream(nomefile, FileMode.Append, FileAccess.Write, FileShare.Read);
            BinaryWriter writer = new BinaryWriter(oStream);
            //converte la string in un array di caratteri
            char[] linea = riga.ToCharArray();
            //scrive sul file
            writer.Write(linea);
            //chiusura dei flussi
            writer.Close();
            oStream.Close();
        }

        public prodotto RecOrCancLog(string prodottostringa, string sp, int c)
        {
            //tracrizione delle parti divise della stringa nei vari campi della struct
            prodotto p;
            string[] div = prodottostringa.Split(sp[0]);
            p.nome = div[0];
            p.prezzo = float.Parse(div[1]);
            p.quantita = int.Parse(div[2]);
            //se recupera c = 1, se cancella c = 0
            p.c = c;
            return p;
        }

        public prodotto ModProd(string prodottostringa, string nome, float prezzo, int quantita, string sp)
        {
            //tracrizione delle modifiche nei vari campi della struct
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
            //dichiarazioni
            prodotto p;
            string line;
            byte[] br;
            //apertura del file e dello strumento di lettura
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
            string line;
            byte[] br;
            var file = new FileStream(nomefile, FileMode.Open, FileAccess.ReadWrite);
            var appoggio = new FileStream("appoggio.txt", FileMode.Open, FileAccess.ReadWrite);
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
            reader.Close();
            writer.Close();
            file.Close();
            appoggio.Close();
        }
    }
}