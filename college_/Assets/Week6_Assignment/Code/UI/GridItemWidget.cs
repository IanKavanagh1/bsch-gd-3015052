using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Week6_Assignment.Code.UI
{
    public class GridItemWidget : MonoBehaviour
    {
        [SerializeField]
        private Image _itemShownIcon;

        [SerializeField]
        private Button _itemButton;
        
        private string iconName = " ";

        public UnityEvent<string> gridItemSelectedEvent;

        private void OnEnable()
        {
            // Set up button click listener
            if ( _itemButton != null )
            {
                _itemButton.onClick.AddListener( OnItemClickedListener );   
            }
        }
        
        private void OnItemClickedListener()
        {
            // Trigger item selected event and pass the icon name for the selected item
            if ( _itemShownIcon != null )
            {
                gridItemSelectedEvent.Invoke( _itemShownIcon.sprite.name );
            }
        }
    }   
}
