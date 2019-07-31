using LibraryProject.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProject
{
    public class BlogDbContext: DbContext 
    {
        public DbSet<BookTbl> BookTbls { get; set; }
        public DbSet<MembersTbl> MembersTbls { get; set; }
        public DbSet<BorrowerTbl> BorrowerTbls { get; set; }
    }
}
