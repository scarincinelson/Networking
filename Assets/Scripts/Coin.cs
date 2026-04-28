using Unity.Netcode;
using UnityEngine;

public class Coin : Item
{
    public override string GetItemData()
    {
        return _itemName;
    }

    public override void PickUp()
    {
        if (IsServer)
        {
            NetworkObject.Despawn();
        }
        else
        {
            PickUpServerRpc();
        }
        Debug.Log($"Picked: {_itemName}");
    }

    [Rpc(SendTo.Server)]
    private void PickUpServerRpc()
    {
        NetworkObject.Despawn(true);
    }
}