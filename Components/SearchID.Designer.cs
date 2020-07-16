namespace Applied_Accounts
{
    partial class SearchID
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
            this.SearchBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // SearchBox
            // 
            this.SearchBox.Location = new System.Drawing.Point(0, 0);
            this.SearchBox.Name = "SearchBox";
            this.SearchBox.Size = new System.Drawing.Size(100, 20);
            this.SearchBox.TabIndex = 0;
            // 
            // SearchID
            // 
            this.Enter += new System.EventHandler(this.SearchBox_Enter);
            this.Validating += new System.ComponentModel.CancelEventHandler(this.SearchBox_Validation);
            this.Validated += new System.EventHandler(this.SearchBox_Validated);
            this.TextChanged += new System.EventHandler(this.SearchBox_TextChanged);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TextBox SearchBox;
    }
}
