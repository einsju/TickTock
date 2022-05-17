﻿using System;
using UnityEngine;

namespace TickTock.Utilities
{
    [Serializable]
    public struct TimeInterval
    {
        [SerializeField] float start;
        [SerializeField] float stop;
        
        public float Start => start;
        public float Stop => stop;

        public override string ToString() => stop > 0f
            ? $"{start.ToFormattedString()} - {stop.ToFormattedString()}"
            : start.ToFormattedString();
    }
}