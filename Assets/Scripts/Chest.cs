using Unity.Netcode;
using UnityEngine;

public class Chest : MonoBehaviour
{
    [SerializeField] private Item _coin;
    private bool _wasOpened;
    public void OpenChest()
    {
        if (_wasOpened) return;

        _wasOpened = true;

        OpenChestServerRpc();
    }

    [ServerRpc]
    private void OpenChestServerRpc()
    {
        var objectToSpawn = Instantiate(_coin);
        objectToSpawn.GetComponent<NetworkObject>().Spawn();
    }
}
