using Unity.Netcode;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : NetworkBehaviour
{
    CharacterController _characterController;
    Vector2 _input;
    float _speed = 5f;

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        //if (!IsOwner) return;

        if (Keyboard.current.dKey.wasPressedThisFrame)
        {
            this.transform.position = new Vector3(transform.position.x + 1, 0, 0);
        }

        if (Keyboard.current.aKey.wasPressedThisFrame)
        {
            this.transform.position = new Vector3(transform.position.x - 1, 0, 0);
        }

        /*
        Vector3 move = new Vector3(_input.x, 0, _input.y);
        Debug.Log(move);

        _characterController.Move(move * _speed * Time.deltaTime);
        */
    }

    /*

    public void OnMove(InputValue value)
    {
        _input = value.Get<Vector2>();
    }
    */
}