using UnityEngine;

namespace FinalProject.Code.Player
{
    [CreateAssetMenu(fileName = "PlayerData", menuName = "Player/PlayerData", order = 0)]
    public class PlayerData : ScriptableObject
    {
        [SerializeField]
        private float _maxHealth;

        [SerializeField]
        private float _currentHealth;

        [SerializeField]
        private float _walkSpeed;

        [SerializeField]
        private float _runSpeed;

        [SerializeField]
        private float _accleration;

        [SerializeField]
        private float _jumpForce;

        [SerializeField]
        private float _crouchHeight;

        // Public Getters for PlayerData Properties
        public float MaxHealth => _maxHealth;

        public float CurrentHealth
        {
            get => _currentHealth;

            set => _currentHealth = value;
        }
        public float WalkSpeed => _walkSpeed;
        public float RunSpeed => _runSpeed;
        public float Acceleration => _accleration;
        public float JumpForce => _jumpForce;
        public float CrouchHeight => _crouchHeight;
    }
}