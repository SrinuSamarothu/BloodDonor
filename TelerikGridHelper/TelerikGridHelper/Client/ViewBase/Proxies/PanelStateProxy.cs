using TelerikGridHelper.Shared.DataContract;
using TelerikGridHelper.Shared.ServiceContracts;
using System.Threading.Tasks;

namespace TelerikGridHelper.Client.ViewBase.Proxies
{
    public class PanelStateProxy : IPanelState
    {
        Func<IPanelState> servicefactory;
        public PanelStateProxy(Func<IPanelState> _servicefactory)
        {
            servicefactory = _servicefactory;
        }

        public Task<PanelStateData?> GetPanelState()
        {
            return servicefactory().GetPanelState();
        }

        public async Task InsertPanelState(PanelStateData panelStateData)
        {
            try
            {
                servicefactory().InsertPanelState(panelStateData);
            }
            catch (Exception ex)
            {

            }
        }

        public async Task UpdatePanelState(PanelStateData panelStateData)
        {
            try
            {
                servicefactory().UpdatePanelState(panelStateData);
            }
            catch (Exception ex)
            {

            }
        }
    }
}
