using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DhfLib.Serialization;
using Caliburn.Micro;
using System.Collections.ObjectModel;

namespace CameraSelectionOfAssistant
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();

            DataContext = new MainWindowViewModel();

            //Sensor sensor = JsonSerialization.DeserializeObjectFromFile<Sensor>("EV76C570.json");
            ////Sensor sensor = new Sensor("EV76C570", ShutterType.GlobalShutter, new Size<int>(1602, 1202), 4.5, @"1/1.8", 60);
            ////JsonSerialization.SerializeObjectToFile(sensor, $"{sensor.Name}.json");
            //Console.WriteLine(sensor);
        }

        /// <summary>
        /// 按下事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                TextBox tb = sender as TextBox;
                BindingExpression be = tb.GetBindingExpression(TextBox.TextProperty);
                be.UpdateSource();
            }
        }

        /// <summary>
        /// 失去焦点事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = sender as TextBox;
            BindingExpression be = tb.GetBindingExpression(TextBox.TextProperty);
            be.UpdateSource();

            tb.PreviewMouseDown += new MouseButtonEventHandler(TextBox_PreviewMouseDown);
        }

        #region 实现点击后自动全选功能

        private void TextBox_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            var textBox = sender as TextBox;
            textBox.Focus();
            e.Handled = true;
        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            var textBox = sender as TextBox;
            textBox.SelectAll();
            textBox.PreviewMouseDown -= new MouseButtonEventHandler(TextBox_PreviewMouseDown);
        }

        #endregion

    }

    public class MainWindowViewModel : Screen
    {
        private ObservableCollection<Sensor> _sensors = new ObservableCollection<Sensor>();

        /// <summary>
        /// 传感器
        /// </summary>
        public ObservableCollection<Sensor> Sensors
        {
            get { return _sensors; }
            set { _sensors = value; NotifyOfPropertyChange(() => Sensors); }
        }

        private ObservableCollection<Sensor> _validSensors = new ObservableCollection<Sensor>();

        /// <summary>
        /// 有效传感器
        /// </summary>
        public ObservableCollection<Sensor> ValidSensors
        {
            get { return _validSensors; }
            set { _validSensors = value; NotifyOfPropertyChange(() => ValidSensors); }
        }

        public MainWindowViewModel()
        {
            Sensor sensor;

            sensor = new Sensor("AR0521", SensorType.CMOS, ShutterType.RollingShutter, new Size<int>(2592, 1944), 2.2, @"1/2.5");
            Sensors.Add(sensor);
            sensor = new Sensor("CMV2000", SensorType.CMOS, ShutterType.GlobalShutter, new Size<int>(2040, 1086), 5.5, @"2/3");
            Sensors.Add(sensor);
            sensor = new Sensor("CMV4000", SensorType.CMOS, ShutterType.GlobalShutter, new Size<int>(2046, 2040), 5.5, @"1");
            Sensors.Add(sensor);
            sensor = new Sensor("EV76C560", SensorType.CMOS, ShutterType.RollingShutter, new Size<int>(1280, 1024), 5.3, @"1/1.8");
            Sensors.Add(sensor);
            sensor = new Sensor("EV76C570", SensorType.CMOS, ShutterType.GlobalShutter, new Size<int>(1600, 1200), 4.5, @"1/1.8");
            Sensors.Add(sensor);
            sensor = new Sensor("EV76C661", SensorType.CMOS, ShutterType.GlobalShutter, new Size<int>(1280, 1024), 5.3, @"1/1.8");
            Sensors.Add(sensor);
            sensor = new Sensor("E2V", SensorType.CMOS, ShutterType.GlobalShutter, new Size<int>(1280, 1024), 10, @"1");
            Sensors.Add(sensor);
            sensor = new Sensor("IMX174", SensorType.CMOS, ShutterType.GlobalShutter, new Size<int>(1920, 1200), 5.86, @"1/1.2");
            Sensors.Add(sensor);
            sensor = new Sensor("IMX178", SensorType.CMOS, ShutterType.RollingShutter, new Size<int>(3072, 2048), 2.4, @"1/1.8");
            Sensors.Add(sensor);
            sensor = new Sensor("IMX183", SensorType.CMOS, ShutterType.RollingShutter, new Size<int>(5472, 3648), 2.4, @"1");
            Sensors.Add(sensor);
            sensor = new Sensor("IMX226", SensorType.CMOS, ShutterType.RollingShutter, new Size<int>(4024, 3036), 1.85, @"1/1.7");
            Sensors.Add(sensor);
            sensor = new Sensor("IMX249", SensorType.CMOS, ShutterType.GlobalShutter, new Size<int>(1920, 1200), 5.86, @"1/1.2");
            Sensors.Add(sensor);
            sensor = new Sensor("IMX250", SensorType.CMOS, ShutterType.GlobalShutter, new Size<int>(2448, 2048), 3.45, @"2/3");
            Sensors.Add(sensor);
            sensor = new Sensor("IMX252", SensorType.CMOS, ShutterType.GlobalShutter, new Size<int>(2048, 1536), 3.45, @"1/1.8");
            Sensors.Add(sensor);
            sensor = new Sensor("IMX253", SensorType.CMOS, ShutterType.GlobalShutter, new Size<int>(4096, 3000), 3.45, @"1.1");
            Sensors.Add(sensor);
            sensor = new Sensor("IMX255", SensorType.CMOS, ShutterType.GlobalShutter, new Size<int>(4096, 2168), 3.45, @"1");
            Sensors.Add(sensor);
            sensor = new Sensor("IMX264", SensorType.CMOS, ShutterType.GlobalShutter, new Size<int>(2448, 2048), 3.45, @"2/3");
            Sensors.Add(sensor);
            sensor = new Sensor("IMX265", SensorType.CMOS, ShutterType.GlobalShutter, new Size<int>(2048, 1536), 3.45, @"1/1.8");
            Sensors.Add(sensor);
            sensor = new Sensor("IMX267", SensorType.CMOS, ShutterType.GlobalShutter, new Size<int>(4096, 2160), 3.45, @"1");
            Sensors.Add(sensor);
            sensor = new Sensor("IMX273", SensorType.CMOS, ShutterType.GlobalShutter, new Size<int>(1440, 1080), 3.45, @"1/2.9");
            Sensors.Add(sensor);
            sensor = new Sensor("IMX287", SensorType.CMOS, ShutterType.GlobalShutter, new Size<int>(720, 540), 6.9, @"1/2.9");
            Sensors.Add(sensor);
            sensor = new Sensor("IMX304", SensorType.CMOS, ShutterType.GlobalShutter, new Size<int>(4096, 3000), 3.45, @"1.1");
            Sensors.Add(sensor);
            sensor = new Sensor("IMX430", SensorType.CMOS, ShutterType.GlobalShutter, new Size<int>(1624, 1240), 4.5, @"1/1.7");
            Sensors.Add(sensor);
            sensor = new Sensor("MT9F002", SensorType.CMOS, ShutterType.RollingShutter, new Size<int>(4608, 3288), 1.4, @"1/2.3");
            Sensors.Add(sensor);
            sensor = new Sensor("MT9J003", SensorType.CMOS, ShutterType.RollingShutter, new Size<int>(3840, 2748), 1.67, @"1/2.3");
            Sensors.Add(sensor);
            sensor = new Sensor("MT9P031", SensorType.CMOS, ShutterType.RollingShutter, new Size<int>(2592, 1944), 2.2, @"1/2.5");
            Sensors.Add(sensor);
            sensor = new Sensor("PYTHON", SensorType.CMOS, ShutterType.GlobalShutter, new Size<int>(640, 480), 4.8, @"1/3.6");
            Sensors.Add(sensor);
            sensor = new Sensor("PYTHON300", SensorType.CMOS, ShutterType.GlobalShutter, new Size<int>(672, 512), 4.8, @"1/4");
            Sensors.Add(sensor);
            sensor = new Sensor("PYTHON480", SensorType.CMOS, ShutterType.GlobalShutter, new Size<int>(808, 608), 4.8, @"1/3.6");
            Sensors.Add(sensor);
            sensor = new Sensor("PYTHON1300", SensorType.CMOS, ShutterType.GlobalShutter, new Size<int>(1280, 1024), 4.8, @"1/2");
            Sensors.Add(sensor);
            sensor = new Sensor("PYTHON2000", SensorType.CMOS, ShutterType.GlobalShutter, new Size<int>(1920, 1200), 4.8, @"2/3");
            Sensors.Add(sensor);
            sensor = new Sensor("PYTHON5000", SensorType.CMOS, ShutterType.GlobalShutter, new Size<int>(2592, 2048), 4.8, @"1");
            Sensors.Add(sensor);
            sensor = new Sensor("RJ33", SensorType.CMOS, ShutterType.GlobalShutter, new Size<int>(1280, 960), 3.75, @"1/3");
            Sensors.Add(sensor);
            sensor = new Sensor("SS", SensorType.CMOS, ShutterType.GlobalShutter, new Size<int>(1280, 1024), 4.0, @"1/2.7");
            Sensors.Add(sensor);

        }

        #region 计算分辨率


        private int _sideIndex = 0;

        /// <summary>
        /// 边索引(0-短边 1-长边)
        /// </summary>
        public int SideIndex
        {
            get { return _sideIndex; }
            set { _sideIndex = value; NotifyOfPropertyChange(() => SideIndex); }
        }

        private double _viewLength2;

        /// <summary>
        /// 视野(mm)
        /// </summary>
        public double ViewLength2
        {
            get { return _viewLength2; }
            set { _viewLength2 = value; NotifyOfPropertyChange(() => ViewLength2); }
        }

        private double _precision = 0.1;

        /// <summary>
        /// 精度(mm)
        /// </summary>
        public double Precision
        {
            get { return _precision; }
            set { _precision = value; NotifyOfPropertyChange(() => Precision); }
        }

        private double _multiple = 2;

        /// <summary>
        /// 放大倍数
        /// </summary>
        public double Multiple
        {
            get { return _multiple; }
            set { _multiple = value; NotifyOfPropertyChange(() => Multiple); }
        }

        private double _pixel;

        /// <summary>
        /// 像素
        /// </summary>
        public double Pixel
        {
            get { return _pixel; }
            set { _pixel = value; NotifyOfPropertyChange(() => Pixel); }
        }

        /// <summary>
        /// 计算分辨率
        /// </summary>
        public void CalculatePixel()
        {
            Pixel = VisionCalculate.CalculatePixel(ViewLength2, Precision, Multiple);
        }

        private int _shutterTypeIndex = 0;

        /// <summary>
        /// 快门类型索引
        /// </summary>
        public int ShutterTypeIndex
        {
            get { return _shutterTypeIndex; }
            set { _shutterTypeIndex = value; NotifyOfPropertyChange(() => ShutterTypeIndex); }
        }

        /// <summary>
        /// 滤波器
        /// </summary>
        public void Filter()
        {
            var data = Sensors.Where(x => (SideIndex == 0) ? (x.ResolutionSize.Vertical > Pixel) : (x.ResolutionSize.Horizontal > Pixel))
                .Where(x => x.ShutterType == ((ShutterTypeIndex == 0) ? ShutterType.RollingShutter : ShutterType.GlobalShutter));

            ValidSensors = new ObservableCollection<Sensor>(data);
        }

        #endregion

        #region 计算

        private double _sensorLength;

        /// <summary>
        /// 传感器尺寸
        /// </summary>
        public double SensorLength
        {
            get { return _sensorLength; }
            set { _sensorLength = value; NotifyOfPropertyChange(() => SensorLength); }
        }

        private double _viewLength;

        /// <summary>
        /// 传感器尺寸
        /// </summary>
        public double ViewLength
        {
            get { return _viewLength; }
            set { _viewLength = value; NotifyOfPropertyChange(() => ViewLength); }
        }

        private double _focus;

        /// <summary>
        /// 焦距
        /// </summary>
        public double Focus
        {
            get { return _focus; }
            set { _focus = value; NotifyOfPropertyChange(() => Focus); }
        }

        private double _height;

        /// <summary>
        /// 工作距离
        /// </summary>
        public double Height
        {
            get { return _height; }
            set { _height = value; NotifyOfPropertyChange(() => Height); }
        }

        private double _result;

        /// <summary>
        /// 结果
        /// </summary>
        public double Result
        {
            get { return _result; }
            set { _result = value; NotifyOfPropertyChange(() => Result); }
        }


        private int _calculateTypeIndex;

        /// <summary>
        /// 计算类型索引
        /// </summary>
        public int CalculateTypeIndex
        {
            get { return _calculateTypeIndex; }
            set { _calculateTypeIndex = value; NotifyOfPropertyChange(() => CalculateTypeIndex); }
        }

        public void Calculate()
        {
            switch (CalculateTypeIndex)
            {
                case 0:
                    SensorLength = VisionCalculate.CalculateSensorLength(ViewLength, Focus, Height);
                    Result = SensorLength;
                    break;
                case 1:
                    ViewLength = VisionCalculate.CalculateViewLength(SensorLength, Focus, Height);
                    Result = ViewLength;
                    break;
                case 2:
                    Focus = VisionCalculate.CalculateFocus(SensorLength, ViewLength, Height);
                    Result = Focus;
                    break;
                case 3:
                    Height = VisionCalculate.CalculateHeight(SensorLength, ViewLength, Focus);
                    Result = Height;
                    break;
                default:
                    break;
            }
        }

        #endregion

        #region 计算视野范围


        private int _sensorIndex;

        //传感器索引
        public int SensorIndex
        {
            get { return _sensorIndex; }
            set { _sensorIndex = value; NotifyOfPropertyChange(() => SensorIndex); }
        }

        private double _height3;

        /// <summary>
        /// 工作距离
        /// </summary>
        public double Height3
        {
            get { return _height3; }
            set { _height3 = value; NotifyOfPropertyChange(() => Height3); }
        }

        private double _focus3;

        /// <summary>
        /// 焦距
        /// </summary>
        public double Focus3
        {
            get { return _focus3; }
            set { _focus3 = value; NotifyOfPropertyChange(() => Focus3); }
        }

        private string _viewSize = "";

        /// <summary>
        /// 视野范围
        /// </summary>
        public string ViewSize
        {
            get { return _viewSize; }
            set { _viewSize = value; NotifyOfPropertyChange(() => ViewSize); }
        }

        /// <summary>
        /// 计算视野范围
        /// </summary>
        public void CalculateViewSize()
        {
            if ((SensorIndex == -1) || (SensorIndex >= ValidSensors?.Count))
            {
                MessageBox.Show("未选择有效传感器");
                return;
            }

            var sensor = ValidSensors[SensorIndex];

            var h = VisionCalculate.CalculateViewLength(sensor.SensorSize.Horizontal, Focus3, Height3);
            var v = VisionCalculate.CalculateViewLength(sensor.SensorSize.Vertical, Focus3, Height3);

            ViewSize = new Size<double>(h, v).ToString();
        }

        #endregion

    }
}
