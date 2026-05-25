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
            gameObject.SetActive(false);
            NetworkObject.Despawn(false);
        }
        else
        {
            PickUpServerRpc();
        }
        Debug.Log($"Picked: {_itemName}");
    }

    [Rpc(SendTo.Server, InvokePermission = RpcInvokePermission.Everyone)]
    private void PickUpServerRpc()
    {
        gameObject.SetActive(false);
        NetworkObject.Despawn(false);
    }
}