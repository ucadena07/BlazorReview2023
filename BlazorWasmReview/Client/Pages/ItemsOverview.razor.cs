using BlazorWasmReview.Business;
using BlazorWasmReview.Client.ItemEdit;
using BlazorWasmReview.GeneralUI.DropdownControl;
using BlazorWasmReview.Shared.Contracts;
using BlazorWasmReview.Shared.Enums;
using Microsoft.AspNetCore.Components;

namespace BlazorWasmReview.Client.Pages;

public partial class ItemsOverview
{
    //[Inject]
    //public ItemEditService ItemEditService { get; set; }
    [Inject]
    private IUserItemManager UserItemManager { get; set; }
    [Inject]
    private ICurrentUserService CurrentUserService { get; set; }
    [Parameter]
    public string TypeString { get; set; }
    [Parameter]
    public int? Id { get; set; }

    public bool ShowEdit { get; set; }

    DropdownItem<ItemTypeEnum> SelectedDropdownType { get; set; } = new();
    IList<DropdownItem<ItemTypeEnum>> DropdownTypes { get; set; } = new List<DropdownItem<ItemTypeEnum>>();
    protected override void OnInitialized()
    {
        base.OnInitialized();
        DropdownTypes = new List<DropdownItem<ItemTypeEnum>>();

        var item = new DropdownItem<ItemTypeEnum>();
        item.ItemObject = ItemTypeEnum.Text;
        item.DisplayText = "Text";
        DropdownTypes.Add(item);

        item = new DropdownItem<ItemTypeEnum>();
        item.ItemObject = ItemTypeEnum.Url;
        item.DisplayText = "Url";
        DropdownTypes.Add(item);

        item = new DropdownItem<ItemTypeEnum>();
        item.ItemObject = ItemTypeEnum.Parent;
        item.DisplayText = "Parent";
        DropdownTypes.Add(item);
        //ItemEditService.ItemEditChanged += HandleEditItemChanged;
    }
    protected override void OnParametersSet()
    {
        base.OnParametersSet();
        if(Id != null && Enum.TryParse(typeof(ItemTypeEnum), TypeString,out _))
        {
            ShowEdit = true;
        }else
        {
            ShowEdit = false;
        }
    }

    private void HandleEditItemChanged(object sender, ItemEditEventArgs e)
    {
        ShowEdit = e.Item != null;
        StateHasChanged();
    }

    async Task AddNew()
    {
        if (SelectedDropdownType == null)
        {
            return;
        }
        await UserItemManager.CreateNewUserItemAndAddItToUserAsync(
                            CurrentUserService.CurrentUser,
                            SelectedDropdownType.ItemObject);
    }
}