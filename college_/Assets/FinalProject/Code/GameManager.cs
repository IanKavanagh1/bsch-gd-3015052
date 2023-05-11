using FinalProject.Code.UI;
using UnityEngine;
using UnityEngine.Playables;

namespace FinalProject.Code
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField]
        private PlayerHUDController _playerHUDController;

        [SerializeField]
        private MainMenuController _mainMenuController;

        [SerializeField]
        private PlayableDirector _introCinematicDirector;
        
        private void Awake()
        {
            // Keep the GameManager loaded when scenes change
            DontDestroyOnLoad( gameObject );
        }

        private void OnEnable()
        {
            if ( _mainMenuController != null )
            {
                _mainMenuController.onStartGameEvent.AddListener( OnStartGameEventHandler );
            }
        }

        private void OnDisable()
        {
            if ( _mainMenuController != null )
            {
                _mainMenuController.onStartGameEvent.RemoveListener( OnStartGameEventHandler );
            }
        }

        private void OnStartGameEventHandler()
        {
            //Trigger Intro Cinematic 
            //TODO: Only trigger intro cinematic if its the first time the player starts the game
            if ( _introCinematicDirector != null )
            {
                _introCinematicDirector.Play();
            }
        }
    }
}