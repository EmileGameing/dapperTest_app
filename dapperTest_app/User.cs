using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dapperTest_app
{
    [Table("emps")]
    public class User
    {
        [Key]
        public int UserId { set; get; }
        public string Name { set; get; }
        public int Sex { set; get; }
        public int Address { set; get; }
        public Sex sex { set; get; }
        public Address address { set; get; }
    }

    public class Sex
    {
        [Key]
        public int sexID { set; get; }
        public string SexResult { set; get; }
    }
    public class Address
    {
        [Key]
        public int addressID { set; get; }
        public string addresName { set; get; }
    }
}
