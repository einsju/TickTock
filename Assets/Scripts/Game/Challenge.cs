using System;
using TickTock.Utilities;
using UnityEngine;

namespace TickTock.Game
{
    public enum Operators { After, Before, Between, Equal }
    
    [Serializable]
    public class Challenge
    {
        [Range(1, 10)] public  int numberOfRepetitions = 1;
        public Operators operatorName;
        public TimeInterval timeToExecute;

        public string OperatorNameLabel => 
            operatorName switch
            {
                Operators.After => "A",
                Operators.Before => "B",
                Operators.Between => "IB",
                Operators.Equal => "E",
                _ => "N/A"
            };
    }
}
