namespace OngameNotesMerger
{
    partial class Form1
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
            this.tbMasterFile = new System.Windows.Forms.TextBox();
            this.lblMasterFile = new System.Windows.Forms.Label();
            this.btnBrowseMaster = new System.Windows.Forms.Button();
            this.tbSlaveFile = new System.Windows.Forms.TextBox();
            this.lblSlaveFile = new System.Windows.Forms.Label();
            this.btnBrowseSlave = new System.Windows.Forms.Button();
            this.btnMerge = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbMasterFile
            // 
            this.tbMasterFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbMasterFile.Location = new System.Drawing.Point(76, 12);
            this.tbMasterFile.Name = "tbMasterFile";
            this.tbMasterFile.Size = new System.Drawing.Size(188, 20);
            this.tbMasterFile.TabIndex = 0;
            // 
            // lblMasterFile
            // 
            this.lblMasterFile.AutoSize = true;
            this.lblMasterFile.Location = new System.Drawing.Point(12, 15);
            this.lblMasterFile.Name = "lblMasterFile";
            this.lblMasterFile.Size = new System.Drawing.Size(58, 13);
            this.lblMasterFile.TabIndex = 1;
            this.lblMasterFile.Text = "Master File";
            // 
            // btnBrowseMaster
            // 
            this.btnBrowseMaster.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowseMaster.Location = new System.Drawing.Point(270, 10);
            this.btnBrowseMaster.Name = "btnBrowseMaster";
            this.btnBrowseMaster.Size = new System.Drawing.Size(75, 23);
            this.btnBrowseMaster.TabIndex = 2;
            this.btnBrowseMaster.Text = "Browse";
            this.btnBrowseMaster.UseVisualStyleBackColor = true;
            this.btnBrowseMaster.Click += new System.EventHandler(this.btnBrowseMaster_Click);
            // 
            // tbSlaveFile
            // 
            this.tbSlaveFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbSlaveFile.Location = new System.Drawing.Point(76, 41);
            this.tbSlaveFile.Name = "tbSlaveFile";
            this.tbSlaveFile.Size = new System.Drawing.Size(188, 20);
            this.tbSlaveFile.TabIndex = 3;
            // 
            // lblSlaveFile
            // 
            this.lblSlaveFile.AutoSize = true;
            this.lblSlaveFile.Location = new System.Drawing.Point(17, 44);
            this.lblSlaveFile.Name = "lblSlaveFile";
            this.lblSlaveFile.Size = new System.Drawing.Size(53, 13);
            this.lblSlaveFile.TabIndex = 4;
            this.lblSlaveFile.Text = "Slave File";
            // 
            // btnBrowseSlave
            // 
            this.btnBrowseSlave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowseSlave.Location = new System.Drawing.Point(270, 39);
            this.btnBrowseSlave.Name = "btnBrowseSlave";
            this.btnBrowseSlave.Size = new System.Drawing.Size(75, 23);
            this.btnBrowseSlave.TabIndex = 5;
            this.btnBrowseSlave.Text = "Browse";
            this.btnBrowseSlave.UseVisualStyleBackColor = true;
            this.btnBrowseSlave.Click += new System.EventHandler(this.btnBrowseSlave_Click);
            // 
            // btnMerge
            // 
            this.btnMerge.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMerge.Location = new System.Drawing.Point(270, 80);
            this.btnMerge.Name = "btnMerge";
            this.btnMerge.Size = new System.Drawing.Size(75, 23);
            this.btnMerge.TabIndex = 8;
            this.btnMerge.Text = "Merge";
            this.btnMerge.UseVisualStyleBackColor = true;
            this.btnMerge.Click += new System.EventHandler(this.btnMerge_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(357, 115);
            this.Controls.Add(this.btnMerge);
            this.Controls.Add(this.btnBrowseSlave);
            this.Controls.Add(this.lblSlaveFile);
            this.Controls.Add(this.tbSlaveFile);
            this.Controls.Add(this.btnBrowseMaster);
            this.Controls.Add(this.lblMasterFile);
            this.Controls.Add(this.tbMasterFile);
            this.MinimumSize = new System.Drawing.Size(321, 146);
            this.Name = "Form1";
            this.Text = "OngameNotesMerger";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbMasterFile;
        private System.Windows.Forms.Label lblMasterFile;
        private System.Windows.Forms.Button btnBrowseMaster;
        private System.Windows.Forms.TextBox tbSlaveFile;
        private System.Windows.Forms.Label lblSlaveFile;
        private System.Windows.Forms.Button btnBrowseSlave;
        private System.Windows.Forms.Button btnMerge;
    }
}

