using ClipboardDB.Models.Common;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClipboardDB.Models
{
    public class ClipboardItem
    {
        public Guid Id { get; set; }
        public DateTime TimeStamp { get; set; }
        public ItemType Type { get; set; }
        public string TextValue { get; set; } 
        public byte[] ImageValue { get; set; }
        public string[] FilesValue { get; set; }
    }
}
