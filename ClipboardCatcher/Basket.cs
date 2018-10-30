using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ClipboardCatcher
{
    public class Basket<T>
    {

        #region events

        public event EventHandler FillHotKeyPressed = new EventHandler((x, y) => { return; });
        public event EventHandler EmptyHotKeyPressed = new EventHandler((x, y) => { return; });
        public event EventHandler DeleteHotKeyPressed = new EventHandler((x, y) => { return; });

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
        /// Represents the whole basket items meged as one item ready to be copied or pasted as one unit
        /// </summary>
        public T BasketContents { get => GetContents(); }
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

        #endregion

        #region cst

        public Basket(  Keys fillKey, HotKey.KeyModifiers fillModifier, 
                        Keys emptyKey, HotKey.KeyModifiers emptyModifier,
                        Keys deleteKey, HotKey.KeyModifiers deleteModifier)
        {
            this.EmptyHotKeyPressed += Basket_EmptyHotKeyPressed;
            this.FillHotKeyPressed += Basket_FillHotKeyPressed;
            this.DeleteHotKeyPressed += Basket_DeleteHotKeyPressed;

            this.EmptyBasketHotKey = new HotKey(emptyKey, emptyModifier, EmptyHotKeyPressed);
            this.FillBasketHotKey = new HotKey(fillKey, fillModifier, FillHotKeyPressed);
            this.DeleteBasketHotKey = new HotKey(deleteKey, deleteModifier, DeleteHotKeyPressed);
        }

        #endregion

        #region helpers

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
        
        private T GetContents()
        {
            throw new NotImplementedException();
            //if (this.Items == null) return default(T);

            //var contents = this.Items.Select(x => x);
        }
        #endregion
    }
}
