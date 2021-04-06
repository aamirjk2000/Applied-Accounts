
namespace Applied_Accounts.Forms
{
    partial class frmTemp
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
            this.components = new System.ComponentModel.Container();
            this.cBoxTest = new System.Windows.Forms.ComboBox();
            this.txtValue = new System.Windows.Forms.TextBox();
            this.txtItem = new System.Windows.Forms.TextBox();
            this.txtIndex = new System.Windows.Forms.TextBox();
            this.txtText = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ds_Voucher = new Applied_Accounts.Data.ds_Voucher();
            this.dsVoucherBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSorted = new System.Windows.Forms.Button();
            this.lBox = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.ds_Voucher)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsVoucherBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // cBoxTest
            // 
            this.cBoxTest.FormattingEnabled = true;
            this.cBoxTest.Location = new System.Drawing.Point(494, 159);
            this.cBoxTest.Name = "cBoxTest";
            this.cBoxTest.Size = new System.Drawing.Size(403, 21);
            this.cBoxTest.Sorted = true;
            this.cBoxTest.TabIndex = 0;
            this.cBoxTest.SelectedIndexChanged += new System.EventHandler(this.cBoxTest_SelectedIndexChanged);
            // 
            // txtValue
            // 
            this.txtValue.Location = new System.Drawing.Point(85, 56);
            this.txtValue.Name = "txtValue";
            this.txtValue.Size = new System.Drawing.Size(332, 20);
            this.txtValue.TabIndex = 1;
            // 
            // txtItem
            // 
            this.txtItem.Location = new System.Drawing.Point(85, 82);
            this.txtItem.Name = "txtItem";
            this.txtItem.Size = new System.Drawing.Size(332, 20);
            this.txtItem.TabIndex = 2;
            // 
            // txtIndex
            // 
            this.txtIndex.Location = new System.Drawing.Point(85, 108);
            this.txtIndex.Name = "txtIndex";
            this.txtIndex.Size = new System.Drawing.Size(332, 20);
            this.txtIndex.TabIndex = 3;
            // 
            // txtText
            // 
            this.txtText.Location = new System.Drawing.Point(85, 30);
            this.txtText.Name = "txtText";
            this.txtText.Size = new System.Drawing.Size(544, 20);
            this.txtText.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Text";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "SelectValue";
            // 
            // ds_Voucher
            // 
            this.ds_Voucher.DataSetName = "ds_Voucher";
            this.ds_Voucher.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dsVoucherBindingSource
            // 
            this.dsVoucherBindingSource.DataSource = this.ds_Voucher;
            this.dsVoucherBindingSource.Position = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Select Item";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 111);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Index";
            // 
            // btnSorted
            // 
            this.btnSorted.Location = new System.Drawing.Point(822, 333);
            this.btnSorted.Name = "btnSorted";
            this.btnSorted.Size = new System.Drawing.Size(75, 23);
            this.btnSorted.TabIndex = 9;
            this.btnSorted.Text = "Sorted";
            this.btnSorted.UseVisualStyleBackColor = true;
            this.btnSorted.Click += new System.EventHandler(this.btnSorted_Click);
            // 
            // lBox
            // 
            this.lBox.FormattingEnabled = true;
            this.lBox.Location = new System.Drawing.Point(85, 157);
            this.lBox.Name = "lBox";
            this.lBox.Size = new System.Drawing.Size(403, 199);
            this.lBox.TabIndex = 10;
            // 
            // frmTemp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(958, 451);
            this.Controls.Add(this.lBox);
            this.Controls.Add(this.btnSorted);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtText);
            this.Controls.Add(this.txtIndex);
            this.Controls.Add(this.txtItem);
            this.Controls.Add(this.txtValue);
            this.Controls.Add(this.cBoxTest);
            this.Name = "frmTemp";
            this.Text = "Temp";
            ((System.ComponentModel.ISupportInitialize)(this.ds_Voucher)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsVoucherBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cBoxTest;
        private System.Windows.Forms.TextBox txtValue;
        private System.Windows.Forms.TextBox txtItem;
        private System.Windows.Forms.TextBox txtIndex;
        private System.Windows.Forms.TextBox txtText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private Data.ds_Voucher ds_Voucher;
        private System.Windows.Forms.BindingSource dsVoucherBindingSource;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnSorted;
        private System.Windows.Forms.ListBox lBox;
    }
}