using FinalProject.Code.DialogSystem;
using FinalProject.Code.Player;
using UnityEngine;

namespace FinalProject.Code.NPC
{
    public class CaptainController : MonoBehaviour
    {
        [SerializeField]
        private GameObject _interationPrompt;

        [SerializeField]
        private DialogSettings _dialogSettings;
        
        private void OnTriggerEnter(Collider other)
        {
            if ( other.CompareTag( "Player" ) )
            {
                if ( _interationPrompt != null )
                {
                    _interationPrompt.SetActive( true );
                }
            }
        }

        private void OnTriggerStay(Collider other)
        {
            if ( other.CompareTag( "Player" ))
            {
                if ( _interationPrompt != null )
                {
                    if ( Input.GetKeyDown( KeyCode.E ))
                    {
                        PlayerEvents.OnPlayerInteractionEvent.Invoke( _dialogSettings );
                        _interationPrompt.SetActive( false );
                    }
                }
            }
        }
        
        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag( "Player" ))
            {
                if ( _interationPrompt != null )
                {
                    _interationPrompt.SetActive( false );
                }
            }
        }
    }   
}
