using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] private List<string> _inventory = new List<string>();
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Item>(out var item))
        {
            _inventory.Add(item.GetItemData());
            item.PickUp();
        }
    }
}