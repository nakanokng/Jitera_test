using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using SampleOrderApp.Models;

namespace SampleOrderApp.Data
{
    /// <summary>
    /// マスタCSVの読み込み。DBを使わずに動かせるよう、CSVにしている。
    /// 文字コードは UTF-8、1行目はヘッダ。
    /// </summary>
    public class CsvRepository
    {
        private readonly string _dataDir;

        public CsvRepository(string dataDir)
        {
            _dataDir = dataDir;
        }

        public List<Product> LoadProducts()
        {
            return ReadRows("products.csv").Select(c => new Product
            {
                Code = c[0],
                Name = c[1],
                Category = c[2],
                UnitPrice = decimal.Parse(c[3]),
                Stock = int.Parse(c[4]),
                SafetyStock = int.Parse(c[5])
            }).ToList();
        }

        public List<Customer> LoadCustomers()
        {
            return ReadRows("customers.csv").Select(c => new Customer
            {
                Code = c[0],
                Name = c[1],
                Rank = c[2],
                Area = int.Parse(c[3]),
                IsCredit = c[4] == "1",
                CreditLimit = decimal.Parse(c[5]),
                Receivable = decimal.Parse(c[6])
            }).ToList();
        }

        private IEnumerable<string[]> ReadRows(string fileName)
        {
            var path = Path.Combine(_dataDir, fileName);
            if (!File.Exists(path))
                throw new FileNotFoundException("マスタファイルが見つかりません: " + path);

            return File.ReadAllLines(path, Encoding.UTF8)
                .Skip(1)
                .Where(l => !string.IsNullOrWhiteSpace(l))
                .Select(l => l.Split(','));
        }
    }
}
