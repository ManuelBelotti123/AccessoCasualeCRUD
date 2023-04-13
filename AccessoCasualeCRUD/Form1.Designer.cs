namespace AccessoCasualeCRUD
{
    partial class Form1
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.aggiungi = new System.Windows.Forms.Button();
            this.cancella = new System.Windows.Forms.Button();
            this.modifica = new System.Windows.Forms.Button();
            this.recdato = new System.Windows.Forms.Button();
            this.ricomp = new System.Windows.Forms.Button();
            this.leggi = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.nome = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.prezzo = new System.Windows.Forms.TextBox();
            this.quantita = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.quantitamod = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.prezzomod = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.nomemod = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // aggiungi
            // 
            this.aggiungi.Location = new System.Drawing.Point(47, 237);
            this.aggiungi.Name = "aggiungi";
            this.aggiungi.Size = new System.Drawing.Size(261, 23);
            this.aggiungi.TabIndex = 0;
            this.aggiungi.Text = "Aggiungi";
            this.aggiungi.UseVisualStyleBackColor = true;
            this.aggiungi.Click += new System.EventHandler(this.aggiungi_Click);
            // 
            // cancella
            // 
            this.cancella.Location = new System.Drawing.Point(47, 266);
            this.cancella.Name = "cancella";
            this.cancella.Size = new System.Drawing.Size(261, 23);
            this.cancella.TabIndex = 1;
            this.cancella.Text = "Cancella";
            this.cancella.UseVisualStyleBackColor = true;
            this.cancella.Click += new System.EventHandler(this.cancella_Click);
            // 
            // modifica
            // 
            this.modifica.Location = new System.Drawing.Point(47, 295);
            this.modifica.Name = "modifica";
            this.modifica.Size = new System.Drawing.Size(261, 23);
            this.modifica.TabIndex = 2;
            this.modifica.Text = "Modifica";
            this.modifica.UseVisualStyleBackColor = true;
            this.modifica.Click += new System.EventHandler(this.modifica_Click);
            // 
            // recdato
            // 
            this.recdato.Location = new System.Drawing.Point(47, 324);
            this.recdato.Name = "recdato";
            this.recdato.Size = new System.Drawing.Size(261, 23);
            this.recdato.TabIndex = 3;
            this.recdato.Text = "Recupera";
            this.recdato.UseVisualStyleBackColor = true;
            this.recdato.Click += new System.EventHandler(this.recdato_Click);
            // 
            // ricomp
            // 
            this.ricomp.Location = new System.Drawing.Point(47, 353);
            this.ricomp.Name = "ricomp";
            this.ricomp.Size = new System.Drawing.Size(261, 23);
            this.ricomp.TabIndex = 4;
            this.ricomp.Text = "Ricompatta";
            this.ricomp.UseVisualStyleBackColor = true;
            // 
            // leggi
            // 
            this.leggi.Location = new System.Drawing.Point(47, 382);
            this.leggi.Name = "leggi";
            this.leggi.Size = new System.Drawing.Size(261, 23);
            this.leggi.TabIndex = 5;
            this.leggi.Text = "Visualizza";
            this.leggi.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Corbel", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(361, 33);
            this.label1.TabIndex = 6;
            this.label1.Text = "Gestione File Accesso Casuale";
            // 
            // nome
            // 
            this.nome.Location = new System.Drawing.Point(47, 88);
            this.nome.Name = "nome";
            this.nome.Size = new System.Drawing.Size(100, 20);
            this.nome.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(47, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Nome";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(47, 113);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Prezzo";
            // 
            // prezzo
            // 
            this.prezzo.Location = new System.Drawing.Point(47, 132);
            this.prezzo.Name = "prezzo";
            this.prezzo.Size = new System.Drawing.Size(100, 20);
            this.prezzo.TabIndex = 9;
            // 
            // quantita
            // 
            this.quantita.Location = new System.Drawing.Point(47, 177);
            this.quantita.Name = "quantita";
            this.quantita.Size = new System.Drawing.Size(100, 20);
            this.quantita.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(208, 158);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 13);
            this.label5.TabIndex = 18;
            this.label5.Text = "Quantità";
            // 
            // quantitamod
            // 
            this.quantitamod.Location = new System.Drawing.Point(208, 177);
            this.quantitamod.Name = "quantitamod";
            this.quantitamod.Size = new System.Drawing.Size(100, 20);
            this.quantitamod.TabIndex = 17;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(208, 113);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(39, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "Prezzo";
            // 
            // prezzomod
            // 
            this.prezzomod.Location = new System.Drawing.Point(208, 132);
            this.prezzomod.Name = "prezzomod";
            this.prezzomod.Size = new System.Drawing.Size(100, 20);
            this.prezzomod.TabIndex = 15;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(208, 69);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Nome";
            // 
            // nomemod
            // 
            this.nomemod.Location = new System.Drawing.Point(208, 88);
            this.nomemod.Name = "nomemod";
            this.nomemod.Size = new System.Drawing.Size(100, 20);
            this.nomemod.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(47, 158);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "Quantità";
            // 
            // listView1
            // 
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(367, 88);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(389, 317);
            this.listView1.TabIndex = 20;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.quantitamod);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.prezzomod);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.nomemod);
            this.Controls.Add(this.quantita);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.prezzo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nome);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.leggi);
            this.Controls.Add(this.ricomp);
            this.Controls.Add(this.recdato);
            this.Controls.Add(this.modifica);
            this.Controls.Add(this.cancella);
            this.Controls.Add(this.aggiungi);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button aggiungi;
        private System.Windows.Forms.Button cancella;
        private System.Windows.Forms.Button modifica;
        private System.Windows.Forms.Button recdato;
        private System.Windows.Forms.Button ricomp;
        private System.Windows.Forms.Button leggi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox nome;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox prezzo;
        private System.Windows.Forms.TextBox quantita;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox quantitamod;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox prezzomod;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox nomemod;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListView listView1;
    }
}

