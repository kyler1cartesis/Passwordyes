using System.Threading;
using System;
using static System.Net.Mime.MediaTypeNames;
using System.Windows.Threading;

namespace Password_Manager.MVVM.Model {
    public static class ClipBoardManager
    {
        public static void SetText(string text)
        {
            var settings = (AppSettings)ConfigUtil.AppConf.GetSection("StormSettings");

            System.Windows.Clipboard.SetText(text);

            DispatcherTimer dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(Timer);
            dispatcherTimer.Interval = new TimeSpan(0, 0, settings.TimeToDelete);
            dispatcherTimer.Start();
        }

        private static void Timer(object? sender, EventArgs e)
        {
            System.Windows.Clipboard.Clear();
        }
    }
}