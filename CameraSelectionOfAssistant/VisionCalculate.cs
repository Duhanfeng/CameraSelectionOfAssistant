using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraSelectionOfAssistant
{
    static class VisionCalculate
    {
        /// <summary>
        /// 计算分辨率
        /// </summary>
        /// <param name="viewLength">视野(单位:mm)</param>
        /// <param name="precision">精度(单位:mm)</param>
        /// <param name="multiple">倍数</param>
        /// <returns>分辨率</returns>
        public static int CalculatePixel(double viewLength, double precision, double multiple = 2)
        {
            double pixel = viewLength / precision * multiple;
            return (int)pixel;
        }

        /// <summary>
        /// 计算高度(单位:mm)
        /// </summary>
        /// <param name="sensorLength">传感器尺寸(单位:mm)</param>
        /// <param name="viewLength">视野(单位:mm)</param>
        /// <param name="focus">焦距(单位:mm)</param>
        /// <returns>高度(单位:mm)</returns>
        public static double CalculateHeight(double sensorLength, double viewLength, double focus)
        {

            return viewLength / sensorLength * focus;
        }

        /// <summary>
        /// 计算焦距(单位:mm)
        /// </summary>
        /// <param name="sensorLength">传感器尺寸(单位:mm)</param>
        /// <param name="viewLength">视野(单位:mm)</param>
        /// <param name="height">高度(单位:mm)</param>
        /// <returns>焦距(单位:mm)</returns>
        public static double CalculateFocus(double sensorLength, double viewLength, double height)
        {
            return sensorLength / viewLength * height;
        }

        /// <summary>
        /// 计算视野(单位:mm)
        /// </summary>
        /// <param name="sensorLength">传感器尺寸(单位:mm)</param>
        /// <param name="focus">焦距(单位:mm)</param>
        /// <param name="height">高度(单位:mm)</param>
        /// <returns>视野(单位:mm)</returns>
        public static double CalculateViewLength(double sensorLength, double focus, double height)
        {
            return sensorLength / focus * height;
        }

        /// <summary>
        /// 传感器尺寸(单位:mm)
        /// </summary>
        /// <param name="viewLength">视野(单位:mm)</param>
        /// <param name="focus">焦距(单位:mm)</param>
        /// <param name="height">高度(单位:mm)</param>
        /// <returns>传感器尺寸(单位:mm)</returns>
        public static double CalculateSensorLength(double viewLength, double focus, double height)
        {
            return  focus / height * viewLength;
        }
    }
}
