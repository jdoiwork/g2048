using System;
using G2048.Tools.Ad.AdTools;


#pragma warning disable CS0436 // 型がインポートされた型と競合しています

namespace G2048.Tools.Ad
{
    public static class AdToolFactory
    {
        public static void Init()
        {
        }

        public static AdTool Create()
        {
            return new UnityAdTool();
        }
    }
}


#pragma warning restore CS0436 // 型がインポートされた型と競合しています
