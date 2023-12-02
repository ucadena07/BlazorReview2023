using BlazorWasmReview.Shared.Entities;
using Microsoft.AspNetCore.Components;

namespace BlazorWasmReview.Client.Components;

public partial class ItemCheckBox
{
    [Parameter]
    public BaseItem Item { get; set; }
    [CascadingParameter]
    public string ColorPrefix { get; set; }
}