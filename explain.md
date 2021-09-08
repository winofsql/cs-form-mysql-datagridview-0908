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

### 実行する SQL の準備
```cs
            command.Connection = connection;
            // コマンドを通常 SQL用に変更
            command.CommandType = CommandType.Text;

            // *****************************
            // 実行 SQL
            // *****************************
            command.CommandText = "select * from 社員マスタ";
```

## 読み込みと DataGridView への結果のセット
```cs
            try
            {
                OdbcDataReader reader = command.ExecuteReader();

                DataTable dataTable = new DataTable();

                // DataReader よりデータを格納
                dataTable.Load(reader);

                // 画面の一覧表示用コントロールにセット
                dataGridView1.DataSource = dataTable;

                // リーダを使い終わったので閉じる
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("エラー:" + ex.Message);

            }
```
