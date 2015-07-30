using System;
using System.Windows.Controls;

namespace Microsoft.Xna.Framework.Audio
{
    public class SoundEffectInstance : IDisposable
    {
        MediaElement _mediaElement;
        System.Windows.RoutedEventHandler _loopMediaEventHandler;

        public SoundEffectInstance(MediaElement mediaElement)
        {
            _mediaElement = mediaElement;
        }

        void _mediaElement_MediaEnded(object sender, System.Windows.RoutedEventArgs e)
        {
            _mediaElement.Play();
        }

        public bool Loop
        {
            set
            {
                if (value && _loopMediaEventHandler == null)
                {
                    _loopMediaEventHandler = new System.Windows.RoutedEventHandler(_loopMediaEventHandler);
                    
                }
                else
                {
                    _mediaElement.MediaEnded -= _loopMediaEventHandler;
                    _loopMediaEventHandler = null;
                }
            }
        }

        public void Resume()
        {
            _mediaElement.Play();
        }

        public void Pause()
        {
            _mediaElement.Pause();
        }

        public void Play()
        {
            _mediaElement.Play();
            if(_loopMediaEventHandler != null)
                _mediaElement.MediaEnded += _loopMediaEventHandler;
        }

        public void Stop()
        {
            if (_loopMediaEventHandler != null)
                _mediaElement.MediaEnded -= _loopMediaEventHandler;

            _mediaElement.Stop();
        }

        public MediaElement MediaElement
        {
            get { return _mediaElement; }
        }


        public bool IsDisposed
        {
            get { return _mediaElement == null; }
        }

        public void Dispose()
        {
            _mediaElement = null;
        }

        public void Apply3D(AudioListener listener, AudioEmitter emitter)
        {
            throw new NotImplementedException();
        }

        public void Apply3D(AudioListener[] listeners, AudioEmitter emitter)
        {
            throw new NotImplementedException();
        }

        public Single Volume
        {
            get { return -1; }
            set { throw new NotImplementedException(); }
        }

        public Single Pitch
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public Single Pan
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public bool IsLooped
        {
            get { throw new NotImplementedException(); }
        }

        public SoundState State
        {
            get { throw new NotImplementedException(); }
        }


    }
}
