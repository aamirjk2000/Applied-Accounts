namespace Applied_Accounts.Forms
{
    partial class frmEmails
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
            this.txtEmails = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.ListSubject = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // txtEmails
            // 
            this.txtEmails.Location = new System.Drawing.Point(12, 130);
            this.txtEmails.Multiline = true;
            this.txtEmails.Name = "txtEmails";
            this.txtEmails.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtEmails.Size = new System.Drawing.Size(776, 279);
            this.txtEmails.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(688, 415);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Load Emails";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ListSubject
            // 
            this.ListSubject.FormattingEnabled = true;
            this.ListSubject.Location = new System.Drawing.Point(12, 12);
            this.ListSubject.Name = "ListSubject";
            this.ListSubject.Size = new System.Drawing.Size(776, 108);
            this.ListSubject.TabIndex = 2;
            this.ListSubject.SelectedValueChanged += new System.EventHandler(this.ListSubject_SelectedValueChanged);
            // 
            // frmEmails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ListSubject);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtEmails);
            this.Name = "frmEmails";
            this.Text = "Emails";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtEmails;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListBox ListSubject;
    }
}