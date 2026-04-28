using Unity.Netcode;
using UnityEngine;

public abstract class Item : NetworkBehaviour
{
    [SerializeField] protected GameObject _visualGO;
    [SerializeField] protected string _itemName;
    [SerializeField] protected float _rotationSpeed;

    public abstract void PickUp();

    public abstract string GetItemData();

    private void Update()
    {
        _visualGO.transform.Rotate(0, _rotationSpeed * Time.deltaTime, 0);
    }
}