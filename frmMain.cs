﻿using ClipboardCatcher;
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
        private void tsViewBasket_Click(object sender, EventArgs e)
        {
            ViewBasket();
        }
        private void tsAbout_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Made by Emad Saber: emadsaber89@gmail.com");
        }
        private void tsExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void notifier_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ViewBasket();
        }
        private void tsStatistics_Click(object sender, EventArgs e)
        {
            var stats = GetStatistics();
            if (string.IsNullOrEmpty(stats))
            {
                MessageBox.Show("Failed to get statistics", "Statistics", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            MessageBox.Show(stats, "Statistics", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void txtSearch_Enter(object sender, EventArgs e)
        {
            if (txtSearch.Text == Constants.UI.SearchPlaceHolder)
            {
                txtSearch.Text = "";
            }
        }
        private void txtSearch_Leave(object sender, EventArgs e)
        {
            if (txtSearch.Text == "")
            {
                txtSearch.Text = Constants.UI.SearchPlaceHolder;
            }

        }
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (txtSearch.Text == Constants.UI.SearchPlaceHolder) return;
            if (txtSearch.Text == "") { RefreshItems(); return; }
            SearchText(txtSearch.Text);
        }
        #endregion

        #region helpers
        private void RefreshItems(List<ClipboardItem> items = null)
        {
            var allItems = items == null ? ClipBoardDBUnity.ClipBoardItems.GetAll().Reverse().ToList() : items;
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
            if(! chkDisableNotifications.Checked)
                notifier.ShowBalloonTip(3000, "Clipboard Basket", status, ToolTipIcon.Info);
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
        private void ViewBasket()
        {
            this.WindowState = FormWindowState.Normal;
            this.Show();
            this.BringToFront();
        }
        private string GetStatistics()
        {
            try
            {
                var stats = new StringBuilder();
                var allItems = ClipBoardDBUnity.ClipBoardItems.GetAll();
                stats.AppendLine($"All Basket Items: {allItems.Count()}");
                stats.AppendLine();
                stats.AppendLine($"Texts In Basket: {allItems.Count(x => x.Type == ItemType.Text)}");
                stats.AppendLine();
                stats.AppendLine($"Images In Basket: {allItems.Count(x => x.Type == ItemType.Bitmap)}");
                stats.AppendLine();

                return stats.ToString();
            }
            catch
            {
                return null;
            }
        }
        private void SearchText(string text)
        {
            var items = ClipBoardDBUnity.ClipBoardItems.Find(text).ToList();
            RefreshItems(items);
        }
        #endregion
        
    }
}
