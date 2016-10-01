using System.Collections.Generic;
using System.Windows.Forms;
using TheUnseenLibrary.Database;
using TheUnseenLibrary.Model;
using TheUnseenLibrary.Presenter;
using TheUnseenLibrary.UI.Base;
using TheUnseenLibrary.UI.SectionCells;

namespace TheUnseenLibrary.UI.CustomViews
{
    public class PageFlowPanel : TableLayoutPanel
    {
        public PageFlowPanel()
        {
            ColumnCount = 1;
            GrowStyle = TableLayoutPanelGrowStyle.AddRows;
        }

        public void SetSections(List<Section> sections)
        {
            Controls.Clear();

            int i = Controls.Count;
            foreach (var section in sections)
            {
                if (section is LinkSection)
                {
                    this.AddLinkSectionCell((LinkSection)section, "LinkSectionCell", i);
                }
                else if (section is PageSection)
                {
                    this.AddPageSectionCell((PageSection)section, "PageSectionCell", i);
                }
                else
                {
                    TextSectionEditCell cell = new TextSectionEditCell(section.Title, "");
                    Controls.Add(cell);
                    //this.AddTextSectionCell((TextSection)section, "TextSectionCell", i);
                }
                i++;
            }
        }
    }
}
