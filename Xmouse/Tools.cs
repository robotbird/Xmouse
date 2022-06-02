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

        public static void ToolTip(string tip,Control control)
        {
            // 创建the ToolTip 
            ToolTip toolTip1 = new ToolTip();
            // 设置显示样式
            toolTip1.AutoPopDelay = 5000;//提示信息的可见时间
            toolTip1.InitialDelay = 500;//事件触发多久后出现提示
            toolTip1.ReshowDelay = 500;//指针从一个控件移向另一个控件时，经过多久才会显示下一个提示框
            toolTip1.ShowAlways = true;//是否显示提示框
            //  设置伴随的对象.
            toolTip1.SetToolTip(control, tip);//设置提示按钮和提示内容
            control.Cursor = Cursors.Hand;
        }
    }
}
