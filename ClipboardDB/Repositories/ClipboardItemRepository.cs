using ClipboardDB.Conracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClipboardDB.Models;
using ClipboardDB.Context;

namespace ClipboardDB.Repositories
{
    public class ClipboardItemRepository : IClipboardItemRepository, IDisposable
    {
        private SerializationContext _ctx;
        public ClipboardItemRepository(SerializationContext db)
        {
            _ctx = db;
        }
        public bool Add(ClipboardItem entity)
        {
            _ctx.ClipBoardItems.Add(entity);
            return _ctx.SaveChanges();
        }

        public bool Delete(Guid id)
        {
            _ctx.ClipBoardItems.RemoveAll(x => x.Id == id);
            return _ctx.SaveChanges();
        }

        public bool Delete(ClipboardItem entity)
        {
            _ctx.ClipBoardItems.Remove(entity);
            return _ctx.SaveChanges();
        }

        public void Dispose()
        {
            this.Dispose();
        }

        public ClipboardItem Get(Guid id)
        {
            return _ctx.ClipBoardItems.SingleOrDefault(x => x.Id == id);
        }

        public IList<ClipboardItem> GetAll()
        {
            return _ctx.ClipBoardItems.ToList();
        }

        public bool Update(ClipboardItem entity)
        {
            var index = _ctx.ClipBoardItems.FindIndex(x => x.Id == entity.Id);
            _ctx.ClipBoardItems.RemoveAt(index);
            _ctx.ClipBoardItems.Insert(index, entity);
            return _ctx.SaveChanges();
        }
    }
}
