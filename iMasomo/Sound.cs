using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows;
using NAudio.Wave;
using NAudio.CoreAudioApi;
using iMasomo;

namespace iMasomo_Teacher
{
    public  class Sound
    {
        private static WaveIn waveIn = null;
        private static WaveOut waveOut = null;
        static WaveFileWriter waveWriter = null;
        private static int inputDevice = -1;

        private static string wordName;
     
        public static void RecordSound(string name)
        {
            int waveDeviceCount = WaveIn.DeviceCount;
            if (waveDeviceCount > 0)
            {
                inputDevice = 0;
            }

            wordName = name;
            try
            {
                
                waveIn = new WaveIn();
                waveIn.DeviceNumber = inputDevice;
                waveIn.WaveFormat = new NAudio.Wave.WaveFormat(44100, WaveIn.GetCapabilities(inputDevice).Channels);

                waveIn.DataAvailable += waveIn_DataAvailable;
                waveWriter = new WaveFileWriter(Environment.CurrentDirectory + @"\Media\" + wordName + ".wav", waveIn.WaveFormat);
                waveIn.StartRecording();
                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private static void waveIn_DataAvailable(object sender, WaveInEventArgs e)
        {
            waveWriter.Write(e.Buffer, 0, e.BytesRecorded);
            waveWriter.Flush();
        }

        public static void StopRecording()
        {
            if (waveIn != null)
            {
                waveIn.StopRecording();
                waveIn.Dispose();
                waveIn = null;
            }
            if (waveWriter != null)
            {
                waveWriter.Dispose();
                waveWriter = null;
            }
        }

        public static void PlayBackgroundMusic()
        {
            if (waveOut.PlaybackState == PlaybackState.Paused)
            {
                waveOut.Play();
            }
        }
        public static void PauseBackgroundMusic()
        {
            if(waveOut.PlaybackState==PlaybackState.Playing)
            {
                waveOut.Pause();
            }

          
        }

        public static void StartBackgroundMusic()
        {
            if (waveOut == null)
            {
                WaveFileReader reader = new WaveFileReader(@"Media\bgd.wav");
                LoopStream loop = new LoopStream(reader);
                waveOut = new WaveOut();
                waveOut.Init(loop);
                waveOut.Play();
            }
            else
            {
                waveOut.Stop();
                waveOut.Dispose();
                waveOut = null;
            }
            
        }
    }

     

}
