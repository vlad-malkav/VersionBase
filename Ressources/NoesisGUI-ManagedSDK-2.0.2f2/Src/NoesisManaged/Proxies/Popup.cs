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
using System.Collections.Generic;

namespace Noesis
{

public class Popup : FrameworkElement {
  internal new static Popup CreateProxy(IntPtr cPtr, bool cMemoryOwn) {
    return new Popup(cPtr, cMemoryOwn);
  }

  internal Popup(IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn) {
  }

  internal static HandleRef getCPtr(Popup obj) {
    return (obj == null) ? new HandleRef(null, IntPtr.Zero) : obj.swigCPtr;
  }

  #region Events
  #region Closed
  public delegate void ClosedHandler(object sender, EventArgs e);
  public event ClosedHandler Closed {
    add {
      if (!_Closed.ContainsKey(swigCPtr.Handle)) {
        _Closed.Add(swigCPtr.Handle, null);

        NoesisGUI_PINVOKE.BindEvent_Popup_Closed(_raiseClosed, swigCPtr.Handle);
        if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
      }

      _Closed[swigCPtr.Handle] += value;
    }
    remove {
      if (_Closed.ContainsKey(swigCPtr.Handle)) {

        _Closed[swigCPtr.Handle] -= value;

        if (_Closed[swigCPtr.Handle] == null) {
          NoesisGUI_PINVOKE.UnbindEvent_Popup_Closed(_raiseClosed, swigCPtr.Handle);
          if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();

          _Closed.Remove(swigCPtr.Handle);
        }
      }
    }
  }

  internal delegate void RaiseClosedCallback(IntPtr cPtr, IntPtr sender, IntPtr e);
  private static RaiseClosedCallback _raiseClosed = RaiseClosed;

  [MonoPInvokeCallback(typeof(RaiseClosedCallback))]
  private static void RaiseClosed(IntPtr cPtr, IntPtr sender, IntPtr e) {
    try {
      if (!_Closed.ContainsKey(cPtr)) {
        throw new InvalidOperationException("Delegate not registered for Closed event");
      }
      if (sender == IntPtr.Zero && e == IntPtr.Zero) {
        _Closed.Remove(cPtr);
        return;
      }
      if (Noesis.Extend.Initialized) {
        ClosedHandler handler = _Closed[cPtr];
        if (handler != null) {
          handler(Noesis.Extend.GetProxy(sender, false), new EventArgs(e, false));
        }
      }
    }
    catch (Exception exception) {
      Noesis.Error.SetNativePendingError(exception);
    }
  }

  static Dictionary<IntPtr, ClosedHandler> _Closed =
      new Dictionary<IntPtr, ClosedHandler>();
  #endregion

  #region Opened
  public delegate void OpenedHandler(object sender, EventArgs e);
  public event OpenedHandler Opened {
    add {
      if (!_Opened.ContainsKey(swigCPtr.Handle)) {
        _Opened.Add(swigCPtr.Handle, null);

        NoesisGUI_PINVOKE.BindEvent_Popup_Opened(_raiseOpened, swigCPtr.Handle);
        if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
      }

      _Opened[swigCPtr.Handle] += value;
    }
    remove {
      if (_Opened.ContainsKey(swigCPtr.Handle)) {

        _Opened[swigCPtr.Handle] -= value;

        if (_Opened[swigCPtr.Handle] == null) {
          NoesisGUI_PINVOKE.UnbindEvent_Popup_Opened(_raiseOpened, swigCPtr.Handle);
          if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();

          _Opened.Remove(swigCPtr.Handle);
        }
      }
    }
  }

  internal delegate void RaiseOpenedCallback(IntPtr cPtr, IntPtr sender, IntPtr e);
  private static RaiseOpenedCallback _raiseOpened = RaiseOpened;

