using DeepTownClicker.Interfaces;
using System;
using System.Diagnostics;
using System.IO;

namespace DeepTownClicker.Core
{
    public class ADB : IScreenshotTaker
    {
        private static bool firstExecution = true;

        private string RunCommand(string program, string args)
        {
            if (program.Equals("adb.exe"))
            {
                if (firstExecution)
                {
                    firstExecution = false;
                    RunCommand("adb.exe", "start-server");
                }
            }

            ProcessStartInfo processInfo = new ProcessStartInfo();
            processInfo.FileName = "adb.exe";
            processInfo.UseShellExecute = false;
            processInfo.CreateNoWindow = true;
            processInfo.RedirectStandardInput = false;
            processInfo.RedirectStandardOutput = true;
            processInfo.RedirectStandardError = true;
            processInfo.EnvironmentVariables.Add("VARIABLE1", "1");
            processInfo.Arguments = args;

            Process process = new Process();
            process.StartInfo = processInfo;
            process.Start();

            StreamReader sr = process.StandardError;
            string output = sr.ReadToEnd();
            process.WaitForExit();

            return output;
        }

        public void ClickBack()
        {
            RunCommand("adb.exe", "shell input keyevent KEYCODE_BACK");
        }

        public void Click(int X, int Y)
        {
            RunCommand("adb.exe", "shell input touchscreen tap " + X + " " + Y);
        }

        public void Swipe(int X1, int Y1, int X2, int Y2, int duration = 100)
        {
            RunCommand("adb.exe", "shell input touchscreen swipe " + X1 + " " + Y1 + " " + X2 + " " + Y2 + " " + duration);
        }

        public FileInfo TakeScreenshot()
        {
            string error = "";
            error += RunCommand("adb.exe", "shell screencap -p /sdcard/screenshot.png");
            RunCommand("adb.exe", "pull /sdcard/screenshot.png");
            error += RunCommand("adb.exe", "shell rm /sdcard/screenshot.png");

            if (error != "" || !File.Exists("screenshot.png"))
            {
                throw new Exception("screenshot.png doesn't exist");
            }

            return new FileInfo("screenshot.png");
        }
    }
}
