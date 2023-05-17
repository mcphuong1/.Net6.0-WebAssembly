using Tesing2.Server.Model.Entity;
using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.AspNetCore.Http;
using Tesing2.Server.Services;

namespace Tesing2.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HocSinhController : ControllerBase
    {
        private readonly IHocSinhService _hocsinhService;
        public HocSinhController(IHocSinhService hocsinhService)
        {
            _hocsinhService = hocsinhService;
        }

        [HttpGet]
        public async Task<IEnumerable<HocSinh>> GetAll()
        {
            return await _hocsinhService.GetAllHocSinh();
        }

        [HttpGet("{id}")]
        public async Task<HocSinh> Get(int id)
        {
            return await _hocsinhService.GetHocSinh(id);
        }
        [HttpPost]
        public async Task<HocSinh> AddHocSinh([FromBody] HocSinh hocsinh)
        {
            return await _hocsinhService.AddHocSinh(hocsinh);
        }

        [HttpDelete("{id}")]
        public async Task<bool> DeleteHocSinh(int id)
        {
            await _hocsinhService.DeleteHocSinh(id); return true;
        }

        [HttpPut("{id}")]
        public async Task<bool> UpdateHocSinh(int id, [FromBody] HocSinh Object)
        {
            await _hocsinhService.UpdateHocSinh(id, Object); return true;
        }
    }


}
