using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheUnseenLibrary.UI.CustomViews
{
    public class AutoResizingTextBox : TextBox
    {
        public AutoResizingTextBox()
        {
            TextChanged += TextView_TextChanged;
        }

        private void TextView_TextChanged(object sender, EventArgs e)
        {
            Multiline = true;

            Size sz = new Size(ClientSize.Width, int.MaxValue);
            TextFormatFlags flags = TextFormatFlags.WordBreak;
            int padding = 3;
            int borders = Height - ClientSize.Height;
            sz = TextRenderer.MeasureText(Text, Font, sz, flags);
            int h = sz.Height + borders + padding;
            if (h < 29)
            {
                h = 29;
            }
            Height = h;
        }
    }
}
