using TelerikGridHelper.Shared.DataContract;

namespace TelerikGridHelper.Server.Repos
{
    public interface IRepo
    {
        public Task<PanelStateData?> GetPanelState();

        public Task InsertPanelState(PanelStateData panelStateData);

        public Task UpdatePanelState(PanelStateData panelStateData);

    }
}
