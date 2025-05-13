using System.Collections.Generic;
using UnityEngine;

namespace GoalSystem 
{ 
    public class GoalSequenceController : MonoBehaviour
    {
        [SerializeField] private List<GoalSequence> goals;
        public GoalSequence GoalSequence { get; private set; }  

        private void Awake()
        {
            GoalSequence = new GoalSequence((IEnumerable<IGoal>)goals);
        }

        private void Start()
        {
            GoalSequence.GoalsCompleted += OnGoalsCompleted;
        }

        private void OnDestroy()
        {
            GoalSequence.GoalsCompleted -= OnGoalsCompleted;

        }

        private void OnGoalsCompleted()
        {

        }
    }
}
