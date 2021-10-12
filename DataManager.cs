using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;



namespace TrainTimetable
{
    /// <summary>
    /// 列车开行方案、运行图、交路图数据管理工具
    /// </summary>
    class DataManager
    {
        /// <summary>
        /// 所有列车列表
        /// </summary>
        public List<Train> TrainList;

        /// <summary>
        /// 上行列车列表
        /// </summary>
        public List<Train> upTrainList;

        /// <summary>
        /// 下行列车列表
        /// </summary>
        public List<Train> downTrainList;

        /// <summary>
        /// 所有列车字典
        /// </summary>
        public Dictionary<string, Train> TrainDic;

        /// <summary>
        /// 上行列车字典
        /// </summary>
        public Dictionary<string, Train> UpTrainDic;

        /// <summary>
        /// 下行列车字典
        /// </summary>
        public Dictionary<string, Train> DownTrainDic;

        /// <summary>
        /// 车站列表
        /// </summary>
        public List<Station> stationList;

        /// <summary>
        /// 车站名列表
        /// </summary>
        public List<String> stationStringList;

        /// <summary>
        /// 车站里程列表
        /// </summary>
        public List<double> stationMileList;
        /// <summary>
        /// 动车段车站名称列表
        /// </summary>
        public List<String> depotStringList;

        /// <summary>
        /// 动车段车站里程列表
        /// </summary>
        public List<double> depotMileList;
        /// <summary>
        /// 列车衔接信息
        /// </summary>
        public Dictionary<string, List<List<string>>> ConnInfo;

        /// <summary>
        /// 将时间格式转化为分钟格式
        /// </summary>
        /// <param name="trainList">列车列表</param>
        public void ToMinute(List<Train> trainList)
        {
            foreach (Train train in TrainList)
            {
                train.MinuteDic = new Dictionary<string, List<int>>();
                foreach (KeyValuePair<string, List<string>> time in train.staTimeDic)
                {
                    List<int> minutelist = new List<int>();
                    if (train.staTimeDic[time.Key][0] != "")
                    {
                        if (train.staTimeDic[time.Key][0].Contains(":"))
                        {
                            string[] trainarrminute = train.staTimeDic[time.Key][0].Split(':');
                            minutelist.Add(int.Parse(trainarrminute[0]) * 60 + int.Parse(trainarrminute[1]));
                        } 
                        else
                        {
                            minutelist.Add(Convert.ToInt32(train.staTimeDic[time.Key][0]));
                        }
                    }
                    else minutelist.Add(0);

                    if (train.staTimeDic[time.Key][1] != "")
                    {
                        if (train.staTimeDic[time.Key][1].Contains(":"))
                        {
                            string[] traindepminute = train.staTimeDic[time.Key][1].Split(':');
                            minutelist.Add(int.Parse(traindepminute[0]) * 60 + int.Parse(traindepminute[1]));
                        }
                        else
                        {
                            minutelist.Add(Convert.ToInt32(train.staTimeDic[time.Key][1]));
                        }
                    }
                    else minutelist.Add(0);
                    train.MinuteDic.Add(time.Key, minutelist);
                }
            }
        }

