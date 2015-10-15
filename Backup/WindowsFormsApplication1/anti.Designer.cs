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
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.buttonSetHinder = new System.Windows.Forms.Button();
            this.buttonClearHinder = new System.Windows.Forms.Button();
            this.buttonSetStart = new System.Windows.Forms.Button();
            this.buttonSetGoal = new System.Windows.Forms.Button();
            this.buttonClear = new System.Windows.Forms.Button();
            this.labelStartPoint = new System.Windows.Forms.Label();
            this.labelGoalPoint = new System.Windows.Forms.Label();
            this.buttonStart = new System.Windows.Forms.Button();
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
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
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
            this.labelStartPoint.Location = new System.Drawing.Point(605, 252);
            this.labelStartPoint.Name = "labelStartPoint";
            this.labelStartPoint.Size = new System.Drawing.Size(41, 12);
            this.labelStartPoint.TabIndex = 6;
            this.labelStartPoint.Text = "起点：";
            // 
            // labelGoalPoint
            // 
            this.labelGoalPoint.AutoSize = true;
            this.labelGoalPoint.Location = new System.Drawing.Point(605, 274);
            this.labelGoalPoint.Name = "labelGoalPoint";
            this.labelGoalPoint.Size = new System.Drawing.Size(41, 12);
            this.labelGoalPoint.TabIndex = 7;
            this.labelGoalPoint.Text = "终点：";
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(608, 157);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(75, 23);
            this.buttonStart.TabIndex = 8;
            this.buttonStart.Text = "开始";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // anti
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(687, 406);
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
    }
}