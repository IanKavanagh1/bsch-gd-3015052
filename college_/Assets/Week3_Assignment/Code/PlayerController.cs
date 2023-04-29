using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region Movement Variables
    
    [Header("Movement Variables")]
    
    [SerializeField]
    private float maxSpeed;

    [SerializeField]
    private float accelerationSpeed;

    [SerializeField]
    private float inAirAccelerationSpeed;

    [SerializeField]
    private float inAirMaxSpeed;

    [SerializeField]
    private float jumpForce;

    [SerializeField]
    private int maxJumps;
    
    [SerializeField]
    private bool grounded;

    #endregion

    #region Components
    [Header("Components")]
    
    [SerializeField]
    private Rigidbody2D _rigidbody2D;

    [SerializeField]
    private Animator _animator;

    [SerializeField]
    private SpriteRenderer _spriteRenderer;

    [SerializeField]
    private ParticleSystem _particleSystem;
    
    #endregion

    #region Private Variables
    
    private float currentSpeed;
    private int cachedMaxJumps;
    private static readonly int movementAnimatorParam = Animator.StringToHash("Horizontal_Movement");
    private static readonly int jumpAnimatorParam = Animator.StringToHash("Jump");
    
    #endregion

    #region Unity Callbacks

    private void OnEnable()
    {
        // When the player gameobject is enabled cache the max jumps they start with so we can reset them later on
        cachedMaxJumps = maxJumps;
    }

    void LateUpdate()
    {
        // Firstly check to make sure we have access to all components we need to avoid any null references
        if ( _rigidbody2D != null && _particleSystem != null && _spriteRenderer != null )
        {
            // set the currentSpeed to the current velocity of the player rigidbody
            currentSpeed = _rigidbody2D.velocity.x;

            float moveInput = Input.GetAxis("Horizontal");

            // If the player is moving in any direction left or right we can play the particle system
            if ( moveInput < 0 )
            {
                _spriteRenderer.flipX = false;
                _particleSystem.Play();
            }
            else if ( moveInput > 0 )
            {
                _spriteRenderer.flipX = true;
                _particleSystem.Play();
            }
            
            // stop the particle system when there is no movement input
            if (moveInput == 0)
            {
                _particleSystem.Stop();
            }

            // Handle movement on the ground
            if (Mathf.Abs(currentSpeed) < maxSpeed && grounded)
            {
                _rigidbody2D.AddForce(new Vector2( moveInput * accelerationSpeed, 0));
            }
            
            // Handle inAir movement
            if (Mathf.Abs(currentSpeed) < inAirMaxSpeed && !grounded)
            {
                _rigidbody2D.AddForce(new Vector2( moveInput * inAirAccelerationSpeed, 0));
            }
            
            // Handle jumping
            if (Input.GetKeyDown("space") && maxJumps > 0)
            {
                _rigidbody2D.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
                
                // the player is in the air so we can set grounded to false
                grounded = false;
                
                // decrease max jumps each time the player presses jump
                maxJumps--;
            }
            
            // Set the animator parameters for moving and jumping
            if ( _animator != null )
            {
                _animator.SetFloat(movementAnimatorParam, Mathf.Abs(currentSpeed * moveInput));
                _animator.SetBool(jumpAnimatorParam, !grounded);
            }
        }
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        // Check if the players collider has collided with the ground
        if (other.gameObject.CompareTag("Ground"))
        {
            // player is on the ground so set grounded to true
            grounded = true;
            
            // when the player touches the ground we can reset the maxJumps back to their original value
            maxJumps = cachedMaxJumps;
        }
    }
    
    #endregion
}
