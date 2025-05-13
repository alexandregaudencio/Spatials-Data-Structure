using System;


namespace EventSystem
{
    public class GameEvent : IComparable<GameEvent>
    {
        public string Description;
        public float TriggerTime; // Tempo em segundos no Time.time

        public GameEvent(string description, float triggerTime)
        {
            Description = description;
            TriggerTime = triggerTime;
        }

        public int CompareTo(GameEvent other)
        {
            return TriggerTime.CompareTo(other.TriggerTime);
        }
    }

}