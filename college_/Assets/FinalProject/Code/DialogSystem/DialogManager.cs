using FinalProject.Code.Player;
using UnityEngine;

namespace FinalProject.Code.DialogSystem
{
    public class DialogManager : MonoBehaviour
    {
        [SerializeField]
        private DialogUIController _dialogUIController;
        
        private void Awake()
        {
            // Keep the DialogManager loaded when scenes change
            DontDestroyOnLoad(gameObject);
        }

        private void OnEnable()
        {
            PlayerEvents.OnPlayerInteractionEvent.AddListener( OnPlayerInteractionEventHandler );
        }

        private void OnDisable()
        {
            PlayerEvents.OnPlayerInteractionEvent.RemoveListener( OnPlayerInteractionEventHandler );
        }

        private void OnPlayerInteractionEventHandler( object dialogSettings )
        {
            DisplayDialog( dialogSettings );
        }

        private void DisplayDialog( object dialogSettings )
        {
            DialogSettings dialog = dialogSettings as DialogSettings;

            if ( _dialogUIController != null )
            {
                _dialogUIController.ShowDialog( dialog );
            }
        }
    }   
}
