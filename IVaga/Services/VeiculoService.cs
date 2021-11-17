using IVaga.Data;
using IVaga.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IVaga.Services
{
    public class VeiculoService
    {
        private readonly IVagaContext _context;

        public VeiculoService(IVagaContext context)
        {
            _context = context;
        }

        public async Task<List<Veiculo>> FindAllAsync()
        {
            return await _context.Veiculo.OrderBy(veiculo => veiculo.Modelo).ToListAsync();
        }
    }
}
