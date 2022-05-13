using System;
using UnityEngine;

namespace TickTock.Utilities
{
    [Serializable]
    public struct TimeInterval
    {
        [SerializeField] TimeIntervalValue start;
        [SerializeField] TimeIntervalValue stop;
    }

    [Serializable]
    public struct TimeIntervalValue
    {
        [SerializeField] [Range(0, 59)] int second;
        [SerializeField] [Range(0, 999)] int millisecond;
    }
}