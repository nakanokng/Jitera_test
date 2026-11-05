using System;
using System.Linq;
using SampleOrderApp.Models;

namespace SampleOrderApp.Services
{
    /// <summary>
    /// 受注登録の業務処理（入力チェック → 金額計算 → 与信チェック → 在庫引当 → 出荷日決定）
    /// </summary>
    public class OrderService
    {
        private readonly PriceCalculator _calculator;
        private readonly InventoryService _inventory;
        private readonly Func<DateTime> _now;
        private static int _seq = 0;

        public OrderService() : this(new PriceCalculator(), new InventoryService(), () => DateTime.Now) { }

        public OrderService(PriceCalculator calculator, InventoryService inventory, Func<DateTime> now)
        {
            _calculator = calculator;
            _inventory = inventory;
            _now = now;
        }

        /// <summary>受注を登録する。結果は order.Status / order.Messages で返す。</summary>
        public Order Register(Order order)
        {
            order.OrderedAt = _now();
            order.OrderNo = "J" + order.OrderedAt.ToString("yyMMdd") + (++_seq).ToString("0000");

            // --- 入力チェック ---
            if (order.Customer == null)
            {
                order.Status = OrderStatus.Rejected;
                order.Messages.Add("得意先を選択してください");
                return order;
            }
            if (order.Lines.Count == 0)
            {
                order.Status = OrderStatus.Rejected;
                order.Messages.Add("明細が1件もありません");
                return order;
            }
            if (order.Lines.Any(l => l.Quantity <= 0 || l.Quantity > 999))
            {
                order.Status = OrderStatus.Rejected;
                order.Messages.Add("数量は1〜999で入力してください");
                return order;
            }

            // --- 金額計算 ---
            _calculator.Calculate(order);

            // --- 与信チェック（掛売りのみ）---
            if (order.Customer.IsCredit &&
                order.Customer.Receivable + order.Total > order.Customer.CreditLimit)
            {
                order.Status = OrderStatus.OnHold;
                order.Messages.Add("与信限度額を超えるため保留になりました。営業管理課の承認が必要です");
                // 保留時は在庫引当しない
                order.ShipDate = DateTime.MinValue;
                return order;
            }

            // --- 在庫引当 ---
            _inventory.Allocate(order);

            // --- 出荷予定日 ---
            order.ShipDate = CalcShipDate(order.OrderedAt);
            if (order.Lines.Any(l => l.IsBackOrder))
            {
                // 取り寄せ品がある場合は一括出荷のため +7営業日
                order.ShipDate = AddBusinessDays(order.ShipDate, 7);
            }

            order.Status = OrderStatus.Confirmed;
            if (order.Customer.IsCredit)
            {
                order.Customer.Receivable += order.Total;
            }
            return order;
        }

        /// <summary>
        /// 出荷予定日：15時までの受注は翌営業日、15時以降は翌々営業日。
        /// TODO: 祝日・年末年始休業に未対応（土日のみ考慮）
        /// </summary>
        public DateTime CalcShipDate(DateTime orderedAt)
        {
            var days = orderedAt.Hour < 15 ? 1 : 2;
            return AddBusinessDays(orderedAt.Date, days);
        }

        /// <summary>土日を除いて n 営業日後の日付を返す</summary>
        public DateTime AddBusinessDays(DateTime date, int n)
        {
            var d = date;
            while (n > 0)
            {
                d = d.AddDays(1);
                if (d.DayOfWeek != DayOfWeek.Saturday && d.DayOfWeek != DayOfWeek.Sunday)
                {
                    n--;
                }
            }
            return d;
        }
    }
}
