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

public class Shape : FrameworkElement {
  internal new static Shape CreateProxy(IntPtr cPtr, bool cMemoryOwn) {
    return new Shape(cPtr, cMemoryOwn);
  }

  internal Shape(IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn) {
  }

  internal static HandleRef getCPtr(Shape obj) {
    return (obj == null) ? new HandleRef(null, IntPtr.Zero) : obj.swigCPtr;
  }

  protected Shape() {
  }

  public static DependencyProperty FillProperty {
    get {
      IntPtr cPtr = NoesisGUI_PINVOKE.Shape_FillProperty_get();
      if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
      return (DependencyProperty)Noesis.Extend.GetProxy(cPtr, false);
    }
  }

  public static DependencyProperty StretchProperty {
    get {
      IntPtr cPtr = NoesisGUI_PINVOKE.Shape_StretchProperty_get();
      if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
      return (DependencyProperty)Noesis.Extend.GetProxy(cPtr, false);
    }
  }

  public static DependencyProperty StrokeProperty {
    get {
      IntPtr cPtr = NoesisGUI_PINVOKE.Shape_StrokeProperty_get();
      if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
      return (DependencyProperty)Noesis.Extend.GetProxy(cPtr, false);
    }
  }

  public static DependencyProperty StrokeDashArrayProperty {
    get {
      IntPtr cPtr = NoesisGUI_PINVOKE.Shape_StrokeDashArrayProperty_get();
      if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
      return (DependencyProperty)Noesis.Extend.GetProxy(cPtr, false);
    }
  }

  public static DependencyProperty StrokeDashCapProperty {
    get {
      IntPtr cPtr = NoesisGUI_PINVOKE.Shape_StrokeDashCapProperty_get();
      if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
      return (DependencyProperty)Noesis.Extend.GetProxy(cPtr, false);
    }
  }

  public static DependencyProperty StrokeDashOffsetProperty {
    get {
      IntPtr cPtr = NoesisGUI_PINVOKE.Shape_StrokeDashOffsetProperty_get();
      if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
      return (DependencyProperty)Noesis.Extend.GetProxy(cPtr, false);
    }
  }

  public static DependencyProperty StrokeEndLineCapProperty {
    get {
      IntPtr cPtr = NoesisGUI_PINVOKE.Shape_StrokeEndLineCapProperty_get();
      if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
      return (DependencyProperty)Noesis.Extend.GetProxy(cPtr, false);
    }
  }

  public static DependencyProperty StrokeLineJoinProperty {
    get {
      IntPtr cPtr = NoesisGUI_PINVOKE.Shape_StrokeLineJoinProperty_get();
      if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
      return (DependencyProperty)Noesis.Extend.GetProxy(cPtr, false);
    }
  }

  public static DependencyProperty StrokeMiterLimitProperty {
    get {
      IntPtr cPtr = NoesisGUI_PINVOKE.Shape_StrokeMiterLimitProperty_get();
      if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
      return (DependencyProperty)Noesis.Extend.GetProxy(cPtr, false);
    }
  }

  public static DependencyProperty StrokeStartLineCapProperty {
    get {
      IntPtr cPtr = NoesisGUI_PINVOKE.Shape_StrokeStartLineCapProperty_get();
      if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
      return (DependencyProperty)Noesis.Extend.GetProxy(cPtr, false);
    }
  }

  public static DependencyProperty StrokeThicknessProperty {
    get {
      IntPtr cPtr = NoesisGUI_PINVOKE.Shape_StrokeThicknessProperty_get();
      if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
      return (DependencyProperty)Noesis.Extend.GetProxy(cPtr, false);
    }
  }

  public Brush Fill {
    set {
      NoesisGUI_PINVOKE.Shape_Fill_set(swigCPtr, Brush.getCPtr(value));
      if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
    } 
    get {
      IntPtr cPtr = NoesisGUI_PINVOKE.Shape_Fill_get(swigCPtr);
      if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
      return (Brush)Noesis.Extend.GetProxy(cPtr, false);
    }
  }

