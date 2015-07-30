using System;

namespace SilverArcade.SilverSprite.Tests
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            ConsoleKeyInfo ch = new ConsoleKeyInfo();

            do
            {
                switch (ch.Key)
                {
                    case ConsoleKey.D0:
                        using (TestApps.SimpleSpriteBatch game = new TestApps.SimpleSpriteBatch())
                        {
                            game.Run();
                        }
                        break;
                    case ConsoleKey.D1:
                        using (TestApps.DrawStrings game = new TestApps.DrawStrings())
                        {
                            game.Run();
                        }
                        break;
                    case ConsoleKey.D2:
                        using (TestApps.SoundEffects game = new TestApps.SoundEffects())
                        {
                            game.Run();
                        }
                        break;
                    case ConsoleKey.D3:
                        using (TestApps.DrawTextures game = new TestApps.DrawTextures())
                        {
                            game.Run();
                        }
                        break;
                    case ConsoleKey.D4:
                        using (TestApps.SingleGameComponent game = new TestApps.SingleGameComponent())
                        {
                            game.Run();
                        }
                        break;
                    case ConsoleKey.D5:
                        using (TestApps.DrawOrderTests game = new TestApps.DrawOrderTests())
                        {
                            game.Run();
                        }
                        break;
                    case ConsoleKey.D7:
                        using (TestApps.KeyHandling game = new TestApps.KeyHandling())
                        {
                            game.Run();
                        }

                        break;
                    case ConsoleKey.D6:
                        using (TestApps.StartupSequence game = new TestApps.StartupSequence())
                        {
                            game.Run();
                        }
                        break;
					case ConsoleKey.D8:
						using (TestApps.GamePadMappings game = new TestApps.GamePadMappings())
						{
							game.Run();
						}
						break;
					case ConsoleKey.D9:
						using (TestApps.ViewportTransformTests game = new TestApps.ViewportTransformTests())
						{
							game.Run();
						}
						break;

                }

                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("Press a number to start a test");
                Console.WriteLine("=================================================");
                Console.WriteLine("0. SpriteBatch.DrawString");
                Console.WriteLine("1. SpriteBatch.DrawString - layerDepth");
                Console.WriteLine("2. Sounds");
                Console.WriteLine("3. SpriteBatch.Draw (Textures)");
                Console.WriteLine("4. Single DrawableGameComponent");
                Console.WriteLine("5. DrawableGameComponents");                
                Console.WriteLine("6. Startup Sequencing");
                Console.WriteLine("7. Keyboard Handling");
				Console.WriteLine("8. GamePad Status");
				Console.WriteLine("9. Viewports and Transforms");
				Console.WriteLine("ESC - Exit");

                ch = Console.ReadKey();
            }
            while (ch.Key != ConsoleKey.Escape);
        }
    }
}

