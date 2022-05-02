using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Xmouse
{
  public  class Tools
    {
        /**//// <summary>
            /// 窗口居中
            /// </summary>
        public static void SetMid(Form form)
        {
            // Center the Form on the user's screen everytime it requires a Layout.
            form.SetBounds((Screen.GetBounds(form).Width / 2) - (form.Width / 2),
                (Screen.GetBounds(form).Height / 2) - (form.Height / 2),
                form.Width, form.Height, BoundsSpecified.Location);
        }
    }
}
