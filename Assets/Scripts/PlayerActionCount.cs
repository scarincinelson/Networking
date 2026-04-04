using Unity.Netcode;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerActionCount : NetworkBehaviour
{

    public NetworkVariable<int> counter = new NetworkVariable<int>(0);

    private void Update()
    {
        if (!IsOwner) return;

        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            IncrementServerRPC();
        }
    }

    [ServerRpc]
    private void IncrementServerRPC()
    {
        counter.Value++;
    }

    public override void OnNetworkSpawn()
    {
        counter.OnValueChanged += OnCounterValueChange;
    }

    public override void OnNetworkDespawn()
    {
        base.OnNetworkDespawn();
        counter.OnValueChanged -= OnCounterValueChange;
    }

    private void OnCounterValueChange(int oldValue, int newValue)
    {
        Debug.Log($"Player {OwnerClientId} contador: {newValue}");
    }
}
