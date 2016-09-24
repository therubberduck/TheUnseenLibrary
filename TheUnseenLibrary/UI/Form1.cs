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
            db.Pages.Create("Cities", rootId);
            db.Pages.Create("People", rootId);

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
            }
            label1.Text = labelText;
        }
    }
}
