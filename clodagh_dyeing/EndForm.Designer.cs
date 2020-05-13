using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace clodagh_dyeing
{
    partial class EndForm
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
            this.components = new Container();
            ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(EndForm));
            this.timeLabel = new Label();
            this.timer1 = new Timer(this.components);
            this.ShowColorBtn = new Button();
            base.SuspendLayout();
            this.timeLabel.Font = new Font("Gulim", 18f, FontStyle.Regular, GraphicsUnit.Point, 129);
            this.timeLabel.Location = new Point(12, 9);
            this.timeLabel.Name = "timeLabel";
            this.timeLabel.Size = new Size(390, 31);
            this.timeLabel.TabIndex = 2003;
            this.timeLabel.Text = "컴퓨터가 60초 후에 종료됩니다.";
            this.timeLabel.TextAlign = ContentAlignment.MiddleCenter;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new EventHandler(this.timer1_Tick);
            this.ShowColorBtn.BackColor = SystemColors.ButtonFace;
            this.ShowColorBtn.DialogResult = DialogResult.Cancel;
            this.ShowColorBtn.FlatAppearance.BorderColor = Color.Black;
            this.ShowColorBtn.FlatAppearance.MouseDownBackColor = Color.DarkGray;
            this.ShowColorBtn.FlatAppearance.MouseOverBackColor = Color.DarkGray;
            this.ShowColorBtn.Font = new Font("Microsoft NeoGothic", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.ShowColorBtn.ForeColor = Color.Black;
            this.ShowColorBtn.Location = new Point(165, 50);
            this.ShowColorBtn.Name = "ShowColorBtn";
            this.ShowColorBtn.Size = new Size(100, 25);
            this.ShowColorBtn.TabIndex = 2001;
            this.ShowColorBtn.Text = "종료 취소";
            this.ShowColorBtn.UseVisualStyleBackColor = false;
            this.ShowColorBtn.Click += new EventHandler(this.ShowColorBtn_Click);
            base.AutoScaleDimensions = new SizeF(7f, 12f);
            base.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = SystemColors.Control;
            base.ClientSize = new Size(414, 87);
            base.ControlBox = false;
            base.Controls.Add(this.timeLabel);
            base.Controls.Add(this.ShowColorBtn);
            base.FormBorderStyle = FormBorderStyle.FixedSingle;
            //base.Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
            base.MaximizeBox = false;
            base.MinimizeBox = false;
            base.Name = "EndForm";
            base.ShowIcon = false;
            base.ShowInTaskbar = false;
            base.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Exit Windows";
            base.TopMost = true;
            base.Load += new EventHandler(this.EndForm_Load);
            base.ResumeLayout(false);
        }

        #endregion
    }
}