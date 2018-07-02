using ClipboardDB.Conracts.Bases;
using ClipboardDB.Models;
using ClipboardDB.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClipboardDB.Conracts
{
    public interface IClipboardItemRepository : IRepository<ClipboardItem>
    {
    }
}
