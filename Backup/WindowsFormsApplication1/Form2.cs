using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace WindowsFormsApplication1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            Control.CheckForIllegalCrossThreadCalls = false;            //允许跨线程访问
            InitializeComponent();
        }

        int[] numAuto = new int[7];
        int[] numCheck = new int[7];
        long count = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                numCheck[0] = int.Parse(textBox1.Text);
                numCheck[1] = int.Parse(textBox2.Text);
                numCheck[2] = int.Parse(textBox3.Text);
                numCheck[3] = int.Parse(textBox4.Text);
                numCheck[4] = int.Parse(textBox5.Text);
                numCheck[5] = int.Parse(textBox6.Text);
                numCheck[6] = int.Parse(textBox7.Text);
            }
            catch
            {
                MessageBox.Show("选号格式不正确！");
                return;
            }
            timer1.Enabled = true;
            Thread a = new Thread(st);
            a.Start();

        }

        #region 自动选号

        private void fullNumAuto()
        {
            Random a = new Random();
            label1.Text = null;
            Array.Clear(numAuto, 0, 7);
            int temp = a.Next(36);
            int temp0 = a.Next(36);
            numAuto[0] = temp0;
            for (int i = 0; i < 7; i++)
            {
                temp = a.Next(36);
                while (numAuto[i]==0)
                {
                    temp = a.Next(36);
                    for (int j = 0; j <= i; j++)
                    {
                        if (numAuto[j] == temp)
                        {
                            temp = a.Next(36);
                            break;
                        }
                        if (j == i)
                        {
                            numAuto[i] = temp;
                        }
                    }
                }
            }
            for (int i = 0; i < 7; i++)
            {
                label1.Text += numAuto[i].ToString() + "  ";
            }
        }

        #endregion

        #region 自动手动对比

        private bool ifSame()
        {
            int sameCount = 0;
            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    if (numCheck[i] == numAuto[j])
                    {
                        sameCount++;
                        break;
                    }
                }
            }
            if (sameCount == 7)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion

        private void st()
        {
            while (ifSame() == false)
            {
                fullNumAuto();
                count++;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label2.Text = count.ToString();
        }
    }
}
