using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MVC_Proekt.Models
{
    public class DataBase : DbContext
    {
        public DbSet<UserAccount> useraccount { get; set; }
    }
}