using UnityEngine;
using UnityEngine.Events;

namespace Week4_5_Assignment.Code
{
    public class Collectible : MonoBehaviour
    {
        public UnityEvent onItemCollectedEvent;
        
        // Check if the player has collected the item 
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                // Fire item collected event and destroy the game object
                onItemCollectedEvent.Invoke();
                Destroy( gameObject );
            }
        }
    }   
}
