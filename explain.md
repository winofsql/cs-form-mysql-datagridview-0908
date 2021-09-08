## 接続文字列作成
```cs
            OdbcConnectionStringBuilder builder = new OdbcConnectionStringBuilder();
            builder.Driver = "MySQL ODBC 8.0 Unicode Driver";

            // 接続用のパラメータを追加
            builder.Add("server", "localhost");
            builder.Add("database", "lightbox");
            builder.Add("uid", "root");
            builder.Add("pwd", "");
```

## 接続
```cs
            OdbcConnection connection = new OdbcConnection();
            connection.ConnectionString = builder.ConnectionString;

            OdbcCommand command = new OdbcCommand();

            try
            {
                connection.Open();

            }
            catch (Exception ex)
            {
                MessageBox.Show("エラー:" + ex.Message);

            }
```
