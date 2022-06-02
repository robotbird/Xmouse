using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Xmouse
{
    public partial class WechatQR : Form
    {
        public WechatQR()
        {
            InitializeComponent();
        }

        private void WechatQR_Load(object sender, EventArgs e)
        {
            Tools.SetMid(this);
           // this.BackColor = Color.White;
            //this.TransparencyKey = Color.White;
            //this.FormBorderStyle = FormBorderStyle.None;
        }
    }
}
