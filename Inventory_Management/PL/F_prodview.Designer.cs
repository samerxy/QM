namespace Inventory_Management.PL
{
    partial class F_prodview
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dvp = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dvp)).BeginInit();
            this.SuspendLayout();
            // 
            // dvp
            // 
            this.dvp.AllowUserToAddRows = false;
            this.dvp.AllowUserToDeleteRows = false;
            this.dvp.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dvp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dvp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dvp.Location = new System.Drawing.Point(0, 0);
            this.dvp.Name = "dvp";
            this.dvp.ReadOnly = true;
            this.dvp.Size = new System.Drawing.Size(800, 450);
            this.dvp.TabIndex = 0;
            this.dvp.DoubleClick += new System.EventHandler(this.dvp_DoubleClick);
            // 
            // F_prodview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dvp);
            this.Name = "F_prodview";
            this.Text = "F_prodview";
            ((System.ComponentModel.ISupportInitialize)(this.dvp)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.DataGridView dvp;
    }
}