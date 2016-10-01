using System.Windows.Forms;
using TheUnseenLibrary.Database;
using TheUnseenLibrary.Model;
using TheUnseenLibrary.Presenter;
using TheUnseenLibrary.UI.CustomViews;
using TheUnseenLibrary.UI.SectionCells;

namespace TheUnseenLibrary.UI.Base
{
    public static class AddControl
    {

        public static Button AddButton(this Control parent, string name, int tabIndex)
        {
            Button view = new Button
            {
                Name = name,
                TabIndex = tabIndex
            };
            parent.Controls.Add(view);
            return view;
        }

        public static FlowLayoutPanel AddFlowLayoutPanel(this Control parent, string name, int tabIndex)
        {
            FlowLayoutPanel view = new FlowLayoutPanel
            {
                Name = name,
                TabIndex = tabIndex
            };
            parent.Controls.Add(view);
            return view;
        }

        public static Label AddLabel(this Control parent, string name, int tabIndex)
        {
            Label view = new Label
            {
                Name = name,
                TabIndex = tabIndex
            };
            parent.Controls.Add(view);
            return view;
        }

        public static Panel AddPanel(this Control parent, string name, int tabIndex)
        {
            Panel view = new Panel
            {
                Name = name,
                TabIndex = tabIndex
            };
            parent.Controls.Add(view);
            return view;
        }

        public static RichTextBox AddRichTextBox(this Control parent, string name, int tabIndex)
        {
            RichTextBox view = new RichTextBox
            {
                Name = name,
                TabIndex = tabIndex
            };
            parent.Controls.Add(view);
            return view;
        }

        public static TableLayoutPanel AddTableLayoutPanel(this Control parent, string name, int tabIndex)
        {
            TableLayoutPanel view = new TableLayoutPanel
            {
                Name = name,
                TabIndex = tabIndex
            };
            parent.Controls.Add(view);
            return view;
        }

        public static TextBox AddTextBox(this Control parent, string name, int tabIndex)
        {
            TextBox view = new TextBox
            {
                Name = name,
                TabIndex = tabIndex
            };
            parent.Controls.Add(view);
            return view;
        }

        //
        // Custom Controls
        //

        public static PageFlowPanel AddPageFlowPanel(this Control parent, string name, int tabIndex)
        {
            PageFlowPanel view = new PageFlowPanel
            {
                Name = name,
                TabIndex = tabIndex
            };
            parent.Controls.Add(view);
            return view;
        }

        public static AutoResizingTextBox AddAutoResizingTextBox(this Control parent, string name, int tabIndex)
        {
            AutoResizingTextBox view = new AutoResizingTextBox
            {
                Name = name,
                TabIndex = tabIndex
            };
            parent.Controls.Add(view);
            return view;
        }

        //
        // Menu
        //


        public static MenuStrip AddMenuStrip(this Control parent, string name, int tabIndex)
        {
            MenuStrip view = new MenuStrip
            {
                Name = name,
                TabIndex = tabIndex
            };
            parent.Controls.Add(view);
            return view;
        }


        public static ToolStripMenuItem AddMenuItem(this MenuStrip parent, string name)
        {
            ToolStripMenuItem view = new ToolStripMenuItem
            {
                Name = name
            };
            parent.Items.Add(view);
            return view;
        }

        //
        // Sections
        //

        public static LinkSectionCell AddLinkSectionCell(this Control parent, LinkSection section, string name, int tabIndex)
        {
            LinkSectionCell view = new LinkSectionCell(section.Title, section.ChildPageId)
            {
                Name = name,
                TabIndex = tabIndex
            };
            parent.Controls.Add(view);
            return view;
        }

        public static PageSectionCell AddPageSectionCell(this Control parent, PageSection section, string name, int tabIndex)
        {
            PageSectionCell view = new PageSectionCell(section.Page)
            {
                Name = name,
                TabIndex = tabIndex
            };
            parent.Controls.Add(view);
            return view;
        }

        public static TextSectionCell AddTextSectionCell(this Control parent, TextSection section, string name, int tabIndex)
        {
            TextSectionCell view = new TextSectionCell(section.Title, section.Body)
            {
                Name = name,
                TabIndex = tabIndex
            };
            parent.Controls.Add(view);
            return view;
        }
    }
}
