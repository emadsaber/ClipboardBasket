using ClipboardDB.Models;
using Polenter.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClipboardDB.Context
{
    public class SerializationContext : BaseContext, IDisposable
    {
        private SharpSerializer _serializer;
        public List<ClipboardItem> ClipBoardItems;


        public SerializationContext()
        {
            this.ClipBoardItems = new List<ClipboardItem>();

            this._serializer = new SharpSerializer();

            GetAllItems();
        }

        private void GetAllItems()
        {
            //Load Clipboard Items
            using (var fs = new FileStream(FilePath(typeof(ClipboardItem).Name), FileMode.OpenOrCreate))
            {
                if (fs.Length > 0)
                {
                    this.ClipBoardItems = (List<ClipboardItem>)_serializer.Deserialize(fs);
                }
            }
        }
        public string FilePath(string name) { return $"{name}s.DB.xml"; }

        public void Dispose()
        {
            this.Dispose();
        }

        public override bool SaveChanges()
        {
            using (var fs = new FileStream(FilePath(typeof(ClipboardItem).Name), FileMode.Create))
            {
                _serializer.Serialize(ClipBoardItems, fs);
            }

            return true;
        }
    }
}
