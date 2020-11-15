using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Microsoft.JSInterop.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sol_Demo.Pages.Demo
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
                            .InvokeAsync<IJSObjectReference>("import", "./js/components/IsolationDemo.js")
                            .AsTask();
        }

        #endregion Private Method

        #region Ui Events

        private async Task OnClickAlert()
        {
            await (await _module).InvokeVoidAsync(identifier: "onDisplay", "Hello Js");
        }

        #endregion Ui Events

        #region Protected Method

        protected override void OnAfterRender(bool firstRender)
        {
            if (firstRender)
            {
                this.LoadJsModules();
            }
        }

        public async ValueTask DisposeAsync()
        {
            if (_module != null)
            {
                await (await _module).DisposeAsync();
            }
        }

        #endregion Protected Method
    }
}