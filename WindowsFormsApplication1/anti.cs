using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace WindowsFormsApplication1
{
    public partial class anti : Form
    {
        public anti()
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
        }

        private void fun(int a)
        {
            a = 2;
        }

        State systemState = State.nothing;                  //表示当前系统正在进行哪种设置

        public oneBlock[,] map = new oneBlock[60, 40];      //存储地图信息，1001表示障碍，1002表示什么都没有，1003表示起点，1004表示终点，1000表示一只蚂蚁，1000以下的数字表示信息素的浓度大于，浓度越高，信息素越强烈
        public oneAnti[] allAnti=new oneAnti[50];   //存储当前环境中的全部蚂蚁，上限为50只
        public int systemRunTime = 0;           //系统运行时间，毫秒
        public State specialNum = State.nullVal;              //特殊查看数据
        public const int maxInfo = 10000;
        int startX = 0;             //起点X坐标
        int startY = 0;             //起点Y坐标
        int goalX = 59;             //终点X坐标
        int goalY = 39;             //终点Y坐标
        List<mapPoint> shortestLine;

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
            map = new oneBlock[60, 40];                          //map数据清空
            for (int i = 0; i < 60; i++)
            {
                for (int j = 0; j < 40; j++)
                {
                    map[i, j] = new oneBlock();
                    map[i, j].state = State.nothing;
                }
            }
            map[0, 0].state = State.start;
            map[59, 39].state = State.goal;
            drawPointOnNet(Brushes.Green, 0, 0);            //绘制起点
            drawPointOnNet(Brushes.Red, 59, 39);            //绘制终点

            for (int i = 0; i < allAnti.Length; i++)
            {
                allAnti[i] = new oneAnti();
            }
        }

        #endregion

        #region 按键操作

        private void buttonSetHinder_Click(object sender, EventArgs e)
        {
            buttonSetHinder.Text = "设置障碍*";
            buttonClearHinder.Text = "清除障碍";
            buttonSetStart.Text = "设置起点";
            buttonSetGoal.Text = "设置终点";
            systemState = State.hinder;
        }

        private void buttonClearHinder_Click(object sender, EventArgs e)
        {
            buttonSetHinder.Text = "设置障碍";
            buttonClearHinder.Text = "清除障碍*";
            buttonSetStart.Text = "设置起点";
            buttonSetGoal.Text = "设置终点";
            systemState = State.nothing;
        }

        private void buttonSetStart_Click(object sender, EventArgs e)
        {
            buttonSetHinder.Text = "设置障碍";
            buttonClearHinder.Text = "清除障碍";
            buttonSetStart.Text = "设置起点*";
            buttonSetGoal.Text = "设置终点";
            systemState = State.start;
        }

        private void buttonSetGoal_Click(object sender, EventArgs e)
        {
            buttonSetHinder.Text = "设置障碍";
            buttonClearHinder.Text = "清除障碍";
            buttonSetStart.Text = "设置起点";
            buttonSetGoal.Text = "设置终点*";
            systemState = State.goal;
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
                //Image image = new Bitmap(600, 400);
                Brush br = col;
                Graphics g = pictureBox1.CreateGraphics();
                Pen pen = new Pen(Color.Black, 1);
                g.FillRectangle(br, (x * 10) + 1, (y * 10) + 1, 9, 9);
                g.Dispose();
                //pen.Dispose();
                //br.Dispose();
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
                if (systemState == State.hinder)                       //障碍物
                {
                    if (map[e.X / 10, e.Y / 10].state != State.start && map[e.X / 10, e.Y / 10].state!=State.goal)
                    {
                        drawPointOnNet(Brushes.Black, e.X / 10, e.Y / 10);
                        map[e.X / 10, e.Y / 10].state = State.hinder;
                    }
                }
                else if (systemState == State.nothing)                  //空白地区
                {
                    if (map[e.X / 10, e.Y / 10].state==State.hinder)
                    {
                        drawPointOnNet(Brushes.White, e.X / 10, e.Y / 10);
                        map[e.X / 10, e.Y / 10].state = State.nothing;
                    }
                }
                else if (systemState == State.start)                  //起点
                {
                    if (map[e.X / 10, e.Y / 10].state != State.goal)
                    {
                        drawPointOnNet(Brushes.White, startX, startY);      //清空之前起点坐标
                        map[startX, startY].state = State.nothing;
                        drawPointOnNet(Brushes.Green, e.X / 10, e.Y / 10);
                        map[e.X / 10, e.Y / 10].state = State.start;
                        startX = e.X / 10;                  //设置新的起点坐标
                        startY = e.Y / 10;
                        labelStartPoint.Text = "起点：" + startX.ToString() + "," + startY.ToString();
                        for (int j = 0; allAnti[j].enable == true; j++)
                        {
                            allAnti[j].antiX = startX;
                            allAnti[j].antiY = startY;
                        }
                    }
                }
                else if (systemState == State.goal)                  //终点
                {
                    if (map[e.X / 10, e.Y / 10].state != State.start)
                    {
                        drawPointOnNet(Brushes.White, goalX, goalY);      //清空之前终点坐标
                        map[goalX, goalY].state = State.nothing;
                        drawPointOnNet(Brushes.Red, e.X / 10, e.Y / 10);
                        map[e.X / 10, e.Y / 10].state = State.goal;
                        goalX = e.X / 10;                  //设置新的终点坐标
                        goalY = e.Y / 10;
                        labelGoalPoint.Text = "终点：" + goalX.ToString() + "," + goalY.ToString();
                    }
                }
            }
        }

        #endregion

        #region 刷新网格显示
        /// <summary>
        /// 刷新网格显示
        /// </summary>
        private void displayRefresh()
        {
            Color col = Color.White;

            markState(State.hinder, Color.Black);
            markState(State.goal, Color.Red);
            markState(State.start, Color.Green);
            markState(State.nothing, Color.White);
            markState(State.anti, Color.Blue);
            if (checkBoxSearchVal.Checked == true)
            {
                markState(false, State.nothing);
            }
            if (checkBoxBackVal.Checked == true)
            {
                markState(true, State.nothing);
            }
            for (int k = 0; allAnti[k].enable == true; k++)
            {
                //drawPointOnNet(Brushes.Blue, allAnti[k].antiX, allAnti[k].antiY);
            }
        }

        private void displayRefresh(bool anti)
        {
            for (int k = 0; allAnti[k].enable == true; k++)
            {
                drawPointOnNet(Brushes.Blue, allAnti[k].antiX, allAnti[k].antiY);
            }
        }

        private void markState(State sta, Color col)
        {
            SolidBrush bru = new SolidBrush(col);
            for (int i = 0; i < 60; i++)
            {
                for (int j = 0; j < 40; j++)
                {
                    if (map[i, j].state == sta)
                    {
                        drawPointOnNet(bru, i, j);
                    }
                }
            }
        }

        private void markState(bool ifFind,State sta)
        {
            SolidBrush bru;
            float colval = 0;
            for (int i = 0; i < 60; i++)
            {
                for (int j = 0; j < 40; j++)
                {
                    if (ifFind == true && map[i, j].state == sta)
                    {
                        colval = 255 - map[i, j].backValue / 4;
                        bru = new SolidBrush(Color.FromArgb(colval < 0 ? 0 : (int)colval, colval < 0 ? 0 : (int)colval, 255));
                        drawPointOnNet(bru, i, j);
                    }
                    else if(ifFind == false && map[i, j].state == sta)
                    {
                        colval = 255 - map[i, j].searchValue / 4;
                        bru = new SolidBrush(Color.FromArgb(colval < 0 ? 0 : (int)colval, colval < 0 ? 0 : (int)colval, 255));
                        drawPointOnNet(bru, i, j);
                    }
                }
            }
        }

        private void drawLine(List<mapPoint> line,Color col)
        {
            SolidBrush br = new SolidBrush(col);
            Graphics g = pictureBox1.CreateGraphics();
            Pen pen = new Pen(col, 1);
            for (int i = 0; i < line.Count; i++)
            {
                g.FillRectangle(br, (line[i].pointX * 10) + 4, (line[i].pointY * 10) + 4, 3, 3);
                if (i != 0)
                {
                    g.DrawLine(pen, line[i - 1].pointX * 10 + 5, line[i - 1].pointY * 10 + 5, line[i].pointX * 10 + 5, line[i].pointY * 10 + 5);
                }
                Thread.Sleep(10);
            }
            g.Dispose();
        }

        #endregion

        #region 按下开始键

        /// <summary>
        /// 按下开始键
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonStart_Click(object sender, EventArgs e)
        {
            //Random rantool = new Random();
            //buttonStart.Text = rantool.Next(2).ToString();
            //displayRefresh();


            Thread a = new Thread(sysClk);
            a.Start();
            timerDisplayRefresh.Enabled = true;
        }

        #endregion

        #region 行为代码

        /// <summary>
        /// 蚂蚁按照自身属性进行一格移动
        /// </summary>
        /// <param name="anti">蚂蚁的实例</param>
        /// <returns></returns>
        public Runresult antiGo(oneAnti anti)
        {
            //先检测周围是否有起点或终点
            State temp=ifGoalAndStart(anti);
            if (temp == State.goal && anti.ifFind == false)
            {
                return Runresult.arriveGoal;
            }
            else if (temp == State.start && anti.ifFind == true)
            {
                return Runresult.arriveStart;
            }

            #region 没有检测到起点或终点

            Runresult goResult = ifCanGo(anti, anti.direct);
            if (goResult == Runresult.success)
            {
                if (map[anti.antiX, anti.antiY].state == State.anti)
                {
                    map[anti.antiX, anti.antiY].state = State.nothing;          //清空蚂蚁所在点的状态
                }
                if (anti.direct == Direct.up)
                {
                    anti.antiY = anti.antiY - 1;
                }
                else if (anti.direct == Direct.down)
                {
                    anti.antiY = anti.antiY + 1;
                }
                else if (anti.direct == Direct.left)
                {
                    anti.antiX = anti.antiX - 1;
                }
                else if (anti.direct == Direct.rigth)
                {
                    anti.antiX = anti.antiX + 1;
                }
                else if (anti.direct == Direct.upLeft)
                {
                    anti.antiX = anti.antiX - 1;
                    anti.antiY = anti.antiY - 1;
                }
                else if (anti.direct == Direct.upRight)
                {
                    anti.antiX = anti.antiX + 1;
                    anti.antiY = anti.antiY - 1;
                }
                else if (anti.direct == Direct.downLeft)
                {
                    anti.antiX = anti.antiX - 1;
                    anti.antiY = anti.antiY + 1;
                }
                else if (anti.direct == Direct.downRight)
                {
                    anti.antiX = anti.antiX + 1;
                    anti.antiY = anti.antiY + 1;
                }
                anti.steps++;                                               //步数加一
                map[anti.antiX, anti.antiY].state = State.anti;             //将地图上蚂蚁位置进行标注
                mapPoint tempPoint = new mapPoint(anti.antiX, anti.antiY);
                anti.linePoint.Add(tempPoint);                              //将走过的点加入线路中
                anti.movedPoint.Add(tempPoint);
                return Runresult.success;
            }
            else if (goResult == Runresult.haveGone)
            {
                return Runresult.haveGone;
            }
            else
            {
                return Runresult.overstepBoundary;
            }
            #endregion 
        }

        //当蚂蚁走投无路时退后一格
        public void antiBack(oneAnti anti)
        {
            map[anti.antiX, anti.antiY].state = State.nothing;
            anti.antiX = anti.linePoint[anti.linePoint.Count - 2].pointX;
            anti.antiY = anti.linePoint[anti.linePoint.Count - 2].pointY;
            map[anti.antiX, anti.antiY].state = State.anti;
            anti.linePoint.RemoveAt(anti.linePoint.Count - 1);
            anti.steps--;
        }

        /// <summary>
        /// 某只蚂蚁是否可以在某个方向上走一格
        /// </summary>
        /// <param name="anti"></param>
        /// <param name="dir"></param>
        /// <returns></returns>
        public Runresult ifCanGo(oneAnti anti, Direct dir)
        {
            int x0 = anti.antiX;
            int y0 = anti.antiY;
            int x1 = 0;
            int y1 = 0;
            if (dir == Direct.up)
            {
                x1 = x0;
                y1 = y0 - 1;
            }
            else if (dir == Direct.down)
            {
                x1 = x0;
                y1 = y0 + 1;
            }
            else if (dir == Direct.left)
            {
                x1 = x0 - 1;
                y1 = y0;
            }
            else if (dir == Direct.rigth)
            {
                x1 = x0 + 1;
                y1 = y0;
            }
            else if (dir == Direct.upLeft)
            {
                x1 = x0 - 1;
                y1 = y0 - 1;
            }
            else if (dir == Direct.upRight)
            {
                x1 = x0 + 1;
                y1 = y0 - 1;
            }
            else if (dir == Direct.downLeft)
            {
                x1 = x0 - 1;
                y1 = y0 + 1;
            }
            else if (dir == Direct.downRight)
            {
                x1 = x0 + 1;
                y1 = y0 + 1;
            }
            if (x1 <= 59 && x1 >= 0 && y1 >= 0 && y1 <= 39 &&   //目标坐标不能超范围
                (map[x1, y1].state == State.nothing || map[x1, y1].state == State.anti) &&           //目标坐标状态必须是nothing
                //通往目标坐标的路径上必须是nothing goal start之一
                (map[x1, y0].state == State.nothing || map[x1, y0].state == State.goal || map[x1, y0].state == State.start || map[x0, y1].state == State.nothing || map[x0, y1].state == State.goal || map[x0, y1].state == State.start) &&
                ifMoved(anti, x1, y1) == false)
            {
                return Runresult.success;
            }
            else if (x1 <= 59 && x1 >= 0 && y1 >= 0 && y1 <= 39 && ifMoved(anti, x1, y1) == true)
            {
                return Runresult.haveGone;
            }
            else
            {
                return Runresult.overstepBoundary;
            }
        }

        public bool ifMoved(oneAnti anti, int x, int y)
        {
            mapPoint point = new mapPoint(x, y);
            for (int i = 0; i < anti.movedPoint.Count; i++)
            {
                if (anti.movedPoint[i].pointX == point.pointX && anti.movedPoint[i].pointY == point.pointY)
                {
                    return true;
                }
            }
            return false;
        }

        #region 在可探测的3*3范围内是否有终点或起点

        public State ifGoalAndStart(oneAnti anti)
        {
            int i, j;
         
            for (i = -1; i < 2; i++)
            {
                for (j = -1; j < 2; j++)
                {
                    if (anti.antiX + i > 59 || anti.antiX + i < 0 || anti.antiY + j > 39 || anti.antiY + j < 0)
                    {

                    }
                    else if (map[anti.antiX + i, anti.antiY + j].state == State.goal)
                    {
                        return State.goal;
                    }
                    else if (map[anti.antiX + i, anti.antiY + j].state == State.start)
                    {
                        return State.start;
                    }
                }
            }
            return State.nothing;
        }

        #endregion

        /// <summary>
        /// 判断该蚂蚁是否走过某个点，蚂蚁最多只能记住走过的10个点
        /// </summary>
        /// <param name="anti"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public bool crossed(oneAnti anti, int x, int y)
        {
            for (int i = 0; i < anti.crossPiont.Length; i++)
            {
                if (anti.crossPiont[i].pointX == x && anti.crossPiont[i].pointY == y)
                {
                    return true;
                }
            }
            return false;
        }

        public void memoryPoint(oneAnti anti, int x, int y)
        {
            anti.crossPoint_i += 1;
            anti.crossPiont[anti.crossPoint_i].pointX = x;
            anti.crossPiont[anti.crossPoint_i].pointY = y;
        }

        public void clearMemory(oneAnti anti)
        {
            for (int i = 0; i < anti.crossPiont.Length; i++)
            {
                anti.crossPiont[i] = new mapPoint();
            }
            anti.crossPoint_i = 0;
        }

        /// <summary>
        /// 蚂蚁周围信息素的轮盘选择算法
        /// </summary>
        /// <param name="anti"></param>
        /// <returns></returns>
        public Direct detectEnvironment(oneAnti anti)
        {
            int counts = 0;     //方向计数器
            int sum = 0;
            int[] valTable = new int[9];        //用来存储9个方格中的信息素值
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    int xTemp = anti.antiX + i - 1;
                    int yTemp = anti.antiY + j - 1;
                    if (xTemp >= 0 && xTemp <= 59 && yTemp >= 0 && yTemp <= 39 && (map[xTemp, yTemp].state == State.nothing || map[xTemp, yTemp].state == State.anti) && ifMoved(anti, xTemp, yTemp) == false && (i * 3 + j) != 4)
                    {
                        counts++;
                        int val = 0;
                        if (anti.ifFind == true)
                        {
                            //为了保证没有信息素的点也有在轮盘中被选中的可能，故信息素为0时，按1算
                            val = map[xTemp, yTemp].backValue == 0 ? 1 : (int)map[xTemp, yTemp].backValue;
                        }
                        else
                        {
                            val = map[xTemp, yTemp].searchValue == 0 ? 1 : (int)map[xTemp, yTemp].searchValue;
                        }
                        sum += val;
                        //一种三进制计序法，用 i*3+j 来表示当前3*3方格中的某格是从左到右从上到下数的第几个格，从0开始最大为8
                        valTable[i * 3 + j] = val;
                    }
                }
            }

            Random ran = new Random();
            int ranNum=ran.Next(1, 10);
            int temp = ranNum * 10 + ranNum;
            while (temp-- > 0) ;
            if (counts == sum && sum != 0 && /*anti.direct != Direct.nop && */ranNum != 4)          //如果每个点的信息素都为1那么就返回空值
            {
                return anti.direct;
                //return getRanDirect(anti);
            }
            else if (ranNum == 4)
            {
                return getRanDirect(anti);
            }
            if (sum == 0)
            {
                return Direct.nop;
            }

            int stopPointer = ran.Next(1, sum);         //定义一个轮盘指针,表示指针将停止的位置
            int k = 0;
            while (stopPointer > 0)
            {
                if (k == 9)
                {
                    k = 0;
                }
                if (k != 4)
                {
                    stopPointer -= valTable[k];
                }
                k++;
            }
            Direct back = Direct.nop;
            switch (k - 1)
            {
                case 0: back = Direct.upLeft; break;
                case 1: back = Direct.left; break;
                case 2: back = Direct.downLeft; break;
                case 3: back = Direct.up; break;
                //case 4: back = Direct.nop; break;
                case 5: back = Direct.down; break;
                case 6: back = Direct.upRight; break;
                case 7: back = Direct.rigth; break;
                case 8: back = Direct.downRight; break;
            }
            return back;
        }

        public Direct getRanDirect(oneAnti anti)
        {
            Direct[] table = { Direct.up,
                                 Direct.down, 
                                 Direct.left, 
                                 Direct.rigth, 
                                 Direct.upLeft, 
                                 Direct.upRight, 
                                 Direct.downLeft, 
                                 Direct.downRight };
            Direct[] back=new Direct[8];
            int i = 0;
            int j = 0;
            while (j == 0)
            {
                for (i = 0; i < table.Length; i++)
                {
                    if (ifCanGo(anti, table[i]) == Runresult.success)
                    {
                        back[j++] = table[i];
                    }
                }
                if (j == 0)
                {
                    try
                    {
                        map[anti.antiX, anti.antiY].state = State.nothing;
                        anti.antiX = anti.linePoint[anti.linePoint.Count - 2].pointX;
                        anti.antiY = anti.linePoint[anti.linePoint.Count - 2].pointY;
                        map[anti.antiX, anti.antiY].state = State.anti;
                        anti.linePoint.RemoveAt(anti.linePoint.Count - 1);
                        anti.steps--;
                    }
                    catch 
                    {
                        MessageBox.Show("走过"+anti.movedPoint.Count.ToString()+"个点后发现路全被堵死了，过不去！");
                        return Direct.nop;
                    }
                }
            }

            Random ran = new Random();

            return back[ran.Next(0, j)];
        }

        public void sysClk()
        {
            Random ran = new Random();
            Runresult result = 0;
            Direct direct = 0;
            bool thisIsFind = true;                 //表示本轮是正在搜索食物还是返回，true表示正在找食物
            int time = 500;
            progressBarSys.Minimum=0;
            progressBarSys.Maximum = time;
            while (time-->0)
            {
                while (allAnti[0].ifFind==false)
                {
                    for (int i = 0; allAnti[i].enable == true; i++)
                    {
                        if (allAnti[i].ifFind == thisIsFind)
                        {
                            continue;
                        }
                        direct = detectEnvironment(allAnti[i]);
                        //direct = getRanDirect(allAnti[i]);
                        if (direct != Direct.nop)
                        {
                            allAnti[i].direct = direct;
                        }
                        result = antiGo(allAnti[i]);
                        if (result == Runresult.overstepBoundary || result == Runresult.noActive || result == Runresult.haveGone)        //越界或未激活
                        {
                            allAnti[i].direct = getRanDirect(allAnti[i]);
                            if (allAnti[i].direct == Direct.nop)
                            {
                                return;
                            }
                        }
                        else if (result == Runresult.arriveGoal)                   //到达终点
                        {
                            if (allAnti[i].ifFind == false)
                            {
                                allAnti[i].ifFind = true;
                            }
                            allAnti[i].antiX = 0;
                            allAnti[i].antiY = 0;
                            timerDisplayRefresh.Enabled = false;
                            //drawLine(allAnti[i].linePoint, Color.Gray);
                            //timerDisplayRefresh.Enabled = true;
                            label2.Text = "路线长度：" + allAnti[i].linePoint.Count.ToString();
                            label3.Text = "探测位置数：" + allAnti[i].movedPoint.Count.ToString();
                            //return;
                            if (shortestLine==null||allAnti[i].linePoint.Count < shortestLine.Count)
                            {
                                shortestLine = new List<mapPoint>(allAnti[i].linePoint);
                            }
                        }
                        else if (result == Runresult.arriveStart)                   //回到起点
                        {
                            if (allAnti[i].ifFind == true)
                            {
                                allAnti[i].ifFind = false;
                            }
                            //timerDisplayRefresh.Enabled = false;
                            //drawLine(allAnti[i].linePoint, Color.Gray);
                            //timerDisplayRefresh.Enabled = true;
                            if (shortestLine == null || allAnti[i].linePoint.Count < shortestLine.Count)
                            {
                                shortestLine = new List<mapPoint>(allAnti[i].linePoint);
                            }
                        }
                    }
                }
                environmentDec();
                sendinfo();
                allAnti[0].ifFind = false;
                //Thread.Sleep(1);
                //displayRefresh(true);
                progressBarSys.Value = 500-time;
            }
            timerDisplayRefresh.Enabled = false;
            MessageBox.Show("完成");
            displayRefresh();
            drawLine(shortestLine, Color.Gray);
            
        }

        public void sendinfo()
        {
            for (int i = 0; allAnti[i].enable == true; i++)
            {
                for (int j = 0; j < allAnti[i].linePoint.Count; j++)
                {
                    if (allAnti[i].ifFind == true)
                    {
                        map[allAnti[i].linePoint[j].pointX, allAnti[i].linePoint[j].pointY].searchValue += (float)10000.0 / allAnti[i].steps;
                    }
                    else
                    {
                        map[allAnti[i].linePoint[j].pointX, allAnti[i].linePoint[j].pointY].backValue += (float)10000.0 / allAnti[i].steps;
                    }
                }
                allAnti[i].linePoint.Clear();
                allAnti[i].movedPoint.Clear();
                allAnti[i].steps = 0;
            }
        }

        public bool ifAllOk(bool thisFind)
        {
            for (int i = 0; allAnti[i].enable == true; i++)
            {
                if (allAnti[i].ifFind == thisFind)
                    return false;
            }
            return true;
        }

        //环境信息素衰减
        public void environmentDec()
        {
            for (int i = 0; i < 60; i++)
            {
                for (int j = 0; j < 40; j++)
                {
                    if (map[i, j].searchValue > 0)
                    {
                        map[i, j].searchValue =(float)(map[i, j].searchValue* 0.9);
                    }
                    if (map[i, j].backValue > 0)
                    {
                        map[i, j].backValue =(float)(map[i, j].searchValue* 0.9);
                    }
                }
            }
        }

        #endregion

        private void buttonAddAnti_Click(object sender, EventArgs e)
        {
            int i = 0;
            if (allAnti[49].enable == true)
            {
                MessageBox.Show("蚂蚁数目已达到上限（50只）！");
                return;
            }
            for (i = 0; i < 50 && allAnti[i].enable == true; i++) ;
            allAnti[i].enable = true;
            allAnti[i].antiX = startX;
            allAnti[i].antiY = startY;
            clearMemory(allAnti[i]);
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            displayRefresh();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            displayRefresh();
        }

        private void anti_Load(object sender, EventArgs e)
        {
            buttonClear_Click(null, null);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //specialNum = int.Parse(textBox1.Text);
            }
            catch
            {
                specialNum = 0;
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            environmentDec();
        }

        private void buttonTest_Click(object sender, EventArgs e)
        {
            oneAnti testAnti = new oneAnti();
            testAnti.antiX = 8;
            testAnti.antiY = 8;
            int upleft = 0;
            int up = 0;
            int upright = 0;
            int left = 0;
            int right = 0;
            int downleft = 0;
            int down = 0;
            int downright = 0;
            map[7, 7].searchValue = 10;
            map[8, 7].searchValue = 20;
            map[9, 7].searchValue = 30;
            map[7, 8].searchValue = 40;
            map[9, 8].searchValue = 50;
            map[7, 9].searchValue = 60;
            map[8, 9].searchValue = 70;
            map[9, 9].searchValue = 80;
            Direct resultdir = Direct.nop;
            for (int i = 0; i < 3600; i++)
            {
                resultdir = detectEnvironment(testAnti);
                if (resultdir == Direct.upLeft)
                {
                    upleft++;
                }
                else if (resultdir == Direct.up)
                {
                    up++;
                }
                else if (resultdir == Direct.upRight)
                {
                    upright++;
                }
                else if (resultdir == Direct.left)
                {
                    left++;
                }
                else if (resultdir == Direct.rigth)
                {
                    right++;
                }
                else if (resultdir == Direct.downLeft)
                {
                    downleft++;
                }
                else if (resultdir == Direct.down)
                {
                    down++;
                }
                else if (resultdir == Direct.downRight)
                {
                    downright++;
                }
                //else
                //{
                //    MessageBox.Show("BUG!");
                //    return;
                //}
            }
            MessageBox.Show("OVER!");
            return;
        }

    }

    public partial class oneAnti
    {
        public int antiX=0;         //蚂蚁当前位置X
        public int antiY=0;         //蚂蚁当前位置Y
        public int state = 1;       //状态，1为出去，2为回来
        public Direct direct = Direct.nop;
        public bool enable = false; //是否激活
        public bool ifFind = false; //是否找到目标
        public int allInfo = 10000; //蚂蚁所携带的信息素总量
        public mapPoint[] crossPiont = new mapPoint[10];
        public int steps = 0;       //蚂蚁所走过的步数，到达起点或终点后清零，步数越大，在整条路线上洒下的信息素越少
        public List<mapPoint> linePoint = new List<mapPoint>();    //走过的路线，去重
        public List<mapPoint> movedPoint = new List<mapPoint>();
        public bool[,] movedMap = new bool[60, 40];
        private int i = 0;
        public int crossPoint_i
        {
            set
            {
                i = value;
                if (i >= 10)
                {
                    i = 0;
                }
            }
            get
            {
                return i;
            }
        }
    }

    public partial class mapPoint
    {
        public int pointX = 0;
        public int pointY = 0;
        public mapPoint()
        {
            pointY = 0;
            pointX = 0;
        }
        public mapPoint(int x,int y)
        {
            pointX = x;
            pointY = y;
        }
        public mapPoint(mapPoint point)
        {
            pointX = point.pointX;
            pointY = point.pointY;
        }
    }

    public enum State { anti, hinder, start, goal, nothing,nullVal };
    public enum Runresult { success,overstepBoundary,noActive,arriveGoal,arriveStart,noDirect,haveGone};
    public enum Direct { up,down,left,rigth,upLeft,upRight,downLeft,downRight,nop,stayHere};

    public partial class oneBlock
    {
        public float searchValue = 0;
        public float backValue = 0;
        public State state = State.nothing;
    }



}
