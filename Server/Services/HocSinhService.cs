using Tesing2.Server.Model.Entity;
using Tesing2.Server.Repository;

namespace Tesing2.Server.Services
{
    public interface IHocSinhService
    {
        Task<HocSinh> AddHocSinh(HocSinh hocsinh);

        Task<bool> UpdateHocSinh(int id, HocSinh hocsinh);

        Task<bool> DeleteHocSinh(int id);

        Task<IEnumerable<HocSinh>> GetAllHocSinh();

        Task<HocSinh> GetHocSinh(int id);
    }

    public class HocSinhService : IHocSinhService
    {
        private readonly IHocSinhRepository<HocSinh> _hocsinh;
        public HocSinhService(IHocSinhRepository<HocSinh> hocsinh)
        {
            _hocsinh = hocsinh;
        }
        public async Task<HocSinh> AddHocSinh(HocSinh hocsinh)
        {
            return await _hocsinh.CreateHocSinh(hocsinh);
        }

        public async Task<bool> DeleteHocSinh(int id)
        {
            await _hocsinh.DeleteHocSinh(id);
            return true;
        }

        public async Task<IEnumerable<HocSinh>> GetAllHocSinh()
        {
            return (List<HocSinh>)await _hocsinh.GetAllHocSinh();
        }

        public async Task<HocSinh> GetHocSinh(int id)
        {
            return await _hocsinh.GetHocSinhById(id);
        }

        public async Task<bool> UpdateHocSinh(int id, HocSinh _object)
        {
            var data = await _hocsinh.GetHocSinhById(id);

            if (data != null)
            {
                data.Name = _object.Name;
                data.Class = _object.Class;
                data.Phone = _object.Phone;

                await _hocsinh.UpdateHocSinh(data);
                return true;
            }
            else
                return false;
        }
    }
}
