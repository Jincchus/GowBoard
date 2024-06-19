using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace GowBoard.Models.Context
{
    public class MemberDbContext : DbContext
    {
        public DbSet<Member> Member { get; set; }
    }
}