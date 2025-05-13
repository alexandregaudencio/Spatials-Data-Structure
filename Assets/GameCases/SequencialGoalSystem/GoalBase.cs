namespace GoalSystem
{
    using UnityEngine;
    using System;

    public abstract class GoalBase : MonoBehaviour, IGoal
    {
        public string Description { get; protected set; }
        public bool IsComplete { get; protected set; } = false;

        public event Action OnGoalComplete;


        public abstract void Finish();

        public abstract void Start();


        public abstract void Update();

    }

}
