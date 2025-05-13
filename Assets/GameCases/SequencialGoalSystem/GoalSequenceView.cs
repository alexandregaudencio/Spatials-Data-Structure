using System;
using UnityEngine;

namespace GoalSystem {
    public class GoalSequenceView : MonoBehaviour
    {
        private GoalSequence goalSequence;
        private void Awake()
        {
            goalSequence = GetComponent<GoalSequenceController>().GoalSequence;

        }

        private void Start()
        {
            goalSequence.GoalChanged += OnGoalChanged;
            goalSequence.GoalsCompleted += OnGoalsCompleted;
        }
        private void OnDestroy()
        {
            goalSequence.GoalChanged -= OnGoalChanged;
            goalSequence.GoalsCompleted -= OnGoalsCompleted;

        }

        private void OnGoalsCompleted()
        {
        }

        private void OnGoalChanged(IGoal goal)
        {

        }



    }
}
