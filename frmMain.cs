using ClipboardCatcher;
using ClipboardDB;
using ClipboardDB.Models;
using ClipboardDB.Models.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClipboardBasket
{
    public partial class frmMain : CatcherForm
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.TextCopied += Form1_TextCopied;
            this.ImageCopied += FrmMain_ImageCopied;
        }

        private void FrmMain_ImageCopied(object sender, Bitmap e)
        {
            
        }

        private void Form1_TextCopied(object sender, string e)
        {
            lstHistory.Items.Add(e);

            ClipBoardDBUnity.ClipBoardItems.Add(new ClipboardItem() { Id = new Guid(), TimeStamp = DateTime.Now, Type = ItemType.Text });
        }
    }
}
