using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorWasmReview.GeneralUI.BusyOverlay;

public class BusyChangedEventArgs : EventArgs
{
    public BusyEnum BusyState { get; set; }
}
public enum BusyEnum
{
    Busy,
    NotBusy
}