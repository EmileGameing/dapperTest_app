using Dapper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dapperTest_app
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            var u = new SortableBindingList<User>();
            u.Add(new User() { UserId = 0, Name = "太郎" });
            u.Add(new User() { UserId = 1, Name = "次郎" });
            u.Add(new User() { UserId = 2, Name = "三郎" });

            dataGridView1.DataSource = u;

            dataGridView1.Columns["UserID"].DisplayIndex = 0;
            var index = dataGridView1.Columns["UserID"].Index;

        }

        private void dapper_test1()
        {
            using (var connection = new MySql.Data.MySqlClient.MySqlConnection("Server=localhost;User=root;Database=test;"))
            {
                connection.Open();
                var aaa = connection.Query<User, Sex, Address, (User user, Sex sex, Address address)>(@"SELECT * FROM user INNER JOIN sex on sex.sexID = user.Sex INNER JOIN address on address.addressID = user.Address",
                    (User, Sex, Address) =>
                    {
                        var t = (User, Sex, Address);
                        t.User = User;
                        t.Address = Address;
                        t.Sex = Sex;
                        return t;
                    }, splitOn: "UserId,sexID,addressID").ToList();

                var f = aaa.Where(a => a.sex.SexResult == "男").ToList();
            }
        }
    }
}
