using System;
namespace G2048.Tools
{
    public static class PlayTimeFormatter
    {
        public static string Format(float seconds)
        {
            var t = TimeSpan.FromSeconds(seconds);
            var f = ((t.TotalMinutes > 60) ? "{0}:{1:D2}:{2:D2}" : "{1:D2}:{2:D2}");
            return string.Format(f, (int)t.TotalHours, t.Minutes, t.Seconds);
        }
    }
}
