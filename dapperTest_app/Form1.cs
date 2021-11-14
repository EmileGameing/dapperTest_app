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

        private List<User> dapper_test1()
        {
            var sql = @"SELECT * FROM user INNER JOIN sex on sex.sexID = user.Sex 
                        left JOIN address as a1 on a1.addressID = user.Address1 
                        left JOIN address as a2 on a2.addressID = user.Address2
                        left Join item as i1 on i1.item_id = user.item_1
                        left Join item as i2 on i2.item_id = user.item_2
                        left Join item as i3 on i3.item_id = user.item_3
                        left Join item as i4 on i4.item_id = user.item_4
                        left Join item as i5 on i5.item_id = user.item_5
                        left Join item as i6 on i6.item_id = user.item_6
                        left Join item as i7 on i7.item_id = user.item_7
                        left Join item as i8 on i8.item_id = user.item_8";
            using (var connection = new MySql.Data.MySqlClient.MySqlConnection("Server=localhost;User=root;Database=test;"))
            {
                connection.Open();
                var aaa = connection.Query<User>(sql,
                    new[] { typeof(User), typeof(Sex), typeof(Address), typeof(Address),
                            typeof(Item),typeof(Item),typeof(Item),typeof(Item),
                            typeof(Item),typeof(Item),typeof(Item),typeof(Item)}, obj =>
                          {
                              User user = obj[0] as User;
                              Address A1 = obj[1] as Address;
                              user.item_name_1 = (obj[4] as Item).item_name;
                              user.item_name_2 = (obj[5] as Item).item_name;
                              user.item_name_3 = (obj[6] as Item).item_name;
                              user.item_name_4 = (obj[7] as Item).item_name;
                              user.item_name_5 = (obj[8] as Item).item_name;
                              user.item_name_6 = (obj[9] as Item).item_name;
                              user.item_name_7 = (obj[10] as Item).item_name;
                              user.item_name_8 = (obj[11] as Item).item_name;

                              return user;
                          }, splitOn: "UserId,sexID,addressID,addressID,item_id,item_id,item_id,item_id,item_id,item_id,item_id,item_id").ToList();
                return aaa;
            }
        }
    }
}
