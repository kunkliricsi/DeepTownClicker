using DeepTownClicker.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace DeepTownClicker.Core
{
    public class ScreenshotGrabber
    {
        private readonly IScreenshotTaker _screenshotTaker;
        private readonly ReaderWriterLock _rwLock;

        private object lastImage; // TODO: make not object
        private CancellationTokenSource cancellation;

        public ScreenshotGrabber(IScreenshotTaker screenshotTaker)
        {
            _screenshotTaker = screenshotTaker;
            _rwLock = new ReaderWriterLock();
        }

        public void Start()
        {
            cancellation = new CancellationTokenSource();
            StartInternal();
        }

        public void Stop()
        {
            cancellation.Cancel();
        }

        public object GetLastImage()
        {
            try
            {
                _rwLock.AcquireReaderLock(1000);
                // TODO: make and return copy
                return lastImage;
            }
            finally
            {
                _rwLock.ReleaseReaderLock();
            }
        }

        private void StartInternal()
        {
            Task.Run(() =>
            {
                while (!cancellation.IsCancellationRequested)
                {
                    var screenshot = _screenshotTaker.TakeScreenshot();

                    // TODO: try catch maybe
                    _rwLock.AcquireWriterLock(100);
                    lastImage = screenshot;
                    _rwLock.ReleaseWriterLock();
                }
            });
        }
    }
}