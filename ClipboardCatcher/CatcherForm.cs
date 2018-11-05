using System;
using System.Collections.Generic;
using System.Collections.Specialized;
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

        #region Constructors

        public CatcherForm()
        {
            InitializeComponent();
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
                    #region Text
                    string text = (string)iData.GetData(DataFormats.UnicodeText);

                    //Fire event
                    this.TextCopied.Invoke(this, text);
                    #endregion
                }
                else if (iData.GetDataPresent(DataFormats.Bitmap))
                {
                    #region Image

                    Bitmap image = (Bitmap)iData.GetData(DataFormats.Bitmap);
                    //Fire event
                    this.ImageCopied.Invoke(this, image);

                    #endregion
                }
                else if (iData.GetDataPresent(DataFormats.FileDrop))
                {
                    #region Files

                    var files = (string[])iData.GetData(DataFormats.FileDrop);

                    //Fire event
                    this.FilesCopied.Invoke(this, files);
                    #endregion
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

    }
}