  [MonoPInvokeCallback(typeof(RaiseOpenedCallback))]
  private static void RaiseOpened(IntPtr cPtr, IntPtr sender, IntPtr e) {
    try {
      if (!_Opened.ContainsKey(cPtr)) {
        throw new InvalidOperationException("Delegate not registered for Opened event");
      }
      if (sender == IntPtr.Zero && e == IntPtr.Zero) {
        _Opened.Remove(cPtr);
        return;
      }
      if (Noesis.Extend.Initialized) {
        OpenedHandler handler = _Opened[cPtr];
        if (handler != null) {
          handler(Noesis.Extend.GetProxy(sender, false), new EventArgs(e, false));
        }
      }
    }
    catch (Exception exception) {
      Noesis.Error.SetNativePendingError(exception);
    }
  }

  static Dictionary<IntPtr, OpenedHandler> _Opened =
      new Dictionary<IntPtr, OpenedHandler>();
  #endregion

  #endregion

  public Popup() {
  }

  protected override IntPtr CreateCPtr(Type type, out bool registerExtend) {
    if ((object)type.TypeHandle == typeof(Popup).TypeHandle) {
      registerExtend = false;
      return NoesisGUI_PINVOKE.new_Popup();
    }
    else {
      return base.CreateExtendCPtr(type, out registerExtend);
    }
  }

  public static DependencyProperty AllowsTransparencyProperty {
    get {
      IntPtr cPtr = NoesisGUI_PINVOKE.Popup_AllowsTransparencyProperty_get();
      if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
      return (DependencyProperty)Noesis.Extend.GetProxy(cPtr, false);
    }
  }

  public static DependencyProperty ChildProperty {
    get {
      IntPtr cPtr = NoesisGUI_PINVOKE.Popup_ChildProperty_get();
      if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
      return (DependencyProperty)Noesis.Extend.GetProxy(cPtr, false);
    }
  }

  public static DependencyProperty HasDropShadowProperty {
    get {
      IntPtr cPtr = NoesisGUI_PINVOKE.Popup_HasDropShadowProperty_get();
      if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
      return (DependencyProperty)Noesis.Extend.GetProxy(cPtr, false);
    }
  }

  public static DependencyProperty HorizontalOffsetProperty {
    get {
      IntPtr cPtr = NoesisGUI_PINVOKE.Popup_HorizontalOffsetProperty_get();
      if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
      return (DependencyProperty)Noesis.Extend.GetProxy(cPtr, false);
    }
  }

  public static DependencyProperty IsOpenProperty {
    get {
      IntPtr cPtr = NoesisGUI_PINVOKE.Popup_IsOpenProperty_get();
      if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
      return (DependencyProperty)Noesis.Extend.GetProxy(cPtr, false);
    }
  }

  public static DependencyProperty PlacementProperty {
    get {
      IntPtr cPtr = NoesisGUI_PINVOKE.Popup_PlacementProperty_get();
      if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
      return (DependencyProperty)Noesis.Extend.GetProxy(cPtr, false);
    }
  }

  public static DependencyProperty PlacementRectangleProperty {
    get {
      IntPtr cPtr = NoesisGUI_PINVOKE.Popup_PlacementRectangleProperty_get();
      if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
      return (DependencyProperty)Noesis.Extend.GetProxy(cPtr, false);
    }
  }

  public static DependencyProperty PlacementTargetProperty {
    get {
      IntPtr cPtr = NoesisGUI_PINVOKE.Popup_PlacementTargetProperty_get();
      if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
      return (DependencyProperty)Noesis.Extend.GetProxy(cPtr, false);
    }
  }

  public static DependencyProperty PopupAnimationProperty {
    get {
      IntPtr cPtr = NoesisGUI_PINVOKE.Popup_PopupAnimationProperty_get();
      if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
      return (DependencyProperty)Noesis.Extend.GetProxy(cPtr, false);
    }
  }

  public static DependencyProperty StaysOpenProperty {
    get {
      IntPtr cPtr = NoesisGUI_PINVOKE.Popup_StaysOpenProperty_get();
      if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
      return (DependencyProperty)Noesis.Extend.GetProxy(cPtr, false);
    }
  }

  public static DependencyProperty VerticalOffsetProperty {
    get {
      IntPtr cPtr = NoesisGUI_PINVOKE.Popup_VerticalOffsetProperty_get();
      if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
      return (DependencyProperty)Noesis.Extend.GetProxy(cPtr, false);
    }
  }

