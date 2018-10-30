using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClipboardCatcher
{
    public partial class CatcherForm : Form
    {
        #region Externs

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SetClipboardViewer(IntPtr hWndNewViewer);

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern bool ChangeClipboardChain(IntPtr hWndRemove, IntPtr hWndNewNext);

        private const int WM_DRAWCLIPBOARD = 0x0308;
        private IntPtr _clipboardViewerNext;

        #endregion
        
        #region Events

        public event EventHandler<string> TextCopied = new EventHandler<string>((x, y) => { return; });
        public event EventHandler<Bitmap> ImageCopied = new EventHandler<Bitmap>((x, y) => { return; });
        public event EventHandler<string[]> FilesCopied = new EventHandler<string[]>((x, y) => { return; });

        #endregion

        #region Properties

        public Basket<string> TextBasket { get; set; }
        public Basket<string[]> FileBasket { get; set; }

        #endregion

        #region Constructors

        public CatcherForm()
        {
            InitializeComponent();

            Init();
        }

        #endregion

        #region Methods

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == WM_DRAWCLIPBOARD)
            {
                IDataObject iData = Clipboard.GetDataObject();

                if (iData.GetDataPresent(DataFormats.Text))
                {
                    //this.IsB
                    string text = (string)iData.GetData(DataFormats.UnicodeText);
                    //Fire event
                    this.TextCopied.Invoke(this, text);
                }
                else if (iData.GetDataPresent(DataFormats.Bitmap))
                {
                    Bitmap image = (Bitmap)iData.GetData(DataFormats.Bitmap);
                    //Fire event
                    this.ImageCopied.Invoke(this, image);
                }
                else if (iData.GetDataPresent(DataFormats.FileDrop))
                {
                    var files = (string[])iData.GetData(DataFormats.FileDrop);
                    //Fire event
                    this.FilesCopied.Invoke(this, files);
                }
            }
        }
        private void CatcherForm_Load(object sender, EventArgs e)
        {
            this._clipboardViewerNext = SetClipboardViewer(this.Handle);
        }
        private void CatcherForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            ChangeClipboardChain(this.Handle, _clipboardViewerNext);
        }
        
        #endregion

        #region Helpers

        private void Init()
        {
            this.FileBasket = new Basket<string[]>(Keys.F1, HotKey.KeyModifiers.Control, Keys.F1, HotKey.KeyModifiers.Shift, Keys.F1, HotKey.KeyModifiers.Alt); 
            this.TextBasket = new Basket<string>(Keys.F2, HotKey.KeyModifiers.Control, Keys.F2, HotKey.KeyModifiers.Shift, Keys.F2, HotKey.KeyModifiers.Alt);
        }

        #endregion
    }
}
