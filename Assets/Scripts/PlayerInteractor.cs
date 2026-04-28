using UnityEngine;

public class PlayerInteractor : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Chest>(out var chest))
        {
            chest.OpenChest();
        }
    }
}
