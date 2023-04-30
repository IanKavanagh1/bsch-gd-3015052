using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace Week6_Assignment.Code.UI
{
    public class TimerWidget : MonoBehaviour
    {
        [SerializeField]
        private TMP_Text _timer;

        [SerializeField]
        private float _timeAllowed;

        public UnityEvent onTimerFinishedEvent; 
        
        private void Update()
        {
            // Check if the timer is greater than 0
            if ( _timeAllowed > 0 )
            {
                // Decrease the time remaining by the amount of time that has passed since the last frame
                _timeAllowed -= Time.deltaTime;
            }
            else
            {
                // Once the timer reaches 0 trigger an event 
                onTimerFinishedEvent.Invoke();
            }

            // Check the timer object is not null
            if ( _timer != null )
            {
                // Create a string with the timer represented as a whole number and with s suffix 
                string timerString = string.Format("{0}s", Mathf.RoundToInt(_timeAllowed));
                _timer.text = timerString;
            }
        }
    }
}