using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClipboardCatcher
{
    public class HotKey : IMessageFilter
    {


        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, KeyModifiers fsModifiers, Keys vk);
        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);


        public enum KeyModifiers
        {
            None = 0,
            Alt = 1,
            Control = 2,
            Shift = 4,
            Windows = 8
        }

        private const int WM_HOTKEY = 0x0312;
        private const int id = 100;


        private IntPtr handle;
        public IntPtr Handle
        {
            get { return handle; }
            set { handle = value; }
        }

        private event EventHandler HotKeyPressed;

        public Keys Key { get; set; }
        public KeyModifiers Modifier { get; set; }

        public HotKey(Keys key, KeyModifiers modifier, EventHandler hotKeyPressed)
        {
            HotKeyPressed = hotKeyPressed;
        }

        public void Register()
        {
            RegisterHotKey(Key, Modifier);
            Application.AddMessageFilter(this);
        }

        ~HotKey()
        {
            Application.RemoveMessageFilter(this);
            UnregisterHotKey(handle, id);
        }

        public void RegisterHotKey(Keys key, KeyModifiers modifier)
        {
            if (key == Keys.None)
                return;

            bool isKeyRegisterd = RegisterHotKey(handle, id, modifier, key);
            if (!isKeyRegisterd)
                throw new ApplicationException("Hotkey allready in use");
        }

        public bool UnregisterHotKey()
        {
            return UnregisterHotKey(handle, id);
        }

        public bool PreFilterMessage(ref Message m)
        {
            switch (m.Msg)
            {
                case WM_HOTKEY:
                    HotKeyPressed(this, new EventArgs());
                    return true;
            }
            return false;
        }

    }
}
