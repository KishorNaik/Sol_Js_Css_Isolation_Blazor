using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sol_Demo.Components
{
    public partial class DemoComponent
    {
        #region Public Property

        [Inject]
        public IJSRuntime JSRuntime { get; set; }

        #endregion Public Property

        #region Private Property

        private ElementReference DivElement { get; set; }

        #endregion Private Property

        #region Private Method

        public async Task OnClickCssChange()
        {
            await JSRuntime.InvokeVoidAsync(identifier: "onChangeCss", DivElement);
        }

        #endregion Private Method
    }
}