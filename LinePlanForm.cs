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
    public partial class LinePlanForm : Form
    {
        public LinePlanForm()
        {
            InitializeComponent();
        }
        public void DrawLinePlanPicture()
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
        private void LinePlanForm_Load(object sender, EventArgs e)
        {

        }

        private void 绘制开行方案ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
