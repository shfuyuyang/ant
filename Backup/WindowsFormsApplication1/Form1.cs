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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }



        #region 蛇运行参数

        Keys direct = Keys.R;  //表示蛇头前进方向，上下左右，初始为向右
        int[,] displayMemory=new int[16,16];        //显存数组，为0表示空，为1表示蛇身，为2表示糖果
        int length = 3;             //蛇身长度，初始为3
        int headX = 4;              //头坐标x
        int headY = 1;              //头坐标y
        int endX = 1;              //头坐标x
        int endY = 1;              //头坐标y

        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            timerRefresh.Enabled = true;
            timer1Step.Enabled = true;
            snakeInit();
            textBox1.Select();
            int[] a = getRandnum();
            displayMemory[a[0], a[1]] = 2;
        }


        private void refreshDisplay()
        {
            Image imag = new Bitmap(160, 160);
            Graphics g = pictureBox1.CreateGraphics();
            Pen pen = new Pen(Color.Red, 1);
            g.Clear(Color.White);
            int x = 0;
            int y = 0;
            for (x = 0; x < 16; x++)
            {
                for (y = 0; y < 16; y++)
                {
                    if (displayMemory[x, y] % 10 != 0)
                    {
                        g.DrawRectangle(pen, x * 10, y * 10, 8, 8);
                    }
                }
            }
            g.Dispose();
        }

        //从值为0的坐标中随机获取一个坐标
        private int[] getRandnum()
        {
            Random aa=new Random();
            int numx=aa.Next(16);
            int numy=aa.Next(16);
            int i = 0;
            int[] back=new int[2];
            while(i<10000)
            {
                numx=aa.Next(16);
                numy=aa.Next(16);
                if (displayMemory[numx, numy] == 0)
                {
                    back[0] = numx;
                    back[1] = numy;
                    label1.Text = i.ToString();
                    return back;
                }
                i++;
            }
            back[0] = 100;
            back[1] = 100;
            return back;
        }

        private void timerRefresh_Tick(object sender, EventArgs e)
        {
            refreshDisplay();
        }

        private void timer1Step_Tick(object sender, EventArgs e)
        {
            //int[] a = getRandnum();
            //displayMemory[a[0], a[1]] = 1;
            go1Step();
        }

        private void snakeInit()
        {
            direct = Keys.Right;
            displayMemory[1, 1] = 11;
            displayMemory[2, 1] = 11;
            displayMemory[3, 1] = 11;
            displayMemory[4, 1] = 11;

        }

        private int go1Step()
        {
            if (headX > 15 || headX < 0 || headY > 15 || headX < 0)
            {
                timer1Step.Enabled = false;
                MessageBox.Show("GAME OVER!");
                return 2;
            }
            if (displayMemory[headX, headY] == 11)
            {
                headX += 1;
                headY = headY;
            }
            else if (displayMemory[headX, headY] == 21)
            {
                headX -= 1;
                headY = headY;
            }
            else if (displayMemory[headX, headY] == 41)
            {
                headX = headX;
                headY += 1;
            }
            else if (displayMemory[headX, headY] == 81)
            {
                headX = headX;
                headY -= 1;
            }

            if (displayMemory[endX, endY] == 11)
            {
                if (adjust() == 0)
                {
                    endX += 1;
                    endY = endY;
                }
            }
            else if (displayMemory[endX, endY] == 21)
            {
                if (adjust() == 0)
                {
                    endX -= 1;
                    endY = endY;
                }
            }
            else if (displayMemory[endX, endY] == 41)
            {
                if (adjust() == 0)
                {
                    endX = endX;
                    endY += 1;
                }
            }
            else if (displayMemory[endX, endY] == 81)
            {
                if (adjust() == 0)
                {
                    endX = endX;
                    endY -= 1;
                }
            }

            if (direct == Keys.Up)
            {
                displayMemory[headX, headY] = 81;
            }
            else if (direct == Keys.Down)
            {
                displayMemory[headX, headY] = 41;
            }
            else if (direct == Keys.Left)
            {
                displayMemory[headX, headY] = 21;
            }
            else if (direct == Keys.Right)
            {
                displayMemory[headX, headY] = 11;
            }

            return 0;
        }

        private int adjust()
        {
            if (headX > 15 || headX < 0 || headY > 15 || headY < 0)
            {
                timer1Step.Enabled = false;
                MessageBox.Show("GAME OVER!");
                return 2;
            }
            else if (displayMemory[headX, headY] == 2)
            {
                int[] a = getRandnum();
                displayMemory[a[0], a[1]] = 2;
                return 2;
            }
            else if (displayMemory[headX, headY] % 10 == 1)
            {
                timer1Step.Enabled = false;
                MessageBox.Show("GAME OVER!");
                return 2;
            }
            else
            {
                displayMemory[endX, endY] = 0;
                return 0;
            }
        }

        private void pictureBox1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
 
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (direct == Keys.Up && e.KeyCode == Keys.Down)
            {
                return;
            }
            if (direct == Keys.Down && e.KeyCode == Keys.Up)
            {
                return;
            }
            if (direct == Keys.Left && e.KeyCode == Keys.Right)
            {
                return;
            }
            if (direct == Keys.Right && e.KeyCode == Keys.Left)
            {
                return;
            }
            direct = e.KeyCode;
            go1Step();
        }

    }
}
