using SampleOrderApp.Config;
using SampleOrderApp.Models;

namespace SampleOrderApp.Services
{
    /// <summary>在庫引当</summary>
    public class InventoryService
    {
        /// <summary>
        /// 引当可能数 = 現在庫 - 安全在庫（マイナスは0）
        /// </summary>
        public int GetAvailable(Product product)
        {
            var available = product.Stock - product.SafetyStock;
            return available < 0 ? 0 : available;
        }

        /// <summary>
        /// 明細ごとに在庫を引き当てる。引当可能数を超える明細は全数を取り寄せ扱いにする
        /// （一部引当は行わない）。引き当てた分は Stock から減算する。
        /// </summary>
        public void Allocate(Order order)
        {
            foreach (var line in order.Lines)
            {
                if (line.Quantity <= GetAvailable(line.Product))
                {
                    line.Product.Stock -= line.Quantity;
                    line.IsBackOrder = false;
                }
                else
                {
                    line.IsBackOrder = true;
                    order.Messages.Add(string.Format(
                        "{0} は在庫不足のため {1} から取り寄せになります（引当可能数 {2}）",
                        line.Product.Name, AppSettings.MainSupplierName, GetAvailable(line.Product)));
                }
            }
        }
    }
}
