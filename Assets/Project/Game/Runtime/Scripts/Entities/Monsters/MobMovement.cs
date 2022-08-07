using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobMovement : MonoBehaviour
{

    private MobBase mobBase;
    private MobStats stats;

    private Vector2 target;

    private bool moving;
    private float moveTime;
    private Vector3 moveStartPos;
    private Vector3 moveEndPos;

    private int turnCounter;

    private void Awake()
    {
        mobBase = GetComponentInParent<MobBase>();
        stats = mobBase.StatsAsset;
        turnCounter = stats.TurnsToMove;

        moveTime = 0f;
        turnCounter = 0;
    }

    private void Update()
    {
        if (!moving) { return; }

        mobBase.transform.position = Vector3.Lerp(moveStartPos, moveEndPos, moveTime);
        moveTime += (Time.deltaTime / GlobalSettings.EntityMoveTime);

        if (moveTime >= 1f)
        {
            moving = false;
            moveTime = 0f;
            mobBase.transform.position = Utils.CentrePosOnTile(mobBase.transform.position);
            turnCounter = 0;
        }
    }

    public void Move()
    {
        if (moving) { return; }
        turnCounter += 1;

        if (turnCounter >= stats.TurnsToMove)
        {
            moving = true;
        }

        moveStartPos = mobBase.transform.position;
        moveEndPos = CalcNextMovePoint();
    }

    private Vector3 CalcNextMovePoint()
    {
        Vector3 _dir = (mobBase.Player.transform.position - moveStartPos).normalized;

        if (Mathf.Abs(_dir.x) >= Mathf.Abs(_dir.y))
        {
            _dir = moveStartPos + new Vector3(Mathf.Sign(_dir.x) , 0, 0) * GlobalSettings.TilemapScale;
        }
        else
        {
            _dir = moveStartPos + new Vector3(0, Mathf.Sign(_dir.y), 0) * GlobalSettings.TilemapScale;
        }

        return _dir;
    }
}
