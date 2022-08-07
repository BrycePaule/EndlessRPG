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

    private void Awake()
    {
        mobBase = GetComponentInParent<MobBase>();
        stats = mobBase.StatsAsset;

        moveTime = 0f;
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
        }
    }

    public void Move()
    {
        if (moving) { return; }

        moveStartPos = mobBase.transform.position;
        moveEndPos = CalcNextMovePoint();
        moving = true;
    }

    private Vector3 CalcNextMovePoint()
    {
        Vector3 _dir = (mobBase.Player.transform.position - moveStartPos).normalized;

        if (Mathf.Abs(_dir.x) >= Mathf.Abs(_dir.y))
        {
            _dir = moveStartPos + new Vector3(Mathf.Sign(_dir.x) , 0, 0) * mobBase.StatsAsset.MovementSpeed;
        }
        else
        {
            _dir = moveStartPos + new Vector3(0, Mathf.Sign(_dir.y), 0) * mobBase.StatsAsset.MovementSpeed;
        }

        return _dir;
    }
}
