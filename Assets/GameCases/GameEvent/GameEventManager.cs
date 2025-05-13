using System.Collections.Generic;
using Tree.Binary;
using UnityEngine;

namespace EventSystem
{
    public class GameEventManager : MonoBehaviour
    {
        private BinarySearchTree<GameEvent> eventTree = new();

        private void Start()
        {
            // Agende eventos em qualquer momento
            this.ScheduleEvent("Spawn Inimigo", 2.5f);
            this.ScheduleEvent("Buff Jogador", 5.0f);
            this.ScheduleEvent("Explosão", 1.0f);

        }

        public void ScheduleEvent(string description, float delay)
        {
            float triggerTime = Time.time + delay;
            var gameEvent = new GameEvent(description, triggerTime);
            eventTree.Insert(gameEvent);
        }

        void Update()
        {
            List<GameEvent> readyEvents = new();

            eventTree.TraverseInOrder(e => {
                if (e.TriggerTime <= Time.time)
                    readyEvents.Add(e);
            });

            foreach (var evt in readyEvents)
            {
                Debug.Log($"Evento: {evt.Description} no tempo {Time.time:F2}");
                RemoveEvent(evt); 
            }
        }

        public void RemoveEvent(GameEvent evt)
        {
            // simplificação: recriar a árvore sem o evento (poderia ser AVL para eficiência real)
            var newTree = new BinarySearchTree<GameEvent>();
            eventTree.TraverseInOrder(e => {
                if (e != evt) newTree.Insert(e);
            });
            eventTree = newTree;
        }
    }

}