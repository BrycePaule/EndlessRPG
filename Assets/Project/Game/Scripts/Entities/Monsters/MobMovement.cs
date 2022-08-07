using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobMovement : MonoBehaviour
{

    private MobBase mobBase;
    private MobStats stats;

    private Vector2 target;

    private void Awake()
    {
        mobBase = GetComponentInParent<MobBase>();
        stats = mobBase.StatsAsset;
    }

    private void FixedUpdate()
    {
        // Move();
    }

    public void Move()
    {
        mobBase.transform.position += CalcMoveDir() * 2;
    }

    private Vector3 CalcMoveDir()
    {
        Vector3 _dir = (mobBase.Player.transform.position - transform.position).normalized;

        if (Mathf.Abs(_dir.x) >= Mathf.Abs(_dir.y))
        {
            _dir = new Vector3(Mathf.Sign(_dir.x) , 0, 0);
        }
        else
        {
            _dir = new Vector3(0, Mathf.Sign(_dir.y), 0);
        }

        return _dir;
    }

}
