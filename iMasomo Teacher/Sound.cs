using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows;
using NAudio.Wave;
using NAudio.CoreAudioApi;

namespace iMasomo_Teacher
{
    public  class Sound
    {
        private static WaveIn waveIn = null;
        private static NAudio.Wave.DirectSoundOut waveOut = null;
        private static BufferedWaveProvider waveProvider = null;
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
                MessageBox.Show("Recording...");
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
    }

     

}
