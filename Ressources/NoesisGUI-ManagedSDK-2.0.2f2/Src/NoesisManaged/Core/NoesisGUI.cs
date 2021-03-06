﻿using System;
using System.Runtime.InteropServices;

namespace Noesis
{
    public static class GUI
    {
        /// <summary>
        /// Returns the build version, for example "1.2.6f5".
        /// </summary>
        public static string GetBuildVersion()
        {
            IntPtr version = Noesis_GetBuildVersion();
            return Noesis.Extend.StringFromNativeUtf8(version);
        }

        private static bool _initialized = false;

        /// <summary>
        /// Initializes NoesisGUI.
        /// </summary>
        public static void Init()
        {
            if (!_initialized)
            {
                _initialized = true;

                NoesisGUI_PINVOKE.Init();
                Error.RegisterCallback();
                Extend.RegisterCallbacks();

                Noesis_Init_();

                Extend.Init();
                SoftwareKeyboard = new SoftwareKeyboard();
                Noesis_SetSoftwareKeyboardCallbacks_(_showSoftwareKeyboard, _hideSoftwareKeyboard);
                Noesis_SetUpdateCursorCallback(_updateCursor);
            }
        }

        /// <summary>
        /// Shuts down NoesisGUI library.
        /// </summary>
        public static void Shutdown()
        {
            Noesis_SetUpdateCursorCallback_(null);
            Noesis_SetSoftwareKeyboardCallbacks_(null, null);
            Extend.Shutdown();

            Noesis_Shutdown_();

            Extend.UnregisterCallbacks();
        }

        /// <summary>
        /// Sets a local directory where resources will be loaded.
        /// </summary>
        /// <param name="rootFolder">Path relative to current working directory.</param>
        public static void SetResourceProvider(string rootFolder)
        {
            Noesis_SetResourceProviderPath_(rootFolder);
        }

        /// <summary>
        /// Sets custom providers to load resources.
        /// </summary>
        public static void SetResourceProvider(Provider provider)
        {
            Noesis_SetResourceProviders_(
                Extend.GetInstanceHandle(provider.XamlProvider),
                Extend.GetInstanceHandle(provider.TextureProvider),
                Extend.GetInstanceHandle(provider.FontProvider));
        }

        /// <summary>
        /// Sets Theme resources.
        /// </summary>
        /// <param name="theme">Dictionary with default styles for all controls.</param>
        public static void SetTheme(ResourceDictionary theme)
        {
            Noesis_SetTheme_(Extend.GetInstanceHandle(theme));
        }

        /// <summary>
        /// Gets or sets the object that manages the visibility of software keyboard on touch devices.
        /// </summary>
        public static SoftwareKeyboard SoftwareKeyboard
        {
            get { return _softwareKeyboard; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("SoftwareKeyboard");
                }

                if (_softwareKeyboard != value)
                {
                    _softwareKeyboard = value;
                }
            }
        }

        /// <summary>
        /// Sets a callback that is called each time cursor icon needs to be updated.
        /// </summary>
        public delegate void UpdateCursorCallback(Cursor cursor);
        public static void SetUpdateCursorCallback(UpdateCursorCallback callback)
        {
            _updateCursorCallback = callback;
        }

        /// <summary>
        /// Loads a XAML resource.
        /// </summary>
        /// <param name="xaml">Path to the resource.</param>
        /// <returns>Root of the loaded XAML.</returns>
        public static object LoadXaml(string xaml)
        {
            IntPtr root = Noesis_LoadXaml_(xaml);
            return Extend.GetProxy(root, true);
        }

        /// <summary>
        /// Loads contents of the specified component from a XAML.
        /// Used from InitializeComponent; supplied component must match the type of the XAML root
        /// </summary>
        public static void LoadComponent(object component, string xaml)
        {
            Noesis_LoadComponent_(Extend.GetInstanceHandle(component), xaml);
        }

        /// <summary>
        /// Creates a View that manages a tree of UI elements.
        /// </summary>
        /// <param name="content">Root of the UI tree.</param>
        /// <returns>A new View for the specified content.</returns>
        public static View CreateView(FrameworkElement content)
        {
            return new View(content);
        }

        /// <summary>
        /// Unregisters the native types generated for managed extend classes, so they can be
        /// modified and updated without unloading NoesisGUI.
        /// </summary>
        public static void UnregisterNativeTypes()
        {
            Extend.UnregisterNativeTypes();
        }

