using System.Drawing;
using System.Windows.Forms;
using TheUnseenLibrary.UI.Base;

namespace TheUnseenLibrary.UI.SectionCells
{
    public class TextSectionCell : BaseUserControl
    {
        private FlowLayoutPanel _flwLayoutPanel;
        private Label _lblTitle;
        private Label _lblBody;
        
        public TextSectionCell(string title, string body)
        {
            AddControls();
            LayoutControls();
            SetAppearance();
            SetData(title, body);
        }

        private void AddControls()
        {
            Name = "TextSectionCell";

            _flwLayoutPanel = this.AddFlowLayoutPanel("FlwLayoutPanel", 0);

            _lblTitle = _flwLayoutPanel.AddLabel("LblTitle", 0);
            _lblBody = _flwLayoutPanel.AddLabel("LblBody", 0);
        }

        private void LayoutControls()
        {
            SuspendLayout();
            _flwLayoutPanel.SuspendLayout();

            this.Size = new Size(69, 75);
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;


            // 
            // flowLayoutPanel1
            // 
            _flwLayoutPanel.Location = new Point(0, 0);
            _flwLayoutPanel.Size = new Size(69, 75);
            _flwLayoutPanel.AutoSize = true;
            _flwLayoutPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            _flwLayoutPanel.Dock = DockStyle.Fill;
            _flwLayoutPanel.FlowDirection = FlowDirection.TopDown;

            // 
            // lblTitle
            // 
            _lblTitle.Location = new Point(0, 0);
            _lblTitle.Size = new Size(69, 45);
            _lblTitle.AutoSize = true;
            _lblTitle.Margin = new Padding(0);
            _lblTitle.Padding = new Padding(5, 10, 10, 10);

            // 
            // lblBody
            // 
            _lblBody.Location = new Point(0, 45);
            _lblBody.Size = new Size(69, 30);
            _lblBody.Anchor = (AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom);
            _lblBody.AutoSize = true;
            _lblBody.Margin = new Padding(0);
            _lblBody.Padding = new Padding(5);

            _flwLayoutPanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        private void SetAppearance()
        {
            _lblTitle.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            _lblTitle.Text = "Title";

            _lblBody.Text = "Body";
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
                _lblBody.Text = body;
            }
            else
            {
                _lblBody.Hide();
            }
        }
    }
}
