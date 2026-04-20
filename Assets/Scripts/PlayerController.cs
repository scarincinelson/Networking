using Unity.Netcode;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : NetworkBehaviour
{
    CharacterController _characterController;
    Vector2 _input;
    float _speed = 5f;
    private PlayerInput playerInput;

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
        playerInput = GetComponent<PlayerInput>();
        playerInput.enabled = false;
    }

    private void Update()
    {
        Vector3 move = new Vector3(_input.x, 0, _input.y);
        _characterController.Move(move * _speed * Time.deltaTime);
    }

    public override void OnNetworkSpawn()
    {
        playerInput.enabled = IsOwner;
    }

    public override void OnNetworkDespawn()
    {
        playerInput.enabled = false;
    }


    public void OnMove(InputValue value)
    {
        _input = value.Get<Vector2>();
    }

}