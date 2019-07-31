using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProject.Model
{
    public partial class BorrowerTbl
    {
        public int ID { get; set; }
        public int IDMember { get; set; }
        public int IDBook { get; set; }
        public System.DateTime ReciveDate { get; set; }
        public Nullable<System.DateTime> ReturnDate { get; set; }
        public System.DateTime DueDate { get; set; }

        public virtual BookTbl BookTbl { get; set; }
        public virtual MembersTbl MembersTbl { get; set; }
    }
}
