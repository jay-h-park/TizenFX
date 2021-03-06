/*
 * Copyright(c) 2019 Samsung Electronics Co., Ltd.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 *
 */

using System;
using Tizen.NUI.Binding;
using System.ComponentModel;

namespace Tizen.NUI
{

    /// <summary>
    /// The Color class.
    /// </summary>
    [Tizen.NUI.Binding.TypeConverter(typeof(ColorTypeConverter))]
    public class Color : Disposable, ICloneable
    {
        /// <summary>
        /// Gets the black colored Color class.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly Color Black = new Color(0.0f, 0.0f, 0.0f, 1.0f);

        /// <summary>
        /// Gets the white colored Color class.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly Color White = new Color(1.0f, 1.0f, 1.0f, 1.0f);

        /// <summary>
        /// Gets the red colored Color class.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly Color Red = new Color(1.0f, 0.0f, 0.0f, 1.0f);

        /// <summary>
        /// Gets the green colored Color class.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly Color Green = new Color(0.0f, 1.0f, 0.0f, 1.0f);

        /// <summary>
        /// Gets the blue colored Color class.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly Color Blue = new Color(0.0f, 0.0f, 1.0f, 1.0f);

        /// <summary>
        /// Gets the yellow colored Color class.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly Color Yellow = new Color(1.0f, 1.0f, 0.0f, 1.0f);

        /// <summary>
        /// Gets the magenta colored Color class.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly Color Magenta = new Color(1.0f, 0.0f, 1.0f, 1.0f);

        /// <summary>
        /// Gets the cyan colored Color class.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly Color Cyan = new Color(0.0f, 1.0f, 1.0f, 1.0f);

        /// <summary>
        /// Gets the  transparent colored Color class.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly Color Transparent = new Color(0.0f, 0.0f, 0.0f, 0.0f);

