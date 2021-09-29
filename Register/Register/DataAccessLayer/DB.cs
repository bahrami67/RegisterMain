using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Register.Models
{ 

    public class DB:DbContext
    {
        public DB(DbContextOptions<DB> options) : base(options) { }
   
        public DbSet<Human> Human { set; get; }
    }

   
}
