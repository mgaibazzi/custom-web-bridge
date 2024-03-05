namespace customwebbridge
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
            this.bt_usb = new System.Windows.Forms.Button();
            this.bt_open_file = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // bt_usb
            // 
            this.bt_usb.Location = new System.Drawing.Point(599, 64);
            this.bt_usb.Name = "bt_usb";
            this.bt_usb.Size = new System.Drawing.Size(108, 68);
            this.bt_usb.TabIndex = 0;
            this.bt_usb.Text = "PRINT";
            this.bt_usb.UseVisualStyleBackColor = true;
            this.bt_usb.Click += new System.EventHandler(this.bt_usb_Click);
            // 
            // bt_open_file
            // 
            this.bt_open_file.Location = new System.Drawing.Point(97, 64);
            this.bt_open_file.Name = "bt_open_file";
            this.bt_open_file.Size = new System.Drawing.Size(144, 59);
            this.bt_open_file.TabIndex = 1;
            this.bt_open_file.Text = "Open File";
            this.bt_open_file.UseVisualStyleBackColor = true;
            this.bt_open_file.Click += new System.EventHandler(this.bt_open_file_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(599, 271);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(108, 78);
            this.button1.TabIndex = 2;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(821, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.bt_open_file);
            this.Controls.Add(this.bt_usb);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bt_usb;
        private System.Windows.Forms.Button bt_open_file;
        private System.Windows.Forms.Button button1;
    }
}

