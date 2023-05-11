using UnityEngine.Events;

namespace FinalProject.Code.Player
{
    // Static Class to contain all player events
    public static class PlayerEvents
    {
        public static UnityEvent<float> OnPlayerDamagedEvent = new UnityEvent<float>();
        public static UnityEvent<float> OnPlayerHealedEvent = new UnityEvent<float>();
        public static UnityEvent OnPlayerDeathEvent = new UnityEvent();
        public static UnityEvent<object> OnPlayerInteractionEvent = new UnityEvent<object>();
    }
}