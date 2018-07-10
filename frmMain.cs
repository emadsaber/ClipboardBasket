using ClipboardCatcher;
using ClipboardDB;
using ClipboardDB.Models;
using ClipboardDB.Models.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClipboardBasket
{
    public partial class frmMain : CatcherForm
    {
        #region constructors
        public frmMain()
        {
            InitializeComponent();
        }

        #endregion

        #region Event Handlers
        private void Form1_Load(object sender, EventArgs e)
        {
            this.TextCopied += Form1_TextCopied;
            this.ImageCopied += FrmMain_ImageCopied;

            RefreshItems();

        }
        private void FrmMain_ImageCopied(object sender, Bitmap e)
        {
            ClipBoardDBUnity.ClipBoardItems.Add(new ClipboardItem()
            {
                Id = Guid.NewGuid(),
                TimeStamp = DateTime.Now,
                Type = ItemType.Bitmap,
                TextValue = "Image",
                ImageValue = GetImageBytes(e)
            });
            ShowStatus("New Item detected!");
            RefreshItems();
        }
        private void Form1_TextCopied(object sender, string e)
        {
            ClipBoardDBUnity.ClipBoardItems.Add(new ClipboardItem()
            {
                Id = Guid.NewGuid(),
                TimeStamp = DateTime.Now,
                Type = ItemType.Text,
                TextValue = e,
                ImageValue = null
            });
            ShowStatus("New Item detected!");
            RefreshItems();
        }
        private void lstHistory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstHistory.SelectedIndex < 0) return;
            if (lstHistory.SelectedValue == null) return;

            var value = Guid.Parse(lstHistory.SelectedValue.ToString()); 
            if (value == null) return;

            var selectedCBItem = ClipBoardDBUnity.ClipBoardItems.Get(value);
            if (selectedCBItem == null) return;

            if (selectedCBItem.Type == ItemType.Text)
            {
                rtbView.Visible = true;
                picView.Visible = false;
                rtbView.Text = selectedCBItem.TextValue;
            }
            else if(selectedCBItem.Type == ItemType.Bitmap)
            {
                rtbView.Visible = false;
                picView.Visible = true;
                picView.BackgroundImageLayout = ImageLayout.Center;
                picView.BackgroundImage = GetImage(selectedCBItem.ImageValue);
            }
        }
        private void btnCopy_Click(object sender, EventArgs e)
        {
            if (lstHistory.SelectedIndex == -1) return;
            if (lstHistory.SelectedValue == null) return;

            CopySelected();
        }
        private void lstHistory_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lstHistory.SelectedIndex == -1) return;
            if (lstHistory.SelectedValue == null) return;

            CopySelected();
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lstHistory.SelectedIndex == -1) return;
            if (lstHistory.SelectedValue == null) return;

            var value = Guid.Parse(lstHistory.SelectedValue.ToString());
            if (value == null) return;

            if (ClipBoardDBUnity.ClipBoardItems.Delete(value))
            {
                ShowStatus("Deleted Successfully");
                RefreshItems();
            }
        }
        private void btnDeleteAll_Click(object sender, EventArgs e)
        {
            var dlgResult = MessageBox.Show("Are you sure you want to delete all items. They can not be restored again?", "Confirm Clear History!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (dlgResult == DialogResult.No) return;

            if (ClipBoardDBUnity.ClipBoardItems.DeleteAll())
            {
                ShowStatus("All history deleted");
            }
            else
            {
                ShowStatus("Failed to delete all history");
            }
            RefreshItems();
        }
        #endregion

        #region helpers
        private void RefreshItems()
        {
            var allItems = ClipBoardDBUnity.ClipBoardItems.GetAll().Reverse().ToList();
            lstHistory.ValueMember = "Id";
            lstHistory.DisplayMember = "TextValue";
            lstHistory.DataSource = allItems;
        }
        private Image GetImage(byte[] bytes)
        {
            var fs = new MemoryStream(bytes);
            return Bitmap.FromStream(fs);
        }
        private byte[] GetImageBytes(Bitmap image)
        {
            ImageConverter conv = new ImageConverter();
            return (byte[])conv.ConvertTo(image, typeof(byte[]));
        }
        private void ShowStatus(string status)
        {
            lblStatus.Text = status;
        }
        private void CopySelected()
        {
            var value = Guid.Parse(lstHistory.SelectedValue.ToString());
            if (value == null) return;

            var selectedCBItem = ClipBoardDBUnity.ClipBoardItems.Get(value);
            if (selectedCBItem == null) return;

            if (selectedCBItem.Type == ItemType.Text)
            {
                Clipboard.SetText(selectedCBItem.TextValue, TextDataFormat.UnicodeText);
            }
            else if (selectedCBItem.Type == ItemType.Bitmap)
            {
                Clipboard.SetImage(GetImage(selectedCBItem.ImageValue));
            }
            if (ClipBoardDBUnity.ClipBoardItems.Delete(value))
            {
                if (ClipBoardDBUnity.ClipBoardItems.Delete(ClipBoardDBUnity.ClipBoardItems.GetLast()))
                {
                    ShowStatus("Copied Successfully");
                }
            }
            else
            {
                ShowStatus("Failed to copy item");
            }

            RefreshItems();
        }

        #endregion
        
    }
}