        #region Software Keyboard
        delegate void ShowSoftwareKeyboardCallback(IntPtr focusedElement);
        private static ShowSoftwareKeyboardCallback _showSoftwareKeyboard = ShowSoftwareKeyboard;
        [MonoPInvokeCallback(typeof(ShowSoftwareKeyboardCallback))]
        private static void ShowSoftwareKeyboard(IntPtr focusedElement)
        {
            try
            {
                if (_initialized)
                {
                    UIElement element = Extend.GetProxy(focusedElement, false) as UIElement;
                    _softwareKeyboard.Show(element);
                }
            }
            catch (Exception e)
            {
                Noesis.Error.SetNativePendingError(e);
            }
        }

        delegate void HideSoftwareKeyboardCallback();
        static private HideSoftwareKeyboardCallback _hideSoftwareKeyboard = HideSoftwareKeyboard;
        [MonoPInvokeCallback(typeof(HideSoftwareKeyboardCallback))]
        private static void HideSoftwareKeyboard()
        {
            try
            {
                if (_initialized)
                {
                    _softwareKeyboard.Hide();
                }
            }
            catch (Exception e)
            {
                Error.SetNativePendingError(e);
            }
        }

        private static SoftwareKeyboard _softwareKeyboard;

        static void Noesis_SetSoftwareKeyboardCallbacks_(ShowSoftwareKeyboardCallback showCallback,
            HideSoftwareKeyboardCallback hideCallback)
        {
            Noesis_SetSoftwareKeyboardCallbacks(showCallback, hideCallback);
            Error.Check();
        }
        #endregion

        #region Cursor
        private static UpdateCursorCallback _updateCursorCallback;

        delegate void NoesisUpdateCursorCallback(int cursor);
        private static NoesisUpdateCursorCallback _updateCursor = UpdateCursor;
        [MonoPInvokeCallback(typeof(NoesisUpdateCursorCallback))]
        private static void UpdateCursor(int cursor)
        {
            try
            {
                if (_initialized && _updateCursorCallback != null)
                {
                    _updateCursorCallback((Cursor)cursor);
                }
            }
            catch (Exception e)
            {
                Error.SetNativePendingError(e);
            }
        }

        static void Noesis_SetUpdateCursorCallback_(NoesisUpdateCursorCallback callback)
        {
            Noesis_SetUpdateCursorCallback(callback);
            Error.Check();
        }
        #endregion

        #region Imports
        static void Noesis_Init_()
        {
            Noesis_Init();
            Error.Check();
        }

        static void Noesis_Shutdown_()
        {
            Noesis_Shutdown();
            Error.Check();
        }

        static void Noesis_SetResourceProviderPath_(string path)
        {
            Noesis_SetResourceProviderPath(path);
            Error.Check();
        }

        static void Noesis_SetResourceProviders_(HandleRef xamlProvider, HandleRef textureProvider,
            HandleRef fontProvider)
        {
            Noesis_SetResourceProviders(xamlProvider, textureProvider, fontProvider);
            Error.Check();
        }

        static void Noesis_SetTheme_(HandleRef theme)
        {
            Noesis_SetTheme(theme);
            Error.Check();
        }

        static IntPtr Noesis_LoadXaml_(string xaml)
        {
            IntPtr result = Noesis_LoadXaml(xaml);
            Error.Check();
            return result;
        }

        static void Noesis_LoadComponent_(HandleRef component, string xaml)
        {
            Noesis_LoadComponent(component, xaml);
            Error.Check();
        }

        [DllImport(Library.Name)]
        static extern IntPtr Noesis_GetBuildVersion();

        [DllImport(Library.Name)]
        static extern void Noesis_Init();

        [DllImport(Library.Name)]
        static extern void Noesis_Shutdown();

        [DllImport(Library.Name)]
        static extern void Noesis_SetResourceProviderPath(
            [MarshalAs(UnmanagedType.LPStr)] string path);

        [DllImport(Library.Name)]
        static extern void Noesis_SetResourceProviders(HandleRef xamlProvider,
            HandleRef textureProvider, HandleRef fontProvider);

        [DllImport(Library.Name)]
        static extern void Noesis_SetTheme(HandleRef theme);

        [DllImport(Library.Name)]
        static extern void Noesis_SetSoftwareKeyboardCallbacks(
            ShowSoftwareKeyboardCallback showCallback, HideSoftwareKeyboardCallback hideCallback);

        [DllImport(Library.Name)]
        static extern void Noesis_SetUpdateCursorCallback(NoesisUpdateCursorCallback callback);

        [DllImport(Library.Name)]
        static extern IntPtr Noesis_LoadXaml([MarshalAs(UnmanagedType.LPStr)] string xaml);

        [DllImport(Library.Name)]
        static extern void Noesis_LoadComponent(HandleRef component,
            [MarshalAs(UnmanagedType.LPStr)] string xaml);
        #endregion
    }

    public class Provider
    {
        public XamlProvider XamlProvider { get; set; }
        public TextureProvider TextureProvider { get; set; }
        public FontProvider FontProvider { get; set; }
    }
}
