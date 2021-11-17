using IVaga.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IVaga.Data
{
    public class IVagaContext : DbContext
    {
        public IVagaContext(DbContextOptions<IVagaContext> options) 
            : base(options)
        {
        }

        public DbSet<Veiculo> Veiculo { get; set; }
    }
}
