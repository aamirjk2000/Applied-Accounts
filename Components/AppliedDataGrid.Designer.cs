namespace Applied_Accounts
{
    partial class AppliedDataGrid
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
            this._DataGrid = new System.Windows.Forms.DataGridView();
            this.lblMessage = new System.Windows.Forms.Label();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.txtTag = new System.Windows.Forms.TextBox();
            this.txtTitle = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this._DataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // _DataGrid
            // 
            this._DataGrid.AllowUserToAddRows = false;
            this._DataGrid.AllowUserToDeleteRows = false;
            this._DataGrid.AllowUserToResizeColumns = false;
            this._DataGrid.AllowUserToResizeRows = false;
            this._DataGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._DataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._DataGrid.Location = new System.Drawing.Point(3, 3);
            this._DataGrid.Name = "_DataGrid";
            this._DataGrid.Size = new System.Drawing.Size(484, 296);
            this._DataGrid.TabIndex = 0;
            this._DataGrid.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this._DataGrid_RowEnter);
            this._DataGrid.RowLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this._DataGrid_RowLeave);
            // 
            // lblMessage
            // 
            this.lblMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblMessage.AutoSize = true;
            this.lblMessage.Location = new System.Drawing.Point(3, 308);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(31, 13);
            this.lblMessage.TabIndex = 1;
            this.lblMessage.Text = "Clear";
            this.lblMessage.Click += new System.EventHandler(this.lblMessage_Click);
            // 
            // txtCode
            // 
            this.txtCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtCode.Location = new System.Drawing.Point(58, 305);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(84, 20);
            this.txtCode.TabIndex = 2;
            this.txtCode.TextChanged += new System.EventHandler(this.txtCode_TextChanged);
            this.txtCode.Leave += new System.EventHandler(this.txtCode_Leave);
            // 
            // txtTag
            // 
            this.txtTag.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtTag.Location = new System.Drawing.Point(148, 305);
            this.txtTag.Name = "txtTag";
            this.txtTag.Size = new System.Drawing.Size(84, 20);
            this.txtTag.TabIndex = 3;
            this.txtTag.TextChanged += new System.EventHandler(this.txtTag_TextChanged);
            this.txtTag.Leave += new System.EventHandler(this.txtTag_Leave);
            // 
            // txtTitle
            // 
            this.txtTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTitle.Location = new System.Drawing.Point(238, 305);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(249, 20);
            this.txtTitle.TabIndex = 4;
            this.txtTitle.TextChanged += new System.EventHandler(this.txtTitle_TextChanged);
            this.txtTitle.Leave += new System.EventHandler(this.txtTitle_Leave);
            // 
            // AppliedDataGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.txtTag);
            this.Controls.Add(this.txtCode);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this._DataGrid);
            this.Name = "AppliedDataGrid";
            this.Size = new System.Drawing.Size(490, 331);
            ((System.ComponentModel.ISupportInitialize)(this._DataGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.DataGridView _DataGrid;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.TextBox txtTag;
        private System.Windows.Forms.TextBox txtTitle;
        public System.Windows.Forms.Label lblMessage;
    }
}
