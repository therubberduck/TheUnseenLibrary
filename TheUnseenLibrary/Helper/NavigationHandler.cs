using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheUnseenLibrary.Helper
{
    public class NavigationHandler
    {

        private List<long> _navigationStack;
        private int _navigationIndex;

        public NavigationHandler(long initialPageId)
        {
            _navigationStack = new List<long> { initialPageId };
            _navigationIndex = 0;
        }

        public void ChangePageTo(long pageId)
        {
            int index = _navigationIndex + 1;
            int count = _navigationStack.Count - index;
            _navigationStack.RemoveRange(index, count); //Remove any pages on the stack after our current index
            _navigationStack.Add(pageId); //Add the new page to the stack
            _navigationIndex++; //Increase index by 1
        }

        public long GetNext()
        {
            if (_navigationIndex < _navigationStack.Count - 1)
            {
                _navigationIndex++;
                long pageId = _navigationStack[_navigationIndex];

                return pageId;
            }
            return -1;
        }

        public long GetPrevious()
        {
            if (_navigationIndex > 0)
            {
                _navigationIndex--;
                long pageId = _navigationStack[_navigationIndex];

                return pageId;
            }
            return -1;
        }
    }
}
