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
    }
}
