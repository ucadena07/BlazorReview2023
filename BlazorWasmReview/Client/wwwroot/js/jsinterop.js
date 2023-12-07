window.addEventListener("resize", () => {
  DotNet.invokeMethodAsync("BlazorWasmReview.Client","OnResize")
})
window.blazorDimension = {
  getWidth: () => {
    return window.innerWidth
  }
}
window.blazorResize = {
  registerRefForResizeEvent: (dotnotRef) => {
    window.addEventListener("resize", () => {
      dotnotRef.invokeMethodAsync("HandleResize",window.innerWidth,window.innerHeight)
    })
  }
}