using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace FinalProject.Code.DialogSystem
{
    public class DialogUIController : MonoBehaviour
    {
        [SerializeField]
        private TMP_Text _dialogText;

        [SerializeField]
        private Button _nextMessageButton;

        private DialogSettings _dialogSettings;
        private int index;

        #region [ Public Methods ]
        
        public void ShowDialog( DialogSettings dialogSettings )
        {
            gameObject.SetActive( true );
            _dialogSettings = dialogSettings;

            if ( _dialogText !=  null )
            {
                // Display the first message
                _dialogText.SetText( _dialogSettings.DialogStrings[0] );
            }
            
            DialogEvents.OnDialogShownEvent.Invoke();
        }
        
        #endregion

        #region [ Private Methods ]
        
        private void OnEnable()
        {
            if ( _nextMessageButton != null )
            {
                _nextMessageButton.onClick.AddListener( UpdateDialog );
            }
        }

        private void OnDisable()
        {
            if ( _nextMessageButton != null )
            {
                _nextMessageButton.onClick.RemoveListener( UpdateDialog );
            }
        }
        
        private void UpdateDialog()
        {
            if ( _dialogText != null )
            {
                if ( index < _dialogSettings.DialogStrings.Length )
                {
                    _dialogText.SetText( _dialogSettings.DialogStrings[ index ]);
                    index++;
                }
                else
                {
                    // Otherwise we are at the end of the dialog so close the UI and reset the index counter
                    gameObject.SetActive( false );
                    index = 0;
                    
                    DialogEvents.OnDialogHideEvent.Invoke();
                }
            }
        }
        
        #endregion
    }
}