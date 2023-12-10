window.addEventListener("resize", () => {
  DotNet.invokeMethodAsync("BlazorWasmReview.Client","OnResize")
})
window.blazorDimension = {
  getWidth: () => {
    return window.innerWidth
  }
}
window.blazorResize = {
  assigments: [],
  registerRefForResizeEvent: (name,dotnotRef) => {
    const handler = () => {
      dotnotRef.invokeMethodAsync("HandleResize", window.innerWidth, window.innerHeight)
    }
    const assigment = {
      name: name,
      handler: handler
    }
    blazorResize.assigments.push(assigment)
    window.addEventListener("resize", assigment.handler)
  },
  unregister: (name) => {
    const assignment = blazorResize.assigments.find(a = a.name === name)
    if (assignment != null) {
      window.removeEventListener("resize", assignment.handler)
    }
  }
}