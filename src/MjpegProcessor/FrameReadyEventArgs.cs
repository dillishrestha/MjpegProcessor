using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace DotNetProjects.MjpegProcessor
{
    public class FrameReadyEventArgs : EventArgs
    {
        public byte[] FrameBuffer { get; }

        public FrameReadyEventArgs(byte[] buffer)
        {
            FrameBuffer = buffer;
        }

#if NETFRAMEWORK
        public BitmapImage GetBitmapImage(Dispatcher dispatcher)
        {
            var bi = new BitmapImage();
            dispatcher.Invoke(() =>
            {                
                bi.BeginInit();
                bi.StreamSource = new MemoryStream(FrameBuffer);
                bi.EndInit();
            });
            return bi;
        }
#endif
    }
}
