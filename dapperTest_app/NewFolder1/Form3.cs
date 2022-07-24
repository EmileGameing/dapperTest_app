using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dapperTest_app
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            dataGridView1.DataBindingComplete += DataGridView1_DataBindingComplete;

            Debug.WriteLine(10 % 4);
            Debug.WriteLine(12 % 4);
        }

        private void DataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewColumn c in dataGridView1.Columns)
            {
                if (c.Name.Contains("数")) c.Visible = true;
                else c.Visible = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            // 簡易データ作成
            List<DataObj> Datas = new List<DataObj>();
            Datas.Add(new DataObj { LineName = "回線1", PhoneNumber = "0000", UserID = "1111", UserName = "田中太郎" });
            Datas.Add(new DataObj { LineName = "回線1", PhoneNumber = "0001", UserID = "1111", UserName = "田中太郎" });
            Datas.Add(new DataObj { LineName = "回線1", PhoneNumber = "0002", UserID = "1111", UserName = "田中太郎" });
            Datas.Add(new DataObj { LineName = "回線3", PhoneNumber = "0003", UserID = "1111", UserName = "田中太郎" });
            Datas.Add(new DataObj { LineName = "回線3", PhoneNumber = "0004", UserID = "1111", UserName = "田中太郎" });
            Datas.Add(new DataObj { LineName = "回線3", PhoneNumber = "0005", UserID = "1111", UserName = "田中太郎" });
            Datas.Add(new DataObj { LineName = "回線1", PhoneNumber = "0000", UserID = "1111", UserName = "山田次郎" });
            Datas.Add(new DataObj { LineName = "回線1", PhoneNumber = "0001", UserID = "1111", UserName = "山田次郎" });
            Datas.Add(new DataObj { LineName = "回線1", PhoneNumber = "0002", UserID = "1111", UserName = "山田次郎" });
            Datas.Add(new DataObj { LineName = "回線2", PhoneNumber = "0003", UserID = "1111", UserName = "山田次郎" });
            Datas.Add(new DataObj { LineName = "回線2", PhoneNumber = "0004", UserID = "1111", UserName = "山田次郎" });
            Datas.Add(new DataObj { LineName = "回線2", PhoneNumber = "0005", UserID = "1111", UserName = "山田次郎" });

            // 簡易回線名リスト
            List<string> LineName = new List<string>() { "回線1", "回線2", "回線3" };

            // データテーブル作成。カラム追加
            DataTable table = new DataTable();
            table.Columns.Add(new DataColumn("UserName", typeof(string)));

            foreach (var n in LineName)
            {
                table.Columns.Add(new DataColumn(n + "DBOBJ", typeof(List<DataObj>)));
                table.Columns.Add(new DataColumn(n + "データ数", typeof(int)));
                table.Columns.Add(new DataColumn(n + "GenesysOBJ", typeof(int)));
                table.Columns.Add(new DataColumn(n + "着信数", typeof(int)));
            }

            // ユーザー名で区切り、カラム名に該当するデータと数を業として追を作成し、テーブルに追加。
            foreach (var d in Datas.GroupBy(a => a.UserName))
            {
                var data = table.NewRow();
                data["UserName"] = d.Key;

                foreach (var n in LineName)
                {
                    data[n + "DBOBJ"] = d.Where(a => a.LineName == n).ToList();
                    data[n + "データ数"] = d.Count(a => a.LineName == n);
                }

                table.Rows.Add(data);
            }

            // 合計行をテーブルから計算し、追加
            var TotalData = table.NewRow();
            foreach (var n in LineName)
            {
                TotalData[n + "データ数"] = table.AsEnumerable().Sum(row => row.Field<int>(n + "データ数"));
            }
            table.Rows.Add(TotalData);

            dataGridView1.DataSource = table;
        }

        public class obj
        {
            public string LineName { set; get; }
            public int Count { set; get; }
            public List<DataObj> DataObjs { set; get; }
        }

        public class DataObj
        {
            public string PhoneNumber { set; get; }
            public string UserID { set; get; }
            public string UserName { set; get; }
            public string LineName { set; get; }
        }

        public static DataTable GetDataTableFromDynamicObject(List<dynamic> listData)
        {
            DataTable table = new DataTable();
            if (listData.Count > 0)
            {
                var firstRow = (IEnumerable<KeyValuePair<string, JToken>>)(JObject)listData.First();

                foreach (KeyValuePair<string, JToken> property in firstRow.OrderBy(x => x.Key))
                    table.Columns.Add(new DataColumn(property.Key));

                foreach (var data in listData)
                {
                    DataRow row = table.NewRow();
                    var record = (IEnumerable<KeyValuePair<string, JToken>>)(JObject)data;

                    foreach (KeyValuePair<string, JToken> kvp in record)
                    {
                        row[kvp.Key] = kvp.Value;
                    }
                    table.Rows.Add(row);
                }
            }
            return table;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var selectRow = (DataRowView)dataGridView1.Rows[e.RowIndex].DataBoundItem;
            var selectdItem = selectRow.Row.ItemArray;

            var aaaa = selectdItem[1] as List<DataObj>;

            foreach (var l in selectdItem)
            {
                Debug.WriteLine(l.GetType());
            }
        }
    }
}
