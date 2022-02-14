namespace VotingSystem
{
    partial class frmMain
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
            this.cboVoteOptions = new System.Windows.Forms.ComboBox();
            this.btnSubmitVote = new System.Windows.Forms.Button();
            this.cboVote = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // cboVoteOptions
            // 
            this.cboVoteOptions.FormattingEnabled = true;
            this.cboVoteOptions.Location = new System.Drawing.Point(12, 60);
            this.cboVoteOptions.Name = "cboVoteOptions";
            this.cboVoteOptions.Size = new System.Drawing.Size(184, 21);
            this.cboVoteOptions.TabIndex = 0;
            // 
            // btnSubmitVote
            // 
            this.btnSubmitVote.Location = new System.Drawing.Point(12, 87);
            this.btnSubmitVote.Name = "btnSubmitVote";
            this.btnSubmitVote.Size = new System.Drawing.Size(184, 23);
            this.btnSubmitVote.TabIndex = 1;
            this.btnSubmitVote.Text = "Submit Vote";
            this.btnSubmitVote.UseVisualStyleBackColor = true;
            this.btnSubmitVote.Click += new System.EventHandler(this.VoteButtonClicked);
            // 
            // cboVote
            // 
            this.cboVote.Enabled = false;
            this.cboVote.FormattingEnabled = true;
            this.cboVote.Location = new System.Drawing.Point(12, 33);
            this.cboVote.Name = "cboVote";
            this.cboVote.Size = new System.Drawing.Size(184, 21);
            this.cboVote.TabIndex = 2;
            this.cboVote.SelectedIndexChanged += new System.EventHandler(this.cboVote_SelectedIndexChanged);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(208, 121);
            this.Controls.Add(this.cboVote);
            this.Controls.Add(this.btnSubmitVote);
            this.Controls.Add(this.cboVoteOptions);
            this.Name = "frmMain";
            this.Text = "Voting System";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cboVoteOptions;
        private System.Windows.Forms.Button btnSubmitVote;
        private System.Windows.Forms.ComboBox cboVote;
    }
}