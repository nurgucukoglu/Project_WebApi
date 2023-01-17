using Microsoft.EntityFrameworkCore;
using Project_WebApi.DAL.Entities;

namespace Project_WebApi.DAL
{
    public class Context: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-0LTDDDI\\SQLEXPRESS01;initial catalog=ApiProjectDb;integrated security=true");
        }

        public DbSet<Category> Categories { get; set; }
    }
}
