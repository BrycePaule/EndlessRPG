using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{

    [Header("References")]
    [SerializeField] private GameObject Player;

    [Header("Inputs")]
    private InputAction _movement;

    private void Awake() 
    {
        PlayerInput _playerInput = new PlayerInput();
        _playerInput.Enable();

        _movement = _playerInput.Player.Movement;

    }

    private void FixedUpdate()
    {
        HandlePlayerMovement();
    }

    private void HandlePlayerMovement()
    {
        Vector2 dir = _movement.ReadValue<Vector2>();
        Player.GetComponentInChildren<PlayerMovement>()?.Move(dir);
    }
}
