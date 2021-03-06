//------------------------------------------------------------------------------
// <auto-generated />
//
// This file was automatically generated by SWIG (http://www.swig.org).
// Version 3.0.10
//
// Do not make changes to this file unless you know what you are doing--modify
// the SWIG interface file instead.
//------------------------------------------------------------------------------


using System;
using System.Runtime.InteropServices;

namespace Noesis
{

public class TimelineEventArgs : EventArgs {
  private HandleRef swigCPtr;

  internal TimelineEventArgs(IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn) {
    swigCPtr = new HandleRef(this, cPtr);
  }

  internal static HandleRef getCPtr(TimelineEventArgs obj) {
    return (obj == null) ? new HandleRef(null, IntPtr.Zero) : obj.swigCPtr;
  }

  ~TimelineEventArgs() {
    Dispose();
  }

  public override void Dispose() {
    lock(this) {
      if (swigCPtr.Handle != IntPtr.Zero) {
        if (swigCMemOwn) {
          swigCMemOwn = false;
          NoesisGUI_PINVOKE.delete_TimelineEventArgs(swigCPtr);
        }
        swigCPtr = new HandleRef(null, IntPtr.Zero);
      }
      GC.SuppressFinalize(this);
      base.Dispose();
    }
  }

  public Noesis.DependencyObject Target {
    get {
      return GetTargetHelper();
    }
  }

  public TimelineEventArgs(DependencyObject t) : this(NoesisGUI_PINVOKE.new_TimelineEventArgs__SWIG_0(DependencyObject.getCPtr(t)), true) {
    if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
  }

  public TimelineEventArgs() : this(NoesisGUI_PINVOKE.new_TimelineEventArgs__SWIG_1(), true) {
    if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
  }

  private DependencyObject GetTargetHelper() {
    IntPtr cPtr = NoesisGUI_PINVOKE.TimelineEventArgs_GetTargetHelper(swigCPtr);
    if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
    return (DependencyObject)Noesis.Extend.GetProxy(cPtr, false);
  }

}

}

