using System;
using System.Collections.Generic;
using System.Linq;
using G2048.Models;

namespace Jdoi
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
            ScoreScale = 1,
            FullScoreScale = 16,
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
            ScoreScale = 2,
            FullScoreScale = 32,
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
            ScoreScale = 4,
            FullScoreScale = 64,
        };

    }
}
