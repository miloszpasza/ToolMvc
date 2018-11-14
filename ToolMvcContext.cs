using Microsoft.EntityFrameworkCore;

namespace ToolMvc
{
    public class ToolMvcContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Server=127.0.0.1;Port=5432;Database=db1;User Id=miloszsmac; Password=mmm;");
        }
        public ToolMvcContext(DbContextOptions<ToolMvcContext> options) : base(options)
        {
        }
        public DbSet<ToolMvc.Models.Tool> Tools { get; set; }
    }
}