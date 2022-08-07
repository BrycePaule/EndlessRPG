using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private PlayerBase playerBase;
    private PlayerStats playerStats;
    private Animator playerAnimator;

    [SerializeField] private GameEvent_Int eTurnEnd;

    private bool moving;
    private float moveTime;

    private Vector3 moveStartPos;
    private Vector3 moveEndPos;

    private void Awake()
    {
        playerBase = GetComponentInParent<PlayerBase>();
        playerAnimator = playerBase.GetComponentInChildren<Animator>();
        playerStats = playerBase.StatsAsset;

        moveTime = 0f;
        moving = false;
    }

    private void Update()
    {
        if (!moving) { return; }

        if (moveTime >= 1f)
        {
            moving = false;
            moveTime = 0f;
        }
        else
        {
            playerBase.transform.position = Vector3.Lerp(moveStartPos, moveEndPos, moveTime);
            moveTime += (Time.deltaTime / (GlobalSettings.EntityMoveTime * Time.timeScale));
        }
    }

    public void Move(Direction direction)
    {
        if (moving) { return; }

        moveStartPos = playerBase.transform.position;

        switch (direction)
        {
            case (Direction.Up):
                moveEndPos = moveStartPos + (Vector3.up * playerStats.MovementSpeed);
                break;

            case (Direction.Down):
                moveEndPos = moveStartPos + (Vector3.down * playerStats.MovementSpeed);
                break;

            case (Direction.Left):
                moveEndPos = moveStartPos + (Vector3.left * playerStats.MovementSpeed);
                break;

            case (Direction.Right):
                moveEndPos = moveStartPos + (Vector3.right * playerStats.MovementSpeed);
                break;
        }

        moving = true;
        playerAnimator.ResetTrigger("Move");
        playerAnimator.SetTrigger("Move");
        eTurnEnd?.Raise(-1);
    }
}