        private readonly bool hashDummy;

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public Color() : this(Interop.Vector4.NewVector4(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }


        /// <summary>
        /// The constructor.
        /// </summary>
        /// <param name="r">The red component.</param>
        /// <param name="g">The green component.</param>
        /// <param name="b">The blue component.</param>
        /// <param name="a">The alpha component.</param>
        /// <since_tizen> 3 </since_tizen>
        public Color(float r, float g, float b, float a) : this(Interop.Vector4.NewVector4(ValueCheck(r), ValueCheck(g), ValueCheck(b), ValueCheck(a)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// The conversion constructor from an array of four floats.
        /// </summary>
        /// <param name="array">array Array of R,G,B,A.</param>
        /// <since_tizen> 3 </since_tizen>
        public Color(float[] array) : this(Interop.Vector4.NewVector4(ValueCheck(array)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// The conversion constructor from an hexcode of four floats.
        /// </summary>
        /// <param name="hexColor">Hex color code</param>
        /// <exception cref="ArgumentNullException">This exception is thrown when hexColor is null.</exception>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Color(string hexColor) : this(Interop.Vector4.NewVector4(), true)
        {
            try
            {
                if (null == hexColor)
                {
                    throw new ArgumentNullException(nameof(hexColor));
                }
                hexColor = hexColor.Replace("#", "");

                R = ((float)Convert.ToInt32(hexColor.Substring(0, 2), 16)) / 255.0f;
                G = ((float)Convert.ToInt32(hexColor.Substring(2, 2), 16)) / 255.0f;
                B = ((float)Convert.ToInt32(hexColor.Substring(4, 2), 16)) / 255.0f;
                A = hexColor.Length > 6 ? ((float)Convert.ToInt32(hexColor.Substring(6, 2), 16)) / 255.0f : 1.0f;
            }
            catch
            {
                throw new global::System.ArgumentException("Please check your hex code");
            }
        }

        /// <summary>
        /// The conversion constructor from an System.Drawing.Color instance.
        /// </summary>
        /// <param name="color">System.Drawing.Color instance</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Color(global::System.Drawing.Color color) : this(Interop.Vector4.NewVector4(), true)
        {
            R = color.R / 255.0f;
            G = color.G / 255.0f;
            B = color.B / 255.0f;
            A = color.A / 255.0f;
        }

        /// <summary>
        /// The copy constructor.
        /// </summary>
        /// <param name="other">The copy target.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Color(Color other) : this((float)other?.R, (float)other.G, (float)other.B, (float)other.A)
        {
        }

        internal Color(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
            hashDummy = false;
        }

        internal Color(ColorChangedCallback cb, float r, float g, float b, float a) : this(Interop.Vector4.NewVector4(ValueCheck(r), ValueCheck(g), ValueCheck(b), ValueCheck(a)), true)
        {
            callback = cb;
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal Color(ColorChangedCallback cb, Color other) : this(cb, other.R, other.G, other.B, other.A)
        {
        }

        internal delegate void ColorChangedCallback(float r, float g, float b, float a);
        private ColorChangedCallback callback = null;

        /// <summary>
        /// The red component.
        /// </summary>
        /// <remarks>
        /// The setter is deprecated in API8 and will be removed in API10. Please use new Color(...) constructor.
        /// </remarks>
        /// <code>
        /// // DO NOT use like the followings!
        /// Color color = new Color();
        /// color.R = 0.1f; 
        /// // Please USE like this
        /// float r = 0.1f, g = 0.5f, b = 0.9f, a = 1.0f;
        /// Color color = new Color(r, g, b, a);
        /// </code>
        /// <since_tizen> 3 </since_tizen>
        public float R
        {
            set
            {
                Tizen.Log.Fatal("NUI", "Please do not use this setter, Deprecated in API8, will be removed in API10. please use new Color(...) constructor");
                Interop.Vector4.RSet(SwigCPtr, ValueCheck(value));
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

                callback?.Invoke(R, G, B, A);
            }
            get
            {
                float ret = Interop.Vector4.RGet(SwigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
                return ret;
            }
        }

        /// <summary>
        /// The green component.
        /// </summary>
        /// <remarks>
        /// The setter is deprecated in API8 and will be removed in API10. Please use new Color(...) constructor.
        /// </remarks>
        /// <code>
        /// // DO NOT use like the followings!
        /// Color color = new Color();
        /// color.G = 0.5f; 
        /// // Please USE like this
        /// float r = 0.1f, g = 0.5f, b = 0.9f, a = 1.0f;
        /// Color color = new Color(r, g, b, a);
        /// </code>
        /// <since_tizen> 3 </since_tizen>
        public float G
        {
            set
            {
                Tizen.Log.Fatal("NUI", "Please do not use this setter, Deprecated in API8, will be removed in API10. please use new Color(...) constructor");
                Interop.Vector4.GSet(SwigCPtr, ValueCheck(value));
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

                callback?.Invoke(R, G, B, A);
            }
            get
            {
                float ret = Interop.Vector4.GGet(SwigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
                return ret;
            }
        }

        /// <summary>
        /// The blue component.
        /// </summary>
        /// <remarks>
        /// The setter is deprecated in API8 and will be removed in API10. Please use new Color(...) constructor.
        /// </remarks>
        /// <code>
        /// // DO NOT use like the followings!
        /// Color color = new Color();
        /// color.B = 0.9f; 
        /// // Please USE like this
        /// float r = 0.1f, g = 0.5f, b = 0.9f, a = 1.0f;
        /// Color color = new Color(r, g, b, a);
        /// </code>
        /// <since_tizen> 3 </since_tizen>
        public float B
        {
            set
            {
                Tizen.Log.Fatal("NUI", "Please do not use this setter, Deprecated in API8, will be removed in API10. please use new Color(...) constructor");
                Interop.Vector4.BSet(SwigCPtr, ValueCheck(value));
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

                callback?.Invoke(R, G, B, A);
            }
            get
            {
                float ret = Interop.Vector4.BGet(SwigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
                return ret;
            }
        }

        /// <summary>
        /// The alpha component.
        /// </summary>
        /// <remarks>
        /// The setter is deprecated in API8 and will be removed in API10. Please use new Color(...) constructor.
        /// </remarks>
        /// <code>
        /// // DO NOT use like the followings!
        /// Color color = new Color();
        /// color.A = 1.0f; 
        /// // Please USE like this
        /// float r = 0.1f, g = 0.5f, b = 0.9f, a = 1.0f;
        /// Color color = new Color(r, g, b, a);
        /// </code>
        /// <since_tizen> 3 </since_tizen>
        public float A
        {
            set
            {
                Tizen.Log.Fatal("NUI", "Please do not use this setter, Deprecated in API8, will be removed in API10. please use new Color(...) constructor");
                Interop.Vector4.ASet(SwigCPtr, ValueCheck(value));
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

                callback?.Invoke(R, G, B, A);
            }
            get
            {
                float ret = Interop.Vector4.AGet(SwigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
                return ret;
            }
        }

        /// <summary>
        /// The array subscript operator overload.
        /// </summary>
        /// <param name="index">The subscript index.</param>
        /// <returns>The float at the given index.</returns>
        /// <since_tizen> 3 </since_tizen>
        public float this[uint index]
        {
            get
            {
                return ValueOfIndex(index);
            }
        }

        /// <summary>
        /// Converts the Color class to Vector4 class implicitly.
        /// </summary>
        /// <param name="color">A color to be converted to Vector4</param>
        /// <since_tizen> 3 </since_tizen>
        public static implicit operator Vector4(Color color)
        {
            return new Vector4((float)color?.R, (float)color.G, (float)color.B, (float)color.A);
        }

        /// <summary>
        /// Converts Vector4 class to Color class implicitly.
        /// </summary>
        /// <param name="vec">A Vector4 to be converted to color.</param>
        /// <since_tizen> 3 </since_tizen>
        public static implicit operator Color(Vector4 vec)
        {
            return new Color((float)vec?.R, (float)vec.G, (float)vec.B, (float)vec.A);
        }

        /// <summary>
        /// The addition operator.
        /// </summary>
        /// <param name="arg1">The first value.</param>
        /// <param name="arg2">The second value.</param>
        /// <returns>The color containing the result of the addition.</returns>
        /// <exception cref="ArgumentNullException"> Thrown when arg1 is null. </exception>
        /// <since_tizen> 3 </since_tizen>
        public static Color operator +(Color arg1, Color arg2)
        {
            if (null == arg1)
            {
                throw new ArgumentNullException(nameof(arg1));
            }
            Color result = arg1.Add(arg2);
            return ValueCheck(result);
        }

        /// <summary>
        /// The subtraction operator.
        /// </summary>
        /// <param name="arg1">The first value.</param>
        /// <param name="arg2">The second value.</param>
        /// <returns>The color containing the result of the subtraction.</returns>
        /// <exception cref="ArgumentNullException"> Thrown when arg1 is null. </exception>
        /// <since_tizen> 3 </since_tizen>
        public static Color operator -(Color arg1, Color arg2)
        {
            if (null == arg1)
            {
                throw new ArgumentNullException(nameof(arg1));
            }
            Color result = arg1.Subtract(arg2);
            return ValueCheck(result);
        }

        /// <summary>
        /// The unary negation operator.
        /// </summary>
        /// <param name="arg1">The target value.</param>
        /// <returns>The color containg the negation.</returns>
        /// <exception cref="ArgumentNullException"> Thrown when arg1 is null. </exception>
        /// <since_tizen> 3 </since_tizen>
        public static Color operator -(Color arg1)
        {
            if (null == arg1)
            {
                throw new ArgumentNullException(nameof(arg1));
            }
            Color result = arg1.Subtract();
            return ValueCheck(result);
        }

        /// <summary>
        /// The multiplication operator.
        /// </summary>
        /// <param name="arg1">The first value.</param>
        /// <param name="arg2">The second value.</param>
        /// <returns>The color containing the result of the multiplication.</returns>
        /// <exception cref="ArgumentNullException"> Thrown when arg1 is null. </exception>
        /// <since_tizen> 3 </since_tizen>
        public static Color operator *(Color arg1, Color arg2)
        {
            if (null == arg1)
            {
                throw new ArgumentNullException(nameof(arg1));
            }
            Color result = arg1.Multiply(arg2);
            return ValueCheck(result);
        }

        /// <summary>
        /// The multiplication operator.
        /// </summary>
        /// <param name="arg1">The first value.</param>
        /// <param name="arg2">The second value.</param>
        /// <returns>The color containing the result of the multiplication.</returns>
        /// <exception cref="ArgumentNullException"> Thrown when arg1 is null. </exception>
        /// <since_tizen> 3 </since_tizen>
        public static Color operator *(Color arg1, float arg2)
        {
            if (null == arg1)
            {
                throw new ArgumentNullException(nameof(arg1));
            }
            Color result = arg1.Multiply(arg2);
            return ValueCheck(result);
        }

        /// <summary>
        /// The division operator.
        /// </summary>
        /// <param name="arg1">The first value.</param>
        /// <param name="arg2">The second value.</param>
        /// <returns>The color containing the result of the division.</returns>
        /// <exception cref="ArgumentNullException"> Thrown when arg1 is null. </exception>
        /// <since_tizen> 3 </since_tizen>
        public static Color operator /(Color arg1, Color arg2)
        {
            if (null == arg1)
            {
                throw new ArgumentNullException(nameof(arg1));
            }
            Color result = arg1.Divide(arg2);
            return ValueCheck(result);
        }

        /// <summary>
        /// The division operator.
        /// </summary>
        /// <param name="arg1">The first value.</param>
        /// <param name="arg2">The second value.</param>
        /// <returns>The color containing the result of the division.</returns>
        /// <exception cref="ArgumentNullException"> Thrown when arg1 is null. </exception>
        /// <since_tizen> 3 </since_tizen>
        public static Color operator /(Color arg1, float arg2)
        {
            if (null == arg1)
            {
                throw new ArgumentNullException(nameof(arg1));
            }
            Color result = arg1.Divide(arg2);
            return ValueCheck(result);
        }

        /// <summary>
        /// Checks if two color classes are same.
        /// </summary>
        /// <param name="rhs">A color to be compared.</param>
        /// <returns>If two colors are are same, then true.</returns>
        /// <since_tizen> 3 </since_tizen>
        public bool EqualTo(Color rhs)
        {
            bool ret = Interop.Vector4.EqualTo(SwigCPtr, Color.getCPtr(rhs));

            if (rhs == null) return false;

            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Checks if two color classes are different.
        /// </summary>
        /// <param name="rhs">A color to be compared.</param>
        /// <returns>If two colors are are different, then true.</returns>
        /// <since_tizen> 3 </since_tizen>
        public bool NotEqualTo(Color rhs)
        {
            bool ret = Interop.Vector4.NotEqualTo(SwigCPtr, Color.getCPtr(rhs));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public object Clone() => new Color(this);

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(Color obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.SwigCPtr;
        }

        internal static Color GetColorFromPtr(global::System.IntPtr cPtr)
        {
            Color ret = new Color(cPtr, false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal static Color ValueCheck(Color color)
        {
            float r = color.R;
            float g = color.G;
            float b = color.B;
            float a = color.A;

            if (IsInvalidValue(ref r) | IsInvalidValue(ref g) | IsInvalidValue(ref b) | IsInvalidValue(ref a))
            {
                NUILog.Error($"The value of Result is invalid! Should be between [0, 1]. Color is {color.R}, {color.G}, {color.B}, {color.A}");
            }
            color = new Color(r, g, b, a);
            return color;
        }

        internal static float ValueCheck(float value)
        {
            float refValue = value;
            if (IsInvalidValue(ref refValue))
            {
                NUILog.Error($"The value of Result is invalid! Should be between [0, 1]. float value is {value}");
            }
            return refValue;
        }

        internal static float[] ValueCheck(float[] arr)
        {
            if (null == arr)
            {
                throw new ArgumentNullException(nameof(arr));
            }

            for (int i = 0; i < arr.Length; i++)
            {
                float refValue = arr[i];
                if (IsInvalidValue(ref refValue))
                {
                    NUILog.Error($"The value of Result is invalid! Should be between [0, 1]. arr[] is {arr[i]}");
                    arr[i] = refValue;
                }
            }
            return arr;
        }

        private static bool IsInvalidValue(ref float value)
        {
            if (value < 0.0f)
            {
                value = 0.0f;
                return true;
            }
            else if (value > 1.0f)
            {
                value = 1.0f;
                return true;
            }
            return false;
        }

        /// This will not be public opened.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.Vector4.DeleteVector4(swigCPtr);
        }

        private Color Add(Color rhs)
        {
            Color ret = new Color(Interop.Vector4.Add(SwigCPtr, Color.getCPtr(rhs)), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private Color AddAssign(Vector4 rhs)
        {
            Color ret = new Color(Interop.Vector4.AddAssign(SwigCPtr, Color.getCPtr(rhs)), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private Color Subtract(Color rhs)
        {
            Color ret = new Color(Interop.Vector4.Subtract(SwigCPtr, Color.getCPtr(rhs)), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private Color SubtractAssign(Color rhs)
        {
            Color ret = new Color(Interop.Vector4.SubtractAssign(SwigCPtr, Color.getCPtr(rhs)), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private Color Multiply(Color rhs)
        {
            Color ret = new Color(Interop.Vector4.Multiply(SwigCPtr, Color.getCPtr(rhs)), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private Color Multiply(float rhs)
        {
            Color ret = new Color(Interop.Vector4.Multiply(SwigCPtr, rhs), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private Color MultiplyAssign(Color rhs)
        {
            Color ret = new Color(Interop.Vector4.MultiplyAssign(SwigCPtr, Color.getCPtr(rhs)), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private Color MultiplyAssign(float rhs)
        {
            Color ret = new Color(Interop.Vector4.MultiplyAssign(SwigCPtr, rhs), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private Color Divide(Vector4 rhs)
        {
            Color ret = new Color(Interop.Vector4.Divide(SwigCPtr, Color.getCPtr(rhs)), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private Color Divide(float rhs)
        {
            Color ret = new Color(Interop.Vector4.Divide(SwigCPtr, rhs), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private Color DivideAssign(Color rhs)
        {
            Color ret = new Color(Interop.Vector4.DivideAssign(SwigCPtr, Color.getCPtr(rhs)), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private Color DivideAssign(float rhs)
        {
            Color ret = new Color(Interop.Vector4.DivideAssign(SwigCPtr, rhs), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private Color Subtract()
        {
            Color ret = new Color(Interop.Vector4.Subtract(SwigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private static bool EqualsColorValue(float f1, float f2)
        {
            float EPS = (float)Math.Abs(f1 * .00001);
            if (Math.Abs(f1 - f2) <= EPS)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static bool EqualsColor(Color c1, Color c2)
        {
            return EqualsColorValue(c1.R, c2.R) && EqualsColorValue(c1.G, c2.G)
                && EqualsColorValue(c1.B, c2.B) && EqualsColorValue(c1.A, c2.A);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns>true if the specified object is equal to the current object; otherwise, false.</returns>
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(System.Object obj)
        {
            Color color = obj as Color;
            bool equal = false;
            if (color == null)
            {
                return equal;
            }

            if (EqualsColor(this, color))
            {
                equal = true;
            }
            return equal;
        }

        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode()
        {
            return hashDummy.GetHashCode();
        }

        private float ValueOfIndex(uint index)
        {
            float ret = Interop.Vector4.ValueOfIndex(SwigCPtr, index);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

    }

}


