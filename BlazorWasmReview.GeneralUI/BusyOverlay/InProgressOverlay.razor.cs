using Microsoft.AspNetCore.Components;

namespace BlazorWasmReview.GeneralUI.BusyOverlay;

public partial class InProgressOverlay
{
    [Parameter]
    public RenderFragment ChildContent { get; set; }
    [Inject]
    public InProgressOverlayService InProgressOverlayService { get; set; }

    public bool IsBusy { get; set; }

    protected override void OnParametersSet()
    {
        base.OnParametersSet();
        InProgressOverlayService.BusyStateChanged += HandleBusyStateChanged;
        IsBusy = InProgressOverlayService.CurrentBusyState == BusyEnum.Busy;
    }

    private void HandleBusyStateChanged(object sender, BusyChangedEventArgs e)
    {
        IsBusy = e.BusyState == BusyEnum.Busy;
        StateHasChanged();
    }
}