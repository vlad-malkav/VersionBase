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
using System.Windows.Input;

namespace Noesis
{

public class Hyperlink : Span {
  internal new static Hyperlink CreateProxy(IntPtr cPtr, bool cMemoryOwn) {
    return new Hyperlink(cPtr, cMemoryOwn);
  }

  internal Hyperlink(IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn) {
  }

  internal static HandleRef getCPtr(Hyperlink obj) {
    return (obj == null) ? new HandleRef(null, IntPtr.Zero) : obj.swigCPtr;
  }

  #region Events

  #region Click
  public delegate void ClickHandler(object sender, RoutedEventArgs e);
  public event ClickHandler Click {
    add {
      if (!_Click.ContainsKey(swigCPtr.Handle)) {
        _Click.Add(swigCPtr.Handle, null);

        NoesisGUI_PINVOKE.BindEvent_Hyperlink_Click(_raiseClick, swigCPtr.Handle);
        if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
      }

      _Click[swigCPtr.Handle] += value;
    }
    remove {
      if (_Click.ContainsKey(swigCPtr.Handle)) {

        _Click[swigCPtr.Handle] -= value;

        if (_Click[swigCPtr.Handle] == null) {
          NoesisGUI_PINVOKE.UnbindEvent_Hyperlink_Click(_raiseClick, swigCPtr.Handle);
          if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();

          _Click.Remove(swigCPtr.Handle);
        }
      }
    }
  }

  internal delegate void RaiseClickCallback(IntPtr cPtr, IntPtr sender, IntPtr e);
  private static RaiseClickCallback _raiseClick = RaiseClick;

  [MonoPInvokeCallback(typeof(RaiseClickCallback))]
  private static void RaiseClick(IntPtr cPtr, IntPtr sender, IntPtr e) {
    try {
      if (!_Click.ContainsKey(cPtr)) {
        throw new InvalidOperationException("Delegate not registered for Click event");
      }
      if (sender == IntPtr.Zero && e == IntPtr.Zero) {
        _Click.Remove(cPtr);
        return;
      }
      if (Noesis.Extend.Initialized) {
        ClickHandler handler = _Click[cPtr];
        if (handler != null) {
          handler(Noesis.Extend.GetProxy(sender, false), new RoutedEventArgs(e, false));
        }
      }
    }
    catch (Exception exception) {
      Noesis.Error.SetNativePendingError(exception);
    }
  }

  static Dictionary<IntPtr, ClickHandler> _Click =
      new Dictionary<IntPtr, ClickHandler>();
  #endregion

  #region RequestNavigate
  public delegate void RequestNavigateHandler(object sender, RequestNavigateEventArgs e);
  public event RequestNavigateHandler RequestNavigate {
    add {
      if (!_RequestNavigate.ContainsKey(swigCPtr.Handle)) {
        _RequestNavigate.Add(swigCPtr.Handle, null);

        NoesisGUI_PINVOKE.BindEvent_Hyperlink_RequestNavigate(_raiseRequestNavigate, swigCPtr.Handle);
        if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
      }

      _RequestNavigate[swigCPtr.Handle] += value;
    }
    remove {
      if (_RequestNavigate.ContainsKey(swigCPtr.Handle)) {

        _RequestNavigate[swigCPtr.Handle] -= value;

        if (_RequestNavigate[swigCPtr.Handle] == null) {
          NoesisGUI_PINVOKE.UnbindEvent_Hyperlink_RequestNavigate(_raiseRequestNavigate, swigCPtr.Handle);
          if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();

          _RequestNavigate.Remove(swigCPtr.Handle);
        }
      }
    }
  }

  internal delegate void RaiseRequestNavigateCallback(IntPtr cPtr, IntPtr sender, IntPtr e);
  private static RaiseRequestNavigateCallback _raiseRequestNavigate = RaiseRequestNavigate;

  [MonoPInvokeCallback(typeof(RaiseRequestNavigateCallback))]
  private static void RaiseRequestNavigate(IntPtr cPtr, IntPtr sender, IntPtr e) {
    try {
      if (!_RequestNavigate.ContainsKey(cPtr)) {
        throw new InvalidOperationException("Delegate not registered for RequestNavigate event");
      }
      if (sender == IntPtr.Zero && e == IntPtr.Zero) {
        _RequestNavigate.Remove(cPtr);
        return;
      }
      if (Noesis.Extend.Initialized) {
        RequestNavigateHandler handler = _RequestNavigate[cPtr];
        if (handler != null) {
          handler(Noesis.Extend.GetProxy(sender, false), new RequestNavigateEventArgs(e, false));
        }
      }
    }
    catch (Exception exception) {
      Noesis.Error.SetNativePendingError(exception);
    }
  }

