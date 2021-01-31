using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using api.Entities;

    public class DadosContext : DbContext
    {
        public DadosContext (DbContextOptions<DadosContext> options)
            : base(options)
        {
        }

        public DbSet<api.Entities.categoria> categoria { get; set; }

        public DbSet<api.Entities.produto> produto { get; set; }
    }
