using System;
using G2048.Models;

namespace G2048.Tools
{
    public class GameState
    {
        public GameDifficulty Difficulty
        {
            get;
            set;
        }

        public static GameState Current
        {
            get;
            set;
        } = new GameState();
    }
}
