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
        };
    }
}
