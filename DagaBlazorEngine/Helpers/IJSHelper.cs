using DagaBlazorEngine.Attributes;
using Microsoft.JSInterop;
using System.Reflection;

namespace DagaBlazorEngine.Helpers
{
    public abstract class IJSHelper(in IJSRuntime jsRuntime)
    {
        protected IJSRuntime JSRuntime { get; } = jsRuntime;

        protected IJSObjectReference? Module { get; set; }

        public virtual async Task InitializeAsync()
        {
            if (GetType().GetCustomAttribute<JSHelperAttribute>() is not JSHelperAttribute jsHelperAttribute)
            {
                throw new InvalidOperationException($"The class {GetType().Name} must have a JSHelperAttribute defined with a valid module path.");
            }

            Module = await JSRuntime.InvokeAsync<IJSObjectReference>("import", jsHelperAttribute.ModulePath);
        }
    }
}
