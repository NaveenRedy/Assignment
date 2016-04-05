﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TwitterClone.Models
{
    public class DBContext: DbContext
    {
        public DBContext()
            : base("Name=dbContext")
        {
            Database.SetInitializer<DBContext>(new DropCreateDatabaseIfModelChanges<DBContext>());
        }
        public DbSet<Content> Contents { get; set; }

     

        public System.Data.Entity.DbSet<TwitterClone.Models.RegisterUser> RegisterUsers { get; set; }
    }

}