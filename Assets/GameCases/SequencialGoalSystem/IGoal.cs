using System;
using UnityEngine;

namespace GoalSystem
{
    public interface IGoal
    {
        string Description { get; }
        bool IsComplete { get; }
        event Action OnGoalComplete;

        void Start();     
        void Update();
        void Finish();

    }

}
