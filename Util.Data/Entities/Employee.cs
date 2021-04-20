using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Util.Data.Entities
{
    public class Employee
    {
        public long ID { get; set; }
        public string NameRus { get; set; }
        public string NameKaz { get; set; }
        public string Profession { get; set; }
        public int FirmID { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
    }
}
