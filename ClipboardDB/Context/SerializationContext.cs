using ClipboardDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClipboardDB.Context
{
    public class SerializationContext:BaseContext, IDisposable
    {
        public List<ClipboardItem> ClipBoardItems;

        public string FilePath { get; set; }

        public SerializationContext()
        {
            this.ClipBoardItems = new List<ClipboardItem>();
        }

        public void Dispose()
        {
            this.Dispose();
        }

        public override bool SaveChanges()
        {
            var result = false;

            //TODO : serialize all objects
            //TODO : write file

            return result;
        }
    }
}
