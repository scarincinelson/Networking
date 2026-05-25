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
        PickUpServerRpc();

        Debug.Log($"Picked: {_itemName}");
    }

    [Rpc(SendTo.Server, InvokePermission = RpcInvokePermission.Everyone)]
    private void PickUpServerRpc()
    {
        NetworkObject.Despawn(false);
    }

    public override void OnNetworkDespawn()
    {
        gameObject.SetActive(false);
        base.OnNetworkDespawn();
    }
}