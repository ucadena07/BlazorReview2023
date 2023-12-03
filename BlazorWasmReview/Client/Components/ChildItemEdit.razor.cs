using BlazorWasmReview.Shared.Contracts;
using BlazorWasmReview.Shared.Entities;
using Microsoft.AspNetCore.Components;

namespace BlazorWasmReview.Client.Components;

public partial class ChildItemEdit : ComponentBase
{
    [Inject]
    private IUserItemManager UserItemManager { get; set; }  
    [Parameter]
    public ParentItem ParentItem { get; set; }
    async Task AddNewChildToParent()
    {
        await UserItemManager.CreateNewChildItemAndAddItToParentItemAsync(ParentItem);
    }
}