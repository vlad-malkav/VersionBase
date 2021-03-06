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

public class ManipulationVelocities : IDisposable {
  private HandleRef swigCPtr;
  protected bool swigCMemOwn;

  internal ManipulationVelocities(IntPtr cPtr, bool cMemoryOwn) {
    swigCMemOwn = cMemoryOwn;
    swigCPtr = new HandleRef(this, cPtr);
  }

  internal static HandleRef getCPtr(ManipulationVelocities obj) {
    return (obj == null) ? new HandleRef(null, IntPtr.Zero) : obj.swigCPtr;
  }

  ~ManipulationVelocities() {
    Dispose();
  }

  public virtual void Dispose() {
    lock(this) {
      if (swigCPtr.Handle != IntPtr.Zero) {
        if (swigCMemOwn) {
          swigCMemOwn = false;
          NoesisGUI_PINVOKE.delete_ManipulationVelocities(swigCPtr);
        }
        swigCPtr = new HandleRef(null, IntPtr.Zero);
      }
      GC.SuppressFinalize(this);
    }
  }

  public float AngularVelocity {
    get {
      return GetAngularVelocityHelper();
    }
    set {
      SetAngularVelocityHelper(value);
    }
  }

  public Noesis.Point ExpansionVelocity {
    get {
      return GetExpansionVelocityHelper();
    }
    set {
      SetExpansionVelocityHelper(value);
    }
  }

  public Noesis.Point LinearVelocity {
    get {
      return GetLinearVelocityHelper();
    }
    set {
      SetLinearVelocityHelper(value);
    }
  }

  private float GetAngularVelocityHelper() {
    float ret = NoesisGUI_PINVOKE.ManipulationVelocities_GetAngularVelocityHelper(swigCPtr);
    if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  private void SetAngularVelocityHelper(float v) {
    NoesisGUI_PINVOKE.ManipulationVelocities_SetAngularVelocityHelper(swigCPtr, v);
    if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
  }

  private Point GetExpansionVelocityHelper() {
    IntPtr ret = NoesisGUI_PINVOKE.ManipulationVelocities_GetExpansionVelocityHelper(swigCPtr);
    if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
    if (ret != IntPtr.Zero) {
      return Marshal.PtrToStructure<Point>(ret);
    }
    else {
      return new Point();
    }
  }

  private void SetExpansionVelocityHelper(Point v) {
    NoesisGUI_PINVOKE.ManipulationVelocities_SetExpansionVelocityHelper(swigCPtr, ref v);
    if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
  }

  private Point GetLinearVelocityHelper() {
    IntPtr ret = NoesisGUI_PINVOKE.ManipulationVelocities_GetLinearVelocityHelper(swigCPtr);
    if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
    if (ret != IntPtr.Zero) {
      return Marshal.PtrToStructure<Point>(ret);
    }
    else {
      return new Point();
    }
  }

  private void SetLinearVelocityHelper(Point v) {
    NoesisGUI_PINVOKE.ManipulationVelocities_SetLinearVelocityHelper(swigCPtr, ref v);
    if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
  }

  public ManipulationVelocities() : this(NoesisGUI_PINVOKE.new_ManipulationVelocities(), true) {
    if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
  }

}

}

