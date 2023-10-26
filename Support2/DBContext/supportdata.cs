using Microsoft.EntityFrameworkCore;
using Support2.Models;

namespace Support2.DBContext
{
    public class supportdata : DbContext
    {
        public supportdata(DbContextOptions options) : base(options)
        {
        }
        public DbSet<zgloszenial> zgloszenia { get; set; }
    }
}
