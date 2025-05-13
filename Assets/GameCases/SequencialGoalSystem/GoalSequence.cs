using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace GoalSystem
{
    public class GoalSequence
    {

        private readonly Queue<IGoal> goals = new();
        private IGoal current;
        public event Action<IGoal> GoalChanged;
        public event Action GoalsCompleted;

        public void AddGoal(IGoal goal) => goals.Enqueue(goal);

        public GoalSequence(IEnumerable<IGoal> goals)
        {
            this.goals = (Queue<IGoal>)goals;
            InitializeGoal();
        }

        public void SetNextGoal()
        {
            if (current == null) return;

            current.Finish();
            current.OnGoalComplete -= OnCurrentCompleted;
            InitializeGoal();
            
        }

        public void InitializeGoal()
        {
            if (goals.Count == 0)
            {
                current = null;
                GoalsCompleted?.Invoke();
                return;
            }
          
            current = goals.Dequeue();
            current.Start();
            GoalChanged?.Invoke(current);
            current.OnGoalComplete += OnCurrentCompleted;
        }

        private void OnCurrentCompleted()
        {
            SetNextGoal();
        }

    }

}