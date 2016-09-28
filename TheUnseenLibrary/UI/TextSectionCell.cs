using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheUnseenLibrary.UI
{
    public partial class TextSectionCell : UserControl
    {
        public TextSectionCell()
        {
            InitializeComponent();
        }

        public void SetLabels(string title, string body)
        {
            if (title != null)
            {
                lblTitle.Text = title;
            }
            else
            {
                lblTitle.Hide();
            }
            if (body != null)
            {
                lblBody.Text = body;
            }
            else
            {
                lblBody.Hide();
            }
        }
    }
}
