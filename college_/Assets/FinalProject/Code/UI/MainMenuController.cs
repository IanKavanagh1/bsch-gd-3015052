using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace FinalProject.Code.UI
{
    public class MainMenuController : MonoBehaviour
    {
        [SerializeField]
        private Button _startGameButton;

        [SerializeField]
        private Button _restartGameButton;

        [SerializeField]
        private Button _quitGameButton;

        public UnityEvent onStartGameEvent;
        
        private void OnEnable()
        {
            // Set up listeners for main menu buttons
            if ( _startGameButton != null )
            {
                _startGameButton.onClick.AddListener( OnStartButtonClicked );
            }

            if ( _restartGameButton != null )
            {
                _restartGameButton.onClick.AddListener( OnRestartButtonClicked );
            }

            if ( _quitGameButton != null )
            {
                _quitGameButton.onClick.AddListener( OnQuitButtonClicked );
            }
        }

        private void OnDisable()
        {
            // Clear all listeners when the gameobject is disabled
            if ( _startGameButton != null )
            {
                _startGameButton.onClick.RemoveListener( OnStartButtonClicked );
            }

            if ( _restartGameButton != null )
            {
                _restartGameButton.onClick.RemoveListener( OnRestartButtonClicked );
            }

            if ( _quitGameButton != null )
            {
                _quitGameButton.onClick.RemoveListener( OnQuitButtonClicked );
            }
        }

        private void OnStartButtonClicked()
        {
            // Trigger Start Game Event
            onStartGameEvent.Invoke();
        }
        
        private void OnRestartButtonClicked()
        {
            // Reload the main scene
            SceneManager.LoadScene( "FinalProjectMainMenuScene", LoadSceneMode.Single );
        }

        private void OnQuitButtonClicked()
        {
            // Close the application
            Application.Quit();
        }
    }   
}
