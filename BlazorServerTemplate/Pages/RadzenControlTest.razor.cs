using Microsoft.AspNetCore.Components;

namespace BlazorServerTemplate.Pages
{
    public partial class RadzenControlTest : ComponentBase
    {
        bool visible = true;
        string text = "True";

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
        }

        void OnButtonClick()
        {
            visible = !visible;
        }
        void SetText()
        {
            this.text = this.text == "True" ? "False" : "True";
        }

        protected override Task OnAfterRenderAsync(bool firstRender)
        {
            return base.OnAfterRenderAsync(firstRender);
        }
        protected override void OnParametersSet()
        {
            base.OnParametersSet();
        }

        protected override bool ShouldRender()
        {
            return base.ShouldRender();
        }
    }
}
