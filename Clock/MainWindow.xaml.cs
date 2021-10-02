using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Clock
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string datetime;
        public MainWindow()
        {
            InitializeComponent();
            _thread = new Thread(() =>
              {
                  while (true)
                  {
                      lbl_time.Dispatcher.Invoke(new Action(() => lbl_time.Content = DateTime.Now.ToString("HH:mm")));


                      if(DateTime.Now.ToString("dddd, dd - MM - yyyy").Contains("Monday"))
                      {
                          datetime = "Thứ hai, " + DateTime.Now.ToString("dd - MM - yyyy");
                      }
                      else if (DateTime.Now.ToString("dddd, dd - MM - yyyy").Contains("Tuesday"))
                      {
                          datetime = "Thứ ba, " + DateTime.Now.ToString("dd - MM - yyyy");
                      }
                      else if (DateTime.Now.ToString("dddd, dd - MM - yyyy").Contains("Wednesday"))
                      {
                          datetime = "Thứ tư, " + DateTime.Now.ToString("dd - MM - yyyy");
                      }
                      else if (DateTime.Now.ToString("dddd, dd - MM - yyyy").Contains("Thursday"))
                      {
                          datetime = "Thứ năm, " + DateTime.Now.ToString("dd - MM - yyyy");
                      }
                      else if (DateTime.Now.ToString("dddd, dd - MM - yyyy").Contains("Friday"))
                      {
                          datetime = "Thứ sáu, " + DateTime.Now.ToString("dd - MM - yyyy");
                      }
                      else if (DateTime.Now.ToString("dddd, dd - MM - yyyy").Contains("Saturday"))
                      {
                          datetime = "Thứ bảy, " + DateTime.Now.ToString("dd - MM - yyyy");
                      }
                      else if (DateTime.Now.ToString("dddd, dd - MM - yyyy").Contains("Sunday"))
                      {
                          datetime = "Chủ nhật, " + DateTime.Now.ToString("dd - MM - yyyy");
                      }
                      else
                      {
                          datetime = DateTime.Now.ToString("dddd, dd - MM - yyyy");
                      }


                      lbl_date.Dispatcher.Invoke(new Action(() => lbl_date.Content = datetime));
                      Thread.Sleep(2000);
                  }
              });
            _thread.Start();
            this.WindowStartupLocation = WindowStartupLocation.Manual;
            try
            {
                this.Top = int.Parse(File.ReadAllLines("config.ini")[0]);
                this.Left = int.Parse(File.ReadAllLines("config.ini")[1]);
            }
            catch
            {
                this.Top = 0;
                this.Left = 0;

            }
        }
        Thread _thread;

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            File.WriteAllLines("config.ini", new string[] { this.Top.ToString(), this.Left.ToString() });
            _thread.Abort();
        }
    }
}
