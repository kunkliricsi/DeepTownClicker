using System.IO;

namespace DeepTownClicker.Layer0.Interfaces
{
    public interface IScreenshotTaker
    {
        FileInfo TakeScreenshot();
    }
}