  static Dictionary<IntPtr, RequestNavigateHandler> _RequestNavigate =
      new Dictionary<IntPtr, RequestNavigateHandler>();
  #endregion

  #endregion

  public ICommand Command {
    get {
      return (ICommand)GetCommandHelper();
    }
    set {
      SetCommandHelper(value);
    }
  }

  public Hyperlink() {
  }

  protected override IntPtr CreateCPtr(Type type, out bool registerExtend) {
    registerExtend = false;
    return NoesisGUI_PINVOKE.new_Hyperlink__SWIG_0();
  }

  public Hyperlink(Inline childInline) : this(NoesisGUI_PINVOKE.new_Hyperlink__SWIG_1(Inline.getCPtr(childInline)), true) {
    if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
  }

  public static DependencyProperty CommandProperty {
    get {
      IntPtr cPtr = NoesisGUI_PINVOKE.Hyperlink_CommandProperty_get();
      if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
      return (DependencyProperty)Noesis.Extend.GetProxy(cPtr, false);
    }
  }

  public static DependencyProperty CommandParameterProperty {
    get {
      IntPtr cPtr = NoesisGUI_PINVOKE.Hyperlink_CommandParameterProperty_get();
      if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
      return (DependencyProperty)Noesis.Extend.GetProxy(cPtr, false);
    }
  }

  public static DependencyProperty CommandTargetProperty {
    get {
      IntPtr cPtr = NoesisGUI_PINVOKE.Hyperlink_CommandTargetProperty_get();
      if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
      return (DependencyProperty)Noesis.Extend.GetProxy(cPtr, false);
    }
  }

  public static DependencyProperty NavigateUriProperty {
    get {
      IntPtr cPtr = NoesisGUI_PINVOKE.Hyperlink_NavigateUriProperty_get();
      if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
      return (DependencyProperty)Noesis.Extend.GetProxy(cPtr, false);
    }
  }

  public static DependencyProperty TargetNameProperty {
    get {
      IntPtr cPtr = NoesisGUI_PINVOKE.Hyperlink_TargetNameProperty_get();
      if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
      return (DependencyProperty)Noesis.Extend.GetProxy(cPtr, false);
    }
  }

  public object CommandParameter {
    set {
      NoesisGUI_PINVOKE.Hyperlink_CommandParameter_set(swigCPtr, Noesis.Extend.GetInstanceHandle(value));
      if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
    }
    get {
      IntPtr cPtr = NoesisGUI_PINVOKE.Hyperlink_CommandParameter_get(swigCPtr);
      if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
      return Noesis.Extend.GetProxy(cPtr, false);
    }
  }

  public UIElement CommandTarget {
    set {
      NoesisGUI_PINVOKE.Hyperlink_CommandTarget_set(swigCPtr, UIElement.getCPtr(value));
      if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
    } 
    get {
      IntPtr cPtr = NoesisGUI_PINVOKE.Hyperlink_CommandTarget_get(swigCPtr);
      if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
      return (UIElement)Noesis.Extend.GetProxy(cPtr, false);
    }
  }

  public string NavigateUri {
    set {
      NoesisGUI_PINVOKE.Hyperlink_NavigateUri_set(swigCPtr, value != null ? value : string.Empty);
      if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
    }
    get {
      IntPtr strPtr = NoesisGUI_PINVOKE.Hyperlink_NavigateUri_get(swigCPtr);
      if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
      string str = Noesis.Extend.StringFromNativeUtf8(strPtr);
      return str;
    }
  }

  public string TargetName {
    set {
      NoesisGUI_PINVOKE.Hyperlink_TargetName_set(swigCPtr, value != null ? value : string.Empty);
      if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
    }
    get {
      IntPtr strPtr = NoesisGUI_PINVOKE.Hyperlink_TargetName_get(swigCPtr);
      if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
      string str = Noesis.Extend.StringFromNativeUtf8(strPtr);
      return str;
    }
  }

  private object GetCommandHelper() {
    IntPtr cPtr = NoesisGUI_PINVOKE.Hyperlink_GetCommandHelper(swigCPtr);
    if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
    return Noesis.Extend.GetProxy(cPtr, false);
  }

  private void SetCommandHelper(object command) {
    NoesisGUI_PINVOKE.Hyperlink_SetCommandHelper(swigCPtr, Noesis.Extend.GetInstanceHandle(command));
    if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
  }

  new internal static IntPtr GetStaticType() {
    IntPtr ret = NoesisGUI_PINVOKE.Hyperlink_GetStaticType();
    if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

}

}

