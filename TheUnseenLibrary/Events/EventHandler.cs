using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheUnseenLibrary.Events
{
    public class EventHandler
    {
        private static EventHandler _instance;

        public static EventHandler Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new EventHandler();
                }
                return _instance;
            }
        }

        public event EventHandler<SimpleEvent> NavigateForwardEvent;
        public void SendNavigateForwardEvent()
        {
            EventHandler<SimpleEvent> handler = NavigateForwardEvent;
            if (handler != null)
            {
                handler(this, new SimpleEvent());
            }
        }

        public event EventHandler<SimpleEvent> NavigateBackwardsEvent;
        public void SendNavigateBackwardsEvent()
        {
            EventHandler<SimpleEvent> handler = NavigateBackwardsEvent;
            if (handler != null)
            {
                handler(this, new SimpleEvent());
            }
        }

        public event EventHandler<PageChangeEvent> PageChangeEvent;
        public void SendPageChangeEvent(PageChangeEvent e)
        {
            EventHandler<PageChangeEvent> handler = PageChangeEvent;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        public event EventHandler<PageChangeEvent> OpenPageEvent;
        public void SendOpenPageEvent(PageChangeEvent e)
        {
            EventHandler<PageChangeEvent> handler = OpenPageEvent;
            if (handler != null)
            {
                handler(this, e);
            }
        }
    }
}
