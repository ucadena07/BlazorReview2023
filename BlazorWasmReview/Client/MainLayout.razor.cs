using BlazorWasmReview.Shared.Contracts;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace BlazorWasmReview.Client;

public partial class MainLayout : IDisposable
{
    [Inject]
    public ICurrentUserService CurrentUserService { get; set; }
    [Inject]
    private  IJSRuntime _js { get; set; }

    [JSInvokable]
    public static void OnResize()
    {
        Console.WriteLine("on rezue");
    }

    public async void Dispose()
    {
        await _js.InvokeVoidAsync("blazorResize.registerReunregisterfForResizeEvent", nameof(MainLayout));
    }

    [JSInvokable]
    public  void HandleResize(int width,int heigth)
    {
        Console.WriteLine($"The size: {width} x {heigth}");
    }

    public  void Signout()
    {
      
    }

    protected override async Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();
        var width = await _js.InvokeAsync<int>("blazorDimension.getWidth");
        var objRef = DotNetObjectReference.Create(this);
        await _js.InvokeVoidAsync("blazorResize.registerRefForResizeEvent", nameof(MainLayout),objRef);
    }
}