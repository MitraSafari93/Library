using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProject.Model
{
    public partial class MembersTbl
    {
        public MembersTbl()
        {
            this.BorrowerTbls = new HashSet<BorrowerTbl>();
        }
        public int ID { get; set; }
        public string FullName { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public Nullable<int> PhoneNumber { get; set; }
        public Nullable<System.DateTime> JoinDate { get; set; }
        public Nullable<System.DateTime> ExpiryDate { get; set; }

        public virtual ICollection<BorrowerTbl> BorrowerTbls { get; set; }
    }
}
