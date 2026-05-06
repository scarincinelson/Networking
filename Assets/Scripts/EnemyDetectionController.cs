using UnityEngine;

public class EnemyDetectionController : MonoBehaviour
{
    [SerializeField] private EnemyAI enemy;

    private void OnTriggerEnter(Collider other)
    {
        if (!enemy.IsServer) return;

        if (!other.CompareTag("Player")) return;

        enemy.OnPlayerDetected(other.gameObject);
    }

    private void OnTriggerExit(Collider other)
    {
        if (!enemy.IsServer) return;

        if (!other.CompareTag("Player")) return;

        enemy.OnPlayerLost(other.gameObject);
    }
}
