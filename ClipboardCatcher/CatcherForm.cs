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
                    #region Text
                    string text = (string)iData.GetData(DataFormats.UnicodeText);

                    //check baskets
                    var isBasketActive = (this.TextBasket != null && this.TextBasket.IsGathering);

                    if (isBasketActive)
                    {
                        //Add to basket
                        this.TextBasket.Push(this, text);
                    }
                    else
                    {
                        //Fire event
                        this.TextCopied.Invoke(this, text);
                    } 
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

                    //check baskets
                    var isBasketActive = (this.FileBasket != null && this.FileBasket.IsGathering);

                    if (isBasketActive)
                    {
                        //Add to basket
                        this.FileBasket.Push(this, files);
                    }
                    else
                    {
                        //Fire event
                        this.FilesCopied.Invoke(this, files);
                    } 

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

        #region publics

        public void OpenBasket()
        {
            this.FileBasket.IsGathering = true;
            this.TextBasket.IsGathering = true;
        }

        public void CloseBasket()
        {
            this.FileBasket.IsGathering = false;
            this.TextBasket.IsGathering = false;
        }

        public void CopyBasket()
        {
            //this.FileBasket.CopyBasket();
            this.TextBasket.CopyBasket();
        }

        public void DeleteBasket()
        {
            this.FileBasket.CopyBasket();
            this.TextBasket.CopyBasket();
        }

        #endregion

        #region Helpers

        private void Init()
        {
            this.FileBasket = new Basket<string[]>();

            this.TextBasket = new Basket<string>();

            this.FileBasket.FillBasketEvent += FileBasket_FillHandler;
            this.FileBasket.EmptyBasketEvent += FileBasket_EmptyHandler;

            this.TextBasket.FillBasketEvent += TextBasket_FillHandler;
            this.TextBasket.EmptyBasketEvent += TextBasket_EmptyHandler;
        }

        private void TextBasket_EmptyHandler(object sender, EventArgs e)
        {
            if (this.TextBasket == null || this.TextBasket.Items == null || this.TextBasket.Items.Count == 0) return;

            var contents = this.TextBasket.Items.Aggregate((x, y) => x + y);

            Clipboard.SetText(contents, TextDataFormat.UnicodeText);

            //SendKeys.Send("^V");
        }

        private void TextBasket_FillHandler(object sender, EventArgs e)
        {
            //SendKeys.Send("^C");
        }

        private void FileBasket_EmptyHandler(object sender, EventArgs e)
        {
            if (this.FileBasket == null || this.FileBasket.Items == null || this.FileBasket.Items.Count == 0) return;

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

            //SendKeys.Send("^V");
        }

        private string[] MergeArrays(string[] x, string[] y)
        {
            if (x == null || y == null) return null;

            var xAsList = x.ToList();
            xAsList.AddRange(y);
            return xAsList.ToArray();
        }

        private void FileBasket_FillHandler(object sender, EventArgs e)
        {
            //SendKeys.Send("^C");
        }

        #endregion
    }
}
    