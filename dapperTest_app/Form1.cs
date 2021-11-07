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
            dataGridView1.DataSource = dapper_test1();

            dataGridView1.Columns["UserID"].DisplayIndex = 0;
            dataGridView1.Columns["UserID"].HeaderText = "ユーザーID";
            var index = dataGridView1.Columns["UserID"].Index;

        }

        private List<dynamic> dapper_test1()
        {
            var sql = @"SELECT * FROM user INNER JOIN sex on sex.sexID = user.Sex left JOIN address as a1 on a1.addressID = user.Address1 left JOIN address as a2 on a2.addressID = user.Address2";
            using (var connection = new MySql.Data.MySqlClient.MySqlConnection("Server=localhost;User=root;Database=test;"))
            {
                connection.Open();
                var aaa = connection.Query<User>(sql,
                    new[] { typeof(User), typeof(Sex), typeof(Address), typeof(Address) }, obj =>
                          {
                              User user = obj[0] as User;
                              Address A1 = obj[1] as Address;

                              return user;
                          }, splitOn: "UserId,sexID,addressID,addressID").ToList();
                var bbb = connection.Query(@"SELECT * FROM user INNER JOIN sex on sex.sexID = user.Sex INNER JOIN address on address.addressID = user.Address").ToList();

                var ccc = (User)bbb[0];
                return bbb;
            }
        }
    }
}
