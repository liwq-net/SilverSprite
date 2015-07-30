#region File Description
//-----------------------------------------------------------------------------
// Sound.cs
//
// Microsoft XNA Community Game Platform
// Copyright (C) Microsoft Corporation. All rights reserved.
//-----------------------------------------------------------------------------
#endregion

#region Using Statements
using System;
using System.IO;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Media;
#endregion

namespace Marblets
{
	/// <summary>
	/// An enum for all of the Marblets sounds
	/// </summary>
	public enum SoundEntry
	{
		/// <summary>
		/// Title Screen music
		/// </summary>
		MusicTitle,
		/// <summary>
		/// In game music
		/// </summary>
		MusicGame,
		/// <summary>
		/// GameOver
		/// </summary>
		MusicGameOver,
		/// <summary>
		/// Board cleared
		/// </summary>
		MusicBoardCleared,
		/// <summary>
		/// Start 3d game
		/// </summary>
		Menu3DStart,
		/// <summary>
		/// Start 2d game
		/// </summary>
		Menu2DStart,
		/// <summary>
		/// Move cursor
		/// </summary>
		Navigate,
		/// <summary>
		/// Clear Marbles
		/// </summary>
		ClearMarbles,
		/// <summary>
		/// Illegal clear less than 2 marbles
		/// </summary>
		ClearIllegal,
		/// <summary>
		/// Bonus sound for large clear
		/// </summary>
		ClearBonus,
		/// <summary>
		/// Marbles landing after breaking
		/// </summary>
		LandMarbles,
	}

	/// <summary>
	/// Abstracts away the sounds for a simple interface using the Sounds enum
	/// </summary>
	public static class Sound
	{
		public static ContentManager Content;
		private static string[] cueNames = new string[]
        {
            "Music_Title", //Title Screen
            "Music_Game", //In-Game Music
            "Music_GameOver", //Game Over
            "Music_BoardCleared", //Clear Board
            "Menu_3DStart", //Menu: 3D select (button press)
            "Menu_2DStart", //Menu: 2D select (button press)
            "Navigate", //In-Game Cursor Move
            "Clear_Marbles", //Clear  marbles (Press A)
            "Clear_Illegal", //Illegal clear (press A w/<2 marbles selected)
            "Clear_Bonus", //Large break bonus
            "Land_Marbles" //Marbles impact sound (after fall)
        };

		private static Dictionary<string, string> cueXref = new Dictionary<string, string>
        {
            {"Music_Title", "IntroMus"}, //Title Screen
            {"Music_Game", "MusLoop_Temp1"}, //In-Game Music
            {"Music_GameOver", "IntroMus"}, //Game Over
            {"Music_BoardCleared", "IntroMus"}, //Clear Board
            {"Menu_3DStart", "start_3"}, //Menu: 3D select (button press)
            {"Menu_2DStart", "start_3"}, //Menu: 2D select (button press)
            {"Navigate", "navigate_1"}, //In-Game Cursor Move
            {"Clear_Marbles", "clear_4"}, //Clear  marbles (Press A)
            {"Clear_Illegal", "clear_illegal"}, //Illegal clear (press A w/<2 marbles selected)
            {"Clear_Bonus", "clear_bonus"}, //Large break bonus
            {"Land_Marbles", "drop2"} //Marbles impact sound (after fall)

        };

		/// <summary>
		/// Plays a sound
		/// </summary>
		/// <param name="cueName">Which sound to play</param>
		/// <returns>XACT cue to be used if you want to stop this particular looped 
		/// sound. Can be ignored for one shot sounds</returns>
		public static void Play(string cueName)
		{
			string sound = "Audio/" + cueXref[cueName];
			if (cueName.Contains("Music"))
			{
				Song song = Content.Load<Song>(sound);
				MediaPlayer.IsRepeating = true;
				MediaPlayer.Play(song);
			}
			else
			{
				SoundEffect effect = Content.Load<SoundEffect>(sound);
				effect.Play();
			}
		}

		/// <summary>
		/// Plays a sound
		/// </summary>
		/// <param name="sound">Which sound to play</param>
		/// <returns>XACT cue to be used if you want to stop this particular looped 
		/// sound. Can be ignored for one shot sounds</returns>
		public static void Play(SoundEntry sound)
		{
			Play(cueNames[(int)sound]);
		}

		/// <summary>
		/// Stops a previously playing cue
		/// </summary>
		/// <param name="cue">The cue to stop that you got returned from Play(sound)
		/// </param>
		public static void Stop(SoundEffect cue)
		{
			if (cue != null)
			{
//				cue.Stop(AudioStopOptions.Immediate);
			}
		}

		/// <summary>
		/// Starts up the sound code
		/// </summary>
		public static void Initialize(ContentManager content)
		{
			Content = content;
		}

		public static void StopMusic()
		{
			MediaPlayer.Stop();
		}

		/// <summary>
		/// Shuts down the sound code tidily
		/// </summary>
		public static void Shutdown()
		{

		}
	}
}
