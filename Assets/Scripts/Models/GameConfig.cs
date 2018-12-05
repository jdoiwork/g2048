using System;
namespace G2048.Models
{
    public class GameConfig
    {
        /// <summary>
        /// 生成する箱の値の範囲
        /// </summary>
        public ulong[] NumberRange
        {
            get;
            set;
        }

        /// <summary>
        /// 次の箱が生成されるまでの猶予時間の減衰率
        /// </summary>
        public float DecayRate
        {
            get;
            set;
        }

        /// <summary>
        /// 最小猶予時間
        /// </summary>
        public float MinCoolTime
        {
            get;
            set;
        }

        /// <summary>
        /// 最大猶予時間
        /// </summary>
        public float MaxCoolTime
        {
            get;
            set;
        }

        /// <summary>
        /// ゲームオーバー猶予時間
        /// </summary>
        /// <value>The max alert cool time.</value>
        public float MaxAlertCoolTime { get; set; }

        /// <summary>
        /// スコアのボーナス係数
        /// </summary>
        public ulong ScoreScale
        {
            get;
            set;
        }

        /// <summary>
        /// 箱がすべて埋まっている場合のボーナス係数
        /// </summary>
        public ulong FullScoreScale
        {
            get;
            set;
        }

        /// <summary>
        /// 初期ボムコスト
        /// </summary>
        public ulong InitialBombCost { get; set; }

        /// <summary>
        /// ボム使用時のコスト係数
        /// </summary>
        public ulong BombCostScale { get; set; }

        /// <summary>
        /// ボムしたらボーナスの底数
        /// </summary>
        public ulong BombBonus { get; set; }
    }
}
