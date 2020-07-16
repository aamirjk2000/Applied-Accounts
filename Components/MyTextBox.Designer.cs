using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace Applied_Accounts
{
    partial class MyTextBox
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
            this.ThisBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            
            this.ThisBox.Location = new System.Drawing.Point(0, 0);
            this.ThisBox.Name = "ThisBox";
            this.ThisBox.Size = new System.Drawing.Size(100, 20);
            this.ThisBox.TabIndex = 0;
            //
            // Event Handler
            //
            this.Enter += new System.EventHandler(this.GetRow);
            this.Validating += new System.ComponentModel.CancelEventHandler(this.Validation);
            this.ResumeLayout(false);

        }
        
        #endregion

        public System.Windows.Forms.TextBox ThisBox;
    }
}
