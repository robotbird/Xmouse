using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Reflection;
using System.IO;
using System.Collections;

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
            this.Resize += Form1_Resize;
        }


        //单机窗体最小化时窗体隐藏 
        void Form1_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Hide();
            }
        }
        void MyNotifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show(); // 窗体显现
            this.WindowState = FormWindowState.Normal; //窗体回复正常大小
        }

        private void Left_Click(object sender, EventArgs e)
        {
            LeftMouse();
        }
        void LeftMouse()
        {
            SwapMouseButton(true);//设置成左手
            LabelText.Text = "左手鼠标";
            mainNotifyIcon.Text = "左手鼠标";
            menu_mouse_left.Text = "左手Alt+L(√)";
            menu_mouse_right.Text = "右手Alt+R";

            string lcur = "aero_arrow_left.cur";
            if (File.Exists(lcur))
            {
                IntPtr cur = LoadCursorFromFile(lcur);//鼠标图标路径  
                Boolean a = SetSystemCursor(cur, 32512);//32512
            }

            pictureBox2.Visible = false;
            pictureBox1.Visible = true;

        }


        private void Right_Click(object sender, EventArgs e)
        {
            RightMouse();
        }
        void RightMouse()
        {
            SwapMouseButton(false);//设置成右手 aero_arrow.cur
            LabelText.Text = "右手鼠标";
            mainNotifyIcon.Text = "右手鼠标";
            menu_mouse_left.Text = "左手Alt+L";
            menu_mouse_right.Text = "右手Alt+R(√)";
            string rcur = "aero_arrow.cur";
            if (File.Exists(rcur))
            {
                IntPtr cur = LoadCursorFromFile(rcur);//鼠标图标路径  
                Boolean a = SetSystemCursor(cur, 32512);//32512
            }

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

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            About about = new About();
            about.Show();
           // System.Diagnostics.Process.Start("https://github.com/robotbird/Xmouse");
        }


        private void Xmouse_FormClosing(object sender, FormClosingEventArgs e)
        {
            // 注意判断关闭事件reason来源于窗体按钮，否则用菜单退出时无法退出!
            if (e.CloseReason == CloseReason.UserClosing)
            {
                //取消"关闭窗口"事件
                e.Cancel = true;
                //使关闭时窗口向右下角缩小的效果
                this.WindowState = FormWindowState.Minimized;
                this.mainNotifyIcon.Visible = true;
                this.Hide();
                return;
            }
        }

        private void Logout_Click(object sender, EventArgs e)
        {
            this.mainNotifyIcon.Visible = false;
            this.Close();
            this.Dispose();
            Application.Exit();
        }


        private int Key_L;
        private int Key_R;

        public void OnHotkey(int HotkeyID)
        {
            if (!this.Visible)
            {
               
                this.BackColor = Color.White;
                this.TransparencyKey = Color.White;
                this.FormBorderStyle = FormBorderStyle.None;
                this.linkLabel1.Visible = false;

                this.Show();
                this.TopMost = true;
                this.WindowState = FormWindowState.Normal;

                countdown.Visible = true;
                timer1.Enabled = false;
                timer1.Start();
                DateTime dt = System.DateTime.Now.AddSeconds(-3);//把结束的时间写在里面，注意格式哦
                TimeSpan ts = System.DateTime.Now - dt;//用结束的时间减去现在系统显示的时间
                Seconds = ts.Seconds;

                ShowTime();
            }


            if (HotkeyID == Key_L)
            {
                LeftMouse();
            }

            if (HotkeyID == Key_R)
            {
                RightMouse();
            }

        }

        int Seconds;
        private void Form1_Load(object sender, EventArgs e)
        {
            Tools.SetMid(this);
            Hotkey hotkey;
            hotkey = new Hotkey(this.Handle);
            Key_L = hotkey.RegisterHotkey(System.Windows.Forms.Keys.L, Hotkey.KeyFlags.MOD_ALT);   //定义快键(Alt+L)
            Key_R = hotkey.RegisterHotkey(System.Windows.Forms.Keys.R, Hotkey.KeyFlags.MOD_ALT);   //定义快键(Alt+R)
            hotkey.OnHotkey += new HotkeyEventHandler(OnHotkey);
            countdown.Visible = false;

        }

       
        private void timer1_Tick(object sender, EventArgs e)
        {
            Seconds--;
            if (Seconds <= 0)
            {
                timer1.Stop();

                if (Seconds != -1)
                {
                    this.WindowState = FormWindowState.Minimized;
                    this.Close();
                }
                
            }
            ShowTime();
        }
        private void ShowTime()
        {
            countdown.ForeColor = Color.Red;
            countdown.Text = string.Format("{0:d1}S", Seconds);

        }

        private void mainNotifyIcon_DoubleClick(object sender, EventArgs e)
        {
            this.BackColor = Color.White;
            this.TransparencyKey = Color.Empty;
            this.FormBorderStyle = FormBorderStyle.Sizable;

            countdown.Visible = false;
            linkLabel1.Visible = true;
        }

     
        private void menu_about_Click(object sender, EventArgs e)
        {
            About about = new About();
            about.Show();
        }
    }
}
