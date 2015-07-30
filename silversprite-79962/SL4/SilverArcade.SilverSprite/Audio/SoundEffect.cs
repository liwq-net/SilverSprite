using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Collections.Generic;
using System.Windows.Resources;
using System.IO;

using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Microsoft.Xna.Framework.Audio
{
    public class SoundEffect
    {
        string _assetName;
        private static float volume = 0.5f;
        List<SoundEffectInstance> sounds = new List<SoundEffectInstance>();
        GraphicsDevice _graphics;
        static Dictionary<string, byte[]> soundBuffers = new Dictionary<string, byte[]>();
        static Dictionary<string, byte[]> wavSoundBuffers = new Dictionary<string, byte[]>();
        bool _isWav = false;

        internal bool IsWav
        {
            get
            {
                return _isWav;
            }
            set
            {
                _isWav = value;
            }
        }

        static bool IsWavAsset(string assetName)
        {
            if (wavSoundBuffers.ContainsKey(assetName))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public SoundEffect(ContentManager content, string assetName)
        {
            _assetName = assetName;
            if (soundBuffers.ContainsKey(assetName) == true)
            {
                _isWav = false;
            }
            else if (wavSoundBuffers.ContainsKey(assetName) == true)
            {
                _isWav = true;
            }
            else
            {
				Stream s = content.GetAssetStream(_assetName, ".mp3");
				if (s == null)
				{
					s = content.GetAssetStream(_assetName, ".wma");
				}
				if (s == null)
				{
					s = content.GetAssetStream(_assetName, ".wav");
                    if (s != null)
                    {
                        _isWav = true;
                    }
				}

                if (s == null)
                    throw new ContentLoadException("Could not load audio asset: " + assetName + "\r\nSilverSprite only supports MP3, WAV, and WMA audio assets.");
                byte[] b = new byte[s.Length];
                s.Read(b, 0, b.Length);
                s.Close();
                if (_isWav)
                {
                    wavSoundBuffers.Add(assetName, b);
                }
                else
                {
                    soundBuffers.Add(assetName, b);
                }
            }
            _graphics = ((IGraphicsDeviceService)content.ServiceProvider.GetService(typeof(IGraphicsDeviceService))).GraphicsDevice;
        }


        public bool Play(float volume, float pitch, float pan, bool loop)
        {            
            return Play(volume);
        }

        public bool Play()
        {
            // Play with default volume
            return Play(volume);
        }

		public bool Play(float volume, float pitch, float pan)
		{
			Play(volume);
			return true;
		}

        public bool Play(float volume)
        {     
            //TODO: Obviously sounds may have more than one media element...
            SoundEffectInstance s = null;
            foreach (SoundEffectInstance ele in sounds)
            {
                if (ele.MediaElement.CurrentState == MediaElementState.Stopped || ele.MediaElement.CurrentState == MediaElementState.Paused)
                {
                    s = ele;
                    break;
                }
            }

            if (s == null)
            {
                s = new SoundEffectInstance(new MediaElement());
                sounds.Add(s);
                _graphics.Root.Children.Add(s.MediaElement);
            }
            if (IsWavAsset(_assetName))
            {
                s.MediaElement.SetSource(new WaveMSS.WaveMediaStreamSource(new MemoryStream(wavSoundBuffers[_assetName])));
            }
            else
            {
                s.MediaElement.SetSource(new MemoryStream(soundBuffers[_assetName]));
            }
            s.MediaElement.Volume = volume;
            s.MediaElement.Play();
            return true;
        }

		public SoundEffectInstance CreateInstance()
		{
			SoundEffectInstance s = new SoundEffectInstance(new MediaElement());
            if (IsWavAsset(_assetName))
            {
                s.MediaElement.SetSource(new WaveMSS.WaveMediaStreamSource(new MemoryStream(wavSoundBuffers[_assetName])));
            }
            else
            {
                s.MediaElement.SetSource(new MemoryStream(soundBuffers[_assetName]));
            }
            s.MediaElement.Volume = volume;
			return s;
		}

        public SoundEffectInstance Play3D(AudioListener listener, AudioEmitter emitter)
        {
            throw new NotImplementedException();
        }

        public SoundEffectInstance Play3D(AudioListener listener, AudioEmitter emitter, Single volume, Single pitch, bool loop)
        {
            throw new NotImplementedException();
        }

        public SoundEffectInstance Play3D(AudioListener[] listeners, AudioEmitter emitter, Single volume, Single pitch, bool loop)
        {
            throw new NotImplementedException();
        }

        public string Name
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public TimeSpan Duration
        {
            get { throw new NotImplementedException(); }
        }
        public static Single MasterVolume
        {
			get { return volume; }
			set { volume = value; }
        }

        public static Single SpeedOfSound
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }
        
        public static Single DopplerScale
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public static Single DistanceScale
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }
    }
}
