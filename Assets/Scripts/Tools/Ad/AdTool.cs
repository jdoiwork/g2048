using System;

namespace G2048.Tools.Ad
{
    public interface AdTool
    {
        void Show(Action<AdResult> resultCallback);
        void Destroy();
        bool IsReady();
    }
}
