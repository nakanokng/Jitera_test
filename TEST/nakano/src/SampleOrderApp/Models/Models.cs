using System;
using System.Collections.Generic;

namespace SampleOrderApp.Models
{
    /// <summary>商品マスタ</summary>
    public class Product
    {
        public string Code { get; set; }
        public string Name { get; set; }
        /// <summary>カテゴリ（文具 / 事務機器 / 食品 など）</summary>
        public string Category { get; set; }
        /// <summary>税抜単価（円）</summary>
        public decimal UnitPrice { get; set; }
        /// <summary>現在庫数</summary>
        public int Stock { get; set; }
        /// <summary>安全在庫数（これを割り込む引当は不可）</summary>
        public int SafetyStock { get; set; }
    }

    /// <summary>得意先マスタ</summary>
    public class Customer
    {
        public string Code { get; set; }
        public string Name { get; set; }
        /// <summary>会員ランク: G=ゴールド, S=シルバー, N=一般</summary>
        public string Rank { get; set; }
        /// <summary>配送地域区分: 0=本州, 1=北海道・九州・四国, 2=離島</summary>
        public int Area { get; set; }
        /// <summary>掛売り(請求書払い)の得意先か</summary>
        public bool IsCredit { get; set; }
        /// <summary>与信限度額（掛売りのみ有効）</summary>
        public decimal CreditLimit { get; set; }
        /// <summary>未入金残高</summary>
        public decimal Receivable { get; set; }
    }

    /// <summary>受注明細</summary>
    public class OrderLine
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }

        // 以下は計算結果（PriceCalculator が設定する）
        public decimal DiscountedUnitPrice { get; set; }
        public decimal Amount { get; set; }
        /// <summary>取り寄せ扱い（在庫引当できなかった）</summary>
        public bool IsBackOrder { get; set; }
    }

    /// <summary>受注ステータス</summary>
    public enum OrderStatus
    {
        /// <summary>受注確定</summary>
        Confirmed,
        /// <summary>与信超過などにより保留</summary>
        OnHold,
        /// <summary>入力エラー</summary>
        Rejected
    }

    /// <summary>受注伝票</summary>
    public class Order
    {
        public string OrderNo { get; set; }
        public DateTime OrderedAt { get; set; }
        public Customer Customer { get; set; }
        public List<OrderLine> Lines { get; } = new List<OrderLine>();

        public decimal SubTotal { get; set; }
        public decimal ShippingFee { get; set; }
        public decimal Tax { get; set; }
        public decimal Total { get; set; }

        public DateTime ShipDate { get; set; }
        public OrderStatus Status { get; set; }
        public List<string> Messages { get; } = new List<string>();
    }
}
