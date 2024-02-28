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
            this.SuspendLayout();
            // 
            // bt_usb
            // 
            this.bt_usb.Location = new System.Drawing.Point(344, 172);
            this.bt_usb.Name = "bt_usb";
            this.bt_usb.Size = new System.Drawing.Size(108, 68);
            this.bt_usb.TabIndex = 0;
            this.bt_usb.Text = "USB";
            this.bt_usb.UseVisualStyleBackColor = true;
            this.bt_usb.Click += new System.EventHandler(this.bt_usb_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.bt_usb);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bt_usb;
    }
}

