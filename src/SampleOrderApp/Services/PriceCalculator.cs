using System;
using System.Linq;
using SampleOrderApp.Models;

namespace SampleOrderApp.Services
{
    /// <summary>
    /// 受注金額の計算。
    /// ※ 2019年の販売管理刷新時に旧VB版から移植。仕様書は残っていない。
    /// </summary>
    public class PriceCalculator
    {
        /// <summary>
        /// 伝票全体の金額（明細金額・小計・送料・消費税・合計）を計算して order に設定する。
        /// </summary>
        public void Calculate(Order order)
        {
            if (order == null) throw new ArgumentNullException(nameof(order));
            if (order.Customer == null) throw new InvalidOperationException("得意先が未設定です");

            decimal subTotal = 0m;
            decimal subTotalReduced = 0m; // 軽減税率(8%)対象

            foreach (var line in order.Lines)
            {
                var price = line.Product.UnitPrice;

                // 数量割引：同一商品10個以上で単価5%引き（1円未満切り捨て）
                if (line.Quantity >= 10)
                {
                    price = Math.Floor(price * 0.95m);
                }

                // 会員ランク割引（数量割引後の単価に対して適用）
                price = Math.Floor(price * (1m - GetRankDiscountRate(order.Customer.Rank)));

                line.DiscountedUnitPrice = price;
                line.Amount = price * line.Quantity;

                if (line.Product.Category == "食品")
                    subTotalReduced += line.Amount;
                else
                    subTotal += line.Amount;
            }

            order.SubTotal = subTotal + subTotalReduced;
            order.ShippingFee = CalcShippingFee(order.SubTotal, order.Customer.Area);

            // 消費税は税率ごとに合計してから計算し、端数は切り捨て（明細単位ではない）
            // 送料は標準税率扱い
            var tax10 = Math.Floor((subTotal + order.ShippingFee) * 0.10m);
            var tax8 = Math.Floor(subTotalReduced * 0.08m);
            order.Tax = tax10 + tax8;

            order.Total = order.SubTotal + order.ShippingFee + order.Tax;
        }

        /// <summary>会員ランク別の割引率</summary>
        public decimal GetRankDiscountRate(string rank)
        {
            switch (rank)
            {
                case "G": return 0.05m;
                case "S": return 0.03m;
                default: return 0m;
            }
        }

        /// <summary>
        /// 送料（税抜）。小計10,000円以上で無料。
        /// 地域区分 1 は +300円、2(離島) は +1,200円。離島は送料無料の対象外。
        /// </summary>
        public decimal CalcShippingFee(decimal subTotal, int area)
        {
            decimal fee;
            if (area == 2)
            {
                fee = 800m + 1200m; // 離島は常に有料
            }
            else if (subTotal >= 10000m)
            {
                fee = 0m;
            }
            else
            {
                fee = 800m;
                if (area == 1) fee += 300m;
            }
            return fee;
        }

        /// <summary>明細数量の合計（画面表示用）</summary>
        public int TotalQuantity(Order order)
        {
            return order.Lines.Sum(l => l.Quantity);
        }
    }
}
