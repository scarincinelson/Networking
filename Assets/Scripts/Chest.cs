using System.Collections;
using Unity.Netcode;
using UnityEngine;

public class Chest : NetworkBehaviour
{
    [SerializeField] private Transform _lootSpawnPosition;
    [SerializeField] private Item _coin;
    [SerializeField] private NetworkVariable<bool> _wasOpened = new(false);
    [SerializeField] private Animator _animator;

    public void OpenChest()
    {
        if (_wasOpened.Value) return;

        OpenChestServerRpc();
    }

    [Rpc(SendTo.Server, InvokePermission = RpcInvokePermission.Everyone)]
    private void OpenChestServerRpc()
    {
        if (!IsServer) return; //Doble validación. Por la etiqueta no debería nunca ejecutarse en un cliente.

        if (_wasOpened.Value) return;

        _wasOpened.Value = true;
        var objectToSpawn = Instantiate(_coin, _lootSpawnPosition.position, Quaternion.identity);
        objectToSpawn.GetComponent<NetworkObject>().Spawn();
    }

    public override void OnNetworkSpawn()
    {
        _wasOpened.OnValueChanged += OnChestStateChanged;

        // Para late joiners
        OnChestStateChanged(false, _wasOpened.Value);
    }

    private void OnChestStateChanged(bool previous, bool current)
    {
        _animator.SetBool("isOpen", current);
    }
}