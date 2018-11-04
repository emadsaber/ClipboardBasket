using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ClipboardCatcher
{
    public class Basket<T>
    {
        #region events

        public event EventHandler FillBasketEvent;
        public event EventHandler EmptyBasketEvent;
        public event EventHandler DropBasketEvent;

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
        public T WholeBasket { get; set; }
        public bool IsGathering { get; set; }
        #endregion

        #region cst

        public Basket()
        {
            this.Items = new List<T>();

            this.FillBasketEvent = new EventHandler(FillEventHandler);
            this.EmptyBasketEvent = new EventHandler(EmptyEventHandler);
            this.DropBasketEvent = new EventHandler(DropEventHandler);
        }

        #endregion

        #region handlers

        private void FillEventHandler(object sender, EventArgs e)
        {
        }
        private void EmptyEventHandler(object sender, EventArgs e){}
        private void DropEventHandler(object sender, EventArgs e) {
            this.Items?.Clear();
        }
        #endregion

        #region methods

        public void Push(object sender, T item)
        {
            this.Items = this.Items ?? new List<T>();
            this.Items.Add(item);
            this.FillBasketEvent.Invoke(sender, new EventArgs());
        }

        public void Delete()
        {
            this.DropBasketEvent.Invoke(this, null);
        }

        public void CopyBasket()
        {
            this.EmptyBasketEvent(this, null);
        }
        #endregion
    }
}
