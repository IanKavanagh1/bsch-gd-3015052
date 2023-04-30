using UnityEngine;

namespace Week4_5_Assignment.Code
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField]
        private Collectible _collectible;

        [SerializeField]
        private GameOverCanvasController _gameOverCanvas;

        [SerializeField]
        private EnemyPatrol _enemyPatrol;

        private void OnEnable()
        {
            if ( _collectible != null )
            {
                _collectible.onItemCollectedEvent.AddListener( OnItemCollectedEventHandler );
            }

            if ( _enemyPatrol != null )
            {
                _enemyPatrol.onPlayerCaughtEvent.AddListener( OnPlayerCaughtEventHandler );
            }
        }

        private void OnItemCollectedEventHandler()
        {
            if ( _gameOverCanvas != null )
            {
                _gameOverCanvas.gameObject.SetActive( true );
                _gameOverCanvas.SetGameOverWonState();
                Time.timeScale = 0f;
            }
        }

        private void OnPlayerCaughtEventHandler()
        {
            if ( _gameOverCanvas != null )
            {
                _gameOverCanvas.gameObject.SetActive( true );
                _gameOverCanvas.SetGameOverLostState();
                Time.timeScale = 0f;
            }
        }
    }   
}
