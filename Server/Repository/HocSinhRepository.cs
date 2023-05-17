using Tesing2.Server.Model.Entity;
using Microsoft.EntityFrameworkCore;
using Tesing2.Server.Context;

namespace Tesing2.Server.Repository
{
    public interface IHocSinhRepository<T>
        {
            public Task<T> CreateHocSinh(T _object);

            public Task UpdateHocSinh(T _object);

            Task<List<T>> GetAllHocSinh();

            public Task<T> GetHocSinhById(int id);

            public Task DeleteHocSinh(int id);
        }

        public class HocSinhRepository : IHocSinhRepository<HocSinh>
        {
            public DapperContext _context;
            public HocSinhRepository(DapperContext context)
            {
                _context = context;
            }
        
            public async Task<HocSinh> CreateHocSinh(HocSinh _object)
            {
                var obj = await _context.HocSinh.AddAsync(_object);
                _context.SaveChanges();
                return obj.Entity;
            }

            public async Task DeleteHocSinh(int id)
            {
                var data = _context.HocSinh.FirstOrDefault(x => x.id == id);
                _context.Remove(data);
                await _context.SaveChangesAsync();
            }

            public async Task<List<HocSinh>> GetAllHocSinh()
            {
                return await _context.HocSinh.ToListAsync();
        }

            public async Task<HocSinh> GetHocSinhById(int id)
            {
                return await _context.HocSinh.FirstOrDefaultAsync(x => x.id == id);
        }

            public async Task UpdateHocSinh(HocSinh _object)
            {
                _context.HocSinh.Update(_object);
                await _context.SaveChangesAsync();
            }
        }
}

