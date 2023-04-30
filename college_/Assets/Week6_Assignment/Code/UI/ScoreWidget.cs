using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace Week6_Assignment.Code.UI
{
    public class ScoreWidget : MonoBehaviour
    {
        [SerializeField]
        private TMP_Text _scoreLabel;

        [SerializeField]
        private int _maxScore;

        private int currentScore = 0;

        public UnityEvent onMaxScoreReachedEvent;
        
        // Function to update the player score when a match is found
        public void UpdateScore(int score)
        {
            // Update current score value
            currentScore += score;

            // Check that we have the label and apply the new score
            if ( _scoreLabel != null )
            {
               _scoreLabel.SetText(currentScore.ToString());
            }

            // Check if the max score has been reached
            if ( currentScore == _maxScore )
            {
                // If so trigger max score event to end the game
                onMaxScoreReachedEvent.Invoke();
            }
        }
    }   
}
