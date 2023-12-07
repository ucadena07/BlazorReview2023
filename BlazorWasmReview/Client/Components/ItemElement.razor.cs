using BlazorWasmReview.Client.ItemEdit;
using BlazorWasmReview.Shared.Entities;
using Microsoft.AspNetCore.Components;
using System.ComponentModel;

namespace BlazorWasmReview.Client.Components;

public partial class ItemElement<TItem> : IDisposable where TItem : BaseItem
{
    [Parameter]
    public RenderFragment MainFragment { get; set; }
    [Parameter]
    public RenderFragment DetailFragment { get; set; }
    [Parameter]
    public TItem Item { get; set; }
    [CascadingParameter]
    public string ColorPrefix { get; set; }
    [CascadingParameter]
    public int TotalNumber { get; set; }
    //[Inject]
    //public ItemEditService ItemEditService { get; set; }
    [Inject]
    public NavigationManager _navigationManager { get; set; }
    private string DetailAreaId { get; set; }
    protected override void OnParametersSet()
    {
        base.OnParametersSet();
        DetailAreaId = $"details{Item.Position}";
    }

    void OpenItemInEditMode()
    {
        Uri.TryCreate($"/items/{Item.ItemTypeEnum}/{Item.Id}", UriKind.Relative, out var url);
        //ItemEditService.EditItem = Item;
        _navigationManager.NavigateTo(url.ToString());
    }

    protected override void OnAfterRender(bool firstRender)
    {
        base.OnAfterRender(firstRender);    
        if(firstRender)
        {
            Item.PropertyChanged += HandleItemPropertyChanged;
        }
    }

    private void HandleItemPropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        StateHasChanged();
    }
    public void Dispose()
    {
        Item.PropertyChanged -= HandleItemPropertyChanged;
    }
}