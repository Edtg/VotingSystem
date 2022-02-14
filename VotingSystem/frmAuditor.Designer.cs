namespace VotingSystem
{
    partial class frmAuditor
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
            this.cboVote = new System.Windows.Forms.ComboBox();
            this.btnViewResults = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cboVote
            // 
            this.cboVote.Enabled = false;
            this.cboVote.FormattingEnabled = true;
            this.cboVote.Location = new System.Drawing.Point(13, 13);
            this.cboVote.Name = "cboVote";
            this.cboVote.Size = new System.Drawing.Size(121, 21);
            this.cboVote.TabIndex = 0;
            // 
            // btnViewResults
            // 
            this.btnViewResults.Location = new System.Drawing.Point(13, 40);
            this.btnViewResults.Name = "btnViewResults";
            this.btnViewResults.Size = new System.Drawing.Size(121, 23);
            this.btnViewResults.TabIndex = 2;
            this.btnViewResults.Text = "View Results";
            this.btnViewResults.UseVisualStyleBackColor = true;
            this.btnViewResults.Click += new System.EventHandler(this.btnViewResults_Click);
            // 
            // frmAuditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(152, 83);
            this.Controls.Add(this.btnViewResults);
            this.Controls.Add(this.cboVote);
            this.Name = "frmAuditor";
            this.Text = "frmAuditor";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cboVote;
        private System.Windows.Forms.Button btnViewResults;
    }
}