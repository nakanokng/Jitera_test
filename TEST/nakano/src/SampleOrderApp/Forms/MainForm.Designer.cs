namespace SampleOrderApp.Forms
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        private void InitializeComponent()
        {
            this.lblCustomer = new System.Windows.Forms.Label();
            this.cmbCustomer = new System.Windows.Forms.ComboBox();
            this.lblCustomerInfo = new System.Windows.Forms.Label();
            this.lblProduct = new System.Windows.Forms.Label();
            this.cmbProduct = new System.Windows.Forms.ComboBox();
            this.lblQty = new System.Windows.Forms.Label();
            this.numQty = new System.Windows.Forms.NumericUpDown();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.gridLines = new System.Windows.Forms.DataGridView();
            this.colCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCategory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDiscounted = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grpTotal = new System.Windows.Forms.GroupBox();
            this.lblSubTotalCaption = new System.Windows.Forms.Label();
            this.lblShippingCaption = new System.Windows.Forms.Label();
            this.lblTaxCaption = new System.Windows.Forms.Label();
            this.lblTotalCaption = new System.Windows.Forms.Label();
            this.lblSubTotal = new System.Windows.Forms.Label();
            this.lblShipping = new System.Windows.Forms.Label();
            this.lblTax = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblCount = new System.Windows.Forms.Label();
            this.btnRegister = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numQty)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLines)).BeginInit();
            this.grpTotal.SuspendLayout();
            this.SuspendLayout();
            //
            // lblCustomer
            //
            this.lblCustomer.AutoSize = true;
            this.lblCustomer.Location = new System.Drawing.Point(16, 19);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Text = "得意先";
            //
            // cmbCustomer
            //
            this.cmbCustomer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCustomer.Location = new System.Drawing.Point(80, 16);
            this.cmbCustomer.Name = "cmbCustomer";
            this.cmbCustomer.Size = new System.Drawing.Size(240, 23);
            this.cmbCustomer.TabIndex = 0;
            this.cmbCustomer.SelectedIndexChanged += new System.EventHandler(this.cmbCustomer_SelectedIndexChanged);
            //
            // lblCustomerInfo
            //
            this.lblCustomerInfo.AutoSize = true;
            this.lblCustomerInfo.ForeColor = System.Drawing.Color.DimGray;
            this.lblCustomerInfo.Location = new System.Drawing.Point(336, 19);
            this.lblCustomerInfo.Name = "lblCustomerInfo";
            //
            // lblProduct
            //
            this.lblProduct.AutoSize = true;
            this.lblProduct.Location = new System.Drawing.Point(16, 55);
            this.lblProduct.Name = "lblProduct";
            this.lblProduct.Text = "商品";
            //
            // cmbProduct
            //
            this.cmbProduct.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProduct.Location = new System.Drawing.Point(80, 52);
            this.cmbProduct.Name = "cmbProduct";
            this.cmbProduct.Size = new System.Drawing.Size(240, 23);
            this.cmbProduct.TabIndex = 1;
            //
            // lblQty
            //
            this.lblQty.AutoSize = true;
            this.lblQty.Location = new System.Drawing.Point(336, 55);
            this.lblQty.Name = "lblQty";
            this.lblQty.Text = "数量";
            //
            // numQty
            //
            this.numQty.Location = new System.Drawing.Point(376, 52);
            this.numQty.Maximum = new decimal(new int[] { 999, 0, 0, 0 });
            this.numQty.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.numQty.Name = "numQty";
            this.numQty.Size = new System.Drawing.Size(70, 23);
            this.numQty.TabIndex = 2;
            this.numQty.Value = new decimal(new int[] { 1, 0, 0, 0 });
            //
            // btnAdd
            //
            this.btnAdd.Location = new System.Drawing.Point(460, 50);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(90, 27);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.Text = "明細追加";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            //
            // btnRemove
            //
            this.btnRemove.Location = new System.Drawing.Point(556, 50);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(90, 27);
            this.btnRemove.TabIndex = 4;
            this.btnRemove.Text = "明細削除";
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            //
            // gridLines
            //
            this.gridLines.AllowUserToAddRows = false;
            this.gridLines.AllowUserToDeleteRows = false;
            this.gridLines.ReadOnly = true;
            this.gridLines.RowHeadersVisible = false;
            this.gridLines.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridLines.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.colCode, this.colName, this.colCategory, this.colPrice,
                this.colQty, this.colDiscounted, this.colAmount });
            this.gridLines.Location = new System.Drawing.Point(16, 92);
            this.gridLines.Name = "gridLines";
            this.gridLines.Size = new System.Drawing.Size(760, 260);
            this.gridLines.TabIndex = 5;
            this.colCode.HeaderText = "商品CD"; this.colCode.Width = 70;
            this.colName.HeaderText = "商品名"; this.colName.Width = 220;
            this.colCategory.HeaderText = "カテゴリ"; this.colCategory.Width = 80;
            this.colPrice.HeaderText = "定価"; this.colPrice.Width = 80;
            this.colQty.HeaderText = "数量"; this.colQty.Width = 60;
            this.colDiscounted.HeaderText = "割引後単価"; this.colDiscounted.Width = 100;
            this.colAmount.HeaderText = "金額"; this.colAmount.Width = 120;
            //
            // grpTotal
            //
            this.grpTotal.Controls.Add(this.lblSubTotalCaption);
            this.grpTotal.Controls.Add(this.lblSubTotal);
            this.grpTotal.Controls.Add(this.lblShippingCaption);
            this.grpTotal.Controls.Add(this.lblShipping);
            this.grpTotal.Controls.Add(this.lblTaxCaption);
            this.grpTotal.Controls.Add(this.lblTax);
            this.grpTotal.Controls.Add(this.lblTotalCaption);
            this.grpTotal.Controls.Add(this.lblTotal);
            this.grpTotal.Location = new System.Drawing.Point(476, 362);
            this.grpTotal.Name = "grpTotal";
            this.grpTotal.Size = new System.Drawing.Size(300, 140);
            this.grpTotal.Text = "金額";
            this.lblSubTotalCaption.Location = new System.Drawing.Point(16, 24); this.lblSubTotalCaption.AutoSize = true; this.lblSubTotalCaption.Text = "小計（税抜）";
            this.lblShippingCaption.Location = new System.Drawing.Point(16, 50); this.lblShippingCaption.AutoSize = true; this.lblShippingCaption.Text = "送料（税抜）";
            this.lblTaxCaption.Location = new System.Drawing.Point(16, 76); this.lblTaxCaption.AutoSize = true; this.lblTaxCaption.Text = "消費税";
            this.lblTotalCaption.Location = new System.Drawing.Point(16, 106); this.lblTotalCaption.AutoSize = true; this.lblTotalCaption.Text = "合計（税込）";
            this.lblSubTotal.Location = new System.Drawing.Point(140, 24); this.lblSubTotal.Size = new System.Drawing.Size(140, 20); this.lblSubTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblShipping.Location = new System.Drawing.Point(140, 50); this.lblShipping.Size = new System.Drawing.Size(140, 20); this.lblShipping.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblTax.Location = new System.Drawing.Point(140, 76); this.lblTax.Size = new System.Drawing.Size(140, 20); this.lblTax.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblTotal.Location = new System.Drawing.Point(140, 102); this.lblTotal.Size = new System.Drawing.Size(140, 24); this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblTotal.Font = new System.Drawing.Font("Yu Gothic UI", 11F, System.Drawing.FontStyle.Bold);
            //
            // lblCount
            //
            this.lblCount.AutoSize = true;
            this.lblCount.Location = new System.Drawing.Point(16, 366);
            this.lblCount.Name = "lblCount";
            //
            // btnRegister
            //
            this.btnRegister.Location = new System.Drawing.Point(16, 462);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(140, 40);
            this.btnRegister.TabIndex = 6;
            this.btnRegister.Text = "受注登録";
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            //
            // btnClear
            //
            this.btnClear.Location = new System.Drawing.Point(166, 462);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(100, 40);
            this.btnClear.TabIndex = 7;
            this.btnClear.Text = "クリア";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            //
            // MainForm
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 518);
            this.Controls.Add(this.lblCustomer);
            this.Controls.Add(this.cmbCustomer);
            this.Controls.Add(this.lblCustomerInfo);
            this.Controls.Add(this.lblProduct);
            this.Controls.Add(this.cmbProduct);
            this.Controls.Add(this.lblQty);
            this.Controls.Add(this.numQty);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.gridLines);
            this.Controls.Add(this.lblCount);
            this.Controls.Add(this.grpTotal);
            this.Controls.Add(this.btnRegister);
            this.Controls.Add(this.btnClear);
            this.Font = new System.Drawing.Font("Yu Gothic UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "受注入力 - SampleOrderApp";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numQty)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLines)).EndInit();
            this.grpTotal.ResumeLayout(false);
            this.grpTotal.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblCustomer;
        private System.Windows.Forms.ComboBox cmbCustomer;
        private System.Windows.Forms.Label lblCustomerInfo;
        private System.Windows.Forms.Label lblProduct;
        private System.Windows.Forms.ComboBox cmbProduct;
        private System.Windows.Forms.Label lblQty;
        private System.Windows.Forms.NumericUpDown numQty;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.DataGridView gridLines;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCategory;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDiscounted;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAmount;
        private System.Windows.Forms.GroupBox grpTotal;
        private System.Windows.Forms.Label lblSubTotalCaption;
        private System.Windows.Forms.Label lblShippingCaption;
        private System.Windows.Forms.Label lblTaxCaption;
        private System.Windows.Forms.Label lblTotalCaption;
        private System.Windows.Forms.Label lblSubTotal;
        private System.Windows.Forms.Label lblShipping;
        private System.Windows.Forms.Label lblTax;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.Button btnClear;
    }
}
