using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Input;

namespace SilverArcade.SilverSprite.Tests.TestApps
{
    public class SingleGameComponent : Game
    {
        GraphicsDeviceManager graphics;

        /// <summary>
        /// Initializes a new instance of the SingleGameComponent class.
        /// </summary>
        public SingleGameComponent()
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            this.Components.Add(new GameComponents.GameComponentOne(this));
        }

    }
}
