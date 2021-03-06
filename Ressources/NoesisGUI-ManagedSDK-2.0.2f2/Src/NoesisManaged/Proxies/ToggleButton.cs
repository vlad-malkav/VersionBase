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

public class ToggleButton : ButtonBase {
  internal new static ToggleButton CreateProxy(IntPtr cPtr, bool cMemoryOwn) {
    return new ToggleButton(cPtr, cMemoryOwn);
  }

  internal ToggleButton(IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn) {
  }

  internal static HandleRef getCPtr(ToggleButton obj) {
    return (obj == null) ? new HandleRef(null, IntPtr.Zero) : obj.swigCPtr;
  }

  #region Events
  #region Checked
  public delegate void CheckedHandler(object sender, RoutedEventArgs e);
  public event CheckedHandler Checked {
    add {
      if (!_Checked.ContainsKey(swigCPtr.Handle)) {
        _Checked.Add(swigCPtr.Handle, null);

        NoesisGUI_PINVOKE.BindEvent_ToggleButton_Checked(_raiseChecked, swigCPtr.Handle);
        if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
      }

      _Checked[swigCPtr.Handle] += value;
    }
    remove {
      if (_Checked.ContainsKey(swigCPtr.Handle)) {

        _Checked[swigCPtr.Handle] -= value;

        if (_Checked[swigCPtr.Handle] == null) {
          NoesisGUI_PINVOKE.UnbindEvent_ToggleButton_Checked(_raiseChecked, swigCPtr.Handle);
          if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();

          _Checked.Remove(swigCPtr.Handle);
        }
      }
    }
  }

  internal delegate void RaiseCheckedCallback(IntPtr cPtr, IntPtr sender, IntPtr e);
  private static RaiseCheckedCallback _raiseChecked = RaiseChecked;

  [MonoPInvokeCallback(typeof(RaiseCheckedCallback))]
  private static void RaiseChecked(IntPtr cPtr, IntPtr sender, IntPtr e) {
    try {
      if (!_Checked.ContainsKey(cPtr)) {
        throw new InvalidOperationException("Delegate not registered for Checked event");
      }
      if (sender == IntPtr.Zero && e == IntPtr.Zero) {
        _Checked.Remove(cPtr);
        return;
      }
      if (Noesis.Extend.Initialized) {
        CheckedHandler handler = _Checked[cPtr];
        if (handler != null) {
          handler(Noesis.Extend.GetProxy(sender, false), new RoutedEventArgs(e, false));
        }
      }
    }
    catch (Exception exception) {
      Noesis.Error.SetNativePendingError(exception);
    }
  }

  static Dictionary<IntPtr, CheckedHandler> _Checked =
      new Dictionary<IntPtr, CheckedHandler>();
  #endregion

  #region Indeterminate
  public delegate void IndeterminateHandler(object sender, RoutedEventArgs e);
  public event IndeterminateHandler Indeterminate {
    add {
      if (!_Indeterminate.ContainsKey(swigCPtr.Handle)) {
        _Indeterminate.Add(swigCPtr.Handle, null);

        NoesisGUI_PINVOKE.BindEvent_ToggleButton_Indeterminate(_raiseIndeterminate, swigCPtr.Handle);
        if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
      }

      _Indeterminate[swigCPtr.Handle] += value;
    }
    remove {
      if (_Indeterminate.ContainsKey(swigCPtr.Handle)) {

        _Indeterminate[swigCPtr.Handle] -= value;

        if (_Indeterminate[swigCPtr.Handle] == null) {
          NoesisGUI_PINVOKE.UnbindEvent_ToggleButton_Indeterminate(_raiseIndeterminate, swigCPtr.Handle);
          if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();

          _Indeterminate.Remove(swigCPtr.Handle);
        }
      }
    }
  }

  internal delegate void RaiseIndeterminateCallback(IntPtr cPtr, IntPtr sender, IntPtr e);
  private static RaiseIndeterminateCallback _raiseIndeterminate = RaiseIndeterminate;

  [MonoPInvokeCallback(typeof(RaiseIndeterminateCallback))]
  private static void RaiseIndeterminate(IntPtr cPtr, IntPtr sender, IntPtr e) {
    try {
      if (!_Indeterminate.ContainsKey(cPtr)) {
        throw new InvalidOperationException("Delegate not registered for Indeterminate event");
      }
      if (sender == IntPtr.Zero && e == IntPtr.Zero) {
        _Indeterminate.Remove(cPtr);
        return;
      }
      if (Noesis.Extend.Initialized) {
        IndeterminateHandler handler = _Indeterminate[cPtr];
        if (handler != null) {
          handler(Noesis.Extend.GetProxy(sender, false), new RoutedEventArgs(e, false));
        }
      }
    }
    catch (Exception exception) {
      Noesis.Error.SetNativePendingError(exception);
    }
  }

