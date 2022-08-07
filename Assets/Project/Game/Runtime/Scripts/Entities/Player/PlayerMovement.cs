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

        playerBase.transform.position = Vector3.Lerp(moveStartPos, moveEndPos, moveTime);
        moveTime += (Time.deltaTime / GlobalSettings.EntityMoveTime);

        if (moveTime >= 1f)
        {
            moving = false;
            moveTime = 0f;
            playerBase.transform.position = Utils.CentrePosOnTile(playerBase.transform.position);
        }
    }

    public void Move(Direction direction)
    {
        if (moving) { return; }

        moveStartPos = playerBase.transform.position;

        switch (direction)
        {
            case (Direction.Up):
                moveEndPos = moveStartPos + (Vector3.up * GlobalSettings.TilemapScale);
                break;

            case (Direction.Down):
                moveEndPos = moveStartPos + (Vector3.down * GlobalSettings.TilemapScale);
                break;

            case (Direction.Left):
                moveEndPos = moveStartPos + (Vector3.left * GlobalSettings.TilemapScale);
                break;

            case (Direction.Right):
                moveEndPos = moveStartPos + (Vector3.right * GlobalSettings.TilemapScale);
                break;
        }

        moving = true;
        playerAnimator.ResetTrigger("Move");
        playerAnimator.SetTrigger("Move");
        eTurnEnd?.Raise(-1);
    }
}
