
using BlazorWasmReview.Client.ItemEdit;
using BlazorWasmReview.Shared.Contracts;
using BlazorWasmReview.Shared.Entities;
using Microsoft.AspNetCore.Components;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace BlazorWasmReview.Client.Components;

public partial class ItemList : IDisposable
{
    [Inject]
    public ICurrentUserService _currentUserService { get; set; }
    [Inject]
    public ItemEditService ItemEditService { get; set; }
    [Inject]
    public IUserItemManager UserItemManager { get; set; }

    ObservableCollection<BaseItem> UserItems = new();

    protected override void OnInitialized()
    {
        base.OnInitialized();

    }


    private void HandleUserItemsCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
    {
        StateHasChanged();
    }

    protected override async Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();
        //await UserItemManager.RetrieveAllUserItemsOfUserAndSetToUserAsync(_currentUserService.CurrentUser);
        UserItems = _currentUserService.CurrentUser.UserItems;
        UserItems.CollectionChanged += HandleUserItemsCollectionChanged;
    }
    void OnBackgroundClicked()
    {
        ItemEditService.EditItem = null;
        StateHasChanged();
    }

    public void Dispose()
    {
        UserItems.CollectionChanged -= HandleUserItemsCollectionChanged;
    }
}