  static Dictionary<IntPtr, IndeterminateHandler> _Indeterminate =
      new Dictionary<IntPtr, IndeterminateHandler>();
  #endregion

  #region Unchecked
  public delegate void UncheckedHandler(object sender, RoutedEventArgs e);
  public event UncheckedHandler Unchecked {
    add {
      if (!_Unchecked.ContainsKey(swigCPtr.Handle)) {
        _Unchecked.Add(swigCPtr.Handle, null);

        NoesisGUI_PINVOKE.BindEvent_ToggleButton_Unchecked(_raiseUnchecked, swigCPtr.Handle);
        if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
      }

      _Unchecked[swigCPtr.Handle] += value;
    }
    remove {
      if (_Unchecked.ContainsKey(swigCPtr.Handle)) {

        _Unchecked[swigCPtr.Handle] -= value;

        if (_Unchecked[swigCPtr.Handle] == null) {
          NoesisGUI_PINVOKE.UnbindEvent_ToggleButton_Unchecked(_raiseUnchecked, swigCPtr.Handle);
          if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();

          _Unchecked.Remove(swigCPtr.Handle);
        }
      }
    }
  }

  internal delegate void RaiseUncheckedCallback(IntPtr cPtr, IntPtr sender, IntPtr e);
  private static RaiseUncheckedCallback _raiseUnchecked = RaiseUnchecked;

  [MonoPInvokeCallback(typeof(RaiseUncheckedCallback))]
  private static void RaiseUnchecked(IntPtr cPtr, IntPtr sender, IntPtr e) {
    try {
      if (!_Unchecked.ContainsKey(cPtr)) {
        throw new InvalidOperationException("Delegate not registered for Unchecked event");
      }
      if (sender == IntPtr.Zero && e == IntPtr.Zero) {
        _Unchecked.Remove(cPtr);
        return;
      }
      if (Noesis.Extend.Initialized) {
        UncheckedHandler handler = _Unchecked[cPtr];
        if (handler != null) {
          handler(Noesis.Extend.GetProxy(sender, false), new RoutedEventArgs(e, false));
        }
      }
    }
    catch (Exception exception) {
      Noesis.Error.SetNativePendingError(exception);
    }
  }

  static Dictionary<IntPtr, UncheckedHandler> _Unchecked =
      new Dictionary<IntPtr, UncheckedHandler>();
  #endregion

  #endregion

  public ToggleButton() {
  }

  protected override IntPtr CreateCPtr(Type type, out bool registerExtend) {
    if ((object)type.TypeHandle == typeof(ToggleButton).TypeHandle) {
      registerExtend = false;
      return NoesisGUI_PINVOKE.new_ToggleButton();
    }
    else {
      return base.CreateExtendCPtr(type, out registerExtend);
    }
  }

  public static DependencyProperty IsCheckedProperty {
    get {
      IntPtr cPtr = NoesisGUI_PINVOKE.ToggleButton_IsCheckedProperty_get();
      if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
      return (DependencyProperty)Noesis.Extend.GetProxy(cPtr, false);
    }
  }

  public static DependencyProperty IsThreeStateProperty {
    get {
      IntPtr cPtr = NoesisGUI_PINVOKE.ToggleButton_IsThreeStateProperty_get();
      if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
      return (DependencyProperty)Noesis.Extend.GetProxy(cPtr, false);
    }
  }

  public Nullable<bool> IsChecked {
    set {
      NullableBool tempvalue = value;
      NoesisGUI_PINVOKE.ToggleButton_IsChecked_set(swigCPtr, ref tempvalue);
      if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
    }

    get {
      IntPtr ret = NoesisGUI_PINVOKE.ToggleButton_IsChecked_get(swigCPtr);
      if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
      if (ret != IntPtr.Zero) {
        return Marshal.PtrToStructure<NullableBool>(ret);
      }
      else {
        return new Nullable<bool>();
      }
    }

  }

  public bool IsThreeState {
    set {
      NoesisGUI_PINVOKE.ToggleButton_IsThreeState_set(swigCPtr, value);
      if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
    } 
    get {
      bool ret = NoesisGUI_PINVOKE.ToggleButton_IsThreeState_get(swigCPtr);
      if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
      return ret;
    } 
  }

  new internal static IntPtr GetStaticType() {
    IntPtr ret = NoesisGUI_PINVOKE.ToggleButton_GetStaticType();
    if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }


  internal new static IntPtr Extend(string typeName) {
    IntPtr nativeType = NoesisGUI_PINVOKE.Extend_ToggleButton(Marshal.StringToHGlobalAnsi(typeName));
    if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
    return nativeType;
  }
}

}

