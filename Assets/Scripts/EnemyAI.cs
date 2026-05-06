using Unity.Netcode;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : NetworkBehaviour
{
    private NavMeshAgent _agent;
    [SerializeField] private Transform _target;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (_target != null)
        { 
            _agent.SetDestination(_target.position);
        }
    }

    public void OnPlayerDetected(GameObject playerDetected)
    {
        _target = playerDetected.transform;
    }

    public void OnPlayerLost(GameObject playerLost)
    {
        if (playerLost == _target)
        {
            _target = null;
        }
    }
}
