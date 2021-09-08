using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Odbc;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cs_form_mysql_datagridview
{
    public partial class Form1 : Form
    {
        // コンストラクタ
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OdbcConnectionStringBuilder builder = new OdbcConnectionStringBuilder();
            builder.Driver = "MySQL ODBC 8.0 Unicode Driver";

            // 接続用のパラメータを追加
            builder.Add("server", "localhost");
            builder.Add("database", "lightbox");
            builder.Add("uid", "root");
            builder.Add("pwd", "");

            Debug.WriteLine("クリックされました");

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

            command.Connection = connection;
            // コマンドを通常 SQL用に変更
            command.CommandType = CommandType.Text;

            // *****************************
            // 実行 SQL
            // *****************************
            command.CommandText = "select * from 商品マスタ where 商品コード <= '0010'";

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

            connection.Close();

            dataGridView1.AutoResizeColumns();

        }
    }
}
