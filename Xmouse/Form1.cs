using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Reflection;
namespace Xmouse
{
    public partial class Xmouse : Form
    {
        [DllImport("user32.dll")]
        private extern static bool SwapMouseButton(bool fSwap);
        //博客地址：http：//www.jqpress.com

        [DllImport("user32.dll")]
        private extern static int GetSystemMetrics(int index);

        [DllImport("user32.dll")]
        public static extern IntPtr SetCursor(IntPtr cursorHandle);

        [DllImport("user32.dll")]
        public static extern IntPtr LoadCursorFromFile(string fileName);

        [DllImport("user32.dll")]
        public static extern bool SetSystemCursor(IntPtr hCursor, int id);


        public Xmouse()
        {
            InitializeComponent();
            int flag = GetSystemMetrics(23);//获取当前鼠标设置状态 
            if (flag == 0)//左手习惯 
            {
                LeftMouse();
            }
            else//右手习惯 
            {
                RightMouse();

            }


        }
        void LeftMouse()
        {
            SwapMouseButton(true);//设置成左手
            LabelText.Text = "左手鼠标";
            IntPtr cur = LoadCursorFromFile("aero_arrow_left.cur");//鼠标图标路径  

            Boolean a = SetSystemCursor(cur, 32512);//32512
            pictureBox2.Visible = false;
            pictureBox1.Visible = true;

        }
        void RightMouse()
        {
            SwapMouseButton(false);//设置成右手 aero_arrow.cur
            LabelText.Text = "右手鼠标";

            IntPtr cur = LoadCursorFromFile("aero_arrow.cur");//鼠标图标路径  

            Boolean a = SetSystemCursor(cur, 32512);//32512
            pictureBox1.Visible = false;
            pictureBox2.Visible = true;

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            RightMouse();
        }
        

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            LeftMouse();
        }
    }
}
