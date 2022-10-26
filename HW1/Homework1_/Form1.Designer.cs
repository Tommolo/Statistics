namespace Homework1_
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.plusLeftLabel1 = new System.Windows.Forms.Label();
            this.startButton = new System.Windows.Forms.Button();
            this.timeLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.plusRightLabel1 = new System.Windows.Forms.Label();
            this.plusLabel1 = new System.Windows.Forms.Label();
            this.equalSign = new System.Windows.Forms.Label();
            this.sum1 = new System.Windows.Forms.NumericUpDown();
            this.plusLeftLabel2 = new System.Windows.Forms.Label();
            this.plusRightNumeric1 = new System.Windows.Forms.NumericUpDown();
            this.plusLabel2 = new System.Windows.Forms.Label();
            this.sum2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.plusRighLabel2 = new System.Windows.Forms.Label();
            this.plusLabel3 = new System.Windows.Forms.Label();
            this.plusLeftNumeric1 = new System.Windows.Forms.NumericUpDown();
            this.sum3 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.answer2 = new System.Windows.Forms.Label();
            this.answer3 = new System.Windows.Forms.Label();
            this.answer1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.sum1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.plusRightNumeric1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.plusLeftNumeric1)).BeginInit();
            this.SuspendLayout();
            // 
            // plusLeftLabel1
            // 
            this.plusLeftLabel1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.plusLeftLabel1.Location = new System.Drawing.Point(87, 60);
            this.plusLeftLabel1.Name = "plusLeftLabel1";
            this.plusLeftLabel1.Size = new System.Drawing.Size(60, 50);
            this.plusLeftLabel1.TabIndex = 0;
            this.plusLeftLabel1.Text = "?";
            this.plusLeftLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.plusLeftLabel1.Click += new System.EventHandler(this.plusLeftLabel_Click);
            // 
            // startButton
            // 
            this.startButton.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.startButton.Location = new System.Drawing.Point(202, 329);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(110, 48);
            this.startButton.TabIndex = 2;
            this.startButton.Text = "Start Quiz";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // timeLabel
            // 
            this.timeLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.timeLabel.Location = new System.Drawing.Point(513, 9);
            this.timeLabel.Name = "timeLabel";
            this.timeLabel.Size = new System.Drawing.Size(200, 30);
            this.timeLabel.TabIndex = 3;
            this.timeLabel.Text = " ";
            this.timeLabel.Click += new System.EventHandler(this.timeLabel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(390, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 35);
            this.label1.TabIndex = 4;
            this.label1.Text = "Time Left";
            // 
            // plusRightLabel1
            // 
            this.plusRightLabel1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.plusRightLabel1.Location = new System.Drawing.Point(304, 60);
            this.plusRightLabel1.Name = "plusRightLabel1";
            this.plusRightLabel1.Size = new System.Drawing.Size(60, 50);
            this.plusRightLabel1.TabIndex = 5;
            this.plusRightLabel1.Text = "?";
            this.plusRightLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.plusRightLabel1.Click += new System.EventHandler(this.plusRightLabel_Click);
            // 
            // plusLabel1
            // 
            this.plusLabel1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.plusLabel1.Location = new System.Drawing.Point(191, 60);
            this.plusLabel1.Name = "plusLabel1";
            this.plusLabel1.Size = new System.Drawing.Size(60, 50);
            this.plusLabel1.TabIndex = 6;
            this.plusLabel1.Text = "+";
            this.plusLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.plusLabel1.Click += new System.EventHandler(this.label2_Click_1);
            // 
            // equalSign
            // 
            this.equalSign.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.equalSign.Location = new System.Drawing.Point(390, 60);
            this.equalSign.Name = "equalSign";
            this.equalSign.Size = new System.Drawing.Size(60, 50);
            this.equalSign.TabIndex = 7;
            this.equalSign.Text = "=";
            this.equalSign.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.equalSign.Click += new System.EventHandler(this.label2_Click_2);
            // 
            // sum1
            // 
            this.sum1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.sum1.Location = new System.Drawing.Point(475, 63);
            this.sum1.Name = "sum1";
            this.sum1.Size = new System.Drawing.Size(100, 47);
            this.sum1.TabIndex = 8;
            this.sum1.ValueChanged += new System.EventHandler(this.sum_ValueChanged);
            // 
            // plusLeftLabel2
            // 
            this.plusLeftLabel2.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.plusLeftLabel2.Location = new System.Drawing.Point(87, 141);
            this.plusLeftLabel2.Name = "plusLeftLabel2";
            this.plusLeftLabel2.Size = new System.Drawing.Size(60, 50);
            this.plusLeftLabel2.TabIndex = 9;
            this.plusLeftLabel2.Text = "?";
            this.plusLeftLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // plusRightNumeric1
            // 
            this.plusRightNumeric1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.plusRightNumeric1.Location = new System.Drawing.Point(304, 141);
            this.plusRightNumeric1.Name = "plusRightNumeric1";
            this.plusRightNumeric1.Size = new System.Drawing.Size(100, 47);
            this.plusRightNumeric1.TabIndex = 10;
            // 
            // plusLabel2
            // 
            this.plusLabel2.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.plusLabel2.Location = new System.Drawing.Point(191, 141);
            this.plusLabel2.Name = "plusLabel2";
            this.plusLabel2.Size = new System.Drawing.Size(60, 50);
            this.plusLabel2.TabIndex = 11;
            this.plusLabel2.Text = "+";
            this.plusLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.plusLabel2.Click += new System.EventHandler(this.label3_Click);
            // 
            // sum2
            // 
            this.sum2.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.sum2.Location = new System.Drawing.Point(496, 141);
            this.sum2.Name = "sum2";
            this.sum2.Size = new System.Drawing.Size(60, 50);
            this.sum2.TabIndex = 12;
            this.sum2.Text = "?";
            this.sum2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(430, 141);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 50);
            this.label5.TabIndex = 13;
            this.label5.Text = "=";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // plusRighLabel2
            // 
            this.plusRighLabel2.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.plusRighLabel2.Location = new System.Drawing.Point(304, 233);
            this.plusRighLabel2.Name = "plusRighLabel2";
            this.plusRighLabel2.Size = new System.Drawing.Size(60, 50);
            this.plusRighLabel2.TabIndex = 14;
            this.plusRighLabel2.Text = "?";
            this.plusRighLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // plusLabel3
            // 
            this.plusLabel3.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.plusLabel3.Location = new System.Drawing.Point(191, 230);
            this.plusLabel3.Name = "plusLabel3";
            this.plusLabel3.Size = new System.Drawing.Size(60, 50);
            this.plusLabel3.TabIndex = 15;
            this.plusLabel3.Text = "+";
            this.plusLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // plusLeftNumeric1
            // 
            this.plusLeftNumeric1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.plusLeftNumeric1.Location = new System.Drawing.Point(58, 236);
            this.plusLeftNumeric1.Name = "plusLeftNumeric1";
            this.plusLeftNumeric1.Size = new System.Drawing.Size(100, 47);
            this.plusLeftNumeric1.TabIndex = 16;
            // 
            // sum3
            // 
            this.sum3.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.sum3.Location = new System.Drawing.Point(496, 230);
            this.sum3.Name = "sum3";
            this.sum3.Size = new System.Drawing.Size(60, 50);
            this.sum3.TabIndex = 17;
            this.sum3.Text = "?";
            this.sum3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(430, 233);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 50);
            this.label7.TabIndex = 18;
            this.label7.Text = "=";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timeLabel_Click);
            // 
            // answer2
            // 
            this.answer2.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.answer2.Location = new System.Drawing.Point(304, 138);
            this.answer2.Name = "answer2";
            this.answer2.Size = new System.Drawing.Size(100, 50);
            this.answer2.TabIndex = 19;
            this.answer2.Text = "?";
            this.answer2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // answer3
            // 
            this.answer3.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.answer3.Location = new System.Drawing.Point(58, 233);
            this.answer3.Name = "answer3";
            this.answer3.Size = new System.Drawing.Size(100, 50);
            this.answer3.TabIndex = 20;
            this.answer3.Text = "?";
            this.answer3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // answer1
            // 
            this.answer1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.answer1.Location = new System.Drawing.Point(475, 60);
            this.answer1.Name = "answer1";
            this.answer1.Size = new System.Drawing.Size(100, 50);
            this.answer1.TabIndex = 21;
            this.answer1.Text = "?";
            this.answer1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(722, 436);
            this.Controls.Add(this.answer1);
            this.Controls.Add(this.answer3);
            this.Controls.Add(this.answer2);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.sum3);
            this.Controls.Add(this.plusLeftNumeric1);
            this.Controls.Add(this.plusLabel3);
            this.Controls.Add(this.plusRighLabel2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.sum2);
            this.Controls.Add(this.plusLabel2);
            this.Controls.Add(this.plusRightNumeric1);
            this.Controls.Add(this.plusLeftLabel2);
            this.Controls.Add(this.sum1);
            this.Controls.Add(this.equalSign);
            this.Controls.Add(this.plusLabel1);
            this.Controls.Add(this.plusRightLabel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.timeLabel);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.plusLeftLabel1);
            this.Name = "Form1";
            this.Text = "Math Quiz";
            ((System.ComponentModel.ISupportInitialize)(this.sum1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.plusRightNumeric1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.plusLeftNumeric1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label plusLeftLabel1;
        private Button startButton;
        private Label timeLabel;
        private Label label1;
        private Label plusRightLabel1;
        private Label plusLabel1;
        private Label equalSign;
        private NumericUpDown sum1;
        private Label plusLeftLabel2;
        private NumericUpDown plusRightNumeric1;
        private Label plusLabel2;
        private Label sum2;
        private Label label5;
        private Label plusRighLabel2;
        private Label plusLabel3;
        private NumericUpDown plusLeftNumeric1;
        private Label sum3;
        private Label label7;
        private System.Windows.Forms.Timer timer1;
        private Label answer2;
        private Label answer3;
        private Label answer1;
    }
}