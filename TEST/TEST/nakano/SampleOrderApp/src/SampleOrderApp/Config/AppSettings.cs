namespace SampleOrderApp.Config
{
    /// <summary>
    /// アプリの設定値。
    /// ※ 2027年度にマスタをCSVから受注DB(Oracle)へ移行予定。接続情報は暫定でここに記載している。
    /// </summary>
    public static class AppSettings
    {
        /// <summary>受注DBの接続文字列（DB移行後に使用予定。現在は未使用）</summary>
        public const string OrderDbConnectionString =
            "Data Source=hrs-db01.corp.example.local:1521/ORDERDB;User Id=order_app;Password=P@ssw0rd2026;";

        /// <summary>主要仕入先（在庫不足時の取り寄せ先）</summary>
        public const string MainSupplierName = "瀬戸内精機";

        /// <summary>システム管理担当者（障害時の連絡先）</summary>
        public const string SystemAdminName = "山田花子";

        /// <summary>社内案件番号（画面タイトルに表示）</summary>
        public const string ProjectCode = "ORD-PJ-0815";
    }
}
