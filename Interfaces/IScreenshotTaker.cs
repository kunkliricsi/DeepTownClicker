using System.IO;

namespace DeepTownClicker.Interfaces
{
    public interface IScreenshotTaker
    {
        FileInfo TakeScreenshot();
    }
}