using TelerikGridHelper.Shared.DataContract;
using TelerikGridHelper.Shared.ServiceContracts;

namespace TelerikGridHelper.Client.ViewBase
{
    public class ViewBaseModel
    {
        private string UserId = "Srinu-Optometrist";
        private readonly IPanelState panelStateProxy;
        public string ErrorMessage = "";

        public ViewBaseModel(IPanelState _panelState)
        {
            panelStateProxy = _panelState;
        }

        public async Task<PanelStateData?> GetPanelState()
        {
            return await Task.Run( () => panelStateProxy.GetPanelState());
        }

        public async Task<string> PanelHandler(string buttonText)
        {

            PanelStateData? currentPanelState = await Task.Run( async () => await GetPanelState());

            // If panel state is null, then add new panel state
            if(currentPanelState == null)
            {
                _ = panelStateProxy.InsertPanelState(new PanelStateData()
                {
                    Status = "Editing",
                    PersonId = UserId
                });
            }

            // If panel is in Editing mode
            else if (currentPanelState.Status == "Editing")
            {
                // If same user, Update status to Saved
                if (currentPanelState.PersonId == UserId)
                {
                    if (buttonText == "Save")
                    {
                        currentPanelState.Status = "Saved";
                        panelStateProxy.UpdatePanelState(currentPanelState);
                    }
                    ErrorMessage = "";
                }
                // If different user, show error message
                else
                {
                    ErrorMessage = $"This panel is being used by {currentPanelState.PersonId}";
                }
            }

            // If panel is in Saved mode, then update the panel state with new UserId 
            else if(currentPanelState.Status == "Saved")
            {
                currentPanelState.Status = "Editing";
                currentPanelState.PersonId = UserId;
                panelStateProxy.UpdatePanelState(currentPanelState);
            }

            return ErrorMessage;
        }
    }
}
