using System;
using System.Collections.Generic;
using System.Linq;
using G2048.Models;

namespace G2048.Tools
{
    public static class GameConfigTools
    {
        public static ulong[] CreateRange(int n)
        {

            return Enumerable
                .Range(1, n)
                .SelectMany(x => Enumerable.Repeat(x, (int)Math.Pow(2, n - x)))
                .Select(x => (ulong)1 << x)
                .ToArray();
        }

        public static GameConfig Easy
        {
            get;
        } = new GameConfig
        {
            NumberRange = CreateRange(1),
            DecayRate = 0.99f,
            MinCoolTime = 0.5f,
            MaxCoolTime = 4.0f,
            MaxAlertCoolTime = 16.0f,
            ScoreScale = 1,
            FullScoreScale = 4,
            InitialBombCost = 2,
            BombCostScale = 2,
        };
        public static GameConfig Normal
        {
            get;
        } = new GameConfig
        {
            NumberRange = CreateRange(2),
            DecayRate = 0.98f,
            MinCoolTime = 0.25f,
            MaxCoolTime = 3.0f,
            MaxAlertCoolTime = 8.0f,
            ScoreScale = 2,
            FullScoreScale = 8,
            InitialBombCost = 4,
            BombCostScale = 4,
        };

        public static GameConfig Hard
        {
            get;
        } = new GameConfig
        {
            NumberRange = CreateRange(3),
            DecayRate = 0.97f,
            MinCoolTime = 0.1f,
            MaxCoolTime = 2.0f,
            MaxAlertCoolTime = 4.0f,
            ScoreScale = 4,
            FullScoreScale = 16,
            InitialBombCost = 8,
            BombCostScale = 8,
        };

        public static GameConfig Expert
        {
            get;
        } = new GameConfig
        {
            NumberRange = CreateRange(4),
            DecayRate = 0.95f,
            MinCoolTime = 0.05f,
            MaxCoolTime = 1.0f,
            MaxAlertCoolTime = 2.0f,
            ScoreScale = 8,
            FullScoreScale = 32,
            InitialBombCost = 16,
            BombCostScale = 16,
        };

        public static GameDifficulty[] GameDifficulties
        {
            get;
        } = new[] {
            GameDifficulty.Easy,
            GameDifficulty.Normal,
            GameDifficulty.Hard,
            GameDifficulty.Expert,
        };

        public static GameConfig Difficulty2Config(GameDifficulty gameDifficulty)
        {
            switch (gameDifficulty)
            {
                case GameDifficulty.Easy: return Easy;
                case GameDifficulty.Normal: return Normal;
                case GameDifficulty.Hard: return Hard;
                case GameDifficulty.Expert: return Expert;
                default: throw new NotImplementedException();

            }
        }
    }
}
