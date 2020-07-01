using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ModdingTools.UEngine
{
    // Don't ask...
    class Lol
    {
        static SoundPlayer pl;
        static bool IsPlaying = false;

        public static void PlayElevatorMusic()
        {
            if (!Properties.Settings.Default.Memes) return;
            var ph = Path.Combine(Program.GetAppRoot(), @"lol.wav");
            if (!File.Exists(ph)) return;
            Debug.WriteLine("MemeStart()");
            IsPlaying = false;
            Task.Factory.StartNew(() =>
            {
                if (pl != null)
                {
                    pl.Stop();
                    pl.Dispose();
                    pl = null;
                }
                
                pl = new SoundPlayer(ph);
                pl.Play(); // can also use soundPlayer.PlaySync()
                IsPlaying = true;
                while (IsPlaying)
                {
                    Thread.Sleep(100);
                }
                pl.Stop();
            });
        }

        public static void StopElevatorMusic()
        {
            if (!Properties.Settings.Default.Memes) return;
            Debug.WriteLine("MemeStop()");
            IsPlaying = false;
        }
    }
}
