using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Media;
using System.Threading;

namespace PreventHeadsetAutoShut_off
{
    class Program
    {
        const int SW_HIDE = 0;
        const int SW_SHOW = 5;

        [DllImport("kernel32.dll")]
        static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        static void Main(string[] args)
        {
            Console.Title = "PreventHeadsetAutoShut-off";
            HideConsole();
            PlaySoundAndWait();
        }

        static void PlaySoundAndWait()
        {
            SoundPlayer muteSoundPlayer = new SoundPlayer(Resource1.Silence);
            while (true)
            {
                muteSoundPlayer.Play();
                Thread.Sleep(180000);
            }
        }

        static void HideConsole()
        {
            var handle = GetConsoleWindow();
            ShowWindow(handle, SW_HIDE);
        }
    }
}
