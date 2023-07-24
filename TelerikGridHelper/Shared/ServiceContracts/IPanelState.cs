using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelerikGridHelper.Shared.DataContract;
using System.ServiceModel;

namespace TelerikGridHelper.Shared.ServiceContracts
{
    [ServiceContract]
    public interface IPanelState
    {
        public Task<PanelStateData?> GetPanelState();

        public Task InsertPanelState(PanelStateData panelStateData);

        public Task UpdatePanelState(PanelStateData panelStateData);
    }
}
