using BlazorWasmReview.Client.ItemEdit;
using BlazorWasmReview.Shared.Enums;
using Microsoft.AspNetCore.Components;

namespace BlazorWasmReview.Client.Pages;

public partial class ItemsOverview
{
    //[Inject]
    //public ItemEditService ItemEditService { get; set; }
    [Parameter]
    public string TypeString { get; set; }
    [Parameter]
    public int? Id { get; set; }

    public bool ShowEdit { get; set; }
    protected override void OnInitialized()
    {
        base.OnInitialized();
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
}