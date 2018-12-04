using System;
using G2048.Models;
using UnityEngine;

namespace G2048.Tools
{
    public class GameState
    {
        public GameDifficulty Difficulty
        {
            get;
            set;
        }

        public Timer NormalProgress { get; set; }
        public Timer AlertProgress { get; set; }

        public static GameState Current
        {
            get;
            set;
        } = new GameState {
            NormalProgress = new Timer(),
            AlertProgress = new Timer(),
        };

        public static void SetNormalProgressMax(float max)
        {
            Current.NormalProgress =
                Current.NormalProgress.ModifyMax(max);
        }

        public static void ReduceNormalProgressMax(GameConfig config)
        {
            var timer = Current.NormalProgress;
            var newMax = Mathf.Max(timer.Max * config.DecayRate, config.MinCoolTime);

            SetNormalProgressMax(newMax);
        }

        public static void ReduceNormalProgress(float time)
        {
            var np = Current.NormalProgress;
            Current.NormalProgress =
                np.ModifyRemain(np.Remain - time);
        }

        public static bool IsOverNormalProgress()
        {
            return Current.NormalProgress.Remain < 0;
        }

        public static void ResetNormalProgress()
        {
            SetNormalProgress(Current.NormalProgress.Max);
        }

        public static void SetNormalProgress(float time)
        {
            Current.NormalProgress =
                Current.NormalProgress.ModifyRemain(time);
        }

        public static void SetNormalProgressActive(bool active)
        {
            Current.NormalProgress =
                Current.NormalProgress.ModifyActive(active);
        }
    }
}
