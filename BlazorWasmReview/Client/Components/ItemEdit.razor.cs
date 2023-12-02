using BlazorWasmReview.Business;
using BlazorWasmReview.Client.ItemEdit;
using BlazorWasmReview.Shared.Contracts;
using BlazorWasmReview.Shared.Entities;
using BlazorWasmReview.Shared.Enums;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;

namespace BlazorWasmReview.Client.Components;

public partial class ItemEdit
{
    [Inject]
    private NavigationManager NavigationManager { get; set; }
    //[Inject]
    //public ItemEditService ItemEditService { get; set; }
    private BaseItem Item { get; set; } = new BaseItem();
    [Inject]
    private ICurrentUserService CurrentUserService { get; set; }

    private int TotalNumber { get; set; }
    protected override void OnInitialized()
    {
        base.OnInitialized();
        //ItemEditService.ItemEditChanged += HandleEditItemChanged;
        //Item = ItemEditService.EditItem;
        SetDataFromUri();
    }

    private void HandleEditItemChanged(object sender, ItemEditEventArgs e)
    {
        //Item = e.Item;
        //StateHasChanged();  
        SetDataFromUri();
    }
    void SetDataFromUri()
    {
        //if (Item != null)
        //{
        //    Item.PropertyChanged -= HandleItemPropertyChanged;
        //}

        var uri = NavigationManager.ToAbsoluteUri(NavigationManager.Uri);

        var segmentCount = uri.Segments.Length;
        if (segmentCount > 2
            && Enum.TryParse(typeof(ItemTypeEnum), uri.Segments[segmentCount - 2].Trim('/'), out var typeEnum)
            && int.TryParse(uri.Segments[segmentCount - 1], out var id))
        {
            var userItem = CurrentUserService.CurrentUser
                .UserItems
                .SingleOrDefault(item => item.ItemTypeEnum == (ItemTypeEnum)typeEnum && item.Id == id);

            //Not found? Redirect to items
            if (userItem == null)
            {
                NavigationManager.LocationChanged -= HandleLocationChanged;
                NavigationManager.NavigateTo("/items");
            }
            else
            {
                Item = userItem;
                //Item.PropertyChanged += HandleItemPropertyChanged;
                NavigationManager.LocationChanged += HandleLocationChanged;
                //TotalNumber = CurrentUserService.CurrentUser.UserItems.Count;
                StateHasChanged();
            }
        }
    }

    private void HandleLocationChanged(object sender, LocationChangedEventArgs e)
    {
        SetDataFromUri();
    }
}