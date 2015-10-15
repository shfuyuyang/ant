namespace WindowsFormsApplication1
{
    partial class anti
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
            System.Environment.Exit(0);             //强制结束所有线程
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.buttonSetHinder = new System.Windows.Forms.Button();
            this.buttonClearHinder = new System.Windows.Forms.Button();
            this.buttonSetStart = new System.Windows.Forms.Button();
            this.buttonSetGoal = new System.Windows.Forms.Button();
            this.buttonClear = new System.Windows.Forms.Button();
            this.labelStartPoint = new System.Windows.Forms.Label();
            this.labelGoalPoint = new System.Windows.Forms.Label();
            this.buttonStart = new System.Windows.Forms.Button();
            this.buttonAddAnti = new System.Windows.Forms.Button();
            this.buttonRefresh = new System.Windows.Forms.Button();
            this.timerDisplayRefresh = new System.Windows.Forms.Timer(this.components);
            this.labelRunTime = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBoxAntiSearch = new System.Windows.Forms.CheckBox();
            this.checkBoxAntiBack = new System.Windows.Forms.CheckBox();
            this.checkBoxSearchVal = new System.Windows.Forms.CheckBox();
            this.checkBoxBackVal = new System.Windows.Forms.CheckBox();
            this.checkBoxNoVal = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonTest = new System.Windows.Forms.Button();
            this.progressBarSys = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(1, 1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(601, 401);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            // 
            // buttonSetHinder
            // 
            this.buttonSetHinder.Location = new System.Drawing.Point(607, 12);
            this.buttonSetHinder.Name = "buttonSetHinder";
            this.buttonSetHinder.Size = new System.Drawing.Size(75, 23);
            this.buttonSetHinder.TabIndex = 1;
            this.buttonSetHinder.Text = "设置障碍";
            this.buttonSetHinder.UseVisualStyleBackColor = true;
            this.buttonSetHinder.Click += new System.EventHandler(this.buttonSetHinder_Click);
            // 
            // buttonClearHinder
            // 
            this.buttonClearHinder.Location = new System.Drawing.Point(607, 41);
            this.buttonClearHinder.Name = "buttonClearHinder";
            this.buttonClearHinder.Size = new System.Drawing.Size(75, 23);
            this.buttonClearHinder.TabIndex = 2;
            this.buttonClearHinder.Text = "清除障碍";
            this.buttonClearHinder.UseVisualStyleBackColor = true;
            this.buttonClearHinder.Click += new System.EventHandler(this.buttonClearHinder_Click);
            // 
            // buttonSetStart
            // 
            this.buttonSetStart.Location = new System.Drawing.Point(607, 70);
            this.buttonSetStart.Name = "buttonSetStart";
            this.buttonSetStart.Size = new System.Drawing.Size(75, 23);
            this.buttonSetStart.TabIndex = 3;
            this.buttonSetStart.Text = "设置起点";
            this.buttonSetStart.UseVisualStyleBackColor = true;
            this.buttonSetStart.Click += new System.EventHandler(this.buttonSetStart_Click);
            // 
            // buttonSetGoal
            // 
            this.buttonSetGoal.Location = new System.Drawing.Point(607, 99);
            this.buttonSetGoal.Name = "buttonSetGoal";
            this.buttonSetGoal.Size = new System.Drawing.Size(75, 23);
            this.buttonSetGoal.TabIndex = 4;
            this.buttonSetGoal.Text = "设置终点";
            this.buttonSetGoal.UseVisualStyleBackColor = true;
            this.buttonSetGoal.Click += new System.EventHandler(this.buttonSetGoal_Click);
            // 
            // buttonClear
            // 
            this.buttonClear.Location = new System.Drawing.Point(607, 128);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(75, 23);
            this.buttonClear.TabIndex = 5;
            this.buttonClear.Text = "重建";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // labelStartPoint
            // 
            this.labelStartPoint.AutoSize = true;
            this.labelStartPoint.Location = new System.Drawing.Point(605, 344);
            this.labelStartPoint.Name = "labelStartPoint";
            this.labelStartPoint.Size = new System.Drawing.Size(41, 12);
            this.labelStartPoint.TabIndex = 6;
            this.labelStartPoint.Text = "起点：";
            // 
            // labelGoalPoint
            // 
            this.labelGoalPoint.AutoSize = true;
            this.labelGoalPoint.Location = new System.Drawing.Point(605, 366);
            this.labelGoalPoint.Name = "labelGoalPoint";
            this.labelGoalPoint.Size = new System.Drawing.Size(41, 12);
            this.labelGoalPoint.TabIndex = 7;
            this.labelGoalPoint.Text = "终点：";
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(608, 186);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(75, 23);
            this.buttonStart.TabIndex = 8;
            this.buttonStart.Text = "开始";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // buttonAddAnti
            // 
            this.buttonAddAnti.Location = new System.Drawing.Point(608, 157);
            this.buttonAddAnti.Name = "buttonAddAnti";
            this.buttonAddAnti.Size = new System.Drawing.Size(75, 23);
            this.buttonAddAnti.TabIndex = 9;
            this.buttonAddAnti.Text = "增加一只蚂蚁";
            this.buttonAddAnti.UseVisualStyleBackColor = true;
            this.buttonAddAnti.Click += new System.EventHandler(this.buttonAddAnti_Click);
            // 
            // buttonRefresh
            // 
            this.buttonRefresh.Location = new System.Drawing.Point(608, 215);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new System.Drawing.Size(75, 23);
            this.buttonRefresh.TabIndex = 10;
            this.buttonRefresh.Text = "刷新显示";
            this.buttonRefresh.UseVisualStyleBackColor = true;
            this.buttonRefresh.Click += new System.EventHandler(this.buttonRefresh_Click);
            // 
            // timerDisplayRefresh
            // 
            this.timerDisplayRefresh.Interval = 5;
            this.timerDisplayRefresh.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // labelRunTime
            // 
            this.labelRunTime.AutoSize = true;
            this.labelRunTime.Location = new System.Drawing.Point(606, 388);
            this.labelRunTime.Name = "labelRunTime";
            this.labelRunTime.Size = new System.Drawing.Size(65, 12);
            this.labelRunTime.TabIndex = 11;
            this.labelRunTime.Text = "运行时间：";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(608, 320);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(74, 21);
            this.textBox1.TabIndex = 12;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(609, 302);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 13;
            this.label1.Text = "显示数值位置";
            // 
            // checkBoxAntiSearch
            // 
            this.checkBoxAntiSearch.AutoSize = true;
            this.checkBoxAntiSearch.Location = new System.Drawing.Point(689, 18);
            this.checkBoxAntiSearch.Name = "checkBoxAntiSearch";
            this.checkBoxAntiSearch.Size = new System.Drawing.Size(84, 16);
            this.checkBoxAntiSearch.TabIndex = 14;
            this.checkBoxAntiSearch.Text = "出发的蚂蚁";
            this.checkBoxAntiSearch.UseVisualStyleBackColor = true;
            // 
            // checkBoxAntiBack
            // 
            this.checkBoxAntiBack.AutoSize = true;
            this.checkBoxAntiBack.Location = new System.Drawing.Point(689, 41);
            this.checkBoxAntiBack.Name = "checkBoxAntiBack";
            this.checkBoxAntiBack.Size = new System.Drawing.Size(84, 16);
            this.checkBoxAntiBack.TabIndex = 15;
            this.checkBoxAntiBack.Text = "返回的蚂蚁";
            this.checkBoxAntiBack.UseVisualStyleBackColor = true;
            // 
            // checkBoxSearchVal
            // 
            this.checkBoxSearchVal.AutoSize = true;
            this.checkBoxSearchVal.Location = new System.Drawing.Point(689, 64);
            this.checkBoxSearchVal.Name = "checkBoxSearchVal";
            this.checkBoxSearchVal.Size = new System.Drawing.Size(132, 16);
            this.checkBoxSearchVal.TabIndex = 16;
            this.checkBoxSearchVal.Text = "搜索时产生的信息素";
            this.checkBoxSearchVal.UseVisualStyleBackColor = true;
            // 
            // checkBoxBackVal
            // 
            this.checkBoxBackVal.AutoSize = true;
            this.checkBoxBackVal.Location = new System.Drawing.Point(689, 87);
            this.checkBoxBackVal.Name = "checkBoxBackVal";
            this.checkBoxBackVal.Size = new System.Drawing.Size(132, 16);
            this.checkBoxBackVal.TabIndex = 17;
            this.checkBoxBackVal.Text = "返回时产生的信息素";
            this.checkBoxBackVal.UseVisualStyleBackColor = true;
            // 
            // checkBoxNoVal
            // 
            this.checkBoxNoVal.AutoSize = true;
            this.checkBoxNoVal.Location = new System.Drawing.Point(689, 110);
            this.checkBoxNoVal.Name = "checkBoxNoVal";
            this.checkBoxNoVal.Size = new System.Drawing.Size(96, 16);
            this.checkBoxNoVal.TabIndex = 18;
            this.checkBoxNoVal.Text = "无信息素的点";
            this.checkBoxNoVal.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(690, 225);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 19;
            this.label2.Text = "label2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(689, 241);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 20;
            this.label3.Text = "label3";
            // 
            // buttonTest
            // 
            this.buttonTest.Location = new System.Drawing.Point(611, 245);
            this.buttonTest.Name = "buttonTest";
            this.buttonTest.Size = new System.Drawing.Size(75, 23);
            this.buttonTest.TabIndex = 21;
            this.buttonTest.Text = "测试用";
            this.buttonTest.UseVisualStyleBackColor = true;
            this.buttonTest.Click += new System.EventHandler(this.buttonTest_Click);
            // 
            // progressBarSys
            // 
            this.progressBarSys.Location = new System.Drawing.Point(692, 267);
            this.progressBarSys.Name = "progressBarSys";
            this.progressBarSys.Size = new System.Drawing.Size(116, 23);
            this.progressBarSys.TabIndex = 22;
            // 
            // anti
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(820, 406);
            this.Controls.Add(this.progressBarSys);
            this.Controls.Add(this.buttonTest);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.checkBoxNoVal);
            this.Controls.Add(this.checkBoxBackVal);
            this.Controls.Add(this.checkBoxSearchVal);
            this.Controls.Add(this.checkBoxAntiBack);
            this.Controls.Add(this.checkBoxAntiSearch);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.labelRunTime);
            this.Controls.Add(this.buttonRefresh);
            this.Controls.Add(this.buttonAddAnti);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.labelGoalPoint);
            this.Controls.Add(this.labelStartPoint);
            this.Controls.Add(this.buttonClear);
            this.Controls.Add(this.buttonSetGoal);
            this.Controls.Add(this.buttonSetStart);
            this.Controls.Add(this.buttonClearHinder);
            this.Controls.Add(this.buttonSetHinder);
            this.Controls.Add(this.pictureBox1);
            this.Name = "anti";
            this.Text = "anti";
            this.Load += new System.EventHandler(this.anti_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button buttonSetHinder;
        private System.Windows.Forms.Button buttonClearHinder;
        private System.Windows.Forms.Button buttonSetStart;
        private System.Windows.Forms.Button buttonSetGoal;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.Label labelStartPoint;
        private System.Windows.Forms.Label labelGoalPoint;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Button buttonAddAnti;
        private System.Windows.Forms.Button buttonRefresh;
        private System.Windows.Forms.Timer timerDisplayRefresh;
        private System.Windows.Forms.Label labelRunTime;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBoxAntiSearch;
        private System.Windows.Forms.CheckBox checkBoxAntiBack;
        private System.Windows.Forms.CheckBox checkBoxSearchVal;
        private System.Windows.Forms.CheckBox checkBoxBackVal;
        private System.Windows.Forms.CheckBox checkBoxNoVal;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonTest;
        private System.Windows.Forms.ProgressBar progressBarSys;
    }
}