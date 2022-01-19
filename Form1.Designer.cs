
namespace Coursework
{
    partial class FreezSpelButton
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.picDisplay = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.lblDirection = new System.Windows.Forms.Label();
            this.addGravitonButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbGraviton = new System.Windows.Forms.TrackBar();
            this.delGravitonButton = new System.Windows.Forms.Button();
            this.directionBox = new System.Windows.Forms.ComboBox();
            this.Points = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.FreezTimer = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picDisplay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbGraviton)).BeginInit();
            this.SuspendLayout();
            // 
            // picDisplay
            // 
            this.picDisplay.Location = new System.Drawing.Point(5, 5);
            this.picDisplay.Margin = new System.Windows.Forms.Padding(2);
            this.picDisplay.Name = "picDisplay";
            this.picDisplay.Size = new System.Drawing.Size(714, 422);
            this.picDisplay.TabIndex = 0;
            this.picDisplay.TabStop = false;
            this.picDisplay.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picDisplay_MouseDown);
            this.picDisplay.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picDisplay_MouseMove);
            this.picDisplay.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picDisplay_MouseUp);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 40;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(730, 13);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Направление";
            // 
            // lblDirection
            // 
            this.lblDirection.AutoSize = true;
            this.lblDirection.Location = new System.Drawing.Point(899, 35);
            this.lblDirection.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDirection.Name = "lblDirection";
            this.lblDirection.Size = new System.Drawing.Size(0, 13);
            this.lblDirection.TabIndex = 3;
            // 
            // addGravitonButton
            // 
            this.addGravitonButton.Location = new System.Drawing.Point(733, 145);
            this.addGravitonButton.Name = "addGravitonButton";
            this.addGravitonButton.Size = new System.Drawing.Size(190, 38);
            this.addGravitonButton.TabIndex = 10;
            this.addGravitonButton.Text = "Добавить гравитон";
            this.addGravitonButton.UseVisualStyleBackColor = true;
            this.addGravitonButton.Click += new System.EventHandler(this.addGravitonButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(730, 82);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(165, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Размер выбранного гравитона";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(899, 104);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 13);
            this.label2.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(899, 158);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 13);
            this.label4.TabIndex = 9;
            // 
            // tbGraviton
            // 
            this.tbGraviton.Location = new System.Drawing.Point(723, 104);
            this.tbGraviton.Margin = new System.Windows.Forms.Padding(2);
            this.tbGraviton.Maximum = 200;
            this.tbGraviton.Name = "tbGraviton";
            this.tbGraviton.Size = new System.Drawing.Size(173, 69);
            this.tbGraviton.TabIndex = 4;
            this.tbGraviton.Scroll += new System.EventHandler(this.tbGraviton_Scroll);
            // 
            // delGravitonButton
            // 
            this.delGravitonButton.Location = new System.Drawing.Point(733, 189);
            this.delGravitonButton.Name = "delGravitonButton";
            this.delGravitonButton.Size = new System.Drawing.Size(190, 38);
            this.delGravitonButton.TabIndex = 11;
            this.delGravitonButton.Text = "Удалить гравитон";
            this.delGravitonButton.UseVisualStyleBackColor = true;
            this.delGravitonButton.Click += new System.EventHandler(this.delGravitonButton_Click);
            // 
            // directionBox
            // 
            this.directionBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.directionBox.FormattingEnabled = true;
            this.directionBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.directionBox.Location = new System.Drawing.Point(733, 35);
            this.directionBox.Name = "directionBox";
            this.directionBox.Size = new System.Drawing.Size(121, 21);
            this.directionBox.TabIndex = 12;
            this.directionBox.SelectedIndexChanged += new System.EventHandler(this.directionBox_SelectedIndexChanged);
            // 
            // Points
            // 
            this.Points.AutoSize = true;
            this.Points.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.Points.Location = new System.Drawing.Point(547, 13);
            this.Points.Name = "Points";
            this.Points.Size = new System.Drawing.Size(192, 25);
            this.Points.TabIndex = 13;
            this.Points.Text = "Количество очков";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(733, 383);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(121, 37);
            this.button1.TabIndex = 14;
            this.button1.Text = "Заморозить поле боя!";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FreezTimer
            // 
            this.FreezTimer.AutoSize = true;
            this.FreezTimer.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F);
            this.FreezTimer.Location = new System.Drawing.Point(860, 383);
            this.FreezTimer.Name = "FreezTimer";
            this.FreezTimer.Size = new System.Drawing.Size(77, 47);
            this.FreezTimer.TabIndex = 15;
            this.FreezTimer.Text = "0.0";
            this.FreezTimer.Click += new System.EventHandler(this.FreezTimer_Click);
            // 
            // FreezSpelButton
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(935, 432);
            this.Controls.Add(this.FreezTimer);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Points);
            this.Controls.Add(this.directionBox);
            this.Controls.Add(this.delGravitonButton);
            this.Controls.Add(this.addGravitonButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbGraviton);
            this.Controls.Add(this.lblDirection);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.picDisplay);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FreezSpelButton";
            this.Text = "Form1";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.picDisplay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbGraviton)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picDisplay;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblDirection;
        private System.Windows.Forms.Button addGravitonButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TrackBar tbGraviton;
        private System.Windows.Forms.Button delGravitonButton;
        private System.Windows.Forms.ComboBox directionBox;
        private System.Windows.Forms.Label Points;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label FreezTimer;
    }
}

