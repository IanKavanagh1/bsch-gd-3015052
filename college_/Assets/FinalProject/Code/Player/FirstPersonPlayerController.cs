using FinalProject.Code.DialogSystem;
using UnityEngine;

namespace FinalProject.Code.Player
{
    public class FirstPersonPlayerController : MonoBehaviour
    {
        [Header("Camera Movement")]
        [SerializeField]
        private float _mouseSensitivity;
        
        [SerializeField]
        [Range(0.0f, 0.5f)]
        private float _mouseSmoothTime;
        
        [SerializeField]
        private Transform _cameraTransform;
        
        [SerializeField]
        private CharacterController _characterController;

        [SerializeField]
        private Transform _groundCheck;

        [SerializeField]
        private LayerMask _ground;
        
        [SerializeField]
        private float _gravity = -9.81f;

        [SerializeField]
        private PlayerData _playerData;

        #region [ Private Fields]

        private float cameraCap;
        private float velocityY;
        private bool isGrounded;
        
        private Vector2 currentMouseDelta;
        private Vector2 currentMouseDeltaVelocity;

        private Vector2 currentDirection;
        private Vector2 currentDirectionVelocity;
        private Vector3 velocity;

        private bool canMoveCamera = true;

        #endregion
        
        private void Start()
        {
           Cursor.lockState = CursorLockMode.Locked;
           Cursor.visible = false;
        }

        private void OnEnable()
        {
            DialogEvents.OnDialogShownEvent.AddListener( OnDialogShownEventHandler );
            DialogEvents.OnDialogHideEvent.AddListener( OnDialogHideEventHandler );
        }

        private void OnDisable()
        {
            DialogEvents.OnDialogShownEvent.RemoveListener( OnDialogShownEventHandler );
            DialogEvents.OnDialogHideEvent.RemoveListener( OnDialogHideEventHandler ); 
        }

        private void OnDialogShownEventHandler()
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            canMoveCamera = false;
        }

        private void OnDialogHideEventHandler()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            canMoveCamera = true;
        }

        public void TakeDamage( float damage )
        {
            if ( _playerData != null )
            {
                // Update the Players current health
                _playerData.CurrentHealth -= damage;
                
                // Check if the Players current health is 0
                if ( _playerData.CurrentHealth <= 0 )
                {
                    // Fire Death Event
                    PlayerEvents.OnPlayerDeathEvent.Invoke();
                }
                //Otherwise update health bar UI
                else
                {
                    // Fire event to update player health 
                    PlayerEvents.OnPlayerDamagedEvent.Invoke( _playerData.CurrentHealth );
                }
            }
        }

        public void Heal()
        {
            if ( _playerData != null )
            {
                // Reset Player health back to max
                _playerData.CurrentHealth = _playerData.MaxHealth;
                
                // Fire Player Healed Event
                PlayerEvents.OnPlayerHealedEvent.Invoke( _playerData.CurrentHealth );
            }
        }

        private void Update()
        {
            // Block camera movement if a dialog UI is visible
            if ( canMoveCamera )
            {
                CameraMovement();   
            }
            
            PlayerMovement();
        }

        private void CameraMovement()
        {
            Vector2 targetMouseDelta = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

            currentMouseDelta = Vector2.SmoothDamp(currentMouseDelta, targetMouseDelta, ref currentMouseDeltaVelocity,
                _mouseSmoothTime);

            cameraCap -= currentMouseDelta.y * _mouseSensitivity;

            cameraCap = Mathf.Clamp(cameraCap, -90.0f, 90.0f);

            if ( _cameraTransform != null )
            {
                _cameraTransform.localEulerAngles = Vector3.right * cameraCap;
            }
            
            transform.Rotate(Vector3.up * (currentMouseDelta.x * _mouseSensitivity) );
        }

        private void PlayerMovement()
        {
            if ( _groundCheck != null && _characterController != null && _playerData != null)
            {
                isGrounded = Physics.CheckSphere( _groundCheck.position, 0.2f, _ground );

                Vector2 targetDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
                targetDirection.Normalize();

                currentDirection =
                    Vector2.SmoothDamp(currentDirection, targetDirection, ref currentDirectionVelocity, 0.3f);

                velocityY += _gravity * 2f * Time.deltaTime;

                Vector3 velocity = (transform.forward * currentDirection.y + transform.right * currentDirection.x) *
                                   _playerData.WalkSpeed + Vector3.up * velocityY;

                _characterController.Move(velocity * Time.deltaTime );

                if ( isGrounded && Input.GetButtonDown("Jump"))
                {
                    velocityY = Mathf.Sqrt( _playerData.JumpForce * -2f * _gravity );
                }

                if ( !isGrounded && _characterController.velocity.y < -1f )
                {
                    velocityY = -8f;
                }
            }
        }
    }
}