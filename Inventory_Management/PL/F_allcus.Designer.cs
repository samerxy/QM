namespace Inventory_Management.PL
{
    partial class F_allcus
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
            this.dvc = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dvc)).BeginInit();
            this.SuspendLayout();
            // 
            // dvc
            // 
            this.dvc.AllowUserToAddRows = false;
            this.dvc.AllowUserToDeleteRows = false;
            this.dvc.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dvc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dvc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dvc.Location = new System.Drawing.Point(0, 0);
            this.dvc.Name = "dvc";
            this.dvc.ReadOnly = true;
            this.dvc.Size = new System.Drawing.Size(800, 450);
            this.dvc.TabIndex = 0;
            this.dvc.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dvc_CellContentClick);
            this.dvc.DoubleClick += new System.EventHandler(this.dvc_DoubleClick);
            // 
            // F_allcus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dvc);
            this.Name = "F_allcus";
            this.Text = "F_allcus";
            ((System.ComponentModel.ISupportInitialize)(this.dvc)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.DataGridView dvc;
    }
}