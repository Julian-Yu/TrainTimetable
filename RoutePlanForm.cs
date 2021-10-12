using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrainTimetable
{
    public partial class RoutePlanForm : Form
    {
        /// <summary>
        /// 交路图总宽度
        /// </summary>
        static int TD_Width = 3000;
        /// <summary>
        /// 交路图总高度
        /// </summary>
        static int TD_Height = 2000;

        public bool TrainLine = false;

        DataManager dm;
        PaintTool pt;
        /// <summary>
        ///bmp，运行图绘制的底图
        /// </summary>
        public Bitmap bmp = new Bitmap(TD_Width, TD_Height);
        public RoutePlanForm()
        {
            pictureBox1 = new PictureBox();
            pictureBox1.Size = new Size(TD_Width, TD_Height);
            InitializeComponent();
            this.Size = new Size(TD_Width, TD_Height);
            dm = new DataManager();
            pt = new PaintTool();
        }

        public void DrawRoutePicture()
        {
            pictureBox1.Size = new Size(TD_Width, TD_Height);
            Graphics gs;
            gs = Graphics.FromImage(bmp);
            int ix = dm.stationList.Count();
            List<double> staMile = new List<double>();
            pictureBox1.BackgroundImage = null;
            gs.Clear(this.pictureBox1.BackColor);
            if (TrainLine == false)
            {
                double total1 = dm.stationMileList.Last();
                pt.RoutePlanFrame(this.bmp.Width, 0, this.bmp.Height, total1, dm.depotMileList, gs, dm.depotStringList);
            }
            else
            {
                double total1 = dm.stationMileList.Last();
                pt.RoutePlanFrame(this.bmp.Width, 0, this.bmp.Height, total1, dm.depotMileList, gs, dm.depotStringList);
                pt.RoutePlanLine(gs, dm.TrainList, dm.depotStringList);
                pt.RouteConLine(0, this.bmp.Height, gs, dm.TrainDic, dm.depotStringList, dm.ConnInfo);

            }
            this.pictureBox1.BackgroundImage = bmp;
        }

        private void 绘制交路框架图ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TrainLine = false;
            DrawRoutePicture();
        }

        private void 绘制上下行交路图ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TrainLine = true;
            DrawRoutePicture();
        }

        private void 放大ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (TD_Width < 6000 && TD_Height < 4000)
            {
                TD_Width += 30;
                TD_Height += 20;
            }
            bmp = new Bitmap(TD_Width, TD_Height);
            pt.TimeX2 = new List<float>();
            pt.staY2 = new List<float>();
            DrawRoutePicture();
        }

        private void 缩小ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (TD_Width > 900 && TD_Height > 600)
            {
                TD_Width -= 30;
                TD_Height -= 20;
            }
            bmp = new Bitmap(TD_Width, TD_Height);
            pt.TimeX2 = new List<float>();
            pt.staY2 = new List<float>();
            DrawRoutePicture();
        }

        private void 导出交路框架图ToolStripMenuItem_Click(object sender, EventArgs e)
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
                            TrainLine = false;
                            DrawRoutePicture();
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

        private void 导出上下行交路图ToolStripMenuItem_Click(object sender, EventArgs e)
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
                            TrainLine = true;
                            DrawRoutePicture();
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

        private void RoutePlanForm_Load(object sender, EventArgs e)
        {

        }
    }
}
