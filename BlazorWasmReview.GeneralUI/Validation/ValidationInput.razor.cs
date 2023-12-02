using Microsoft.AspNetCore.Components;

namespace BlazorWasmReview.GeneralUI.Validation;

public partial class ValidationInput
{
    [Parameter]
    public EventCallback<string> ValueChanged { get; set; }
    [Parameter]
    public string Value { get; set; }
    [Parameter]
    public string Error { get; set; }

    [Parameter(CaptureUnmatchedValues = true)]
    public Dictionary<string, object> InputAttributes { get; set; }


    protected async Task HandleInputChanged(ChangeEventArgs args)
    {
        await ValueChanged.InvokeAsync(args.Value.ToString());
    }
}