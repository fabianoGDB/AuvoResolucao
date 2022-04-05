using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;

namespace Auvo.ClimaTempo.WebApp.Models
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() : base(nameOrConnectionString: "ConnString")
        {

            Database.SetInitializer<DatabaseContext>(null);
        }


        public virtual DbSet<Estado> Estado { get; set; }
        public virtual DbSet<Cidade> Cidade { get; set; }
        public virtual DbSet<PrevisaoClima> PrevisaoClima { get; set; }


    }
}