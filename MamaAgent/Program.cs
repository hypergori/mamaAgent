using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Globalization;
using System.Timers;
using System.Runtime.InteropServices;
namespace MamaAgent
{
    class Program
    {

        [DllImport("kernel32.dll")]
        static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        const int SW_HIDE = 0;
        const int SW_SHOW = 5;

        static DateTime setTime;
        static string partialProcessName= "Minecraft";
        static bool killThreadStarted = false;
        static bool killThreadCompleted = false;
        static IntPtr handle;
        static void Main(string[] args)
        {
            handle = GetConsoleWindow();
            // Hide
            ShowWindow(handle, SW_HIDE);
            //If no arguments or wrong formatted time, return and show message.
            if (args.Length == 0 || !ValidateTime(args[0],"HH:mm")) {
                System.Console.WriteLine("使い方: MamaAgent <hh:mm>  たとえば19:00のフォーマットで時間を入れてください。");
                return;
            }
            //If the time is already passed return
            if(TimeSpan.Compare(setTime.TimeOfDay,DateTime.Now.TimeOfDay) <= 0 )
            {
                System.Console.WriteLine("{0} 時間がすでに過ぎています。未来の時間をセットしてください。現在:{1}", args[0],DateTime.Now);
                return;
            }


            //20 mins before
            LaunchTimer(setTime,-20, PopupTimeWarning);
            //5 mins before
            LaunchTimer(setTime, -10, PopupTimeWarning);
            //5 mins before
            LaunchTimer(setTime, -5, PopupTimeWarning);
            // 1 min before
            LaunchTimer(setTime, -1, PopupTimeWarning);
            // 10 sec before
            LaunchTimer(setTime, -0.16, PopupCountDown);
            //Cut off time
            LaunchTimer(setTime, 0, KillProcess);

            Console.ReadKey();
        }

        //Change the time on the Countdown form and dispose the form at zero
        static Form f;
        static void PopupCountDown(object sender, EventArgs e)
        {
            System.Console.WriteLine("Countdown handler is called");
            f= new CountDownForm();
            f.TopMost = true;
            f.ShowDialog();
            f.Activate();
        }

        static void PopupTimeWarning(object sender, EventArgs e){
            System.Console.WriteLine("Time Elapse event is called");
            WarningForm wf = new WarningForm();
            wf.SetTimeLbl(setTime);
            wf.TopMost = true;
            wf.ShowDialog();
        }
        static void LaunchTimer(DateTime timeLimit, double OffSetMins ,ElapsedEventHandler func2Run )
        {
            Double intervalMiliSec = timeLimit.Subtract(DateTime.Now).TotalMilliseconds + OffSetMins * 60 * 1000;
            if (intervalMiliSec < 0) return;
            System.Console.WriteLine("Time Elapse event will be called in {0} sec", intervalMiliSec/1000);
            System.Timers.Timer timer = new System.Timers.Timer(intervalMiliSec);
            timer.Elapsed +=  func2Run;
            timer.AutoReset = false;  //only once 
            timer.Enabled = true;
            timer.Start();
            
        }

        static bool ValidateTime(string time, string format)
        {
            return DateTime.TryParseExact(time, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out setTime);
        }

        static void KillProcess(object sender,EventArgs e) {
            var allProcceses = Process.GetProcesses();
            bool isKilled = false;
            foreach (Process process in allProcceses)
            {
                string processName = process.ProcessName;
                if (processName.Contains(partialProcessName))
                {
                    try
                    {

                        process.Kill();
                        isKilled = true;
                    }
                    catch (Exception ex)
                    {
                        //Ignore any exception
                    }
                }
            }
            if (isKilled) System.Console.WriteLine("Process is killed!");
            try {
                f.Close();
            } catch (Exception ex2) {//ignore
            }
            System.Console.WriteLine("Completed!");
            // Show
            ShowWindow(handle, SW_SHOW);
        }
    }
}
