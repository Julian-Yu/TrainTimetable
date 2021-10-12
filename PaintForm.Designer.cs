
namespace TrainTimetable
{
    partial class PaintForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.读取时刻表ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.读取车站信息ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.读取交路信息ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.绘制ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.绘制运行图底图ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.绘制上行运行图ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.绘制下行运行图ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.绘制上下行运行图ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.绘制交路图ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.画图控件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.放大ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.缩小ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.导出图片ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.导出运行图底图ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.导出上行运行图ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.导出下行运行图ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.导出上下行运行图ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件ToolStripMenuItem,
            this.绘制ToolStripMenuItem,
            this.绘制交路图ToolStripMenuItem,
            this.画图控件ToolStripMenuItem,
            this.导出图片ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1639, 39);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 文件ToolStripMenuItem
            // 
            this.文件ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.读取时刻表ToolStripMenuItem,
            this.读取车站信息ToolStripMenuItem,
            this.读取交路信息ToolStripMenuItem});
            this.文件ToolStripMenuItem.Name = "文件ToolStripMenuItem";
            this.文件ToolStripMenuItem.Size = new System.Drawing.Size(130, 35);
            this.文件ToolStripMenuItem.Text = "读取文件";
            this.文件ToolStripMenuItem.Click += new System.EventHandler(this.文件ToolStripMenuItem_Click);
            // 
            // 读取时刻表ToolStripMenuItem
            // 
            this.读取时刻表ToolStripMenuItem.Name = "读取时刻表ToolStripMenuItem";
            this.读取时刻表ToolStripMenuItem.Size = new System.Drawing.Size(291, 44);
            this.读取时刻表ToolStripMenuItem.Text = "读取时刻表";
            this.读取时刻表ToolStripMenuItem.Click += new System.EventHandler(this.读取时刻表ToolStripMenuItem_Click);
            // 
            // 读取车站信息ToolStripMenuItem
            // 
            this.读取车站信息ToolStripMenuItem.Name = "读取车站信息ToolStripMenuItem";
            this.读取车站信息ToolStripMenuItem.Size = new System.Drawing.Size(291, 44);
            this.读取车站信息ToolStripMenuItem.Text = "读取车站信息";
            this.读取车站信息ToolStripMenuItem.Click += new System.EventHandler(this.读取车站信息ToolStripMenuItem_Click);
            // 
            // 读取交路信息ToolStripMenuItem
            // 
            this.读取交路信息ToolStripMenuItem.Name = "读取交路信息ToolStripMenuItem";
            this.读取交路信息ToolStripMenuItem.Size = new System.Drawing.Size(291, 44);
            this.读取交路信息ToolStripMenuItem.Text = "读取交路信息";
            this.读取交路信息ToolStripMenuItem.Click += new System.EventHandler(this.读取交路信息ToolStripMenuItem_Click);
            // 
            // 绘制ToolStripMenuItem
            // 
            this.绘制ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.绘制运行图底图ToolStripMenuItem,
            this.绘制上行运行图ToolStripMenuItem,
            this.绘制下行运行图ToolStripMenuItem,
            this.绘制上下行运行图ToolStripMenuItem});
            this.绘制ToolStripMenuItem.Name = "绘制ToolStripMenuItem";
            this.绘制ToolStripMenuItem.Size = new System.Drawing.Size(154, 35);
            this.绘制ToolStripMenuItem.Text = "绘制运行图";
            this.绘制ToolStripMenuItem.Click += new System.EventHandler(this.绘制ToolStripMenuItem_Click);
            // 
            // 绘制运行图底图ToolStripMenuItem
            // 
            this.绘制运行图底图ToolStripMenuItem.Name = "绘制运行图底图ToolStripMenuItem";
            this.绘制运行图底图ToolStripMenuItem.Size = new System.Drawing.Size(339, 44);
            this.绘制运行图底图ToolStripMenuItem.Text = "绘制运行图底图";
            this.绘制运行图底图ToolStripMenuItem.Click += new System.EventHandler(this.绘制运行图底图ToolStripMenuItem_Click);
            // 
            // 绘制上行运行图ToolStripMenuItem
            // 
            this.绘制上行运行图ToolStripMenuItem.Name = "绘制上行运行图ToolStripMenuItem";
            this.绘制上行运行图ToolStripMenuItem.Size = new System.Drawing.Size(339, 44);
            this.绘制上行运行图ToolStripMenuItem.Text = "绘制上行运行图";
            this.绘制上行运行图ToolStripMenuItem.Click += new System.EventHandler(this.绘制上行运行图ToolStripMenuItem_Click);
            // 
            // 绘制下行运行图ToolStripMenuItem
            // 
            this.绘制下行运行图ToolStripMenuItem.Name = "绘制下行运行图ToolStripMenuItem";
            this.绘制下行运行图ToolStripMenuItem.Size = new System.Drawing.Size(339, 44);
            this.绘制下行运行图ToolStripMenuItem.Text = "绘制下行运行图";
            this.绘制下行运行图ToolStripMenuItem.Click += new System.EventHandler(this.绘制下行运行图ToolStripMenuItem_Click);
            // 
            // 绘制上下行运行图ToolStripMenuItem
            // 
            this.绘制上下行运行图ToolStripMenuItem.Name = "绘制上下行运行图ToolStripMenuItem";
            this.绘制上下行运行图ToolStripMenuItem.Size = new System.Drawing.Size(339, 44);
            this.绘制上下行运行图ToolStripMenuItem.Text = "绘制上下行运行图";
            this.绘制上下行运行图ToolStripMenuItem.Click += new System.EventHandler(this.绘制上下行运行图ToolStripMenuItem_Click);
            // 
            // 绘制交路图ToolStripMenuItem
            // 
            this.绘制交路图ToolStripMenuItem.Name = "绘制交路图ToolStripMenuItem";
            this.绘制交路图ToolStripMenuItem.Size = new System.Drawing.Size(154, 35);
            this.绘制交路图ToolStripMenuItem.Text = "绘制交路图";
            this.绘制交路图ToolStripMenuItem.Click += new System.EventHandler(this.绘制交路图ToolStripMenuItem_Click);
            // 
            // 画图控件ToolStripMenuItem
            // 
            this.画图控件ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.放大ToolStripMenuItem,
            this.缩小ToolStripMenuItem});
            this.画图控件ToolStripMenuItem.Name = "画图控件ToolStripMenuItem";
            this.画图控件ToolStripMenuItem.Size = new System.Drawing.Size(130, 35);
            this.画图控件ToolStripMenuItem.Text = "画图控件";
            this.画图控件ToolStripMenuItem.Click += new System.EventHandler(this.画图控件ToolStripMenuItem_Click);
            // 
            // 放大ToolStripMenuItem
            // 
            this.放大ToolStripMenuItem.Name = "放大ToolStripMenuItem";
            this.放大ToolStripMenuItem.Size = new System.Drawing.Size(359, 44);
            this.放大ToolStripMenuItem.Text = "放大";
            this.放大ToolStripMenuItem.Click += new System.EventHandler(this.放大ToolStripMenuItem_Click);
            // 
            // 缩小ToolStripMenuItem
            // 
            this.缩小ToolStripMenuItem.Name = "缩小ToolStripMenuItem";
            this.缩小ToolStripMenuItem.Size = new System.Drawing.Size(359, 44);
            this.缩小ToolStripMenuItem.Text = "缩小";
            this.缩小ToolStripMenuItem.Click += new System.EventHandler(this.缩小ToolStripMenuItem_Click);
            // 
            // 导出图片ToolStripMenuItem
            // 
            this.导出图片ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.导出运行图底图ToolStripMenuItem,
            this.导出上行运行图ToolStripMenuItem,
            this.导出下行运行图ToolStripMenuItem,
            this.导出上下行运行图ToolStripMenuItem});
            this.导出图片ToolStripMenuItem.Name = "导出图片ToolStripMenuItem";
            this.导出图片ToolStripMenuItem.Size = new System.Drawing.Size(130, 35);
            this.导出图片ToolStripMenuItem.Text = "导出图片";
            this.导出图片ToolStripMenuItem.Click += new System.EventHandler(this.导出图片ToolStripMenuItem_Click_1);
            // 
            // 导出运行图底图ToolStripMenuItem
            // 
            this.导出运行图底图ToolStripMenuItem.Name = "导出运行图底图ToolStripMenuItem";
            this.导出运行图底图ToolStripMenuItem.Size = new System.Drawing.Size(339, 44);
            this.导出运行图底图ToolStripMenuItem.Text = "导出运行图底图";
            this.导出运行图底图ToolStripMenuItem.Click += new System.EventHandler(this.导出运行图底图ToolStripMenuItem_Click);
            // 
            // 导出上行运行图ToolStripMenuItem
            // 
            this.导出上行运行图ToolStripMenuItem.Name = "导出上行运行图ToolStripMenuItem";
            this.导出上行运行图ToolStripMenuItem.Size = new System.Drawing.Size(339, 44);
            this.导出上行运行图ToolStripMenuItem.Text = "导出上行运行图";
            this.导出上行运行图ToolStripMenuItem.Click += new System.EventHandler(this.导出上行运行图ToolStripMenuItem_Click);
            // 
            // 导出下行运行图ToolStripMenuItem
            // 
            this.导出下行运行图ToolStripMenuItem.Name = "导出下行运行图ToolStripMenuItem";
            this.导出下行运行图ToolStripMenuItem.Size = new System.Drawing.Size(339, 44);
            this.导出下行运行图ToolStripMenuItem.Text = "导出下行运行图";
            this.导出下行运行图ToolStripMenuItem.Click += new System.EventHandler(this.导出下行运行图ToolStripMenuItem_Click);
            // 
            // 导出上下行运行图ToolStripMenuItem
            // 
            this.导出上下行运行图ToolStripMenuItem.Name = "导出上下行运行图ToolStripMenuItem";
            this.导出上下行运行图ToolStripMenuItem.Size = new System.Drawing.Size(339, 44);
            this.导出上下行运行图ToolStripMenuItem.Text = "导出上下行运行图";
            this.导出上下行运行图ToolStripMenuItem.Click += new System.EventHandler(this.导出上下行运行图ToolStripMenuItem_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(13, 43);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1614, 904);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // PaintForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1639, 959);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "PaintForm";
            this.Text = "高速铁路运行图显示程序";
            this.Load += new System.EventHandler(this.PaintForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 绘制ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 读取时刻表ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 读取车站信息ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 绘制运行图底图ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 绘制上行运行图ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 绘制下行运行图ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 绘制上下行运行图ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 画图控件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 导出图片ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 放大ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 缩小ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 导出运行图底图ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 导出上行运行图ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 导出下行运行图ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 导出上下行运行图ToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripMenuItem 绘制交路图ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 读取交路信息ToolStripMenuItem;
    }
}

