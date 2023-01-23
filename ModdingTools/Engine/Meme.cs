using ModdingTools.Settings;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ModdingTools.Engine
{
    // Don't ask...
    class Meme
    {
        static SoundPlayer pl;
        static bool IsPlaying = false;

        public static void PlayElevatorMusic()
        {
            if (IsPlaying) return; // prevent the ear-rape
            if (!OMMSettings.Instance.Memes) return;
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
                pl.PlayLooping(); // loop the music
                IsPlaying = true;
                while (IsPlaying)
                {
                    Thread.Sleep(100);
                }
                pl.Stop();
                IsPlaying = false;
            });
        }

        public static void StopElevatorMusic()
        {
            if (!OMMSettings.Instance.Memes) return;
            Debug.WriteLine("MemeStop()");
            IsPlaying = false;
        }
    }
}
