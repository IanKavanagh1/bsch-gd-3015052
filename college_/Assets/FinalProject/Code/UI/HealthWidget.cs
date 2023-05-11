using TMPro;
using UnityEngine;

namespace FinalProject.Code.UI
{
    public class HealthWidget : MonoBehaviour
    {
        [SerializeField]
        private TMP_Text _healthValueLabel;

        [SerializeField]
        private Animator _animator;

        private static int HealthBarDamagedVFXAnimParam = Animator.StringToHash("VFX_Damaged");
        private static int HealthBarHealedFXAnimParam = Animator.StringToHash("VFX_Healed");
        
        public void UpdateHealth( float health, bool isDamaged )
        {
            // Check that the text object is not null
            if ( _healthValueLabel != null )
            {
                // Update the UI with the players current health
                _healthValueLabel.SetText( Mathf.RoundToInt(health).ToString() );
            }
            
            // Check that the animator is not null
            if ( _animator != null )
            {
                // Check if the player is taking damage
                if ( isDamaged )
                {
                    // Fire Damaged VFX
                    _animator.SetTrigger( HealthBarDamagedVFXAnimParam );   
                }
                else
                {
                    // Fire Healed VFX
                    _animator.SetTrigger( HealthBarHealedFXAnimParam ); 
                }
            }
        }
    }
}