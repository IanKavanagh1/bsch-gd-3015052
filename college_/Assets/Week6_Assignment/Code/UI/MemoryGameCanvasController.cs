using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Week6_Assignment.Code.UI
{
    public class MemoryGameCanvasController : MonoBehaviour
    {
        [SerializeField]
        private ScoreWidget _scoreWidget;

        [SerializeField]
        private TimerWidget _timerWidget;

        [SerializeField]
        private GridWidget _gridWidget;

        [SerializeField]
        private int scorePerMatch;

        [SerializeField]
        private Animator _animator;

        [SerializeField]
        private Button _restartButton;

        private static int MaxScoreReachedAnimParam = Animator.StringToHash("MaxScoreReached");
        private static int TimerFinishedAnimParam = Animator.StringToHash("TimerFinished");

        // Set up all listeners for events on all UI widgets
        private void OnEnable()
        {
            if ( _timerWidget != null )
            {
                _timerWidget.onTimerFinishedEvent.AddListener( OnTimerFinishedEventHandler );
            }

            if ( _gridWidget != null )
            {
                _gridWidget.onMatchFoundEvent.AddListener( OnMatchFoundEventHandler );
            }

            if ( _scoreWidget != null )
            {
                _scoreWidget.onMaxScoreReachedEvent.AddListener( OnMaxScoreReachedEventHandler );
            }

            if ( _restartButton != null )
            {
                _restartButton.onClick.AddListener( OnRestartButtonClicked );
            }
        }

        // Function to handle the TimerFinishedEvent
        private void OnTimerFinishedEventHandler()
        {
            // Trigger Timer Finished Animation
            if ( _animator != null )
            {
                _animator.SetTrigger( TimerFinishedAnimParam );
            }
        }

        // Function to handle the MatchFoundEvent
        private void OnMatchFoundEventHandler()
        {
            // Update score as a match was found
            if ( _scoreWidget != null )
            {
                _scoreWidget.UpdateScore( scorePerMatch );
            }
        }

        // Function to handle the MaxScoreReachedEvent
        private void OnMaxScoreReachedEventHandler()
        {
            // Trigger the MaxScoreReached Animation
            if ( _animator != null )
            {
                _animator.SetTrigger( MaxScoreReachedAnimParam );           
            }
        }

        private void OnRestartButtonClicked()
        {
            SceneManager.LoadScene("Week6_Scene", LoadSceneMode.Single);
        }
    }   
}
