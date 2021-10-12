using System.Collections.Generic;

namespace TrainTimetable
{
    /// <summary>
    /// 车站类
    /// </summary>
    class Station
    {
        /// <summary>
        ///车站序号
        /// </summary>
        public string stationNo;
        /// <summary>
        ///车站名称
        /// </summary>
        public string stationName;
        /// <summary>
        ///车站累计里程
        /// </summary>
        public int totalMile;
        /// <summary>
        /// 车站在画图中的相对距离，全程为100
        /// </summary>
        public double relativeDis;
        /// <summary>
        /// 车站上行到达列车列表
        /// </summary>
        public List<Train> upStaTraArrList;
        /// <summary>
        /// 车站上行出发列车列表
        /// </summary>
        public List<Train> upStaTraDepList;
        /// <summary>
        /// 车站下行到达列车列表
        /// </summary>
        public List<Train> downStaTraArrList;
        /// <summary>
        /// 车站下行出发列车列表
        /// </summary>
        public List<Train> downStaTraDepList;

    }
}

