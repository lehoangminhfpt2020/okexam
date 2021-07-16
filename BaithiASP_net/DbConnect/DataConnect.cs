using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using BaithiASP_net.Models;


namespace BaithiASP_net.DbConnect
{
    public class DataConnect : DbContext
    {
        public DataConnect() : base("Baithi")
        {

        }

        public DbSet<examModel> examModel { get; set; }
    }
}