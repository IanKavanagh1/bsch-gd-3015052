using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Week6_Assignment.Code.UI
{
    public class GridWidget : MonoBehaviour
    {
        [SerializeField]
        private GridItemWidget[] _gridItemWidgets;

        private List<string> selectedGridItems = new List<string>();

        public UnityEvent onMatchFoundEvent;
        public UnityEvent onNoMatchFoundEvent;

        private void OnEnable()
        {
            for ( int i = 0; i < _gridItemWidgets.Length; i++ )
            {
                // Set up event listeners for all grid items
                _gridItemWidgets[i].gridItemSelectedEvent.AddListener( OnGridItemSelectedEventHandler );
            }
        }

        // Function to handle grid items being selected
        private void OnGridItemSelectedEventHandler( string iconName )
        {
            // If we have less than two items in the list
            if ( selectedGridItems.Count < 2 )
            {
                // Add the current selected icon
                selectedGridItems.Add( iconName );   
            }
            else
            {
                // Otherwise trigger no match found, clear the list and add the currently selected icon
                onNoMatchFoundEvent.Invoke();
                selectedGridItems.Clear();
                selectedGridItems.Add( iconName );
            }

            // Check for a match
            if ( CheckForMatch( selectedGridItems ))
            {
                // If a match is found we trigger an event
                onMatchFoundEvent.Invoke();
            }
        }

        private bool CheckForMatch( List<string> iconNames )
        {
            // Only run comparison if there are at least 2 items in the list
            if ( iconNames.Count >= 2 )
            {
                return string.Equals(iconNames[0], iconNames[1]);
            }
            
            // Return false by default if the list has less than two elements
            return false;
        }
    }   
}
