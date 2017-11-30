using System;
using System.Collections.Generic;

namespace IntegrationSample
{
    class Program
    {
        static Noesis.View _view = null;
        static Noesis.Renderer _renderer = null;
        static bool _eventsAttached = false;

        static void Main(string[] args)
        {
            try
            {
                // Initialization
                GLUTWrapper.Init(800, 600, "NoesisGUI Integration Sample");

                Noesis.GUI.Init();
                Noesis.GUI.SetResourceProvider("Data");

                // Global theme
                {
                    var theme = (Noesis.ResourceDictionary)Noesis.GUI.LoadXaml("NoesisStyle.xaml");
                    Noesis.GUI.SetTheme(theme);
                }

                // Data loading
                {
                    var content = (Noesis.Grid)Noesis.GUI.LoadXaml("TextBox.xaml");
                    _view = Noesis.GUI.CreateView(content);
                    _renderer = _view.Renderer;
                    _renderer.InitGL(new Noesis.VGOptions());
                }

                // Attach to Application events
                GLUTWrapper.Close += OnClose;
                GLUTWrapper.Tick += OnTick;
                GLUTWrapper.PreRender += OnPreRender;
                GLUTWrapper.PostRender += OnPostRender;
                GLUTWrapper.Resize += OnResize;
                GLUTWrapper.MouseMove += OnMouseMove;
                GLUTWrapper.MouseDown += OnMouseDown;
                GLUTWrapper.MouseUp += OnMouseUp;
                GLUTWrapper.KeyDown += OnKeyDown;
                GLUTWrapper.KeyUp += OnKeyUp;
                _eventsAttached = true;

                // Main Loop
                GLUTWrapper.Run();
            }
            catch (Exception e)
            {
                LogError(e.Message);

                OnClose();
            }
        }

        static void LogError(string msg)
        {
            Console.WriteLine("ERROR!");
            Console.WriteLine("--------------------------------------------------------");
            Console.WriteLine(msg);
            Console.WriteLine("--------------------------------------------------------");
        }

        static void OnClose()
        {
            // Detach from Application events
            if (_eventsAttached)
            {
                _eventsAttached = false;
                GLUTWrapper.Close -= OnClose;
                GLUTWrapper.Tick -= OnTick;
                GLUTWrapper.PreRender -= OnPreRender;
                GLUTWrapper.PostRender -= OnPostRender;
                GLUTWrapper.Resize -= OnResize;
                GLUTWrapper.MouseMove -= OnMouseMove;
                GLUTWrapper.MouseDown -= OnMouseDown;
                GLUTWrapper.MouseUp -= OnMouseUp;
                GLUTWrapper.KeyDown -= OnKeyDown;
                GLUTWrapper.KeyUp -= OnKeyUp;
            }

            if (_renderer != null)
            {
                _renderer.Shutdown();
            }

            _view = null;

            try
            {
                Noesis.GUI.Shutdown();
            }
            catch (Exception e)
            {
                LogError(e.Message);
            }

            GLUTWrapper.Shutdown();
        }

        static void OnTick(double timeInSeconds)
        {
            _view.Update(timeInSeconds);
        }

        static void OnPreRender()
        {
            _renderer.UpdateRenderTree();

            if (_renderer.NeedsOffscreen())
            {
                _renderer.RenderOffscreen();
            }
        }

        static void OnPostRender()
        {
            _renderer.Render();
        }

        static void OnResize(int width, int height)
        {
            _view.SetSize(width, height);
        }

        static void OnMouseMove(int x, int y)
        {
            _view.MouseMove(x, y);
        }

        static void OnMouseDown(int x, int y, GLUTWrapper.MouseButton button)
        {
            _view.MouseDown(x, y, (Noesis.MouseButton)button);
        }

        static void OnMouseUp(int x, int y, GLUTWrapper.MouseButton button)
        {
            _view.MouseUp(x, y, (Noesis.MouseButton)button);
        }

        static void OnKeyDown(char key, GLUTWrapper.SpecialKey specialKey, GLUTWrapper.ModifierKey modifiers)
        {
            ProcessModifiers(modifiers);

            Noesis.Key noesisKey = GetNoesisKey(key, specialKey);
            if (noesisKey != Noesis.Key.None)
            {
                _view.KeyDown(noesisKey);
            }

            _view.Char(key);
        }

