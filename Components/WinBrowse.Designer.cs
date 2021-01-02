
namespace Applied_Accounts.Components
{
    partial class WinBrowse
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.myTextBox1 = new Applied_Accounts.MyTextBox();
            this.myTextBox2 = new Applied_Accounts.MyTextBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(3, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "...";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // myTextBox1
            // 
            this.myTextBox1.Allowe_Duplicate = false;
            this.myTextBox1.Allowed_Chars = "0123456789-";
            this.myTextBox1.ColumnName = "Code";
            this.myTextBox1.Location = new System.Drawing.Point(102, 0);
            this.myTextBox1.MaxDigit = 0;
            this.myTextBox1.Mode_Add = false;
            this.myTextBox1.Mode_Delete = false;
            this.myTextBox1.Mode_Edit = false;
            this.myTextBox1.MyDataView = null;
            this.myTextBox1.MyMessage = null;
            this.myTextBox1.MyRow = null;
            this.myTextBox1.Name = "myTextBox1";
            this.myTextBox1.PrimaryKey = "ID";
            this.myTextBox1.Size = new System.Drawing.Size(103, 20);
            this.myTextBox1.TabIndex = 1;
            this.myTextBox1.Text_Mode = 0;
            this.myTextBox1.thisColor = System.Drawing.SystemColors.WindowText;
            // 
            // myTextBox2
            // 
            this.myTextBox2.Allowe_Duplicate = false;
            this.myTextBox2.Allowed_Chars = "0123456789-";
            this.myTextBox2.ColumnName = "Code";
            this.myTextBox2.Location = new System.Drawing.Point(0, 0);
            this.myTextBox2.MaxDigit = 0;
            this.myTextBox2.Mode_Add = false;
            this.myTextBox2.Mode_Delete = false;
            this.myTextBox2.Mode_Edit = false;
            this.myTextBox2.MyDataView = null;
            this.myTextBox2.MyMessage = null;
            this.myTextBox2.MyRow = null;
            this.myTextBox2.Name = "myTextBox2";
            this.myTextBox2.PrimaryKey = "ID";
            this.myTextBox2.Size = new System.Drawing.Size(100, 20);
            this.myTextBox2.TabIndex = 2;
            this.myTextBox2.Text_Mode = 0;
            this.myTextBox2.thisColor = System.Drawing.SystemColors.WindowText;
            // 
            // WinBrowse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.myTextBox2);
            this.Controls.Add(this.myTextBox1);
            this.Controls.Add(this.button1);
            this.Name = "WinBrowse";
            this.Size = new System.Drawing.Size(84, 30);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private MyTextBox myTextBox1;
        private MyTextBox myTextBox2;
    }
}
