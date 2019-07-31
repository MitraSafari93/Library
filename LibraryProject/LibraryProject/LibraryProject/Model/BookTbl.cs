using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProject.Model
{
    public partial class BookTbl
    {
        public BookTbl()
        {
            this.BorrowerTbls = new HashSet<BorrowerTbl>();
        }
        public int ID { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public string translator { get; set; }
        public Nullable<bool> Available { get; set; }
        public virtual ICollection<BorrowerTbl> BorrowerTbls { get; set; }
    }
}
