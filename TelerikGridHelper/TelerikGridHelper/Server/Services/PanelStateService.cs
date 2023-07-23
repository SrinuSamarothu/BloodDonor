using TelerikGridHelper.Server.Repos;
using TelerikGridHelper.Shared.DataContract;
using TelerikGridHelper.Shared.ServiceContracts;
using System.Threading.Tasks;

namespace TelerikGridHelper.Server.Services
{
    public class PanelStateService : IPanelState
    {
        private readonly IRepo panelRepo;
        public PanelStateService(IRepo _panelRepo)
        {
            panelRepo = _panelRepo;
        }

        public async Task InsertPanelState(PanelStateData panelStateData)
        {
            panelRepo.InsertPanelState(panelStateData);
        }

        public async Task UpdatePanelState(PanelStateData panelStateData)
        {
            panelRepo.UpdatePanelState(panelStateData);
        }

        public async Task<PanelStateData?> GetPanelState()
        {
            return await panelRepo.GetPanelState();
        }
    }
}
