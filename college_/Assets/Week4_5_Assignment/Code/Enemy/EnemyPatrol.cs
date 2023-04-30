using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public class EnemyPatrol : MonoBehaviour
{
    [SerializeField]
    private NavMeshAgent _navMeshAgent;

    [SerializeField]
    private Transform[] _goals;

    [SerializeField]
    private GameObject _player;

    [SerializeField]
    private float _detectionRadius;

    [SerializeField]
    private bool _playerDetected;

    public UnityEvent onPlayerCaughtEvent;

    private void Start()
    {
        if ( _navMeshAgent != null && _goals.Length > 0 )
        {
            _navMeshAgent.destination = _goals[0].position;
        }
    }

    private void Update()
    {
        if ( _player != null )
        {
            _playerDetected = Vector3.Distance(_player.transform.position, gameObject.transform.position) 
                              <= _detectionRadius;

            if ( _playerDetected )
            {
                _navMeshAgent.destination = _player.transform.position;
                onPlayerCaughtEvent.Invoke();
            }
            else
            {
                if ( _navMeshAgent.remainingDistance < 1.5f )
                {
                    _navMeshAgent.destination = _goals[Random.Range(0, _goals.Length)].position;
                }
            }
        }
    }
}
