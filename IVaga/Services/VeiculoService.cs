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
        public async Task<Veiculo> FindByIdAsync(int id)
        {
            return await _context.Veiculo.FirstOrDefaultAsync(veiculo => veiculo.Id == id);
        }
        public async Task InsertAsync(Veiculo veiculo)
        {
            _context.Add(veiculo);
            await _context.SaveChangesAsync();
        }
        public async Task RemoveAsync(int id)
        {
            var veiculo = await _context.Veiculo.FindAsync(id);
            _context.Remove(veiculo);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(Veiculo veiculo)
        {
            var HasAny = await _context.Veiculo.AnyAsync(v => v.Id == veiculo.Id);
            _context.Update(veiculo);
            await _context.SaveChangesAsync();

        }
    }
}