        /// <summary>
        /// 读取车站文件（车站编号，车站名，车站里程，是否有动车所）
        /// </summary>
        /// <param name="Filename">车站文件名</param>
        public void ReadStation(string Filename)
        {
            StreamReader sr = new StreamReader(Filename, Encoding.UTF8);
            string str = sr.ReadLine();
            stationList = new List<Station>();
            stationStringList = new List<String>();
            stationMileList = new List<double>();
            while (str != null)
            {
                Station sta = new Station();
                str = str.Replace("\r", string.Empty).Replace("\"", string.Empty).Replace("\t", string.Empty).Replace("'", string.Empty).Replace("\\", string.Empty).Replace("\0", string.Empty).Replace("?", string.Empty).Replace("*", string.Empty);
                String[] strr = str.Split(',');
                sta.stationNo = strr[0];
                sta.stationName = strr[1];
                sta.totalMile = int.Parse(strr[2]);
                stationList.Add(sta);
                stationStringList.Add(sta.stationName);
                stationMileList.Add(sta.totalMile);
                str = sr.ReadLine();
            }
            sr.Close();
        }
        /// <summary>
        /// 读取列车信息（车次号，车站名，到点，发点，起讫站）
        /// </summary>
        /// <param name="Filename">列车时刻表文件</param>
        public void ReadTrain(string Filename)
        {
            TrainDic = new Dictionary<string, Train>();
            TrainDic.Clear();
            StreamReader sr = new StreamReader(Filename, Encoding.UTF8);
            sr.ReadLine();
            string str = sr.ReadLine();
            while (str != null)
            {
                Train tra = new Train();
                str = str.Replace("\r", string.Empty).Replace("\"", string.Empty).Replace("\t", string.Empty).Replace("'", string.Empty).Replace("\\", string.Empty).Replace("\0", string.Empty).Replace("?", string.Empty).Replace("*", string.Empty);
                String[] strr = str.Split(',');
                tra.TrainNo = strr[0];
                string staname = strr[1];
                if (Convert.ToInt16(strr[4]) == 1)//1表示始发站
                {
                    tra.OriSta = staname;
                }
                else if (Convert.ToInt16(strr[4]) == 2)//2表示终点站
                {
                    tra.DesSta = staname;
                }
                string LastNumber = tra.TrainNo.Substring(tra.TrainNo.Length - 1, 1);
                if ((LastNumber == "0") || (LastNumber == "2") || (LastNumber == "4") || (LastNumber == "6") || (LastNumber == "8"))
                {
                    tra.Dir = "up";
                }
                else
                {
                    tra.Dir = "down";
                }

                if (!TrainDic.ContainsKey(tra.TrainNo))
                {
                    tra.staTimeDic = new Dictionary<string, List<string>>();
                    if (!tra.staTimeDic.ContainsKey(staname))
                    {
                        List<string> timelist = new List<string>();
                        timelist.Add(strr[2]);
                        timelist.Add(strr[3]);
                        tra.staTimeDic.Add(staname, timelist);
                    }
                    TrainDic.Add(tra.TrainNo, tra);
                }
                else
                {
                    if (!TrainDic[tra.TrainNo].staTimeDic.ContainsKey(staname))
                    {
                        List<string> timelist = new List<string>();
                        timelist.Add(strr[2]);
                        timelist.Add(strr[3]);
                        TrainDic[tra.TrainNo].staTimeDic.Add(staname, timelist);
                    }
                }
                str = sr.ReadLine();
            }
            sr.Close();
            TrainList = new List<Train>();

            foreach (KeyValuePair<string, Train> trainNumber in TrainDic)//给trainList赋值
            {
                TrainList.Add(TrainDic[trainNumber.Key]);
            }
            for (int i = 0; i < TrainList.Count(); i++)
            {
                TrainList[i].staList = new List<string>();
                foreach (KeyValuePair<string, List<string>> stationName in TrainList[i].staTimeDic)
                {
                    TrainList[i].staList.Add(stationName.Key);
                }
            }
            ToMinute(TrainList);
        }
        

        /// <summary>
        /// 根据车次尾号将列车存入上行或下行列车字典
        /// </summary>
        public void DivideUpDown()
        {
            UpTrainDic = new Dictionary<string, Train>();
            DownTrainDic = new Dictionary<string, Train>();
            for (int i = 0; i < TrainList.Count; i++)
            {
                string LastNumber = TrainList[i].TrainNo.Substring(TrainList[i].TrainNo.Length - 1, 1);
                if ((LastNumber == "0") || (LastNumber == "2") || (LastNumber == "4") || (LastNumber == "6") || (LastNumber == "8"))
                {
                    UpTrainDic.Add(TrainList[i].TrainNo, TrainList[i]);
                }
                else if ((LastNumber == "1") || (LastNumber == "3") || (LastNumber == "5") || (LastNumber == "7") || (LastNumber == "9"))
                {
                    DownTrainDic.Add(TrainList[i].TrainNo, TrainList[i]);
                }
            }

            upTrainList = new List<Train>();

            foreach (KeyValuePair<string, Train> trainNumber in UpTrainDic)//给uptrainList赋值
            {
                upTrainList.Add(UpTrainDic[trainNumber.Key]);
            }
            for (int i = 0; i < upTrainList.Count(); i++)
            {
                upTrainList[i].staList = new List<string>();
                foreach (KeyValuePair<string, List<string>> trainNumber in upTrainList[i].staTimeDic)
                {
                    upTrainList[i].staList.Add(trainNumber.Key);
                }
            }
            ToMinute(upTrainList);

            downTrainList = new List<Train>();

            foreach (KeyValuePair<string, Train> trainNumber in DownTrainDic)//给uptrainList赋值
            {
                downTrainList.Add(DownTrainDic[trainNumber.Key]);
            }
            for (int i = 0; i < downTrainList.Count(); i++)
            {
                downTrainList[i].staList = new List<string>();
                foreach (KeyValuePair<string, List<string>> trainNumber in downTrainList[i].staTimeDic)
                {
                    downTrainList[i].staList.Add(trainNumber.Key);
                }
            }
            ToMinute(downTrainList);
        }

