namespace VotingSystem
{
    partial class frmAdmin
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
            this.listVoteOptions = new System.Windows.Forms.ListBox();
            this.editNewOption = new System.Windows.Forms.TextBox();
            this.btnAddOption = new System.Windows.Forms.Button();
            this.editNewOptionDescription = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblVoteName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // listVoteOptions
            // 
            this.listVoteOptions.FormattingEnabled = true;
            this.listVoteOptions.Location = new System.Drawing.Point(13, 37);
            this.listVoteOptions.Name = "listVoteOptions";
            this.listVoteOptions.Size = new System.Drawing.Size(120, 95);
            this.listVoteOptions.TabIndex = 0;
            // 
            // editNewOption
            // 
            this.editNewOption.Location = new System.Drawing.Point(13, 159);
            this.editNewOption.Name = "editNewOption";
            this.editNewOption.Size = new System.Drawing.Size(120, 20);
            this.editNewOption.TabIndex = 1;
            // 
            // btnAddOption
            // 
            this.btnAddOption.Location = new System.Drawing.Point(12, 227);
            this.btnAddOption.Name = "btnAddOption";
            this.btnAddOption.Size = new System.Drawing.Size(120, 23);
            this.btnAddOption.TabIndex = 2;
            this.btnAddOption.Text = "Add Option";
            this.btnAddOption.UseVisualStyleBackColor = true;
            this.btnAddOption.Click += new System.EventHandler(this.btnAddOption_Click);
            // 
            // editNewOptionDescription
            // 
            this.editNewOptionDescription.Location = new System.Drawing.Point(12, 201);
            this.editNewOptionDescription.Name = "editNewOptionDescription";
            this.editNewOptionDescription.Size = new System.Drawing.Size(119, 20);
            this.editNewOptionDescription.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 141);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 185);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Description:";
            // 
            // lblVoteName
            // 
            this.lblVoteName.AutoSize = true;
            this.lblVoteName.Location = new System.Drawing.Point(14, 9);
            this.lblVoteName.Name = "lblVoteName";
            this.lblVoteName.Size = new System.Drawing.Size(57, 13);
            this.lblVoteName.TabIndex = 6;
            this.lblVoteName.Text = "VoteName";
            // 
            // frmAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(150, 271);
            this.Controls.Add(this.lblVoteName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.editNewOptionDescription);
            this.Controls.Add(this.btnAddOption);
            this.Controls.Add(this.editNewOption);
            this.Controls.Add(this.listVoteOptions);
            this.Name = "frmAdmin";
            this.Text = "frmAdmin";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listVoteOptions;
        private System.Windows.Forms.TextBox editNewOption;
        private System.Windows.Forms.Button btnAddOption;
        private System.Windows.Forms.TextBox editNewOptionDescription;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblVoteName;
    }
}