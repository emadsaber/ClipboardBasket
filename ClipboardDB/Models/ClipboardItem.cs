﻿using ClipboardDB.Models.Common;
using System;
using System.Collections.Generic;
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
    }
}
