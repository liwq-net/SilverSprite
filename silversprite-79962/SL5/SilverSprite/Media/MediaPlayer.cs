using System;

namespace Microsoft.Xna.Framework.Media
{
    public class MediaPlayer
    {
        static Song _song;
        static float _volume = 0.5f;
        static bool _isRepeating = true;

        public static float Volume
        {
            get
            {
                return _volume;
            }
            set
            {
                _volume = value;
                if (_song != null)
                {
                    _song.SetVolume(value);
                }
            }
        }

        public static bool IsRepeating
        {
            get
            {
                return _isRepeating;
            }
            set
            {
                _isRepeating = value;
                if (_song != null)
                {
                    _song.SetRepeating(value);
                }
            }
        }

        public static void Play(Song song)
        {
            _song = song;
            song.SetRepeating(IsRepeating);
            song.Play(Volume);
        }

        public static void Resume()
        {
            if (_song != null)
            {
                _song.Resume();
            }
        }

        public static void Stop()
        {
            if (_song != null)
            {
                _song.Stop();
            }
        }

        public static void Pause()
        {
            if (_song != null)
            {
                _song.Pause();
            }
        }
    }
}
