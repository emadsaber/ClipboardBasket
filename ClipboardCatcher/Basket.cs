using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ClipboardCatcher
{
    public class Basket<T>
    {
        #region events

        public event EventHandler FillHotKeyPressed;
        public event EventHandler EmptyHotKeyPressed;
        public event EventHandler DeleteHotKeyPressed;

        #endregion

        #region props
        /// <summary>
        /// The current basket status (True = contains items, False = empty)
        /// </summary>
        public bool HasItems { get => this.Items == null ? false : this.Items.Count > 0; }
        /// <summary>
        /// Represents all items separated from each other one item per Fill operation
        /// </summary>
        public List<T> Items { get; set; }
        /// <summary>
        /// HotKey to empty the basket into one place
        /// </summary>
        public HotKey EmptyBasketHotKey { get; set; }
        /// <summary>
        /// HotKey to add a new item to basket
        /// </summary>
        public HotKey FillBasketHotKey { get; set; }
        /// <summary>
        /// HotKey to clear all basket items
        /// </summary>
        public HotKey DeleteBasketHotKey { get; set; }
        /// <summary>
        /// Indicates that the basket now is capturing something
        /// </summary>
        public bool IsGathering { get; set; }

        public Keys FillKey { get; private set; }
        public Keys EmptyKey { get; private set; }
        public Keys DeleteKey { get; private set; }
        public HotKey.KeyModifiers FillModifiers { get; set; }
        public HotKey.KeyModifiers EmptyModifiers { get; set; }
        public HotKey.KeyModifiers DeleteModifiers { get; set; }
        #endregion

        #region cst

        public Basket(Keys fillKey, HotKey.KeyModifiers fillModifier,
                        Keys emptyKey, HotKey.KeyModifiers emptyModifier,
                        Keys deleteKey, HotKey.KeyModifiers deleteModifier)
        {
            this.Items = new List<T>();

            this.FillKey = fillKey;
            this.EmptyKey = emptyKey;
            this.DeleteKey = deleteKey;
            this.FillModifiers = fillModifier;
            this.EmptyModifiers = emptyModifier;
            this.DeleteModifiers = deleteModifier;

            this.FillHotKeyPressed = new EventHandler(Basket_FillHotKeyPressed);
            this.EmptyHotKeyPressed = new EventHandler(Basket_EmptyHotKeyPressed);
            this.DeleteHotKeyPressed = new EventHandler(Basket_DeleteHotKeyPressed);
        }

        #endregion

        #region helpers
        public void UpdateEvents()
        {
            this.EmptyBasketHotKey?.UnregisterHotKey();
            this.FillBasketHotKey?.UnregisterHotKey();
            this.DeleteBasketHotKey?.UnregisterHotKey();

            this.EmptyBasketHotKey = new HotKey(EmptyKey, EmptyModifiers, EmptyHotKeyPressed);
            this.FillBasketHotKey = new HotKey(FillKey, FillModifiers, FillHotKeyPressed);
            this.DeleteBasketHotKey = new HotKey(DeleteKey, DeleteModifiers, DeleteHotKeyPressed);
        }

        public void RegisterEvents()
        {
            this.FillBasketHotKey = new HotKey(FillKey, FillModifiers, FillHotKeyPressed);
            this.EmptyBasketHotKey = new HotKey(EmptyKey, EmptyModifiers, EmptyHotKeyPressed);
            this.DeleteBasketHotKey = new HotKey(DeleteKey, DeleteModifiers, DeleteHotKeyPressed);
        }
        private void Basket_FillHotKeyPressed(object sender, EventArgs e)
        {

        }

        private void Basket_EmptyHotKeyPressed(object sender, EventArgs e)
        {

        }

        private void Basket_DeleteHotKeyPressed(object sender, EventArgs e)
        {
            this.Items?.Clear();
        }

        #endregion
    }
}
