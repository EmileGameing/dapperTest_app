using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dapperTest_app
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            DataTable a = new DataTable();
            a.Columns.Add("Num", typeof(int));
            a.Columns.Add("Price", typeof(int));
            a.Columns.Add("Name", typeof(string));
            a.Columns.Add("Total", typeof(int), "Num * Price");

            a.Rows.Add(1, 1, "AAA");
            a.Rows.Add(1, 2, "AAA");
            a.Rows.Add(1, 3, "AAA");
            a.Rows.Add(1, 4, "BBB");
            a.Rows.Add(1, 5, "BBB");

            var totalRow = a.NewRow();
            var aaa = a.Compute("Sum(Num)", "('AAA' = Name or 'BBB' = Name) and price >= 2");

            dataGridView1.DataSource = a.Rows.Cast<DataRow>().Where(d => d["Name"].ToString() == "AAA").CopyToDataTable();

        }
    }
}
