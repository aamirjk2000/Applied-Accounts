namespace Applied_Accounts
{
    partial class Browse
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
            this.lblMessage = new System.Windows.Forms.Label();
            this.btnSelect = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.DataGrid_Browse = new Applied_Accounts.AppliedDataGrid();
            this.SuspendLayout();
            // 
            // lblMessage
            // 
            this.lblMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblMessage.AutoSize = true;
            this.lblMessage.Location = new System.Drawing.Point(12, 459);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(45, 13);
            this.lblMessage.TabIndex = 2;
            this.lblMessage.Text = "Mesage";
            // 
            // btnSelect
            // 
            this.btnSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelect.Location = new System.Drawing.Point(462, 454);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(75, 23);
            this.btnSelect.TabIndex = 4;
            this.btnSelect.Text = "SELECT";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(380, 454);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "CANCEL";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // DataGrid_Browse
            // 
            this.DataGrid_Browse.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DataGrid_Browse.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.DataGrid_Browse.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DataGrid_Browse.ColumnsFormat = null;
            this.DataGrid_Browse.ColumnsName = null;
            this.DataGrid_Browse.ColumnsVisiable = null;
            this.DataGrid_Browse.ColumnsWidth = null;
            this.DataGrid_Browse.IsBrowseWin = false;
            this.DataGrid_Browse.IsPressEnter = false;
            this.DataGrid_Browse.Location = new System.Drawing.Point(15, 12);
            this.DataGrid_Browse.MyDataRow = null;
            this.DataGrid_Browse.MyDataView = null;
            this.DataGrid_Browse.Name = "DataGrid_Browse";
            this.DataGrid_Browse.RecordID = ((long)(0));
            this.DataGrid_Browse.Size = new System.Drawing.Size(522, 436);
            this.DataGrid_Browse.TabIndex = 1;
            // 
            // Browse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(549, 481);
            this.ControlBox = false;
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.DataGrid_Browse);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Browse";
            this.Text = "Browse";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public AppliedDataGrid DataGrid_Browse;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.Button btnCancel;
    }
}