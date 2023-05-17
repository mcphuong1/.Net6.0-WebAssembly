using Microsoft.Data.SqlClient;
using System.Data;
using Microsoft.EntityFrameworkCore;
using Tesing2.Server.Model.Entity;

namespace Tesing2.Server.Context
{
    public class DapperContext : DbContext
    {
        public DapperContext(DbContextOptions<DapperContext> options) : base(options)
        {

        }

        public DbSet<HocSinh> HocSinh { get; set; }
    }
}
