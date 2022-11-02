using Microsoft.AspNetCore.Components;

namespace BlazorServerTemplate.Pages
{
    public partial class RadzenControlTest : ComponentBase
    {
        bool visible = true;
        string text = "True";

        protected override async Task OnInitializedAsync()
        {
            await Task.Run(() => { });
        }

        void OnButtonClick()
        {
            visible = !visible;
        }
        void SetText()
        {
            this.text = this.text == "True" ? "False" : "True";
        }
    }


}