  public Stretch Stretch {
    set {
      NoesisGUI_PINVOKE.Shape_Stretch_set(swigCPtr, (int)value);
      if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
    } 
    get {
      Stretch ret = (Stretch)NoesisGUI_PINVOKE.Shape_Stretch_get(swigCPtr);
      if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
      return ret;
    } 
  }

  public Brush Stroke {
    set {
      NoesisGUI_PINVOKE.Shape_Stroke_set(swigCPtr, Brush.getCPtr(value));
      if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
    } 
    get {
      IntPtr cPtr = NoesisGUI_PINVOKE.Shape_Stroke_get(swigCPtr);
      if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
      return (Brush)Noesis.Extend.GetProxy(cPtr, false);
    }
  }

  public string StrokeDashArray {
    set {
      NoesisGUI_PINVOKE.Shape_StrokeDashArray_set(swigCPtr, value != null ? value : string.Empty);
      if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
    }
    get {
      IntPtr strPtr = NoesisGUI_PINVOKE.Shape_StrokeDashArray_get(swigCPtr);
      if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
      string str = Noesis.Extend.StringFromNativeUtf8(strPtr);
      return str;
    }
  }

  public PenLineCap StrokeDashCap {
    set {
      NoesisGUI_PINVOKE.Shape_StrokeDashCap_set(swigCPtr, (int)value);
      if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
    } 
    get {
      PenLineCap ret = (PenLineCap)NoesisGUI_PINVOKE.Shape_StrokeDashCap_get(swigCPtr);
      if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
      return ret;
    } 
  }

  public float StrokeDashOffset {
    set {
      NoesisGUI_PINVOKE.Shape_StrokeDashOffset_set(swigCPtr, value);
      if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
    } 
    get {
      float ret = NoesisGUI_PINVOKE.Shape_StrokeDashOffset_get(swigCPtr);
      if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
      return ret;
    } 
  }

  public PenLineCap StrokeEndLineCap {
    set {
      NoesisGUI_PINVOKE.Shape_StrokeEndLineCap_set(swigCPtr, (int)value);
      if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
    } 
    get {
      PenLineCap ret = (PenLineCap)NoesisGUI_PINVOKE.Shape_StrokeEndLineCap_get(swigCPtr);
      if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
      return ret;
    } 
  }

  public PenLineJoin StrokeLineJoin {
    set {
      NoesisGUI_PINVOKE.Shape_StrokeLineJoin_set(swigCPtr, (int)value);
      if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
    } 
    get {
      PenLineJoin ret = (PenLineJoin)NoesisGUI_PINVOKE.Shape_StrokeLineJoin_get(swigCPtr);
      if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
      return ret;
    } 
  }

  public float StrokeMiterLimit {
    set {
      NoesisGUI_PINVOKE.Shape_StrokeMiterLimit_set(swigCPtr, value);
      if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
    } 
    get {
      float ret = NoesisGUI_PINVOKE.Shape_StrokeMiterLimit_get(swigCPtr);
      if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
      return ret;
    } 
  }

  public PenLineCap StrokeStartLineCap {
    set {
      NoesisGUI_PINVOKE.Shape_StrokeStartLineCap_set(swigCPtr, (int)value);
      if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
    } 
    get {
      PenLineCap ret = (PenLineCap)NoesisGUI_PINVOKE.Shape_StrokeStartLineCap_get(swigCPtr);
      if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
      return ret;
    } 
  }

  public float StrokeThickness {
    set {
      NoesisGUI_PINVOKE.Shape_StrokeThickness_set(swigCPtr, value);
      if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
    } 
    get {
      float ret = NoesisGUI_PINVOKE.Shape_StrokeThickness_get(swigCPtr);
      if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
      return ret;
    } 
  }

  new internal static IntPtr GetStaticType() {
    IntPtr ret = NoesisGUI_PINVOKE.Shape_GetStaticType();
    if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }


  internal new static IntPtr Extend(string typeName) {
    IntPtr nativeType = NoesisGUI_PINVOKE.Extend_Shape(Marshal.StringToHGlobalAnsi(typeName));
    if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
    return nativeType;
  }
}

}

