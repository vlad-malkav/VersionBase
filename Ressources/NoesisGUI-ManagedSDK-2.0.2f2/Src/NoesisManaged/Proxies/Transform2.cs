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

[StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
public struct Transform2 {

  private Point _r0;
  private Point _r1;
  private Point _r2;

  public Point this[uint i] {
    get {
      switch (i) {
        case 0: return this._r0;
        case 1: return this._r1;
        case 2: return this._r2;
        default: throw new IndexOutOfRangeException();
      }
    }
    set {
      switch (i) {
        case 0: this._r0 = value; break;
        case 1: this._r1 = value; break;
        case 2: this._r2 = value; break;
        default: throw new IndexOutOfRangeException();
      }
    }
  }

  public static Transform2 Identity {
    get { return new Transform2(1.0f, 0.0f, 0.0f, 1.0f, 0.0f, 0.0f); }
  }

  public Transform2(float m00, float m01, float m10, float m11, float m20, float m21) :
    this(new Point(m00, m01), new Point(m10, m11), new Point(m20, m21))
  {
  }

  public Transform2(Point v0, Point v1, Point v2) {
    this._r0 = v0;
    this._r1 = v1;
    this._r2 = v2;
  }

  public void RotateAt(float radians, float centerX, float centerY) {
    this = Transform2.PostTrans(this, -centerX, -centerY);
    this = Transform2.PostRot(this, radians);
    this = Transform2.PostTrans(this, centerX, centerY);
  }

  public void ScaleAt(float scaleX, float scaleY, float centerX, float centerY) {
    this = Transform2.PostTrans(this, -centerX, -centerY);
    this = Transform2.PostScale(this, scaleX, scaleY);
    this = Transform2.PostTrans(this, centerX, centerY);
  }

  public void Translate(float dx, float dy) {
    this = Transform2.PostTrans(this, dx, dy);
  }

  public static Transform2 operator*(Transform2 m, float f) {
    return new Transform2(m[0] * f, m[1] * f, m[2] * f);
  }

  public static Transform2 operator*(float f, Transform2 m) {
    return m * f;
  }

  public static Transform2 operator/(Transform2 m, float f) {
    if (f == 0.0f) { throw new DivideByZeroException(); }
    return new Transform2(m[0] / f, m[1] / f, m[2] / f);
  }

  public static Point operator*(Point v, Transform2 m) {
    return PointTransform(v, m);
  }

  public static Vector3 operator*(Vector3 v, Transform2 m) {
    return new Vector3(
      v[0] * m[0][0] + v[1] * m[1][0] + v[2] * m[2][0],
      v[0] * m[0][1] + v[1] * m[1][1] + v[2] * m[2][1],
      v[2]);
  }

  public static Transform2 operator*(Transform2 m0, Transform2 m1) {
    return new Transform2(
      new Point(
        m0[0][0] * m1[0][0] + m0[0][1] * m1[1][0],
        m0[0][0] * m1[0][1] + m0[0][1] * m1[1][1]),
      new Point(
        m0[1][0] * m1[0][0] + m0[1][1] * m1[1][0],
        m0[1][0] * m1[0][1] + m0[1][1] * m1[1][1]),
      new Point(
        m0[2][0] * m1[0][0] + m0[2][1] * m1[1][0] + m1[2][0],
        m0[2][0] * m1[0][1] + m0[2][1] * m1[1][1] + m1[2][1])
    );
  }

  public static bool operator==(Transform2 m0, Transform2 m1) {
    return m0[0] == m1[0] && m0[1] == m1[1] && m0[2] == m1[2];
  }

  public static bool operator!=(Transform2 m0, Transform2 m1) {
    return !(m0 == m1);
  }

  public override bool Equals(System.Object obj) {
    return obj is Transform2 && this == (Transform2)obj;
  }

  public bool Equals(Transform2 m) {
    return this == m;
  }

  public override int GetHashCode() {
    return (this[0].GetHashCode() ^ this[1].GetHashCode()) ^ this[2].GetHashCode();
  }

  public void SetUpper2x2(Matrix2 m) {
    this[0] = m[0];
    this[1] = m[1];
  }

  public Matrix2 GetUpper2x2() {
    return new Matrix2(this[0], this[1]);
  }

  public void SetTranslation(Point v) {
    this[2] = v;
  }

  public Point GetTranslation() {
    return this[2];
  }

  public static Transform2 Scale(float scaleX, float scaleY) {
    return new Transform2(scaleX, 0.0f, 0.0f, scaleY, 0.0f, 0.0f);
  }

  public static Transform2 Trans(float transX, float transY) {
    return new Transform2(1.0f, 0.0f, 0.0f, 1.0f, transX, transY);
  }

  public static Transform2 Rot(float radians) {
    float cs = (float)Math.Cos(radians);
    float sn = (float)Math.Sin(radians);
    return new Transform2(cs, sn, -sn, cs, 0.0f, 0.0f);
  }

  public static Transform2 ShearXY(float shear) {
    return new Transform2(1.0f, 0.0f, shear, 1.0f, 0.0f, 0.0f);
  }

  public static Transform2 ShearYX(float shear) {
    return new Transform2(1.0f, shear, 0.0f, 1.0f, 0.0f, 0.0f);
  }

  public static Transform2 Skew(float radiansX, float radiansY) {
    return new Transform2(1.0f, radiansY, radiansX, 1.0f, 0.0f, 0.0f);
  }

  public static Point PointTransform(Point v, Transform2 m) {
    return new Point(
      v[0] * m[0][0] + v[1] * m[1][0] + m[2][0],
      v[0] * m[0][1] + v[1] * m[1][1] + m[2][1]);
  }

  public static Point VectorTransform(Point v, Transform2 m) {
    return new Point(
      v[0] * m[0][0] + v[1] * m[1][0],
      v[0] * m[0][1] + v[1] * m[1][1]);
  }

  public static Transform2 Inverse(Transform2 m) {
    Matrix2 rotInv = Matrix2.Inverse(m.GetUpper2x2());
    Point trans = new Point(
      -m[2][0] * rotInv[0][0] - m[2][1] * rotInv[1][0],
      -m[2][0] * rotInv[0][1] - m[2][1] * rotInv[1][1]);
    return new Transform2(rotInv[0], rotInv[1], trans);
  }

  public static Transform2 PreScale(float scaleX, float scaleY, Transform2 m) {
    return new Transform2(
      m[0][0] * scaleX, m[0][1] * scaleX,
      m[1][0] * scaleY, m[1][1] * scaleY,
               m[2][0],          m[2][1]);
  }

  public static Transform2 PreTrans(float transX, float transY, Transform2 m) {
    return new Transform2(
                                            m[0][0],                                       m[0][1],
                                            m[1][0],                                       m[1][1],
      m[2][0] + m[0][0] * transX + m[1][0] * transY, m[2][1] + m[0][1] * transX + m[1][1] * transY);
  }

  public static Transform2 PreRot(float radians, Transform2 m) {
    float cs = (float)Math.Cos(radians);
    float sn = (float)Math.Sin(radians);
    return new Transform2(
      m[0][0] * cs + m[1][0] * sn, m[0][1] * cs + m[1][1] * sn,
      m[1][0] * cs - m[0][0] * sn, m[1][1] * cs - m[0][1] * sn,
                          m[2][0],                     m[2][1]);
  }

  public static Transform2 PreSkew(float radiansX, float radiansY, Transform2 m) {
    return new Transform2(
      m[0][0] + m[1][0] * radiansY, m[0][1] + m[1][1] * radiansY,
      m[1][0] + m[0][0] * radiansX, m[1][1] + m[0][1] * radiansX,
                           m[2][0],                      m[2][1]);
  }

  public static Transform2 PostScale(Transform2 m, float scaleX, float scaleY) {
    return new Transform2(
      m[0][0] * scaleX, m[0][1] * scaleY,
      m[1][0] * scaleX, m[1][1] * scaleY,
      m[2][0] * scaleX, m[2][1] * scaleY);
  }

  public static Transform2 PostTrans(Transform2 m, float transX, float transY) {
    return new Transform2(
               m[0][0],          m[0][1],
               m[1][0],          m[1][1],
      m[2][0] + transX, m[2][1] + transY);
  }

  public static Transform2 PostRot(Transform2 m, float radians) {
    float cs = (float)Math.Cos(radians);
    float sn = (float)Math.Sin(radians);
    return new Transform2(
      m[0][0] * cs - m[0][1] * sn, m[0][1] * cs + m[0][0] * sn,
      m[1][0] * cs - m[1][1] * sn, m[1][1] * cs + m[1][0] * sn,
      m[2][0] * cs - m[2][1] * sn, m[2][1] * cs + m[2][0] * sn);
  }

  public static Transform2 PostSkew(Transform2 m, float radiansX, float radiansY) {
    return new Transform2(
      m[0][0] + m[0][1] * radiansX, m[0][1] + m[0][0] * radiansY,
      m[1][0] + m[1][1] * radiansX, m[1][1] + m[1][0] * radiansY,
      m[2][0] + m[2][1] * radiansX, m[2][1] + m[2][0] * radiansY);
  }

  public static void Decompose(Transform2 t, out float scaleX, out float scaleY,
    out float shearXY, out float rot, out float transX, out float transY) {
    Matrix2.Decompose(t.GetUpper2x2(), out scaleX, out scaleY, out shearXY, out rot);
    transX = t[2][0];
    transY = t[2][1];
  }

  public static Transform2 Parse(string str) {
    Transform2 t;
    if (Transform2.TryParse(str, out t)) {
      return t;
    }
    throw new ArgumentException("Cannot create Transform2 from '" + str + "'");
  }

  public static bool TryParse(string str, out Transform2 output) {
    bool ret = NoesisGUI_PINVOKE.Transform2_TryParse(str != null ? str : string.Empty, out output);
    if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

}

}

