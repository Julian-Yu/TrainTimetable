
namespace TrainTimetable
{
    partial class RoutePlanForm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.绘制交路图ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.绘制交路框架图ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.绘制上下行交路图ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.画图控件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.放大ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.缩小ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.导出图片ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.导出交路框架图ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.导出上下行交路图ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.绘制交路图ToolStripMenuItem,
            this.画图控件ToolStripMenuItem,
            this.导出图片ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1471, 48);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 绘制交路图ToolStripMenuItem
            // 
            this.绘制交路图ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.绘制交路框架图ToolStripMenuItem,
            this.绘制上下行交路图ToolStripMenuItem});
            this.绘制交路图ToolStripMenuItem.Name = "绘制交路图ToolStripMenuItem";
            this.绘制交路图ToolStripMenuItem.Size = new System.Drawing.Size(154, 40);
            this.绘制交路图ToolStripMenuItem.Text = "绘制交路图";
            // 
            // 绘制交路框架图ToolStripMenuItem
            // 
            this.绘制交路框架图ToolStripMenuItem.Name = "绘制交路框架图ToolStripMenuItem";
            this.绘制交路框架图ToolStripMenuItem.Size = new System.Drawing.Size(339, 44);
            this.绘制交路框架图ToolStripMenuItem.Text = "绘制交路框架图";
            this.绘制交路框架图ToolStripMenuItem.Click += new System.EventHandler(this.绘制交路框架图ToolStripMenuItem_Click);
            // 
            // 绘制上下行交路图ToolStripMenuItem
            // 
            this.绘制上下行交路图ToolStripMenuItem.Name = "绘制上下行交路图ToolStripMenuItem";
            this.绘制上下行交路图ToolStripMenuItem.Size = new System.Drawing.Size(339, 44);
            this.绘制上下行交路图ToolStripMenuItem.Text = "绘制动车组交路图";
            this.绘制上下行交路图ToolStripMenuItem.Click += new System.EventHandler(this.绘制上下行交路图ToolStripMenuItem_Click);
            // 
            // 画图控件ToolStripMenuItem
            // 
            this.画图控件ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.放大ToolStripMenuItem,
            this.缩小ToolStripMenuItem});
            this.画图控件ToolStripMenuItem.Name = "画图控件ToolStripMenuItem";
            this.画图控件ToolStripMenuItem.Size = new System.Drawing.Size(130, 40);
            this.画图控件ToolStripMenuItem.Text = "画图控件";
            // 
            // 放大ToolStripMenuItem
            // 
            this.放大ToolStripMenuItem.Name = "放大ToolStripMenuItem";
            this.放大ToolStripMenuItem.Size = new System.Drawing.Size(195, 44);
            this.放大ToolStripMenuItem.Text = "放大";
            this.放大ToolStripMenuItem.Click += new System.EventHandler(this.放大ToolStripMenuItem_Click);
            // 
            // 缩小ToolStripMenuItem
            // 
            this.缩小ToolStripMenuItem.Name = "缩小ToolStripMenuItem";
            this.缩小ToolStripMenuItem.Size = new System.Drawing.Size(195, 44);
            this.缩小ToolStripMenuItem.Text = "缩小";
            this.缩小ToolStripMenuItem.Click += new System.EventHandler(this.缩小ToolStripMenuItem_Click);
            // 
            // 导出图片ToolStripMenuItem
            // 
            this.导出图片ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.导出交路框架图ToolStripMenuItem,
            this.导出上下行交路图ToolStripMenuItem});
            this.导出图片ToolStripMenuItem.Name = "导出图片ToolStripMenuItem";
            this.导出图片ToolStripMenuItem.Size = new System.Drawing.Size(130, 40);
            this.导出图片ToolStripMenuItem.Text = "导出图片";
            // 
            // 导出交路框架图ToolStripMenuItem
            // 
            this.导出交路框架图ToolStripMenuItem.Name = "导出交路框架图ToolStripMenuItem";
            this.导出交路框架图ToolStripMenuItem.Size = new System.Drawing.Size(339, 44);
            this.导出交路框架图ToolStripMenuItem.Text = "导出交路框架图";
            this.导出交路框架图ToolStripMenuItem.Click += new System.EventHandler(this.导出交路框架图ToolStripMenuItem_Click);
            // 
            // 导出上下行交路图ToolStripMenuItem
            // 
            this.导出上下行交路图ToolStripMenuItem.Name = "导出上下行交路图ToolStripMenuItem";
            this.导出上下行交路图ToolStripMenuItem.Size = new System.Drawing.Size(339, 44);
            this.导出上下行交路图ToolStripMenuItem.Text = "导出动车组交路图";
            this.导出上下行交路图ToolStripMenuItem.Click += new System.EventHandler(this.导出上下行交路图ToolStripMenuItem_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(13, 43);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1446, 859);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // RoutePlanForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1471, 914);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "RoutePlanForm";
            this.Text = "高速铁路动车组交路图";
            this.Load += new System.EventHandler(this.RoutePlanForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 绘制交路图ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 画图控件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 导出图片ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 放大ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 缩小ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 导出交路框架图ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 导出上下行交路图ToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripMenuItem 绘制交路框架图ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 绘制上下行交路图ToolStripMenuItem;
    }
}