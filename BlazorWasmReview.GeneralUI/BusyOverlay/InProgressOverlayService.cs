﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorWasmReview.GeneralUI.BusyOverlay;

public class InProgressOverlayService
{
    public event EventHandler<BusyChangedEventArgs> BusyStateChanged;
    protected virtual void OnBusyStateChanged(BusyChangedEventArgs e)
    {
        EventHandler<BusyChangedEventArgs> handler = BusyStateChanged;
        if (handler != null)
        {
            handler(this, e);
        }
    }
    public BusyEnum CurrentBusyState { get; set; }
    public void SetBusyState(BusyEnum busyState)
    {
        CurrentBusyState = busyState;
        var eventArgs = new BusyChangedEventArgs();
        eventArgs.BusyState = CurrentBusyState;
        OnBusyStateChanged(eventArgs);
    }
}
