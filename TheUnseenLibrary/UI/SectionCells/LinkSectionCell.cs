using System;
using System.Drawing;
using System.Windows.Forms;
using TheUnseenLibrary.Events;
using TheUnseenLibrary.UI.Base;
using EventHandler = TheUnseenLibrary.Events.EventHandler;

namespace TheUnseenLibrary.UI.SectionCells
{
    public class LinkSectionCell : UserControl
    {
        private long _pageId;

        private Label _lblTitle;

        public LinkSectionCell(string title, long pageId)
        {
            _pageId = pageId;

            AddControls();
            LayoutControls();
            SetAppearance();
            SetupControls();
            SetData(title);
        }

        private void AddControls()
        {
            Name = "LinkSectionCell";

            _lblTitle = this.AddLabel("LblTitle", 0);
        }

        private void LayoutControls()
        {
            SuspendLayout();

            Size = new Size(980, 45);
            Dock = DockStyle.Fill;
            //AutoSize = true;
            //AutoSizeMode = AutoSizeMode.GrowAndShrink;
            //AutoScaleDimensions = new SizeF(9F, 20F);
            //AutoScaleMode = AutoScaleMode.Font;

            // 
            // lblTitle
            // 
            _lblTitle.Location = new Point(0, 0);
            _lblTitle.Size = new Size(96, 45);
            _lblTitle.AutoSize = true;
            _lblTitle.Padding = new Padding(10);

            ResumeLayout(false);
        }

        private void SetAppearance()
        {
            _lblTitle.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            _lblTitle.ForeColor = SystemColors.HotTrack;
            _lblTitle.Text = "Title";
        }

        private void SetupControls()
        {
            MouseClick += LinkSectionCell_MouseClick;
            _lblTitle.MouseClick += LinkSectionCell_MouseClick;
        }

        public void SetData(string title)
        {
            _lblTitle.Text = title;
        }

        private void LinkSectionCell_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                EventHandler.Instance.SendOpenPageEvent(new PageChangeEvent(_pageId));
            }
            else
            {
                EventHandler.Instance.SendPageChangeEvent(new PageChangeEvent(_pageId));
            }
        }
    }
}
