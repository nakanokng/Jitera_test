using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using SampleOrderApp.Data;
using SampleOrderApp.Models;
using SampleOrderApp.Services;

namespace SampleOrderApp.Forms
{
    /// <summary>受注入力画面</summary>
    public partial class MainForm : Form
    {
        private List<Product> _products = new List<Product>();
        private List<Customer> _customers = new List<Customer>();
        private readonly OrderService _orderService = new OrderService();
        private readonly PriceCalculator _calculator = new PriceCalculator();
        private Order _current = new Order();

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
                var repo = new CsvRepository(Path.Combine(Application.StartupPath, "Data"));
                _products = repo.LoadProducts();
                _customers = repo.LoadCustomers();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "マスタ読込エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            cmbCustomer.DisplayMember = "Name";
            cmbCustomer.DataSource = _customers;
            cmbProduct.DisplayMember = "Name";
            cmbProduct.DataSource = _products;
            ResetOrder();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var product = cmbProduct.SelectedItem as Product;
            if (product == null) return;

            var qty = (int)numQty.Value;

            // 同じ商品が既にあれば数量を加算する
            var exists = _current.Lines.FirstOrDefault(l => l.Product.Code == product.Code);
            if (exists != null)
                exists.Quantity += qty;
            else
                _current.Lines.Add(new OrderLine { Product = product, Quantity = qty });

            RefreshPreview();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (gridLines.CurrentRow == null) return;
            var idx = gridLines.CurrentRow.Index;
            if (idx >= 0 && idx < _current.Lines.Count)
            {
                _current.Lines.RemoveAt(idx);
                RefreshPreview();
            }
        }

        private void cmbCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshPreview();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            _current.Customer = cmbCustomer.SelectedItem as Customer;
            var result = _orderService.Register(_current);

            var msg = string.Join(Environment.NewLine, result.Messages);
            switch (result.Status)
            {
                case OrderStatus.Confirmed:
                    MessageBox.Show(
                        string.Format("受注番号 {0} で登録しました。{1}出荷予定日: {2:yyyy/MM/dd}{1}{3}",
                            result.OrderNo, Environment.NewLine, result.ShipDate, msg),
                        "登録完了", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ResetOrder();
                    break;
                case OrderStatus.OnHold:
                    MessageBox.Show(msg, "受注保留", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    ResetOrder();
                    break;
                default:
                    // 入力エラーは伝票を残したまま再入力させる
                    MessageBox.Show(msg, "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    _current.Messages.Clear();
                    break;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ResetOrder();
        }

        private void ResetOrder()
        {
            _current = new Order();
            RefreshPreview();
        }

        /// <summary>明細グリッドと金額欄を再計算・再表示する（登録前のプレビュー）</summary>
        private void RefreshPreview()
        {
            _current.Customer = cmbCustomer.SelectedItem as Customer;

            if (_current.Customer != null && _current.Lines.Count > 0)
            {
                _calculator.Calculate(_current);
            }
            else
            {
                _current.SubTotal = _current.ShippingFee = _current.Tax = _current.Total = 0m;
            }

            gridLines.Rows.Clear();
            foreach (var l in _current.Lines)
            {
                gridLines.Rows.Add(l.Product.Code, l.Product.Name, l.Product.Category,
                    l.Product.UnitPrice.ToString("#,0"), l.Quantity,
                    l.DiscountedUnitPrice.ToString("#,0"), l.Amount.ToString("#,0"));
            }

            lblSubTotal.Text = _current.SubTotal.ToString("#,0") + " 円";
            lblShipping.Text = _current.ShippingFee.ToString("#,0") + " 円";
            lblTax.Text = _current.Tax.ToString("#,0") + " 円";
            lblTotal.Text = _current.Total.ToString("#,0") + " 円";
            lblCount.Text = "数量合計: " + _calculator.TotalQuantity(_current);

            var c = _current.Customer;
            lblCustomerInfo.Text = c == null ? "" :
                string.Format("ランク: {0} / 地域区分: {1} / {2}",
                    c.Rank, c.Area, c.IsCredit
                        ? string.Format("掛売り（与信残 {0:#,0} 円）", c.CreditLimit - c.Receivable)
                        : "現金・カード");
        }
    }
}
