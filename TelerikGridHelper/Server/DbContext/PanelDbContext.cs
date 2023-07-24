using Microsoft.EntityFrameworkCore;
using TelerikGridHelper.Shared.DataContract;

namespace TelerikGridHelper.Server.PanelDbContext
{
    public class PanelStateDbContext : DbContext
    {

        public PanelStateDbContext(DbContextOptions<PanelStateDbContext> options) : base(options)  { }

        public DbSet<PanelStateData> PanelStates { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder.UseSqlServer("Server=tcp:abdulaleemserver.database.windows.net,1433;Initial Catalog=restaurantDb;Persist Security Info=False;User ID=abdulaleem;Password=Aa@1052001;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"));
        }


    }
}
