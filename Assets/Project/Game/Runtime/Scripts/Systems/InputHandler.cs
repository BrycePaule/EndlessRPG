using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject Player;
    [SerializeField] private Camera MainCamera;
    // [SerializeField] private GameObject Marker;

    [Header("Inputs")]
    private InputAction movement;

    private InputAction moveUp;
    private InputAction moveDown;
    private InputAction moveLeft;
    private InputAction moveRight;

    private InputAction mousePosition;

    private PlayerMovement playerMovement;

    public Vector2 mousePosScreen;
    public Vector3 mousePosWorld;

    private void Awake() 
    {
        playerMovement = Player.GetComponentInChildren<PlayerMovement>();

        PlayerInput _playerInput = new PlayerInput();
        _playerInput.Enable();

        moveUp = _playerInput.Player.MoveUp;
        moveDown = _playerInput.Player.MoveDown;
        moveLeft = _playerInput.Player.MoveLeft;
        moveRight = _playerInput.Player.MoveRight;

        mousePosition = _playerInput.Player.MousePosition;

        moveUp.performed += ctx => OnMoveUp();
        moveDown.performed += ctx => OnMoveDown();
        moveLeft.performed += ctx => OnMoveLeft();
        moveRight.performed += ctx => OnMoveRight();
    }

    private void Update()
    {
        mousePosScreen = mousePosition.ReadValue<Vector2>();
        mousePosWorld = MainCamera.ScreenToWorldPoint(mousePosScreen);
        mousePosWorld.z = 0f;
    }

    private void OnMoveUp() => playerMovement.Move(Direction.Up);
    private void OnMoveDown() => playerMovement.Move(Direction.Down);
    private void OnMoveLeft() => playerMovement.Move(Direction.Left);
    private void OnMoveRight() => playerMovement.Move(Direction.Right);
}
