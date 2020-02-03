using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraSelectionOfAssistant
{
    /// <summary>
    /// 快门类型
    /// </summary>
    public enum ShutterType
    {
        [Description("全局快门")]
        GlobalShutter = 0,

        [Description("卷帘快门")]
        RollingShutter

    }

    /// <summary>
    /// 传感器类型
    /// </summary>
    public enum SensorType
    {
        CMOS = 0,
        CCD
    }


    public class Size<T> : IComparable where T : struct
    {
        /// <summary>
        /// 水平
        /// </summary>
        public T Horizontal { get; set; }

        /// <summary>
        /// 垂直
        /// </summary>
        public T Vertical { get; set; }

        public Size()
        {

        }

        public Size(T horizontal, T vertical)
        {
            Horizontal = horizontal;
            Vertical = vertical;
        }

        public override string ToString()
        {
            if (this is Size<double>)
            {
                return $"{Horizontal:F00} x {Vertical:F2}";

            }
            else
            {
                return $"{Horizontal} x {Vertical}";
            }

        }

        public int CompareTo(object obj)
        {

            if (obj is Size<int>)
            {
                Size<int> data = obj as Size<int>;

                if (this is Size<int>)
                {
                    var size = this as Size<int>;
                    return size.Horizontal - data.Horizontal;
                }
            }
            else if (obj is Size<double>)
            {
                Size<double> data = obj as Size<double>;

                if (this is Size<double>)
                {
                    var size = this as Size<double>;
                    return (int)(size.Horizontal - data.Horizontal);
                }
            }

            throw new NotImplementedException();

        }

    }

    /// <summary>
    /// 传感器实例
    /// </summary>
    public class Sensor
    {
        public Sensor()
        {

        }

        /// <summary>
        /// 创建Sensor新实例
        /// </summary>
        /// <param name="name">传感器名</param>
        /// <param name="sensorType">传感器类型</param>
        /// <param name="shutterType">快门类型</param>
        /// <param name="resolutionSize">分辨率</param>
        /// <param name="pixelSize">像素尺寸</param>
        /// <param name="maxImageCircle">靶面尺寸</param>
        /// <param name="frameRate">帧率</param>
        public Sensor(string name, SensorType sensorType, ShutterType shutterType, Size<int> resolutionSize, double pixelSize, string maxImageCircle)
        {
            Name = name;
            SensorType = sensorType;
            ShutterType = shutterType;
            ResolutionSize = resolutionSize;
            PixelSize = pixelSize;
            MaxImageCircle = maxImageCircle;

            SensorSize = new Size<double>(ResolutionSize.Horizontal * pixelSize / 1000, ResolutionSize.Vertical * pixelSize / 1000);
            Resolution = ResolutionSize.Horizontal * ResolutionSize.Vertical;
            //FrameRate = frameRate;
        }

        /// <summary>
        /// 传感器名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 传感器类型
        /// </summary>
        public SensorType SensorType { get; set; }

        /// <summary>
        /// 快门类型
        /// </summary>
        public ShutterType ShutterType { get; set; }

        /// <summary>
        /// 靶面尺寸(英寸)
        /// </summary>
        public string MaxImageCircle { get; set; }

        /// <summary>
        /// 传感器尺寸(mm)
        /// </summary>
        public Size<double> SensorSize { get; set; }

        /// <summary>
        /// 分辨率(pixel)
        /// </summary>
        public Size<int> ResolutionSize { get; set; }

        /// <summary>
        /// 分辨率(pixel * pixel)
        /// </summary>
        public int Resolution { get; set; }

        /// <summary>
        /// 像素尺寸(um)
        /// </summary>
        public double PixelSize { get; set; }

        ///// <summary>
        ///// 帧率(fps)
        ///// </summary>
        //public double FrameRate { get; set; }

        /// <summary>
        /// 转换为字符串
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Name; 
        }
    }

}
