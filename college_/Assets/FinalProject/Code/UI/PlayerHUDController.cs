using FinalProject.Code.Player;
using UnityEngine;
using UnityEngine.UI;

namespace FinalProject.Code.UI
{
    public class PlayerHUDController : MonoBehaviour
    {
        [SerializeField]
        private HealthWidget _healthWidget;

        [SerializeField]
        private bool damage;

        [SerializeField]
        private Button testButton;

        [SerializeField]
        private FirstPersonPlayerController testPC;

        private void OnEnable()
        {
            PlayerEvents.OnPlayerDamagedEvent?.AddListener( OnPLayerDamagedEventHandler );
            PlayerEvents.OnPlayerHealedEvent?.AddListener( OnPlayerHealedEventHandler );

            testButton.onClick.AddListener( TestButtonClicked );
        }

        private void OnDisable()
        {
            PlayerEvents.OnPlayerDamagedEvent?.RemoveListener( OnPLayerDamagedEventHandler );
        }

        private void TestButtonClicked()
        {
            if ( damage )
            {
                testPC.TakeDamage( 10f );
            }
            else
            {
                testPC.Heal();
            }
        }

        private void OnPLayerDamagedEventHandler( float damage )
        {
            if ( _healthWidget != null )
            {
                _healthWidget.UpdateHealth( damage, true );
                Debug.Log("Player Damaged");
            }
        }

        private void OnPlayerHealedEventHandler( float health )
        {
            if ( _healthWidget != null )
            {
                _healthWidget.UpdateHealth( health, false );
                Debug.Log("Player Healed");
            }
        }
    }   
}
