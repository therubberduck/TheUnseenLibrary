using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TheUnseenLibrary.Database;
using TheUnseenLibrary.Model;

namespace TheUnseenLibrary
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            DbInterface db = new DbInterface();

            db.ClearDb();

            int rootId = db.Pages.Create("Root", -1);
            int cityId = db.Pages.Create("Cities", rootId);
            int peopleId = db.Pages.Create("People", rootId);


            db.Sections.CreatePage(rootId, 1, peopleId);
            db.Sections.CreateLink(rootId, 0, "Cities", cityId);

            db.Sections.CreateText(cityId, 0, "City", "1000");

            db.Sections.CreateText(peopleId, 1, "Summer", "Master");
            db.Sections.CreateText(peopleId, 0, "Pop", "1000");

            var pages = db.Pages.GetAll();
            string labelText = "";
            foreach (var page in pages)
            {
                if (page.Parent != null)
                {
                    labelText += page.Name + "(" + page.Parent.Name + ")" + Environment.NewLine;
                }
                else
                {
                    labelText += page.Name + Environment.NewLine;
                }

                foreach (var section in page.Sections)
                {
                    if (section is LinkSection)
                    {
                        LinkSection linkSection = (LinkSection) section;
                        labelText += "---" + section.Title + " - " + linkSection.Page.Sections[0].Title + Environment.NewLine;
                    }
                    else if (section is PageSection)
                    {
                        PageSection pageSection = (PageSection)section;
                        labelText += "---" + section.Title + " - " + pageSection.Page.Sections[0].Title + " - " + ((TextSection)pageSection.Page.Sections[0]).Body + Environment.NewLine;
                    }
                    else
                    {
                        TextSection textSection = (TextSection)section;
                        labelText += "---" + textSection.Title + " - " + textSection.Body + Environment.NewLine;
                    }
                }
            }
            label1.Text = labelText;
        }
    }
}
