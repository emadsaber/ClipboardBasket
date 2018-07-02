using ClipboardDB.Conracts;
using ClipboardDB.Context;
using ClipboardDB.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClipboardDB
{
    public static class ClipBoardDBUnity
    {
        #region Context
        private static SerializationContext context;
        #endregion

        public static IClipboardItemRepository ClipBoardItems;

        static ClipBoardDBUnity()
        {
            context = new SerializationContext();

            ClipBoardItems = new ClipboardItemRepository(context);
        }
    }
}
