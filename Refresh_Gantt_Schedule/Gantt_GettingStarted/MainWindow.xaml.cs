using Syncfusion.Windows.Controls.Gantt;
using Syncfusion.Windows.Controls.Gantt.Schedule;
using System;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;

namespace Gantt_GettingStarted
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            (this.DataContext as ViewModel).CustomScheduleSource[1].PixelsPerUnit = (sender as Slider).Value;
            this.RefreshSchedule();
        }

        private void RefreshSchedule()
        {

            FieldInfo propertyInfo = typeof(GanttControl).GetField(
                                                              "GanttSchedule",
                                                              BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);

            GanttSchedule ganttSchedule = (GanttSchedule)propertyInfo.GetValue(this.Gantt);
            if (ganttSchedule != null)
            {
                MethodInfo RedrawSchedule = ganttSchedule.GetType().GetMethod("RedrawSchedule", BindingFlags.Instance | BindingFlags.NonPublic);
                RedrawSchedule.Invoke(ganttSchedule, new object[] { });
            }
        }
    }
}
