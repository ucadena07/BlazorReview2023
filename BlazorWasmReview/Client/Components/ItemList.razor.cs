
using BlazorWasmReview.Client.ItemEdit;
using BlazorWasmReview.Shared.Contracts;
using BlazorWasmReview.Shared.Entities;
using Microsoft.AspNetCore.Components;
using System.Collections.ObjectModel;

namespace BlazorWasmReview.Client.Components;

public partial class ItemList
{
    [Inject]
    public ICurrentUserService _currentUserService { get; set; }
    [Inject]
    public ItemEditService ItemEditService { get; set; }
    ObservableCollection<BaseItem> UserItems = new();

    protected override void OnInitialized()
    {
        base.OnInitialized();
        UserItems = _currentUserService.CurrentUser.UserItems;
    }
    protected override Task OnInitializedAsync()
    {
        return base.OnInitializedAsync();
    }
    void OnBackgroundClicked()
    {
        ItemEditService.EditItem = null;
        StateHasChanged();
    }
}