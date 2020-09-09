using DeepTownClicker.Layer0.Interfaces;
using System;
using System.Diagnostics;
using System.IO;

namespace DeepTownClicker.Layer0
{
    public class ADB : IScreenshotTaker
    {
        private bool firstExecution = true;

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

            var processInfo = new ProcessStartInfo
            {
                FileName = program,
                UseShellExecute = false,
                CreateNoWindow = true,
                RedirectStandardInput = false,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                Arguments = args
            };

            var process = new Process
            {
                StartInfo = processInfo
            };

            process.Start();
            var sr = process.StandardError;
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

        public void ClickMultiple(params (int x, int y)[] points)
        {
            var command = "";
            foreach (var (x, y) in points)
            {
                command += (" && input touchscreen tap " + x + " " + y);
            }

            command = command.Substring(4);
            command = "shell " + command;

            RunCommand("adb.exe", command);
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
