﻿using System;
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
        public GameRunning GameRunning { get; set; }
        public string AfterAdSceneName { get; set; }
        public DateTime LastAdShownTime { get; set; } = DateTime.MinValue;

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
            Current.NormalProgress =
                ReduceProgresWithTime(Current.NormalProgress, time);
        }

        public static void UpdateLastAdShownTime()
        {
            Current.LastAdShownTime = DateTime.Now;
        }

        public static void ReduceAlertProgress(float time)
        {
            Current.AlertProgress =
                ReduceProgresWithTime(Current.AlertProgress, time);
        }

        public static Timer ReduceProgresWithTime(Timer timer, float time)
        {
            return timer.ModifyRemain(timer.Remain - time);
        }

        public static bool IsOverNormalProgress()
        {
            return Current.NormalProgress.Remain < 0;
        }

        public static bool IsOverAlertProgress()
        {
            return Current.AlertProgress.Remain < 0;
        }

        public static void ResetNormalProgress()
        {
            SetNormalProgress(Current.NormalProgress.Max);
        }

        public static void ResetAlertProgress()
        {
            SetAlertProgress(Current.AlertProgress.Max);
        }

        public static void SetNormalProgress(float time)
        {
            Current.NormalProgress =
                Current.NormalProgress.ModifyRemain(time);
        }

        public static void SetAlertProgress(float time)
        {
            Current.AlertProgress =
                Current.AlertProgress.ModifyRemain(Current.AlertProgress.Max);
        }

        public static void SetNormalProgressActive(bool active)
        {
            Current.NormalProgress =
                Current.NormalProgress.ModifyActive(active);
        }

        public static void SetAlertProgressActive(bool active)
        {
            Current.AlertProgress =
                Current.AlertProgress.ModifyActive(active);
        }

        public static void SetAlertProgressMax(float max)
        {
            Current.AlertProgress =
                Current.AlertProgress.ModifyMax(max);
        }
    }
}
