﻿using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace Microsoft.Xna.Framework.GamerServices
{
	public enum GamerPresenceMode
	{
		None = 0,
		SinglePlayer = 1,
		Multiplayer = 2,
		LocalCoOp = 3,
		LocalVersus = 4,
		OnlineCoOp = 5,
		OnlineVersus = 6,
		VersusComputer = 7,
		Stage = 8,
		Level = 9,
		CoOpStage = 10,
		CoOpLevel = 11,
		ArcadeMode = 12,
		CampaignMode = 13,
		ChallengeMode = 14,
		ExplorationMode = 15,
		PracticeMode = 16,
		PuzzleMode = 17,
		ScenarioMode = 18,
		StoryMode = 19,
		SurvivalMode = 20,
		TutorialMode = 21,
		DifficultyEasy = 22,
		DifficultyMedium = 23,
		DifficultyHard = 24,
		DifficultyExtreme = 25,
		Score = 26,
		VersusScore = 27,
		Winning = 28,
		Losing = 29,
		ScoreIsTied = 30,
		Outnumbered = 31,
		OnARoll = 32,
		InCombat = 33,
		BattlingBoss = 34,
		TimeAttack = 35,
		TryingForRecord = 36,
		FreePlay = 37,
		WastingTime = 38,
		StuckOnAHardBit = 39,
		NearlyFinished = 40,
		LookingForGames = 41,
		WaitingForPlayers = 42,
		WaitingInLobby = 43,
		SettingUpMatch = 44,
		PlayingWithFriends = 45,
		AtMenu = 46,
		StartingGame = 47,
		Paused = 48,
		GameOver = 49,
		WonTheGame = 50,
		ConfiguringSettings = 51,
		CustomizingPlayer = 52,
		EditingLevel = 53,
		InGameStore = 54,
		WatchingCutscene = 55,
		WatchingCredits = 56,
		PlayingMinigame = 57,
		FoundSecret = 58,
		CornflowerBlue = 59,
	}

	public class GamerPresence
	{
		public GamerPresenceMode PresenceMode { get; set; }
		public int PresenceValue { get; set; }
	}
}
