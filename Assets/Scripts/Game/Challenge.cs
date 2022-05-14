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

        public bool IsExecutedSuccessfully(float time)
        {
            return operatorName switch
            {
                Operators.After => time >= timeToExecute.Start.AsFloat(),
                Operators.Before => time <= timeToExecute.Start.AsFloat(),
                Operators.Between => time >= timeToExecute.Start.AsFloat() && time <= timeToExecute.Stop.AsFloat(),
                Operators.Equal => Math.Abs(time - timeToExecute.Start.AsFloat()) < 0.01f,
                _ => false
            };
        }
    }
}
