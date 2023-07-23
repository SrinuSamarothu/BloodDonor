using TelerikGridHelper.Server.PanelDbContext;
using TelerikGridHelper.Shared.DataContract;

namespace TelerikGridHelper.Server.Repos
{
    public class Repo : IRepo
    {
        private readonly PanelStateDbContext context;

        public Repo(PanelStateDbContext _context)
        {
            context = _context;
        }

        public Task<PanelStateData?> GetPanelState()
        {
            try
            {
                return Task.FromResult(context.PanelStates.FirstOrDefault());
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task InsertPanelState(PanelStateData panelStateData)
        {
            context.PanelStates.Add(panelStateData);
            context.SaveChanges();
        }

        public async Task UpdatePanelState(PanelStateData panelStateData)
        {
            context.PanelStates.Update(panelStateData);
            context.SaveChanges();
        }
    }
}
