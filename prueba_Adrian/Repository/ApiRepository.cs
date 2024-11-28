using Microsoft.EntityFrameworkCore;
using prueba_Adrian.DataAccess;
using prueba_Adrian.Models;

namespace prueba_Adrian.Repository
{
    public class ApiRepository
    {
        private readonly AppDbContext _context;

        public ApiRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddData(DataBank data)
        {
            await _context.ApiData.AddAsync(data);
            await _context.SaveChangesAsync();
        }

        public async Task AddDataList(List<DataBank> data)
        {
            await _context.ApiData.AddRangeAsync(data);
            await _context.SaveChangesAsync();
        }

        public async Task<List<DataBank>> GetData()
        {
            return await _context.ApiData.ToListAsync();
        }

        public async Task<DataBank?> GetDataById(int id)
        {
            return await _context.ApiData.FindAsync(id);
        }

        public async Task<bool> ExistInfo()
        {
            return await _context.ApiData.AnyAsync();
        }
    }
}
