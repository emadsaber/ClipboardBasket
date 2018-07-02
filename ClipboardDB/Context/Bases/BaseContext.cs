using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClipboardDB.Context
{
    public abstract class BaseContext
    {
        public virtual bool SaveChanges()
        {
            return false;
        }
    }
}
