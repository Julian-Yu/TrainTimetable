using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;

namespace TrainTimetable
{
    /// <summary>
    /// 列车开行方案、运行图、交路图绘制工具
    /// </summary>
    class PaintTool
    {
        Font font = new Font("宋体", 8f);
        Brush brush = new SolidBrush(Color.Green);
        StringFormat SF = new StringFormat();
        StringFormat SF1 = new StringFormat();

        List<string> Str = new List<string>();
        List<double> Mile = new List<double>();
        public Dictionary<int, List<string>> str1 = new Dictionary<int, List<string>>();
        /// <summary>
        /// 画运行图的横坐标
        /// </summary>
        public List<float> TimeX = new List<float>();
        /// <summary>
        /// 画运行图的纵坐标
        /// </summary>
        public List<float> staY = new List<float>();
        /// <summary>
        /// 画交路图的横坐标
        /// </summary>
        public List<float> TimeX2 = new List<float>();
        /// <summary>
        /// 画交路图的纵坐标
        /// </summary>
        public List<float> staY2 = new List<float>();
        /// <summary>
        /// 周期（单位：小时）
        /// </summary>
        int TimeCycle = 6;

        /// <summary>
        /// 运行图基本框架
        /// </summary>
        /// <param name="WinWidth">运行图窗口宽度</param>
        /// <param name="WinUp">运行图上边界坐标</param>
        /// <param name="WinDown">运行图下边界坐标</param>
        /// <param name="TotalMile">总里程</param>
        /// <param name="StationMile">车站里程列表</param>
        /// <param name="gs">画图区</param>
        /// <param name="StationName">车站名列表</param>
        public void TimetableFrame(double WinWidth, double WinUp, double WinDown, double TotalMile, List<double> StationMile, Graphics gs, List<string> StationName)
        {
            double WinHeight = WinDown - WinUp;
            SF.Alignment = StringAlignment.Far;
            SF1.Alignment = StringAlignment.Center;
            float Left = 55;//运行图左边留白
            float Right = 10;//运行图右边留白
            float Up = 15;//运行图上边留白
            float Down = 15;//运行图下边留白
            PointF p2 = new PointF();
            Pen pp1 = new Pen(Color.DarkSeaGreen, 1);
            Pen pp3 = new Pen(Color.Green, 1);
            pp3.DashStyle = DashStyle.Custom;
            pp3.DashPattern = new float[] { 10f, 5f };
            Pen pp4 = new Pen(Color.Green, 1);
            double Width = WinWidth - (Left + Right);
            double Height = WinHeight - (Up + Down);
            PointF p1 = new PointF();
            p1.X = Left;
            p1.Y = (float)(Up + WinUp);
            p2.X = Left;
            int a = StationMile.Count;
            p2.Y = (float)(WinUp + Up + Height * StationMile[a - 1] / TotalMile);
            double add1 = Width / (TimeCycle * 60);
            float add = (float)add1;
            float xx;
            int Hour = 0;
            for (int j = 0; j <= TimeCycle * 60; j++)
            {
                if (j % 2 == 0)
                {
                    if (j % 60 == 0)
                    {
                        Pen pp2 = new Pen(Color.Green, 2);
                        gs.DrawLine(pp2, p1, p2);
                        gs.DrawString(Convert.ToString(Hour), font, brush, p2.X, p2.Y + 5, SF1);//在边框下方添加插入时间语句
                        gs.DrawString(Convert.ToString(Hour), font, brush, p1.X, p1.Y - 15, SF1);//在边框上方这添加插入时间语句
                        TimeX.Add(p1.X);
                        p1.X = (float)(p1.X + add);
                        p2.X = (float)(p2.X + add);
                        if (Hour < 23)
                        {
                            Hour++;
                        }
                        else
                        {
                            Hour = 0;
                        }
                    }
                    else if (j % 60 != 0 && j % 30 == 0)
                    {
                        gs.DrawLine(pp3, p1, p2);
                        TimeX.Add(p1.X);
                        p1.X = (float)(p1.X + add);
                        p2.X = (float)(p2.X + add);
                    }
                    else if (j % 60 != 0 && j % 30 != 0 && j % 10 == 0)
                    {
                        gs.DrawLine(pp4, p1, p2);
                        TimeX.Add(p1.X);
                        p1.X = (float)(p1.X + add);
                        p2.X = (float)(p2.X + add);
                    }
                    else
                    {
                        gs.DrawLine(pp1, p1, p2);
                        TimeX.Add(p1.X);
                        p1.X = (float)(p1.X + add);
                        p2.X = (float)(p2.X + add);
                    }
                }
                else
                {
                    TimeX.Add(p1.X);
                    p1.X = (float)(p1.X + add);
                    p2.X = (float)(p2.X + add);
                }
            }
            xx = p1.X - add;
            ////////////////////////////////////////////////以上是时间线
            pp1 = new Pen(Color.Green, 2);
            p1.X = Left;
            p2.X = xx;
            int n = StationMile.Count();
            for (int k = 0; k < n; k++)
            {
                p1.Y = (float)(WinUp + Up + Height * StationMile[k] / TotalMile);
                p2.Y = (float)(WinUp + Up + Height * StationMile[k] / TotalMile);
                gs.DrawLine(pp1, p1, p2);
                gs.DrawString(StationName[k], font, brush, p1.X - 5, p1.Y - 5, SF);//在这插入车站标签语句
                staY.Add(p1.Y);
            }
        }
        /// <summary>
        /// 列车运行线绘制
        /// </summary>
        /// <param name="gs">画图区</param>
        /// <param name="TrainList">列车列表</param>
        /// <param name="StaionList">车站列表</param>
        public void TrainLine(Graphics gs, List<Train> TrainList, List<string> StaionList)
        {
            Pen pp = new Pen(Color.Red, (float)1.2);
            PointF p1 = new PointF();
            PointF p2 = new PointF();
            PointF p3 = new PointF();
            PointF p4 = new PointF();
            foreach (Train train in TrainList)
            {
                int a = train.staList.Count;
                for (int i = 0; i < a - 1; i++)
                {
                    if (StaionList.IndexOf(train.staList[i]) != -1 && StaionList.IndexOf(train.staList[i + 1]) != -1)
                    {


                        if (train.Dir == "down")
                        {
                            if (System.Math.Abs(train.MinuteDic[train.staList[i + 1]][1] - train.MinuteDic[train.staList[i]][0]) > 2 * 30)
                            {
                                int index1 = StaionList.IndexOf(train.staList[i]);
                                int index2 = StaionList.IndexOf(train.staList[i + 1]);
                                p1.Y = staY[index1];
                                p2.Y = staY[index2];
                                int i1 = train.MinuteDic[train.staList[i]][0];
                                int i2 = train.MinuteDic[train.staList[i + 1]][1];
                                int c = (int)Math.Floor((double)(i1 + i2) / (2 * 120));
                                p1.X = TimeX[i1];
                                p2.X = TimeX[i2];
                                p3.X = TimeX[(c + 1) * 120];
                                p4.X = TimeX[c * 120];
                                p3.Y = (float)(TimeX[(c + 1) * 120] - p2.X) * (p1.Y - p2.Y) / ((TimeX[(c + 1) * 120] - p2.X) + (p1.X - TimeX[c * 120])) + p2.Y;
                                p4.Y = p3.Y;
                                gs.DrawLine(pp, p2, p3);
                                gs.DrawLine(pp, p1, p4);
                                train.CrossCycle = true;
                            }
                            else
                            {
                                int index1 = StaionList.IndexOf(train.staList[i]);
                                int index2 = StaionList.IndexOf(train.staList[i + 1]);
                                p1.Y = staY[index1];
                                p2.Y = staY[index2];
                                int i1 = train.MinuteDic[train.staList[i]][0];
                                int i2 = train.MinuteDic[train.staList[i + 1]][1];
                                p1.X = TimeX[i1];
                                p2.X = TimeX[i2];
                                p1.Y = staY[index1];
                                p2.Y = staY[index2];
                                gs.DrawLine(pp, p1, p2);
                            }

                        }
                        else if (train.Dir == "up")
                        {
                            if (System.Math.Abs(train.MinuteDic[train.staList[i + 1]][0] - train.MinuteDic[train.staList[i]][1]) > 2 * 30)
                            {
                                int index1 = StaionList.IndexOf(train.staList[i]);
                                int index2 = StaionList.IndexOf(train.staList[i + 1]);
                                p1.Y = staY[index1];
                                p2.Y = staY[index2];
                                int i1 = train.MinuteDic[train.staList[i]][1];
                                int i2 = train.MinuteDic[train.staList[i + 1]][0];
                                int c = (int)Math.Floor((double)(i1 + i2) / (2 * 120));
                                p1.X = TimeX[i1];
                                p2.X = TimeX[i2];
                                p3.X = TimeX[(c + 1) * 120];
                                p4.X = TimeX[c * 120];
                                p3.Y = (float)(TimeX[(c + 1) * 120] - p1.X) * (p2.Y - p1.Y) / ((TimeX[(c + 1) * 120] - p1.X) + (p2.X - TimeX[c * 120])) + p1.Y;
                                p4.Y = p3.Y;
                                gs.DrawLine(pp, p1, p3);
                                gs.DrawLine(pp, p2, p4);
                                train.CrossCycle = true;
                            }
                            else
                            {
                                int index1 = StaionList.IndexOf(train.staList[i]);
                                int index2 = StaionList.IndexOf(train.staList[i + 1]);
                                p1.Y = staY[index1];
                                p2.Y = staY[index2];
                                int i1 = train.MinuteDic[train.staList[i]][1];
                                int i2 = train.MinuteDic[train.staList[i + 1]][0];
                                p1.X = TimeX[i1];
                                p2.X = TimeX[i2];
                                p1.Y = staY[index1];
                                p2.Y = staY[index2];
                                gs.DrawLine(pp, p1, p2);
                            }

                        }


                    }
                }
                for (int i = 1; i < a - 1; i++)
                {
                    if (StaionList.IndexOf(train.staList[i]) != -1 && train.staList[i] != StaionList[0] && train.staList[i] != StaionList[StaionList.Count - 1])
                    {
                        if (System.Math.Abs(train.MinuteDic[train.staList[i]][0] - train.MinuteDic[train.staList[i]][1]) > 2 * 30)
                        {
                            int index1 = StaionList.IndexOf(train.staList[i]);
                            int i1 = train.MinuteDic[train.staList[i]][0];
                            int i2 = train.MinuteDic[train.staList[i]][1];
                            int c = (int)Math.Floor((double)(i1 + i2) / (2 * 120));
                            p1.X = TimeX[i1];
                            p2.X = TimeX[i2];
                            p1.Y = staY[index1];
                            p2.Y = staY[index1];
                            p3.X = TimeX[(c + 1) * 120];
                            p4.X = TimeX[(c) * 120];
                            p3.Y = staY[index1];
                            p4.Y = p3.Y;
                            if (train.Dir == "down")
                            {
                                gs.DrawLine(pp, p1, p3);
                                gs.DrawLine(pp, p4, p2);
                            }
                            else if (train.Dir == "up")
                            {
                                gs.DrawLine(pp, p1, p3);
                                gs.DrawLine(pp, p4, p2);
                            }
                            train.CrossCycle = true;
                        }
                        else
                        {
                            int index1 = StaionList.IndexOf(train.staList[i]);
                            int i1 = train.MinuteDic[train.staList[i]][0];
                            int i2 = train.MinuteDic[train.staList[i]][1];
                            p1.X = TimeX[i1];
                            p2.X = TimeX[i2];
                            p1.Y = staY[index1];
                            p2.Y = staY[index1];
                            gs.DrawLine(pp, p1, p2);
                        }

                    }
                }
            }
        }
        /// <summary>
        /// 画出交路航空图框架
        /// </summary>
        /// <param name="WinWidth">窗口宽度</param>
        /// <param name="WinUp">窗口上界</param>
        /// <param name="WinDown">窗口下界</param>
        /// <param name="TotalMile">总里程</param>
        /// <param name="DepotStationMile">动车段车站里程</param>
        /// <param name="gs">画图区</param>
        /// <param name="DepotStationName">动车段车站名称</param>
        public void RoutePlanFrame(double WinWidth, double WinUp, double WinDown, double TotalMile, List<double> DepotStationMile, Graphics gs, List<string> DepotStationName)
        {
            double WinHeight = WinDown - WinUp;
            SF.Alignment = StringAlignment.Far;
            SF1.Alignment = StringAlignment.Center;
            float Left = 55;//运行图左边留白
            float Right = 10;//运行图右边留白
            float Up = 50;//运行图上边留白
            float Down = 50;//运行图下边留白
            PointF p2 = new PointF();
            Pen pp1 = new Pen(Color.DarkSeaGreen, 1);
            Pen pp3 = new Pen(Color.Green, 1);
            pp3.DashStyle = DashStyle.Custom;
            pp3.DashPattern = new float[] { 10f, 5f };
            Pen pp4 = new Pen(Color.Green, 1);
            double Width = WinWidth - (Left + Right);
            double Height = WinHeight - (Up + Down);
            PointF p1 = new PointF();
            p1.X = Left;
            p1.Y = (float)(Up + WinUp);
            p2.X = Left;
            int a = DepotStationMile.Count;

            p2.Y = (float)(WinUp + Up + Height * DepotStationMile[a - 1] / TotalMile);
            double add1 = Width / (TimeCycle * 60);
            float add = (float)add1;
            float xx;
            int Hour = 0;
            for (int j = 0; j <= TimeCycle * 60; j++)
            {
                if (j % 2 == 0)
                {
                    if (j % 60 == 0)
                    {
                        Pen pp2 = new Pen(Color.Green, 2);
                        gs.DrawLine(pp2, p1, p2);
                        gs.DrawString(Convert.ToString(Hour), font, brush, p2.X, p2.Y + 5, SF1);//在边框下方添加插入时间语句
                        gs.DrawString(Convert.ToString(Hour), font, brush, p1.X, p1.Y - 15, SF1);//在边框上方这添加插入时间语句
                        TimeX2.Add(p1.X);
                        p1.X = (float)(p1.X + add);
                        p2.X = (float)(p2.X + add);
                        if (Hour < 23)
                        {
                            Hour++;
                        }
                        else
                        {
                            Hour = 0;
                        }
                    }
                    else if (j % 60 != 0 && j % 30 == 0)
                    {
                        gs.DrawLine(pp3, p1, p2);
                        TimeX2.Add(p1.X);
                        p1.X = (float)(p1.X + add);
                        p2.X = (float)(p2.X + add);
                    }
                    else
                    {
                        TimeX2.Add(p1.X);
                        p1.X = (float)(p1.X + add);
                        p2.X = (float)(p2.X + add);
                    }
                }
                else
                {
                    TimeX2.Add(p1.X);
                    p1.X = (float)(p1.X + add);
                    p2.X = (float)(p2.X + add);
                }
            }
            xx = p1.X - add;
            ////////////////////////////////////////////////以上是时间线
            pp1 = new Pen(Color.Green, 2);
            p1.X = Left;
            p2.X = xx;
            int n = DepotStationMile.Count();
            for (int k = 0; k < n; k++)
            {
                p1.Y = (float)(WinUp + Up + Height * DepotStationMile[k] / TotalMile);
                p2.Y = (float)(WinUp + Up + Height * DepotStationMile[k] / TotalMile);
                gs.DrawLine(pp1, p1, p2);
                gs.DrawString(DepotStationName[k], font, brush, p1.X - 5, p1.Y - 5, SF);//在这插入车站标签语句
                staY2.Add(p1.Y);
            }
        }
        /// <summary>
        /// 画出交路图的运行线
        /// </summary>
        /// <param name="gs">画图区</param>
        /// <param name="TrainList">列车列表</param>
        /// <param name="DepotStaionList">动车段车站列表</param>
        public void RoutePlanLine(Graphics gs, List<Train> TrainList, List<string> DepotStaionList)
        {
            Pen pp = new Pen(Color.Red, (float)1.2);
            PointF p1 = new PointF();
            PointF p2 = new PointF();
            PointF p3 = new PointF();
            PointF p4 = new PointF();
            foreach (Train train in TrainList)
            {
                if (DepotStaionList.IndexOf(train.OriSta) != -1 && DepotStaionList.IndexOf(train.DesSta) != -1)
                {
                    int index1 = DepotStaionList.IndexOf(train.OriSta);
                    int index2 = DepotStaionList.IndexOf(train.DesSta);
                    int Os = train.staList.IndexOf(train.OriSta);
                    int Ds = train.staList.IndexOf(train.DesSta);
                    int i1 = train.MinuteDic[train.staList[Os]][1];
                    int i2 = train.MinuteDic[train.staList[Ds]][0];
                    if (train.CrossCycle)
                    {
                        p1.X = TimeX2[i1];
                        p2.X = TimeX2[i2];
                        p1.Y = staY2[index1];
                        p2.Y = staY2[index2];
                        p3.X = TimeCycle * 60;
                        p4.X = 0;
                        if (train.Dir == "up")
                        {
                            if (p1.Y > p2.Y)
                            {
                                p3.Y = (float)(p1.Y * p2.X + p2.Y * (TimeCycle * 60 - p1.X)) / (TimeCycle * 60 - p1.X + p2.X);
                                p4.Y = p3.Y;
                                gs.DrawLine(pp, p1, p3);
                                gs.DrawLine(pp, p2, p4);
                            }
                            else if (p1.Y < p2.Y)
                            {
                                p3.Y = (float)(p2.Y * p1.X + p1.Y * (TimeCycle * 60 - p2.X)) / (TimeCycle * 60 - p2.X + p1.X);
                                p4.Y = p3.Y;
                                gs.DrawLine(pp, p2, p3);
                                gs.DrawLine(pp, p1, p4);
                            }
                        }
                        else if (train.Dir == "down")
                        {
                            if (p1.Y > p2.Y)
                            {
                                p3.Y = (float)(p2.Y * p1.X + p1.Y * (TimeCycle * 60 - p2.X)) / (TimeCycle * 60 - p2.X + p1.X);
                                p4.Y = p3.Y;
                                gs.DrawLine(pp, p2, p3);
                                gs.DrawLine(pp, p1, p4);
                            }
                            else if (p1.Y < p2.Y)
                            {
                                p3.Y = (float)(p1.Y * p2.X + p2.Y * (TimeCycle * 60 - p1.X)) / (TimeCycle * 60 - p1.X + p2.X);
                                p4.Y = p3.Y;
                                gs.DrawLine(pp, p1, p3);
                                gs.DrawLine(pp, p2, p4);
                            }
                        }
                        else
                        {
                            p1.X = TimeX2[i1];
                            p2.X = TimeX2[i2];
                            p1.Y = staY2[index1];
                            p2.Y = staY2[index2];
                            gs.DrawLine(pp, p1, p2);
                        }
                    }
                }
            }
        }
        /// <summary>
        /// 画出交路连接线
        /// </summary>
        /// <param name="gs">画图区</param>
        /// <param name="TrainDic">列车字典</param>
        /// <param name="ConnInfo">交路连接信息</param>
        public void RouteConLine(double WinUp, double WinDown, Graphics gs, Dictionary<string, Train> TrainDic, List<string> DepotStaionList, Dictionary<string, List<List<string>>> ConnInfo)
        {
            Pen pp = new Pen(Color.Red, (float)1.2);
            ///表示画车站横线的部分是否被占用，默认是false
            Dictionary<string, Dictionary<int, Dictionary<int, bool>>> OccupyOrNot = new Dictionary<string, Dictionary<int, Dictionary<int, bool>>>();
            int n = TimeCycle * 60;
            foreach (string station in DepotStaionList)
            {
                Dictionary<int, Dictionary<int, bool>> stationPoint = new Dictionary<int, Dictionary<int, bool>>();
                for (int j = 0; j < 5; j++)
                {
                    Dictionary<int, bool> TimePoint = new Dictionary<int, bool>();
                    for (int i = 0; i <= n; i++)
                    {
                        TimePoint.Clear();
                        TimePoint.Add(i, false);
                    }
                    stationPoint.Add(j, TimePoint);
                }
                OccupyOrNot.Add(station, stationPoint);
            }

            foreach (KeyValuePair<string, List<List<string>>> station in ConnInfo)
            {
                int index = DepotStaionList.IndexOf(station.Key);
                float baseY = staY2[index];
                if (baseY > (WinUp + WinDown) / 2)// 在画图的上半部分
                {
                    foreach (List<string> trainPair in ConnInfo[station.Key])
                    {
                        int time1 = TrainDic[trainPair[0]].MinuteDic[station.Key][0];//第一列车到时
                        int time2 = TrainDic[trainPair[1]].MinuteDic[station.Key][1];//第二列车发时
                        PointF p1 = new PointF();
                        PointF p2 = new PointF();
                        PointF p3 = new PointF();
                        PointF p4 = new PointF();
                        if (time1 >= time2)//跨周期
                        {
                            PointF p5 = new PointF();
                            PointF p6 = new PointF();
                            for (int i = 0; i < OccupyOrNot[station.Key].Count(); i++)
                            {
                                bool o = false;
                                for (int k = time2; k <= TimeCycle * 60; k++)
                                {
                                    if (OccupyOrNot[station.Key][i][k])
                                    {
                                        o = true;
                                        break;
                                    }
                                }
                                for (int k = 0; k <= time1; k++)
                                {
                                    if (OccupyOrNot[station.Key][i][k])
                                    {
                                        o = true;
                                        break;
                                    }
                                }
                                if (o == false)
                                {
                                    p1.X = TimeX2[time1];
                                    p1.Y = baseY;
                                    p2.X = TimeX2[time2];
                                    p2.Y = baseY;
                                    p3.X = p1.X;
                                    p4.X = p2.X;
                                    p3.Y = p1.Y + 5 * (i + 1);
                                    p4.Y = p2.Y + 5 * (i + 1);
                                    p5.X = 0;
                                    p6.X = TimeCycle * 60;
                                    p5.Y = p1.Y + 5 * (i + 1);
                                    p6.Y = p1.Y + 5 * (i + 1);
                                    gs.DrawLine(pp, p1, p3);
                                    gs.DrawLine(pp, p3, p6);
                                    gs.DrawLine(pp, p4, p2);
                                    gs.DrawLine(pp, p4, p5);
                                    for (int k = time1; k <= TimeCycle * 60; k++)
                                    {
                                        OccupyOrNot[station.Key][i][k] = true;
                                    }
                                    for (int k = 0; k <= time2; k++)
                                    {
                                        OccupyOrNot[station.Key][i][k] = true;
                                    }
                                }
                            }
                        }
                        else
                        {
                            for (int i = 0; i < OccupyOrNot[station.Key].Count(); i++)
                            {
                                bool o = false;
                                for (int k = time1; k <= time2; k++)
                                {
                                    if (OccupyOrNot[station.Key][i][k])
                                    {
                                        o = true;
                                        break;
                                    }
                                }
                                if (o == false)
                                {
                                    p1.X = TimeX2[time1];
                                    p1.Y = baseY;
                                    p2.X = TimeX2[time2];
                                    p2.Y = baseY;
                                    p3.X = p1.X;
                                    p4.X = p2.X;
                                    p3.Y = p1.Y + 5 * (i + 1);
                                    p4.Y = p2.Y + 5 * (i + 1);
                                    gs.DrawLine(pp, p1, p3);
                                    gs.DrawLine(pp, p3, p4);
                                    gs.DrawLine(pp, p4, p2);
                                    for (int k = time1; k <= time2; k++)
                                    {
                                        OccupyOrNot[station.Key][i][k] = true;
                                    }
                                }
                            }
                        }
                    }
                }
                else // 在画图的下半部分
                {
                    foreach (List<string> trainPair in ConnInfo[station.Key])
                    {
                        int time1 = TrainDic[trainPair[0]].MinuteDic[station.Key][0];//第一列车到时
                        int time2 = TrainDic[trainPair[1]].MinuteDic[station.Key][1];//第二列车发时
                        PointF p1 = new PointF();
                        PointF p2 = new PointF();
                        PointF p3 = new PointF();
                        PointF p4 = new PointF();
                        if (time1 >= time2)//跨周期
                        {
                            PointF p5 = new PointF();
                            PointF p6 = new PointF();
                            for (int i = 0; i < OccupyOrNot[station.Key].Count(); i++)
                            {
                                bool o = false;
                                for (int k = time2; k <= TimeCycle * 60; k++)
                                {
                                    if (OccupyOrNot[station.Key][i][k])
                                    {
                                        o = true;
                                        break;
                                    }
                                }
                                for (int k = 0; k <= time1; k++)
                                {
                                    if (OccupyOrNot[station.Key][i][k])
                                    {
                                        o = true;
                                        break;
                                    }
                                }
                                if (o == false)
                                {
                                    p1.X = TimeX2[time1];
                                    p1.Y = baseY;
                                    p2.X = TimeX2[time2];
                                    p2.Y = baseY;
                                    p3.X = p1.X;
                                    p4.X = p2.X;
                                    p3.Y = p1.Y - 5 * (i + 1);
                                    p4.Y = p2.Y - 5 * (i + 1);
                                    p5.X = 0;
                                    p6.X = TimeCycle * 60;
                                    p5.Y = p1.Y - 5 * (i + 1);
                                    p6.Y = p1.Y - 5 * (i + 1);
                                    gs.DrawLine(pp, p1, p3);
                                    gs.DrawLine(pp, p3, p6);
                                    gs.DrawLine(pp, p4, p2);
                                    gs.DrawLine(pp, p4, p5);
                                    for (int k = time1; k <= TimeCycle * 60; k++)
                                    {
                                        OccupyOrNot[station.Key][i][k] = true;
                                    }
                                    for (int k = 0; k <= time2; k++)
                                    {
                                        OccupyOrNot[station.Key][i][k] = true;
                                    }
                                }
                            }
                        }
                        else
                        {
                            for (int i = 0; i < OccupyOrNot[station.Key].Count(); i++)
                            {
                                bool o = false;
                                for (int k = time1; k <= time2; k++)
                                {
                                    if (OccupyOrNot[station.Key][i][k])
                                    {
                                        o = true;
                                        break;
                                    }
                                }
                                if (o == false)
                                {
                                    p1.X = TimeX2[time1];
                                    p1.Y = baseY;
                                    p2.X = TimeX2[time2];
                                    p2.Y = baseY;
                                    p3.X = p1.X;
                                    p4.X = p2.X;
                                    p3.Y = p1.Y - 5 * (i + 1);
                                    p4.Y = p2.Y - 5 * (i + 1);
                                    gs.DrawLine(pp, p1, p3);
                                    gs.DrawLine(pp, p3, p4);
                                    gs.DrawLine(pp, p4, p2);
                                    for (int k = time1; k <= time2; k++)
                                    {
                                        OccupyOrNot[station.Key][i][k] = true;
                                    }
                                }
                            }
                        }
                    }
                }
            }

        }

    }
}