        /// <summary>
        /// 把车和车站关联，生成车站的列车列表
        /// </summary>
        public void AddTra2sta()
        {
            for (int i = 0; i < stationList.Count; i++)
            {
                stationList[i].upStaTraArrList = new List<Train>();
                stationList[i].upStaTraDepList = new List<Train>();
                for (int j = 0; j < upTrainList.Count; j++)
                {
                    if (upTrainList[j].staList.Contains(stationList[i].stationName))
                    {
                        stationList[i].upStaTraArrList.Add(upTrainList[j]);
                        stationList[i].upStaTraDepList.Add(upTrainList[j]);
                    }
                }
                stationList[i].upStaTraArrList.Sort(delegate (Train x, Train y)
                {
                    return x.MinuteDic[stationList[i].stationName][0].CompareTo(y.MinuteDic[stationList[i].stationName][0]);
                });
                stationList[i].upStaTraDepList.Sort(delegate (Train x, Train y)
                {
                    return x.MinuteDic[stationList[i].stationName][1].CompareTo(y.MinuteDic[stationList[i].stationName][1]);
                });
            }
            for (int i = 0; i < stationList.Count; i++)
            {
                stationList[i].downStaTraArrList = new List<Train>();
                stationList[i].downStaTraDepList = new List<Train>();
                for (int j = 0; j < downTrainList.Count; j++)
                {
                    if (downTrainList[j].staList.Contains(stationList[i].stationName))
                    {
                        stationList[i].downStaTraArrList.Add(downTrainList[j]);
                        stationList[i].downStaTraDepList.Add(downTrainList[j]);
                    }
                }
                stationList[i].downStaTraArrList.Sort(delegate (Train x, Train y)
                {
                    return x.MinuteDic[stationList[i].stationName][0].CompareTo(y.MinuteDic[stationList[i].stationName][0]);
                });
                stationList[i].downStaTraDepList.Sort(delegate (Train x, Train y)
                {
                    return x.MinuteDic[stationList[i].stationName][1].CompareTo(y.MinuteDic[stationList[i].stationName][1]);
                });
            }
        }

        /// <summary>
        /// 将上下行的停站存入isStopDic字典里
        /// </summary>
        public void GetStop()
        {
            for (int i = 0; i < upTrainList.Count; i++)
            {
                upTrainList[i].isStopDic = new Dictionary<string, bool>();
                for (int j = 0; j < upTrainList[i].staList.Count; j++)
                {
                    if (upTrainList[i].staTimeDic[upTrainList[i].staList[j]][0] == upTrainList[i].staTimeDic[upTrainList[i].staList[j]][1])
                    {
                        upTrainList[i].isStopDic.Add(upTrainList[i].staList[j], false);
                    }
                    else
                    {
                        upTrainList[i].isStopDic.Add(upTrainList[i].staList[j], true);
                    }
                }
            }

            for (int i = 0; i < downTrainList.Count; i++)
            {
                downTrainList[i].isStopDic = new Dictionary<string, bool>();
                for (int j = 0; j < downTrainList[i].staList.Count; j++)
                {
                    if (downTrainList[i].staTimeDic[downTrainList[i].staList[j]][0] == downTrainList[i].staTimeDic[downTrainList[i].staList[j]][1])
                    {
                        downTrainList[i].isStopDic.Add(downTrainList[i].staList[j], false);
                    }
                    else
                    {
                        downTrainList[i].isStopDic.Add(downTrainList[i].staList[j], true);
                    }
                }
            }
        }

    }
}
