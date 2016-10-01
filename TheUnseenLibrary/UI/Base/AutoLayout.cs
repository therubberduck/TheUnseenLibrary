using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheUnseenLibrary.UI.Base
{
    public static class AutoLayout
    {
        //
        // Anchor
        //
        public static void AnchorAllSides(this Control control)
        {
            control.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom);
        }
        
        public static void AnchorBottomAndSides(this Control control)
        {
            control.Anchor = (AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom);
        }

        public static void AnchorTopRight(this Control control)
        {
            control.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
        }

        public static void AnchorTopAndSides(this Control control)
        {
            control.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
        }
    }
}
