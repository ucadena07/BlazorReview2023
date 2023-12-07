using Microsoft.AspNetCore.Components;

namespace BlazorWasmReview.GeneralUI.DropdownControl;

public partial class Dropdown<TValue> : ComponentBase
{
    [Parameter]
    public IList<DropdownItem<TValue>> SelectableItems { get; set; } 
    [Parameter]
    public DropdownItem<TValue> SelectedItem { get; set; }
    [Parameter]
    public EventCallback<DropdownItem<TValue>> SelectedItemChanged { get; set; }

    public async Task OnItemClicked(DropdownItem<TValue> item)
    {
        SelectedItem = item;
        StateHasChanged();
        await SelectedItemChanged.InvokeAsync(item);
    }

}