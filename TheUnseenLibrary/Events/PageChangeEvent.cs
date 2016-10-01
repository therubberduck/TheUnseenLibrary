using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheUnseenLibrary.Events
{
    public class PageChangeEvent : EventArgs
    {
        public long PageId;

        public PageChangeEvent(long pageId)
        {
            PageId = pageId;
        }
    }
}
