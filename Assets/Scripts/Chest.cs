using Unity.Netcode;
using UnityEngine;

public class Chest : NetworkBehaviour
{
    [SerializeField] private Transform _lootSpawnPosition;
    [SerializeField] private Item _coin;
    [SerializeField] private NetworkVariable<bool> _wasOpened = new(false);

    public void OpenChest()
    {
        if (_wasOpened.Value) return;

        OpenChestServerRpc();
    }

    [Rpc(SendTo.Server,InvokePermission = RpcInvokePermission.Everyone)]
    private void OpenChestServerRpc()
    {
        if (!IsServer) return; //Doble validación. Por la etiqueta no debería nunca ejecutarse en un cliente.

        if (_wasOpened.Value) return;

        _wasOpened.Value = true;

        var objectToSpawn = Instantiate(_coin, _lootSpawnPosition.position, Quaternion.identity);
        objectToSpawn.GetComponent<NetworkObject>().Spawn();
    }
}
