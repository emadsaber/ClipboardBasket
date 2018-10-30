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

                    string text = (string)iData.GetData(DataFormats.UnicodeText);

                    //check baskets
                    var isBasketActive = (this.TextBasket != null && this.TextBasket.IsGathering);

                    if (isBasketActive)
                    {
                        //Add to basket
                        this.TextBasket?.Items.Add(text);
                        this.TextBasket.IsGathering = false;
                    }
                    else
                    {
                        //Fire event
                        this.TextCopied.Invoke(this, text);
                    }
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

                    //check baskets
                    var isBasketActive = (this.FileBasket != null && this.FileBasket.IsGathering);

                    if (isBasketActive)
                    {
                        //Add to basket
                        this.FileBasket?.Items.Add(files);
                        this.FileBasket.IsGathering = false;
                    }
                    else
                    {
                        //Fire event
                        this.FilesCopied.Invoke(this, files);
                    }
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
            this.FileBasket = new Basket<string[]>(Keys.E, HotKey.KeyModifiers.Control, Keys.E, HotKey.KeyModifiers.Alt, Keys.E, HotKey.KeyModifiers.Shift);
            this.TextBasket = new Basket<string>(Keys.NumPad0, HotKey.KeyModifiers.Control, Keys.Q, HotKey.KeyModifiers.Alt, Keys.Q, HotKey.KeyModifiers.Shift);

            this.FileBasket.FillHotKeyPressed += FileBasket_FillHotKeyPressed;
            this.FileBasket.EmptyHotKeyPressed += FileBasket_EmptyHotKeyPressed;

            this.TextBasket.FillHotKeyPressed += TextBasket_FillHotKeyPressed;
            this.TextBasket.EmptyHotKeyPressed += TextBasket_EmptyHotKeyPressed;

            //this.FileBasket.UpdateEvents();
            //this.TextBasket.UpdateEvents();
        }

        private void TextBasket_EmptyHotKeyPressed(object sender, EventArgs e)
        {
            if (this.TextBasket == null || this.TextBasket.Items == null) return;

            var contents = this.TextBasket.Items.Aggregate((x, y) => x + y);

            Clipboard.SetText(contents, TextDataFormat.UnicodeText);

            //SendKeys.Send("^V");
        }

        private void TextBasket_FillHotKeyPressed(object sender, EventArgs e)
        {
            this.TextBasket.IsGathering = true;
            //SendKeys.Send("^C");
        }

        private void FileBasket_EmptyHotKeyPressed(object sender, EventArgs e)
        {
            if (this.TextBasket == null || this.TextBasket.Items == null) return;

            var contents = this.FileBasket.Items.Aggregate((x, y) =>
            {
                return x == null && y != null ? y
                : x != null && y == null ? x
                : x == null && y == null ? new string[] { }
                : MergeArrays(x, y);
            });

            var collection = new StringCollection();
            collection.AddRange(contents);
            Clipboard.SetFileDropList(collection);

            SendKeys.Send("^V");
        }

        private string[] MergeArrays(string[] x, string[] y)
        {
            if (x == null || y == null) return null;

            var xAsList = x.ToList();
            xAsList.AddRange(y);
            return xAsList.ToArray();
        }

        private void FileBasket_FillHotKeyPressed(object sender, EventArgs e)
        {
            this.FileBasket.IsGathering = true;
            SendKeys.Send("^C");
        }

        #endregion
    }
}
