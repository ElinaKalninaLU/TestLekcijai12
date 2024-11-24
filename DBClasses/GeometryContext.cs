using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DBClasses
{
    public class GeometryContext : DbContext
    {
        public DbSet<Rectangle> Rectangles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           optionsBuilder.UseSqlServer(_connectionString);
        }

        private readonly string _connectionString;

        public GeometryContext(String connectionString)
        {
            _connectionString = connectionString;
        }

        public GeometryContext()
        {
            _connectionString = "";// "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Geometry2;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
        }
    }
}
