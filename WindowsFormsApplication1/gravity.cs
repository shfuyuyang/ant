using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class gravity : Form
    {
        public gravity()
        {
            InitializeComponent();
        }

        int x = 120;
        int y = 0;
        int Vx = 0;
        int Vy = 0;
        bool up = true;
        int sysTime = 0;//系统经过时间
        int a = 0;      //加速度

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            drawPoint(120, 120, Color.Red);
        }

        private void drawPoint(int x,int y,Color color)
        {
            Image imag = new Bitmap(400, 300);
            Graphics g = pictureBox1.CreateGraphics();
            Pen pen = new Pen(color, 8);
            g.Clear(Color.White);
            //int x = 0;
            //int y = 0;
            g.DrawArc(pen,x-4,y+4,8,8,0,360);
            g.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                a = int.Parse(textBox1.Text);
            }
            catch
            {
                MessageBox.Show("加速度错误！");
                return;
            }
            timerDisplay.Enabled = true;
            timerSystem.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            drawPoint(x, y, Color.Red);
        }

        private void timerSystem_Tick(object sender, EventArgs e)
        {
            if (up == true)
            {
                Vy += a;
                y = (Vy * sysTime)/2;
                sysTime++;
                if (y >= 300)
                {
                    up = false;
                    sysTime = 0;
                }
            }
            else
            {
                y = 300-(Vy*2-a*sysTime)*sysTime/2;
                sysTime++;
                if (y < 5)
                {
                    up = true;
                    sysTime = 0;
                    Vy = 1;
                }
            }
        }
    }
}