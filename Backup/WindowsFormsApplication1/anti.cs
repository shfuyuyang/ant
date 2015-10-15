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
    public partial class anti : Form
    {
        public anti()
        {
            InitializeComponent();
        }

        int systemState = 0;      //系统状态定义  0为初始状态，1为设置障碍，2为清除障碍，3为设置起点，4为设置终点

        public int[,] map=new int[60,40];      //存储地图信息，1001表示障碍，1002表示什么都没有，1003表示起点，1004表示终点，1000以下的数字表示信息素的浓度，浓度越高，信息素越强烈
        int startX = 0;             //起点X坐标
        int startY = 0;             //起点Y坐标
        int goalX = 59;             //终点X坐标
        int goalY = 39;             //终点Y坐标


        #region 蚂蚁属性

        int antiView = 1;           //蚂蚁视野，默认为1
        int antiCount = 10;         //蚂蚁数量

        #endregion

        #region 初始化画网格

        private void displayInit()
        {
            Image image = new Bitmap(600, 400);
            Graphics g = pictureBox1.CreateGraphics();
            Pen pen = new Pen(Color.Gray, 1);
            g.Clear(Color.White);
            int x = 0;
            int y = 0;
            for (x = 0; x <= 600; x++)
            {
                if (x % 10 == 0)
                {
                    g.DrawLine(pen, x, 0, x, 400);
                }
            }
            for (y = 0; y <= 400; y++)
            {
                if (y % 10 == 0)
                {
                    g.DrawLine(pen, 0, y, 600, y);
                }
            }
            g.Dispose();
            map = new int[60, 40];                          //map数据清空
            map[0, 0] = 1003;
            map[58, 38] = 1004;
            drawPointOnNet(Brushes.Green, 0, 0);            //绘制起点
            drawPointOnNet(Brushes.Red, 59, 39);            //绘制终点
        }

        #endregion

        #region 按键操作

        private void buttonSetHinder_Click(object sender, EventArgs e)
        {
            buttonSetHinder.Text = "设置障碍*";
            buttonClearHinder.Text = "清除障碍";
            buttonSetStart.Text = "设置起点";
            buttonSetGoal.Text = "设置终点";
            systemState = 1;
        }

        private void buttonClearHinder_Click(object sender, EventArgs e)
        {
            buttonSetHinder.Text = "设置障碍";
            buttonClearHinder.Text = "清除障碍*";
            buttonSetStart.Text = "设置起点";
            buttonSetGoal.Text = "设置终点";
            systemState = 2;
        }

        private void buttonSetStart_Click(object sender, EventArgs e)
        {
            buttonSetHinder.Text = "设置障碍";
            buttonClearHinder.Text = "清除障碍";
            buttonSetStart.Text = "设置起点*";
            buttonSetGoal.Text = "设置终点";
            systemState = 3;
        }

        private void buttonSetGoal_Click(object sender, EventArgs e)
        {
            buttonSetHinder.Text = "设置障碍";
            buttonClearHinder.Text = "清除障碍";
            buttonSetStart.Text = "设置起点";
            buttonSetGoal.Text = "设置终点*";
            systemState = 4;
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            displayInit();
            buttonSetHinder.Text = "设置障碍";
            buttonClearHinder.Text = "清除障碍";
            buttonSetStart.Text = "设置起点";
            buttonSetGoal.Text = "设置终点";
            systemState = 0;                    //清空当前状态
            startX = 0;
            startY = 0;
            goalX = 59;
            goalY = 39;
        }
        #endregion

        #region 在网格上画一个点

        //在网格上画一个点
        //参数：col:该点的颜色     x:点的x坐标（最大59，最小1）     y:点的y坐标（最大39，最小1）
        //返回值：true:画点成功        false:画点失败
        private bool drawPointOnNet(Brush col,int x,int y)
        {
            try
            {
                Image image = new Bitmap(600, 400);
                Brush br = col;
                Graphics g = pictureBox1.CreateGraphics();
                Pen pen = new Pen(Color.Black, 1);
                g.FillRectangle(br, (x * 10) + 1, (y * 10) + 1, 9, 9);
                g.Dispose();
                return true;
            }
            catch
            {
                return false;
            }
        }

        #endregion

        #region 鼠标画点

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            mouseEvent(e);
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            mouseEvent(e);
        }

        private void mouseEvent(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (e.X >= 600 || e.Y >= 400 || e.X <= 0 || e.Y <= 0)
                {
                    return;
                }
                if (systemState == 1)                       //障碍物
                {
                    if (map[e.X / 10, e.Y / 10] != 1003 && map[e.X / 10, e.Y / 10] != 1004)
                    {
                        drawPointOnNet(Brushes.Black, e.X / 10, e.Y / 10);
                        map[e.X / 10, e.Y / 10] = 1001;
                    }
                }
                else if (systemState == 2)                  //空白地区
                {
                    if (map[e.X / 10, e.Y / 10] == 1001)
                    {
                        drawPointOnNet(Brushes.White, e.X / 10, e.Y / 10);
                        map[e.X / 10, e.Y / 10] = 1002;
                    }
                }
                else if (systemState == 3)                  //起点
                {
                    if (map[e.X / 10, e.Y / 10] != 1004)
                    {
                        drawPointOnNet(Brushes.White, startX, startY);      //清空之前起点坐标
                        map[startX, startY] = 1002;
                        drawPointOnNet(Brushes.Green, e.X / 10, e.Y / 10);
                        map[e.X / 10, e.Y / 10] = 1003;
                        startX = e.X / 10;                  //设置新的起点坐标
                        startY = e.Y / 10;
                        labelStartPoint.Text = "起点：" + startX.ToString() + "," + startY.ToString();
                    }
                }
                else if (systemState == 4)                  //终点
                {
                    if (map[e.X / 10, e.Y / 10] != 1003)
                    {
                        drawPointOnNet(Brushes.White, goalX, goalY);      //清空之前起点坐标
                        map[goalX, goalY] = 1002;
                        drawPointOnNet(Brushes.Red, e.X / 10, e.Y / 10);
                        map[e.X / 10, e.Y / 10] = 1004;
                        goalX = e.X / 10;                  //设置新的起点坐标
                        goalY = e.Y / 10;
                        labelGoalPoint.Text = "终点：" + goalX.ToString() + "," + goalY.ToString();
                    }
                }
            }
        }

        #endregion

        private void buttonStart_Click(object sender, EventArgs e)
        {
            Random rantool = new Random();
            buttonStart.Text = rantool.Next(2).ToString();
        }

        #region 行为代码

        public void antiGo(oneAnti anti)
        {
            Random rantool = new Random();
            int distur = rantool.Next(100);             //计算当前的环境干扰
            if (anti.direct == 0)
            {
                anti.direct = rantool.Next(4) + 1;
            }
            else if (anti.direct == 1 && distur < anti.disturbance)  //向上
            {
                if (anti.antiY - 1 >= 0)
                {
                    
                }
            }
            else if (anti.direct == 2 && distur < anti.disturbance)  //向下
            {

            }
            else if (anti.direct == 3 && distur < anti.disturbance)  //向左
            {

            }
            else if (anti.direct == 4 && distur < anti.disturbance)  //向右
            {

            }
        }

        #endregion

    }

    public partial class oneAnti
    {
        public int antiX=0;         //蚂蚁当前位置X
        public int antiY=0;         //蚂蚁当前位置Y
        public int state = 1;       //状态，1为出去，2为回来
        public int direct = 0;      //前进方向，1234分别为上下左右
        public int disturbance = 5; //扰动系数，即下一步不按行动规则行动的概率，最大为100.
    }



}
