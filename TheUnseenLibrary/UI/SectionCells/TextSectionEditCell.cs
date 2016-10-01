using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TheUnseenLibrary.UI.Base;
using TheUnseenLibrary.UI.CustomViews;

namespace TheUnseenLibrary.UI.SectionCells
{
    public class TextSectionEditCell : BaseUserControl
    {
        private TableLayoutPanel _flwLayoutPanel;
        private Label _lblTitle;
        private AutoResizingTextBox _txtBody;

        public TextSectionEditCell(string title, string body)
        {
            AddControls();
            LayoutControls();
            SetAppearance();
            SetupControls();
            SetData(title, body);
        }

        private void AddControls()
        {
            Name = "TextSectionCell";

            _flwLayoutPanel = this.AddTableLayoutPanel("FlwLayoutPanel", 0);

            _lblTitle = _flwLayoutPanel.AddLabel("LblTitle", 0);
            _txtBody = _flwLayoutPanel.AddAutoResizingTextBox("TxtBody", 0);
        }

        private void LayoutControls()
        {
            SuspendLayout();
            _flwLayoutPanel.SuspendLayout();
            
            Dock = DockStyle.Fill;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;


            // 
            // flowLayoutPanel
            // 
            _flwLayoutPanel.ColumnCount = 1;
            _flwLayoutPanel.GrowStyle = TableLayoutPanelGrowStyle.AddRows;

            _flwLayoutPanel.Dock = DockStyle.Fill;
            _flwLayoutPanel.AutoSize = true;
            _flwLayoutPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;

            // 
            // lblTitle
            // 
            _lblTitle.Dock = DockStyle.Fill;
            _lblTitle.AutoSize = true;

            _lblTitle.Margin = new Padding(0);
            _lblTitle.Padding = new Padding(5, 10, 10, 10);

            // 
            // lblBody
            // 
            _txtBody.Dock = DockStyle.Fill;
            _txtBody.AutoSize = true;

            _txtBody.Margin = new Padding(5);
            _txtBody.Padding = new Padding(5);

            _flwLayoutPanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        private void SetAppearance()
        {
            _lblTitle.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            _lblTitle.Text = "Title";

            _txtBody.Text = "Body";
        }

        private void SetupControls()
        {
        }

        public void SetData(string title, string body)
        {
            if (title != null)
            {
                _lblTitle.Text = title;
            }
            else
            {
                _lblTitle.Hide();
            }
            if (body != null)
            {
                _txtBody.Text = body;
            }
            else
            {
                _txtBody.Hide();
            }
        }
    }
}
