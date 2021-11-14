using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KeyAttribute = Dapper.Contrib.Extensions.KeyAttribute;
using TableAttribute = Dapper.Contrib.Extensions.TableAttribute;

namespace dapperTest_app
{
    [Table("user")]
    public class User
    {
        [Key]
        public int UserId { set; get; }
        public string Name { set; get; }
        public int Sex { set; get; }
        public int Address1 { set; get; }
        public Sex sex { set; get; }
        public Address a1 { set; get; }
        public Address a2 { set; get; }
        public int item_1 { set; get; }
        public int item_2 { set; get; }
        public int item_3 { set; get; }
        public int item_4 { set; get; }
        public int item_5 { set; get; }
        public int item_6 { set; get; }
        public int item_7 { set; get; }
        public int item_8 { set; get; }

        [Write(false)]
        public string item_name_1 { set; get; }
        [Write(false)]
        public string item_name_2 { set; get; }
        [Write(false)]
        public string item_name_3 { set; get; }
        [Write(false)]
        public string item_name_4 { set; get; }
        [Write(false)]
        public string item_name_5 { set; get; }
        [Write(false)]
        public string item_name_6 { set; get; }
        [Write(false)]
        public string item_name_7 { set; get; }
        [Write(false)]
        public string item_name_8 { set; get; }
    }
    [Table("sex")]
    public class Sex
    {
        [Key]
        public int sexID { set; get; }
        public string SexResult { set; get; }
    }
    [Table("address")]
    public class Address
    {
        [Key]
        public int addressID { set; get; }
        public string addresName { set; get; }
    }
    [Table("item")]
    public class Item
    {
        [Key]
        public int item_id { set; get; }
        public string item_name { set; get; }
    }
}
