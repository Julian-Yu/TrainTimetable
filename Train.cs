using System.Collections.Generic;
using System.Drawing;

namespace TrainTimetable
{
    /// <summary>
    /// 列车类
    /// </summary>
    class Train
    {
        /// <summary>
        ///判断是否初次生成trainDic
        /// </summary>
        public bool newbool = true;
        /// <summary>
        ///车次信息
        /// </summary>
        public string TrainNo;
        /// <summary>
        ///始发站
        /// </summary>
        public string OriSta;
        /// <summary>
        ///终到站
        /// </summary>
        public string DesSta;
        /// <summary>
        ///存放列车在各站时刻信息
        /// </summary>
        public Dictionary<string, List<string>> staTimeDic;
        /// <summary>
        ///存放列车在各站时刻信息
        /// </summary>
        public List<string> staList;
        /// <summary>
        ///存放列车在各站时刻int信息
        /// </summary>
        public Dictionary<string, List<int>> MinuteDic;
        /// <summary>
        ///存放列车是否停站信息，true为停，false为不停
        /// </summary>
        public Dictionary<string, bool> isStopDic;
        /// <summary>
        /// 列车运行方向
        /// </summary>
        public string Dir;
        /// <summary>
        /// 列车是否跨越周期
        /// </summary>
        public bool CrossCycle = false;
    }
}
