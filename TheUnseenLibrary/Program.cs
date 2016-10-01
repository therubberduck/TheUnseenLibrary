using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using TheUnseenLibrary.Database;
using TheUnseenLibrary.Presenter;
using TheUnseenLibrary.UI;

namespace TheUnseenLibrary
{
    static class Program
    {


        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            DbInterface db = new DbInterface();

            db.ClearDb();

            int rootId = db.Pages.Create("Root", -1);
            int cityId = db.Pages.Create("Cities", rootId);
            int peopleId = db.Pages.Create("People", rootId);
            int missionId = db.Pages.Create("Missions", rootId);


            db.Sections.CreatePage(rootId, 0, peopleId);
            db.Sections.CreateLink(rootId, 1, "Cities", cityId);

            db.Sections.CreateText(cityId, 0, "City", "1000");
            db.Sections.CreateTitle(cityId, 2, "Quarter of Fools");
            db.Sections.CreatePlainText(cityId, 3, "This is a quiet place.");
            db.Sections.CreatePlainText(cityId, 4, "Not many people live here.");
            db.Sections.CreateTitle(cityId, 5, "Links");
            db.Sections.CreateLink(cityId, 6, "People", peopleId);
            db.Sections.CreateLink(cityId, 7, "Missions", missionId);

            db.Sections.CreateText(peopleId, 0, "Pop", "1000");
            db.Sections.CreateText(peopleId, 1, "Summer", "Master");

            var rootPage = db.Pages.GetRoot();

            var pagePresenter = new PagePresenter(db, rootPage);
            Application.Run(pagePresenter.Form);
        }
    }
}
