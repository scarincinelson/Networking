using Unity.Netcode;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : NetworkBehaviour
{
    private CharacterController _characterController;
    private Vector2 _input;
    private float _speed = 5f;
    private PlayerInput _playerInput;
    private float _yVelocity;
    private float _gravity = -9.81f;

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
        _playerInput = GetComponent<PlayerInput>();
        _playerInput.enabled = false;
    }

    private void Update()
    {
        if (!IsOwner) return;

        Vector3 move = new Vector3(_input.x, 0, _input.y);

        if (_characterController.isGrounded && _yVelocity < 0)
        {
            _yVelocity = -2f;
        }

        _yVelocity += _gravity * Time.deltaTime;
        move.y = _yVelocity;

        _characterController.Move(move * _speed * Time.deltaTime);
    }

    public override void OnNetworkSpawn()
    {
        _playerInput.enabled = IsOwner;
    }

    public override void OnNetworkDespawn()
    {
        _playerInput.enabled = false;
    }


    public void OnMove(InputValue value)
    {
        _input = value.Get<Vector2>();
    }

}