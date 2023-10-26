using Microsoft.EntityFrameworkCore;
using Support2.Models;

namespace Support2.DBContext
{
    public class KontaktZglosznenieData : DbContext
    {
        public KontaktZglosznenieData(DbContextOptions<KontaktZglosznenieData> options) : base(options)
        {
        }
        public DbSet<KontaktZgloszenie> zgloszenia { get; set; }
    }
}
