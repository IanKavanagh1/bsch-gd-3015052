using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Week4_5_Assignment.Code
{
    public class GameOverCanvasController : MonoBehaviour
    {
        [SerializeField]
        private Animator _animator;

        [SerializeField]
        private Button _restartButton;

        private static int GameOverWonAnimParam = Animator.StringToHash("Won");
        private static int GameOverLostAnimParam = Animator.StringToHash("Lost");

        private void OnEnable()
        {
            if ( _restartButton != null )
            {
                _restartButton.onClick.AddListener( OnResetButtonClicked );
            }
        }

        private void OnResetButtonClicked()
        {
            SceneManager.LoadScene("Week4_5_Scene", LoadSceneMode.Single);
            Time.timeScale = 1f;
        }

        public void SetGameOverWonState()
        {
            if ( _animator != null )
            {
                _animator.SetTrigger( GameOverWonAnimParam );
            }
        }

        public void SetGameOverLostState()
        {
            if ( _animator != null )
            {
                _animator.SetTrigger( GameOverLostAnimParam );
            }
        }
    }   
}
