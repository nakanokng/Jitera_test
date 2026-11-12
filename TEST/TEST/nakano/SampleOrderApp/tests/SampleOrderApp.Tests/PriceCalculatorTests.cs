using Microsoft.VisualStudio.TestTools.UnitTesting;
using SampleOrderApp.Models;
using SampleOrderApp.Services;

namespace SampleOrderApp.Tests
{
    /// <summary>
    /// PriceCalculator のテスト。
    /// </summary>
    [TestClass]
    public class PriceCalculatorTests
    {
        private static Product Pen() =>
            new Product { Code = "P001", Name = "ボールペン", Category = "文具", UnitPrice = 480, Stock = 100 };

        private static Customer Normal(int area = 0) =>
            new Customer { Code = "C999", Name = "テスト", Rank = "N", Area = area };

        [TestMethod]
        public void Calculate_一般会員_送料あり_標準税率()
        {
            var order = new Order { Customer = Normal() };
            order.Lines.Add(new OrderLine { Product = Pen(), Quantity = 2 });

            new PriceCalculator().Calculate(order);

            Assert.AreEqual(960m, order.SubTotal);
            Assert.AreEqual(800m, order.ShippingFee);
            Assert.AreEqual(176m, order.Tax);      // (960 + 800) * 10%
            Assert.AreEqual(1936m, order.Total);
        }

        [TestMethod]
        public void GetRankDiscountRate_ゴールドは5パーセント()
        {
            Assert.AreEqual(0.05m, new PriceCalculator().GetRankDiscountRate("G"));
        }
    }
}