  public bool AllowsTransparency {
    set {
      NoesisGUI_PINVOKE.Popup_AllowsTransparency_set(swigCPtr, value);
      if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
    } 
    get {
      bool ret = NoesisGUI_PINVOKE.Popup_AllowsTransparency_get(swigCPtr);
      if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
      return ret;
    } 
  }

  public UIElement Child {
    set {
      NoesisGUI_PINVOKE.Popup_Child_set(swigCPtr, UIElement.getCPtr(value));
      if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
    } 
    get {
      IntPtr cPtr = NoesisGUI_PINVOKE.Popup_Child_get(swigCPtr);
      if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
      return (UIElement)Noesis.Extend.GetProxy(cPtr, false);
    }
  }

  public bool HasDropShadow {
    set {
      NoesisGUI_PINVOKE.Popup_HasDropShadow_set(swigCPtr, value);
      if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
    } 
    get {
      bool ret = NoesisGUI_PINVOKE.Popup_HasDropShadow_get(swigCPtr);
      if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
      return ret;
    } 
  }

  public float HorizontalOffset {
    set {
      NoesisGUI_PINVOKE.Popup_HorizontalOffset_set(swigCPtr, value);
      if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
    } 
    get {
      float ret = NoesisGUI_PINVOKE.Popup_HorizontalOffset_get(swigCPtr);
      if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
      return ret;
    } 
  }

  public bool IsOpen {
    set {
      NoesisGUI_PINVOKE.Popup_IsOpen_set(swigCPtr, value);
      if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
    } 
    get {
      bool ret = NoesisGUI_PINVOKE.Popup_IsOpen_get(swigCPtr);
      if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
      return ret;
    } 
  }

  public PlacementMode Placement {
    set {
      NoesisGUI_PINVOKE.Popup_Placement_set(swigCPtr, (int)value);
      if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
    } 
    get {
      PlacementMode ret = (PlacementMode)NoesisGUI_PINVOKE.Popup_Placement_get(swigCPtr);
      if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
      return ret;
    } 
  }

  public Rect PlacementRectangle {
    set {
      NoesisGUI_PINVOKE.Popup_PlacementRectangle_set(swigCPtr, ref value);
      if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
    }

    get {
      IntPtr ret = NoesisGUI_PINVOKE.Popup_PlacementRectangle_get(swigCPtr);
      if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
      if (ret != IntPtr.Zero) {
        return Marshal.PtrToStructure<Rect>(ret);
      }
      else {
        return new Rect();
      }
    }

  }

  public PopupAnimation PopupAnimation {
    set {
      NoesisGUI_PINVOKE.Popup_PopupAnimation_set(swigCPtr, (int)value);
      if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
    } 
    get {
      PopupAnimation ret = (PopupAnimation)NoesisGUI_PINVOKE.Popup_PopupAnimation_get(swigCPtr);
      if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
      return ret;
    } 
  }

  public bool StaysOpen {
    set {
      NoesisGUI_PINVOKE.Popup_StaysOpen_set(swigCPtr, value);
      if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
    } 
    get {
      bool ret = NoesisGUI_PINVOKE.Popup_StaysOpen_get(swigCPtr);
      if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
      return ret;
    } 
  }

  public float VerticalOffset {
    set {
      NoesisGUI_PINVOKE.Popup_VerticalOffset_set(swigCPtr, value);
      if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
    } 
    get {
      float ret = NoesisGUI_PINVOKE.Popup_VerticalOffset_get(swigCPtr);
      if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
      return ret;
    } 
  }

  new internal static IntPtr GetStaticType() {
    IntPtr ret = NoesisGUI_PINVOKE.Popup_GetStaticType();
    if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }


  internal new static IntPtr Extend(string typeName) {
    IntPtr nativeType = NoesisGUI_PINVOKE.Extend_Popup(Marshal.StringToHGlobalAnsi(typeName));
    if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
    return nativeType;
  }
}

}

