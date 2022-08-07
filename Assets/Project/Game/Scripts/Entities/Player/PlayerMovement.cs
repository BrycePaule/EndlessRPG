using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private PlayerBase playerBase;
    private PlayerStats playerStats;

    [SerializeField] private GameEvent_Int eTurnEnd;

    private void Awake()
    {
        playerBase = GetComponentInParent<PlayerBase>();
        playerStats = playerBase.StatsAsset;
    }

    // public void Move(Vector2 dir)
    // {
    //     playerBase.transform.position += (Vector3) dir * (playerStats.MovementSpeed * GlobalSettings.TravelSpeedScalar);
    //     eTurnEnd?.Raise(-1);
    // }

    public void Move(Direction direction)
    {
        switch (direction)
        {
            case (Direction.Up):
                playerBase.transform.position += Vector3.up * playerStats.MovementSpeed;
                eTurnEnd?.Raise(-1);
                break;

            case (Direction.Down):
                playerBase.transform.position += Vector3.down * playerStats.MovementSpeed;
                eTurnEnd?.Raise(-1);
                break;

            case (Direction.Left):
                playerBase.transform.position += Vector3.left * playerStats.MovementSpeed;
                eTurnEnd?.Raise(-1);
                break;

            case (Direction.Right):
                playerBase.transform.position += Vector3.right * playerStats.MovementSpeed;
                eTurnEnd?.Raise(-1);
                break;
        }
    }

    // public void MoveUp() => playerBase.transform.position += Vector3.up * playerStats.MovementSpeed;
    // public void MoveDown() => playerBase.transform.position += Vector3.down * playerStats.MovementSpeed;
    // public void MoveLeft() => playerBase.transform.position += Vector3.left * playerStats.MovementSpeed;
    // public void MoveRight() => playerBase.transform.position += Vector3.right * playerStats.MovementSpeed;

}
