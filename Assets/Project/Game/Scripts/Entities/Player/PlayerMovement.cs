using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private PlayerBase playerBase;
    private PlayerStats playerStats;
    private Animator playerAnimator;

    [SerializeField] private GameEvent_Int eTurnEnd;

    private void Awake()
    {
        playerBase = GetComponentInParent<PlayerBase>();
        playerAnimator = playerBase.GetComponentInChildren<Animator>();
        playerStats = playerBase.StatsAsset;
    }

    // public void Move(Vector2 dir)
    // {
    //     playerBase.transform.position += (Vector3) dir * (playerStats.MovementSpeed * GlobalSettings.TravelSpeedScalar);
    //     eTurnEnd?.Raise(-1);
    // }

    public void Move(Direction direction)
    {
        playerAnimator.ResetTrigger("Move");

        switch (direction)
        {
            case (Direction.Up):
                playerBase.transform.position += Vector3.up * playerStats.MovementSpeed;
                break;

            case (Direction.Down):
                playerBase.transform.position += Vector3.down * playerStats.MovementSpeed;
                break;

            case (Direction.Left):
                playerBase.transform.position += Vector3.left * playerStats.MovementSpeed;
                break;

            case (Direction.Right):
                playerBase.transform.position += Vector3.right * playerStats.MovementSpeed;
                break;
        }

        eTurnEnd?.Raise(-1);
        playerAnimator.SetTrigger("Move");

    }

    // public void MoveUp() => playerBase.transform.position += Vector3.up * playerStats.MovementSpeed;
    // public void MoveDown() => playerBase.transform.position += Vector3.down * playerStats.MovementSpeed;
    // public void MoveLeft() => playerBase.transform.position += Vector3.left * playerStats.MovementSpeed;
    // public void MoveRight() => playerBase.transform.position += Vector3.right * playerStats.MovementSpeed;

}
