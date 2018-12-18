using System;

#pragma warning disable CS0436 // 型がインポートされた型と競合しています

namespace G2048.Tools.Ad
{
    public interface AdTool
    {
        void Show(Action<AdResult> resultCallback);
        void Destroy();
        bool IsReady();
    }
}


#pragma warning restore CS0436 // 型がインポートされた型と競合しています
