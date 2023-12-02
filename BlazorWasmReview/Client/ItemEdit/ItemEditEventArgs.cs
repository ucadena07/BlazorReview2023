using BlazorWasmReview.Shared.Entities;

namespace BlazorWasmReview.Client.ItemEdit;

public class ItemEditEventArgs : EventArgs
{
    public BaseItem Item { get; set; }
}