        static void OnKeyUp(char key, GLUTWrapper.SpecialKey specialKey, GLUTWrapper.ModifierKey modifiers)
        {
            Noesis.Key noesisKey = GetNoesisKey(key, specialKey);
            if (noesisKey != Noesis.Key.None)
            {
                _view.KeyUp(noesisKey);
            }

            ProcessModifiers(modifiers);
        }

        static Noesis.Key GetNoesisKey(char key, GLUTWrapper.SpecialKey specialKey)
        {
            switch (specialKey)
            {
                case GLUTWrapper.SpecialKey.F1: return Noesis.Key.F1;
                case GLUTWrapper.SpecialKey.F2: return Noesis.Key.F2;
                case GLUTWrapper.SpecialKey.F3: return Noesis.Key.F3;
                case GLUTWrapper.SpecialKey.F4: return Noesis.Key.F4;
                case GLUTWrapper.SpecialKey.F5: return Noesis.Key.F5;
                case GLUTWrapper.SpecialKey.F6: return Noesis.Key.F6;
                case GLUTWrapper.SpecialKey.F7: return Noesis.Key.F7;
                case GLUTWrapper.SpecialKey.F8: return Noesis.Key.F8;
                case GLUTWrapper.SpecialKey.F9: return Noesis.Key.F9;
                case GLUTWrapper.SpecialKey.F10: return Noesis.Key.F10;
                case GLUTWrapper.SpecialKey.F11: return Noesis.Key.F11;
                case GLUTWrapper.SpecialKey.F12: return Noesis.Key.F12;
                case GLUTWrapper.SpecialKey.PageUp: return Noesis.Key.Prior;
                case GLUTWrapper.SpecialKey.PageDown: return Noesis.Key.Next;
                case GLUTWrapper.SpecialKey.Home: return Noesis.Key.Home;
                case GLUTWrapper.SpecialKey.End: return Noesis.Key.End;
                case GLUTWrapper.SpecialKey.Insert: return Noesis.Key.Insert;
                case GLUTWrapper.SpecialKey.Left: return Noesis.Key.Left;
                case GLUTWrapper.SpecialKey.Right: return Noesis.Key.Right;
                case GLUTWrapper.SpecialKey.Up: return Noesis.Key.Up;
                case GLUTWrapper.SpecialKey.Down: return Noesis.Key.Down;
                default: break;
            }

            switch (key)
            {
                case '\n':
                case '\r': return Noesis.Key.Return;
                case '\t': return Noesis.Key.Tab;
                case '\b': return Noesis.Key.Back;
                case ' ': return Noesis.Key.Space;
                case (char)0x01: return Noesis.Key.A;
                case (char)0x03: return Noesis.Key.C;
                case (char)0x16: return Noesis.Key.V;
                case (char)0x18: return Noesis.Key.X;
                case (char)0x7F: return Noesis.Key.Delete;
                default: break;
            }

            if (key >= 'a' && key <= 'z')
            {
                return (Noesis.Key)((int)Noesis.Key.A + (int)key - 'a');
            }
            if (key >= 'A' && key <= 'Z')
            {
                return (Noesis.Key)((int)Noesis.Key.A + (int)key - 'A');
            }

            if (key >= '0' && key <= '9')
            {
                return (Noesis.Key)((int)Noesis.Key.D0 + (int)key - '0');
            }

            return Noesis.Key.None;
        }

        static void ProcessModifiers(GLUTWrapper.ModifierKey modifiers)
        {
            ProcessModifier(ref _isShiftDown, (modifiers & GLUTWrapper.ModifierKey.Shift) != 0, Noesis.Key.LeftShift);
            ProcessModifier(ref _isCtrlDown, (modifiers & GLUTWrapper.ModifierKey.Ctrl) != 0, Noesis.Key.LeftCtrl);
            ProcessModifier(ref _isAltDown, (modifiers & GLUTWrapper.ModifierKey.Alt) != 0, Noesis.Key.LeftAlt);
        }

        static void ProcessModifier(ref bool modifier, bool isDown, Noesis.Key modifierKey)
        {
            if (!modifier)
            {
                if (isDown)
                {
                    modifier = true;
                    _view.KeyDown(modifierKey);
                }
            }
            else
            {
                if (!isDown)
                {
                    modifier = false;
                    _view.KeyUp(modifierKey);
                }
            }
        }

        static bool _isShiftDown = false;
        static bool _isCtrlDown = false;
        static bool _isAltDown = false;
    }
}
