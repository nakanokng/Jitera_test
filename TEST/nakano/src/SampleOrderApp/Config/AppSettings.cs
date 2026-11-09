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
            "Data Source=[ENC:Q4JSB3tBV5oeEj4YjTlF5kqPtE7H2CV/vuXeFqebPTFqVHGx6G2k+pNsK+xNfXKT]:1521/ORDERDB;User Id=order_app;Password=[ENC:rMPevrjOHD0kP9zguswRvg5IKeryBHBuWBjl27VogCw=];";

        /// <summary>主要仕入先（在庫不足時の取り寄せ先）</summary>
        public const string MainSupplierName = "[ENC:yQWs94a3TdQ2mS5T78/oQnk46rXutvXXxDKLAgBUTgA=]";

        /// <summary>システム管理担当者（障害時の連絡先）</summary>
        public const string SystemAdminName = "[ENC:XujgIAg1CDxpH7PbqOusVg2RbcNlcI18169jgKRwToI=]";

        /// <summary>社内案件番号（画面タイトルに表示）</summary>
        public const string ProjectCode = "[ENC:633v+wsKPL7d1bhN5i1GSDNc4oFBXfhjEhUtb6zy9Mw=]";
    }
}
