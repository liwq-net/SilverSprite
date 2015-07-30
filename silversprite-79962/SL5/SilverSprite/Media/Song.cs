using System;
using System.Windows;
using System.Windows.Controls;


using Microsoft.Xna.Framework.Content;

using System.Windows.Resources;
using Microsoft.Xna.Framework.Graphics;

namespace Microsoft.Xna.Framework.Media
{
    public class Song
    {
        MediaElement song;
        string _path;
        GraphicsDevice _graphics;
        bool _repeating = false;
        StreamResourceInfo resourceInfo;

        public Song(ContentManager content, string assetName)
        {
            _path = assetName;
            resourceInfo = Application.GetResourceStream(new Uri(_path + ".mp3", UriKind.Relative));
            if (resourceInfo == null)
            {
                resourceInfo = Application.GetResourceStream(new Uri(_path + ".wma", UriKind.Relative));
            }

            _graphics = ((IGraphicsDeviceService)content.ServiceProvider.GetService(typeof(IGraphicsDeviceService))).GraphicsDevice;
        }

        void song_MediaEnded(object sender, RoutedEventArgs e)
        {
            if (_repeating)
            {
                song.Stop();
                song.Position = TimeSpan.Zero;
                song.Play();
            }
        }

        internal void SetRepeating(bool repeating)
        {
            _repeating = repeating;
        }

        internal void Play(float volume)
        {
            //Creating and setting source within constructor starts
            //playing song immediately.
            song = new MediaElement();
            song.MediaEnded += new RoutedEventHandler(song_MediaEnded);
//            _graphics.Root.Children.Add(song);
            song.SetSource(resourceInfo.Stream);
            song.Volume = volume;
            song.Play();
        }

        internal void SetVolume(float volume)
        {
            if (song != null)
                song.Volume = volume;
        }

        internal void Stop()
        {
            if (song != null)
            {
  //              _graphics.Root.Children.Remove(song);
                song.Stop();
            }
        }

        public string Name
        {
            get { return song.Name; }
        }

        public TimeSpan Duration
        {
            get { throw new NotImplementedException(); }
        }
        public bool IsRated
        {
            get { throw new NotImplementedException(); }
        }
        public int Rating
        {
            get { throw new NotImplementedException(); }
        }
        public int PlayCount
        {
            get { throw new NotImplementedException(); }
        }
        public int TrackNumber
        {
            get { throw new NotImplementedException(); }
        }                   

        internal void Resume()
        {
            song.Play();
        }

        internal void Pause()
        {
            song.Pause();
        }
    }
}
