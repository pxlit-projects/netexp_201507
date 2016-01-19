using Business_objects;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TEST_VERKEERSBORDEN.Models
{
    public class VerkeersbordContext : DbContext
    {
        public DbSet<Verkeersbord>   Datums    { get; set; }
    }
}