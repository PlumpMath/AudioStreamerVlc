using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace AudioStreamerVlc
{
    class Program
    {
        static void Main(string[] args)
        {
            const int portNumber = 8088;
            const string streamName = "fstream";          
            const string audio = "C:\\FlashRecording\\Audio\\5\\43\\1862543\\1862543.wav";
            const string windowQuiet = "-I dummy --dummy-quiet";
            const string tanscode = ":sout=#transcode{vcodec=none,acodec=mp3,ab=128,channels=2,samplerate=44100}";
            var stream = String.Format(@":http{{mux=mp3,dst=:{0}/{1}}}", portNumber, streamName);
            const string keep = ":sout-keep";

            var vlcStreamParamList = new List<string> {windowQuiet, audio, tanscode+stream, keep};

            var process = new Process
            {
                StartInfo =
                {
                    FileName = @"C:\Program Files (x86)\VideoLAN\VLC\vlc.exe",
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true                    
                }
            };

            var vlcParamString = String.Join(" ", vlcStreamParamList);
            process.StartInfo.Arguments = vlcParamString;
            process.Start();
        }
    }
}
