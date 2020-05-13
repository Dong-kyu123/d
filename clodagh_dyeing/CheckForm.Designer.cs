using System;
using System.Drawing;
using System.Windows.Forms;

namespace clodagh_dyeing
{
    partial class CheckForm
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.colorplate = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // label9
            // 
            this.label9.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label9.Location = new System.Drawing.Point(106, 35);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(38, 12);
            this.label9.TabIndex = 19;
            this.label9.Text = "000";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label9.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CheckForm_MouseDown);
            this.label9.MouseMove += new System.Windows.Forms.MouseEventHandler(this.CheckForm_MouseMove);
            // 
            // label8
            // 
            this.label8.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label8.Location = new System.Drawing.Point(61, 35);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(38, 12);
            this.label8.TabIndex = 18;
            this.label8.Text = "000";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label8.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CheckForm_MouseDown);
            this.label8.MouseMove += new System.Windows.Forms.MouseEventHandler(this.CheckForm_MouseMove);
            // 
            // label7
            // 
            this.label7.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label7.Location = new System.Drawing.Point(17, 35);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 12);
            this.label7.TabIndex = 17;
            this.label7.Text = "000";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label7.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CheckForm_MouseDown);
            this.label7.MouseMove += new System.Windows.Forms.MouseEventHandler(this.CheckForm_MouseMove);
            // 
            // label6
            // 
            this.label6.ImageAlign = System.Drawing.ContentAlignment.TopRight;
            this.label6.Location = new System.Drawing.Point(53, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 12);
            this.label6.TabIndex = 16;
            this.label6.Text = "000";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label6.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CheckForm_MouseDown);
            this.label6.MouseMove += new System.Windows.Forms.MouseEventHandler(this.CheckForm_MouseMove);
            // 
            // label5
            // 
            this.label5.ImageAlign = System.Drawing.ContentAlignment.TopRight;
            this.label5.Location = new System.Drawing.Point(98, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 12);
            this.label5.TabIndex = 15;
            this.label5.Text = "000";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label5.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CheckForm_MouseDown);
            this.label5.MouseMove += new System.Windows.Forms.MouseEventHandler(this.CheckForm_MouseMove);
            // 
            // label4
            // 
            this.label4.ImageAlign = System.Drawing.ContentAlignment.TopRight;
            this.label4.Location = new System.Drawing.Point(21, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(26, 10);
            this.label4.TabIndex = 14;
            this.label4.Text = "000";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label4.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CheckForm_MouseDown);
            this.label4.MouseMove += new System.Windows.Forms.MouseEventHandler(this.CheckForm_MouseMove);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(113, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 12);
            this.label3.TabIndex = 13;
            this.label3.Text = "000";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label3.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CheckForm_MouseDown);
            this.label3.MouseMove += new System.Windows.Forms.MouseEventHandler(this.CheckForm_MouseMove);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(68, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 12);
            this.label2.TabIndex = 12;
            this.label2.Text = "000";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CheckForm_MouseDown);
            this.label2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.CheckForm_MouseMove);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(24, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 12);
            this.label1.TabIndex = 11;
            this.label1.Text = "000";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CheckForm_MouseDown);
            this.label1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.CheckForm_MouseMove);
            // 
            // colorplate
            // 
            this.colorplate.BackColor = System.Drawing.Color.Red;
            this.colorplate.Location = new System.Drawing.Point(7, 5);
            this.colorplate.Name = "colorplate";
            this.colorplate.Size = new System.Drawing.Size(10, 40);
            this.colorplate.TabIndex = 10;
            // 
            // CheckForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(164, 87);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.colorplate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CheckForm";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CheckForm";
            this.TopMost = true;
            this.TransparencyKey = System.Drawing.Color.Red;
            this.Load += new System.EventHandler(this.CheckForm_Load);
            this.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.CheckForm_MouseDoubleClick);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CheckForm_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.CheckForm_MouseMove);
            this.Move += new System.EventHandler(this.CheckForm_Move);
            this.ResumeLayout(false);

        }

        #endregion
    }
}

