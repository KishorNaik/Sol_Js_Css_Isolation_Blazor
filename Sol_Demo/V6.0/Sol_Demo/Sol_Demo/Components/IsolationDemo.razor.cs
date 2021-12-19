using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Sol_Demo.Components
{
    public partial class IsolationDemo : IAsyncDisposable
    {
        #region Declaration

        private Task<IJSObjectReference> _module = null;

        #endregion Declaration

        #region Public Property

        [Inject]
        public IJSRuntime JSRuntime { get; set; }

        #endregion Public Property

        #region Private Method

        private void LoadJsModules()
        {
            _module = JSRuntime
                        .InvokeAsync<IJSObjectReference>("import", "./Components/IsolationDemo.razor.js")
                        .AsTask();
        }

        #endregion Private Method

        #region UI Events

        private async Task OnClickAlert()
        {
            await (await _module).InvokeVoidAsync(identifier: "onDisplay", "Hello Js.");
        }

        #endregion UI Events

        #region Protected Method

        protected override void OnAfterRender(bool firstRender)
        {
            if (firstRender)
            {
                this.LoadJsModules();
            }
        }

        #endregion Protected Method

        public async ValueTask DisposeAsync()

        {
            if (_module != null)
            {
                await (await _module).DisposeAsync();
            }
        }
    }
}