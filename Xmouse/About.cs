using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Xmouse
{
    public partial class About: Form
    {
        public About()
        {
            InitializeComponent();
        }

        private void About_Load(object sender, EventArgs e)
        {
            Tools.SetMid(this);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@"mailto:robotbird798@gmail.com");
        }

        private void pictureBox2_MouseHover(object sender, EventArgs e)
        {
            Tools.ToolTip("发送邮件给我", pictureBox2);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            WechatQR wechatQR = new WechatQR();
            wechatQR.Show();
        }

        private void pictureBox3_MouseHover(object sender, EventArgs e)
        {
            Tools.ToolTip("关注微信公众号", pictureBox3);
        }
    }
}
