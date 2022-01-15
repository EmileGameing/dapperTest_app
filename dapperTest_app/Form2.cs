using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Dynamic;

namespace dapperTest_app
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var list = new List<aaa>();
            list.Add(new aaa { name = "a", count = 1, TObj = new tObj() { UseName = "Name", ID = 99 } });
            list.Add(new aaa { name = "b", count = 2 });
            list.Add(new aaa { name = "c", count = 3 });
            list.Add(new aaa { name = "d", count = 4 });

            dynamic d = new ExpandoObject();
            foreach (var l in list)
            {
                ((IDictionary<string, object>)d)[l.name] = l.count;
            }

            List<ExpandoObject> le = new List<ExpandoObject>();
            le.Add(d);

            dataGridView1.DataSource = Aaa.ToDataTable(le);
        }



        public class aaa
        {
            public string name { set; get; }
            public int count { set; get; }
            public tObj TObj { set; get; }
        }


        public class tObj
        {
            public int ID { set; get; }
            public string UseName { set; get; }
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var data = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
        }
    }


    public static class Aaa
    {
        /// <summary>
        /// Extension method to convert dynamic data to a DataTable. Useful for databinding.
        /// </summary>
        /// <param name="items"></param>
        /// <returns>A DataTable with the copied dynamic data.</returns>
        public static DataTable ToDataTable(this IEnumerable<dynamic> items)
        {
            var data = items.ToArray();
            if (data.Count() == 0) return null;

            var dt = new DataTable();
            foreach (var key in ((IDictionary<string, object>)data[0]).Keys)
            {
                dt.Columns.Add(key);
            }
            foreach (var d in data)
            {
                dt.Rows.Add(((IDictionary<string, object>)d).Values.ToArray());
            }
            return dt;
        }
    }



}
