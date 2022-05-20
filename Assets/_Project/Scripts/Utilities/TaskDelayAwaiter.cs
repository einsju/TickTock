using System;
using System.Threading.Tasks;

namespace TickTock.Utilities
{
    public static class TaskDelayAwaiter
    {
        public static async void Wait(Action callback, int delay = 200)
        {
            await Task.Delay(delay);
            callback();
        }
    }
}
