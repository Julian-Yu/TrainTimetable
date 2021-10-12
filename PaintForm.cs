using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace TrainTimetable
{
    public partial class PaintForm : Form
    {
        /// <summary>
        ///运行图总宽度
        /// </summary>
        static int TD_Width = 3600;
        /// <summary>
        ///运行图总高度
        /// </summary>
        static int TD_Height = 1000;
        /// <summary>
        /// 上行图是否显示
        /// </summary>
        public bool UpGraph = false;
        /// <summary>
        /// 下行图是否显示
        /// </summary>
        public bool DownGraph = false;
        /// <summary>
        /// 时刻表文件名
        /// </summary>
        string traFileName;
        /// <summary>
        /// 车站文件名
        /// </summary>
        string staFileName;
        /// <summary>
        /// 交路文件名
        /// </summary>
        string routeFileName;
        /// <summary>
        /// 数据读取和管理类
        /// </summary>
        DataManager dm;
        /// <summary>
        /// 画图工具类
        /// </summary>
        PaintTool pt;
       
        

        /// <summary>
        ///bmp，运行图绘制的底图
        /// </summary>
        public Bitmap bmp = new Bitmap(TD_Width, TD_Height);
        public PaintForm()
        {
            pictureBox1 = new PictureBox();
            pictureBox1.Size = new Size(TD_Width, TD_Height);
            InitializeComponent();
            this.Size = new Size(TD_Width, TD_Height);
            dm = new DataManager();
            pt = new PaintTool();
            dm.ReadStation(Application.StartupPath + @"\\沪宁车站信息.csv");
            dm.ReadTrain(Application.StartupPath + @"\\results3.csv");
            dm.DivideUpDown();
            dm.AddTra2sta();
            dm.GetStop();
        }

        /// <summary>
        /// 统一的画图工具
        /// </summary>
        public void DrawPicture()
        {
            pictureBox1.Size = new Size(TD_Width, TD_Height);
            Graphics gs;
            gs = Graphics.FromImage(bmp);
            int ix = dm.stationList.Count();
            List<double> staMile = new List<double>();
            pictureBox1.BackgroundImage = null;
            gs.Clear(this.pictureBox1.BackColor);
            if (UpGraph == true && DownGraph == true)
            {
                double total1 = dm.stationMileList.Last();
                pt.TimetableFrame(this.bmp.Width, 0, this.bmp.Height, total1, dm.stationMileList, gs, dm.stationStringList);
                pt.TrainLine(gs, dm.upTrainList, dm.stationStringList);
                pt.TrainLine(gs, dm.downTrainList, dm.stationStringList);
                
            }
            else if (UpGraph == true && DownGraph == false)
            {
                double total1 = dm.stationMileList.Last();
                pt.TimetableFrame(this.bmp.Width, 0, this.bmp.Height, total1, dm.stationMileList, gs, dm.stationStringList);
                pt.TrainLine(gs, dm.upTrainList, dm.stationStringList);
            }
            else if (UpGraph == false && DownGraph == true)
            {
                double total1 = dm.stationMileList.Last();
                pt.TimetableFrame(this.bmp.Width, 0, this.bmp.Height, total1, dm.stationMileList, gs, dm.stationStringList);
                pt.TrainLine(gs, dm.downTrainList, dm.stationStringList);
            }
            else
            {
                double total1 = dm.stationMileList.Last();
                pt.TimetableFrame(this.bmp.Width, 0, this.bmp.Height, total1, dm.stationMileList, gs, dm.stationStringList);
            }
            this.pictureBox1.BackgroundImage = bmp;
        }
        private void 绘制ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }


        private void 画图控件ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 导出图片ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {

        }

        private void 文件ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 读取时刻表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Multiselect = true;
            dialog.Title = "请选择文件夹";
            dialog.Filter = "所有文件(*.*)|*.*";
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                traFileName = dialog.FileName;
                dm.ReadTrain(traFileName);
                dm.DivideUpDown();
                dm.AddTra2sta();
                dm.GetStop();
            }
            if (dialog.FileName == null)
            {
                MessageBox.Show("未找到相关文件");
            }
        }

        private void 读取车站信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Multiselect = true;
            dialog.Title = "请选择文件夹";
            dialog.Filter = "所有文件(*.*)|*.*";
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                staFileName = dialog.FileName;
                dm.ReadStation(staFileName);
            }
            if (dialog.FileName == null)
            {
                MessageBox.Show("未找到相关文件");
            }
        }
        private void 读取交路信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void 绘制运行图底图ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpGraph = false;
            DownGraph = false;
            DrawPicture();
        }

        private void 绘制上行运行图ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpGraph = true;
            DownGraph = false;
            DrawPicture();
        }

        private void 绘制下行运行图ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpGraph = false;
            DownGraph = true;
            DrawPicture();
        }

        private void 绘制上下行运行图ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpGraph = true;
            DownGraph = true;
            DrawPicture();
        }

        private void 绘制交路图ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }


        private void 导出运行图底图ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Title = "保存图片";
            dialog.Filter = @"jpeg|*.jpg|bmp|*.bmp|png|*.png";
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string Name = dialog.FileName.ToString();
                if (Name != "" && Name != null)
                {
                    string filename = Name.Substring(Name.LastIndexOf(".") + 1).ToString();
                    System.Drawing.Imaging.ImageFormat imgformat = null;
                    if (filename != "")
                    {
                        switch (filename)
                        {
                            case "jpg":
                                imgformat = System.Drawing.Imaging.ImageFormat.Jpeg;
                                break;
                            case "bmp":
                                imgformat = System.Drawing.Imaging.ImageFormat.Bmp;
                                break;
                            case "png":
                                imgformat = System.Drawing.Imaging.ImageFormat.Png;
                                break;
                            default:
                                imgformat = System.Drawing.Imaging.ImageFormat.Png;
                                break;
                        }
                        try
                        {
                            UpGraph = false;
                            DownGraph = false;
                            DrawPicture();
                            Bitmap bit = new Bitmap(pictureBox1.BackgroundImage);
                            MessageBox.Show(Name);
                            pictureBox1.BackgroundImage.Save(Name, imgformat);
                        }
                        catch
                        {
                        }
                    }
                }
            }
        }

        private void 导出上行运行图ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Title = "保存图片";
            dialog.Filter = @"jpeg|*.jpg|bmp|*.bmp|png|*.png";
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string Name = dialog.FileName.ToString();
                if (Name != "" && Name != null)
                {
                    string filename = Name.Substring(Name.LastIndexOf(".") + 1).ToString();
                    System.Drawing.Imaging.ImageFormat imgformat = null;
                    if (filename != "")
                    {
                        switch (filename)
                        {
                            case "jpg":
                                imgformat = System.Drawing.Imaging.ImageFormat.Jpeg;
                                break;
                            case "bmp":
                                imgformat = System.Drawing.Imaging.ImageFormat.Bmp;
                                break;
                            case "png":
                                imgformat = System.Drawing.Imaging.ImageFormat.Png;
                                break;
                            default:
                                imgformat = System.Drawing.Imaging.ImageFormat.Png;
                                break;
                        }
                        try
                        {
                            UpGraph = true;
                            DownGraph = false;
                            DrawPicture();
                            Bitmap bit = new Bitmap(pictureBox1.BackgroundImage);
                            MessageBox.Show(Name);
                            pictureBox1.BackgroundImage.Save(Name, imgformat);
                        }
                        catch
                        {
                        }
                    }
                }
            }
        }

        private void 导出下行运行图ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Title = "保存图片";
            dialog.Filter = @"jpeg|*.jpg|bmp|*.bmp|png|*.png";
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string Name = dialog.FileName.ToString();
                if (Name != "" && Name != null)
                {
                    string filename = Name.Substring(Name.LastIndexOf(".") + 1).ToString();
                    System.Drawing.Imaging.ImageFormat imgformat = null;
                    if (filename != "")
                    {
                        switch (filename)
                        {
                            case "jpg":
                                imgformat = System.Drawing.Imaging.ImageFormat.Jpeg;
                                break;
                            case "bmp":
                                imgformat = System.Drawing.Imaging.ImageFormat.Bmp;
                                break;
                            case "png":
                                imgformat = System.Drawing.Imaging.ImageFormat.Png;
                                break;
                            default:
                                imgformat = System.Drawing.Imaging.ImageFormat.Png;
                                break;
                        }
                        try
                        {
                            UpGraph = false;
                            DownGraph = true;
                            DrawPicture();
                            Bitmap bit = new Bitmap(pictureBox1.BackgroundImage);
                            MessageBox.Show(Name);
                            pictureBox1.BackgroundImage.Save(Name, imgformat);
                        }
                        catch
                        {
                        }
                    }
                }
            }
        }

        private void 导出上下行运行图ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Title = "保存图片";
            dialog.Filter = @"jpeg|*.jpg|bmp|*.bmp|png|*.png";
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string Name = dialog.FileName.ToString();
                if (Name != "" && Name != null)
                {
                    string filename = Name.Substring(Name.LastIndexOf(".") + 1).ToString();
                    System.Drawing.Imaging.ImageFormat imgformat = null;


                    if (filename != "")
                    {
                        switch (filename)
                        {
                            case "jpg":
                                imgformat = System.Drawing.Imaging.ImageFormat.Jpeg;
                                break;
                            case "bmp":
                                imgformat = System.Drawing.Imaging.ImageFormat.Bmp;
                                break;
                            case "png":
                                imgformat = System.Drawing.Imaging.ImageFormat.Png;
                                break;
                            default:
                                imgformat = System.Drawing.Imaging.ImageFormat.Png;
                                break;
                        }
                        try
                        {
                            UpGraph = true;
                            DownGraph = true;
                            DrawPicture();
                            Bitmap bit = new Bitmap(pictureBox1.BackgroundImage);
                            MessageBox.Show(Name);
                            pictureBox1.BackgroundImage.Save(Name, imgformat);
                        }
                        catch
                        {
                        }
                    }
                }
            }
        }

        private void 放大ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (TD_Width < 6000 && TD_Height < 4000)
            {
                TD_Width += 30;
                TD_Height += 20;
            }
            bmp = new Bitmap(TD_Width, TD_Height);
            pt.TimeX = new List<float>();
            pt.staY = new List<float>();
            DrawPicture();
        }

        private void 缩小ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (TD_Width > 900 && TD_Height > 600)
            {
                TD_Width -= 30;
                TD_Height -= 20;
            }
            bmp = new Bitmap(TD_Width, TD_Height);
            pt.TimeX = new List<float>();
            pt.staY = new List<float>();
            DrawPicture();
        }

        private void PaintForm_Load(object sender, EventArgs e)
        {

        }

    }
}
