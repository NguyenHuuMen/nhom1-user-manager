using Microsoft.EntityFrameworkCore;
using MyWebApiApp.Models;

namespace MyWebApiApp.Data
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions <DBContext>options): base (options) {}


       
        public DbSet<User> Users { get; set; }
      


    }
}
