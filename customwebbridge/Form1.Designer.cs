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
            this.cb_select_USB = new System.Windows.Forms.ComboBox();
            this.bt_pair_USB = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // bt_usb
            // 
            this.bt_usb.Location = new System.Drawing.Point(173, 294);
            this.bt_usb.Name = "bt_usb";
            this.bt_usb.Size = new System.Drawing.Size(144, 68);
            this.bt_usb.TabIndex = 0;
            this.bt_usb.Text = "PRINT";
            this.bt_usb.UseVisualStyleBackColor = true;
            this.bt_usb.Click += new System.EventHandler(this.bt_usb_Click);
            // 
            // bt_open_file
            // 
            this.bt_open_file.Location = new System.Drawing.Point(173, 56);
            this.bt_open_file.Name = "bt_open_file";
            this.bt_open_file.Size = new System.Drawing.Size(142, 71);
            this.bt_open_file.TabIndex = 1;
            this.bt_open_file.Text = "Open File";
            this.bt_open_file.UseVisualStyleBackColor = true;
            this.bt_open_file.Click += new System.EventHandler(this.bt_open_file_Click);
            // 
            // cb_select_USB
            // 
            this.cb_select_USB.FormattingEnabled = true;
            this.cb_select_USB.Location = new System.Drawing.Point(173, 180);
            this.cb_select_USB.Name = "cb_select_USB";
            this.cb_select_USB.Size = new System.Drawing.Size(144, 28);
            this.cb_select_USB.TabIndex = 3;
            this.cb_select_USB.Visible = false;
            this.cb_select_USB.SelectedIndexChanged += new System.EventHandler(this.cb_select_USB_SelectedIndexChanged);
            // 
            // bt_pair_USB
            // 
            this.bt_pair_USB.Location = new System.Drawing.Point(173, 180);
            this.bt_pair_USB.Name = "bt_pair_USB";
            this.bt_pair_USB.Size = new System.Drawing.Size(144, 66);
            this.bt_pair_USB.TabIndex = 4;
            this.bt_pair_USB.Text = "Pair";
            this.bt_pair_USB.UseVisualStyleBackColor = true;
            this.bt_pair_USB.Click += new System.EventHandler(this.bt_pair_USB_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(476, 432);
            this.Controls.Add(this.bt_pair_USB);
            this.Controls.Add(this.cb_select_USB);
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
        private System.Windows.Forms.ComboBox cb_select_USB;
        private System.Windows.Forms.Button bt_pair_USB;
    }
}

