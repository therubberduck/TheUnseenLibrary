using System.Windows.Forms;
using TheUnseenLibrary.Database;
using TheUnseenLibrary.Events;
using TheUnseenLibrary.Helper;
using TheUnseenLibrary.Model;
using TheUnseenLibrary.UI;

namespace TheUnseenLibrary.Presenter
{
    public class PagePresenter
    {
        private DbInterface _db;
        private Page _page;

        private IPageForm _form;

        private NavigationHandler _nav;

        public Form Form
        {
            get { return (Form)_form; }
        }

        public PagePresenter(DbInterface db, Page page)
        {
            _db = db;

            Initialize(page.PageId);
        }

        public PagePresenter(DbInterface db, long pageId)
        {
            _db = db;

            Initialize(pageId);
        }

        public void Initialize(long pageId)
        {
            _form = new PageForm();

            _nav = new NavigationHandler(pageId);
            DoPageChange(pageId);

            EventHandler.Instance.NavigateForwardEvent += GoToNextPage;
            EventHandler.Instance.NavigateBackwardsEvent += GoToPreviousPage;

            EventHandler.Instance.OpenPageEvent += OpenPage;
            EventHandler.Instance.PageChangeEvent += ChangePage;
        }

        public void OpenPage(object sender, PageChangeEvent pageChangeEvent)
        {
            PagePresenter newPage = new PagePresenter(_db, pageChangeEvent.PageId);
            newPage.Show();
        }

        public void ChangePage(object sender, PageChangeEvent pageChangeEvent)
        {
            _nav.ChangePageTo(pageChangeEvent.PageId);

            DoPageChange(pageChangeEvent.PageId);
        }

        public void GoToNextPage(object sender, SimpleEvent simpleEvent)
        {
            long nextPageId = _nav.GetNext();
            if (nextPageId != -1)
            {
                DoPageChange(nextPageId);
            }
        }

        public void GoToPreviousPage(object sender, SimpleEvent simpleEvent)
        {
            long previousPageId = _nav.GetPrevious();
            if (previousPageId != -1)
            {
                DoPageChange(previousPageId);
            }
        }

        private void DoPageChange(long pageId)
        {
            _page = _db.Pages.Get(pageId);

            if (_page.IsRoot)
            {
                _form.HideTitle();
            }
            else
            {
                _form.ShowTitle();
                _form.SetTitle(_page.Name);
            }

            _form.SetSections(_page.Sections);
        }

        public void Show()
        {
            _form.Show();
        }
    }
}
