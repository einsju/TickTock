using System;

namespace TickTock.Utilities
{
    public static class Extensions
    {
        public static string ToFormattedString(this float value) =>
            TimeSpan.FromSeconds(value).ToString(@"mm\:ss\:ff");
    }
}
