using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{

    [Header("References")]
    [SerializeField] private GameObject Player;

    [Header("Inputs")]
    private InputAction movement;
    private InputAction moveUp;
    private InputAction moveDown;
    private InputAction moveLeft;
    private InputAction moveRight;

    private PlayerMovement playerMovement;

    private void Awake() 
    {
        playerMovement = Player.GetComponentInChildren<PlayerMovement>();

        PlayerInput _playerInput = new PlayerInput();
        _playerInput.Enable();

        moveUp = _playerInput.Player.MoveUp;
        moveDown = _playerInput.Player.MoveDown;
        moveLeft = _playerInput.Player.MoveLeft;
        moveRight = _playerInput.Player.MoveRight;

        moveUp.performed += ctx => OnMoveUp();
        moveDown.performed += ctx => OnMoveDown();
        moveLeft.performed += ctx => OnMoveLeft();
        moveRight.performed += ctx => OnMoveRight();
    }

    private void OnMoveUp() => playerMovement.Move(Direction.Up);
    private void OnMoveDown() => playerMovement.Move(Direction.Down);
    private void OnMoveLeft() => playerMovement.Move(Direction.Left);
    private void OnMoveRight() => playerMovement.Move(Direction.Right);
}
