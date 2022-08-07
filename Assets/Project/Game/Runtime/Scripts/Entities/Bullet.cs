using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public Transform Target;

    public int Damage;
    public int Projectiles;
    public float BulletLife;
    public int Chain;
    public int Pierce;

    public float TravelSpeed;

    public BulletTravelStyle TravelStyle;

    private float destructTimer;
    private float moveTime;
    private bool moving;
    private int hits;

    private Vector3 dirVector;
    private Vector3 moveStartPos;
    private Vector3 moveEndPos;

    private void Awake()
    {
        moveTime = 0f;
        moving = false;
        hits = 0;
    }

    private void Start()
    {
        UpdateDirection();
        UpdateRotation();
        Move();
    }

    private void Update()
    {
        destructTimer += Time.deltaTime;
        if (destructTimer >= BulletLife) { Destroy(gameObject); }

        if (!moving) { return; }

        if (TravelStyle == BulletTravelStyle.Homing)
        {
            UpdateDirection();
            UpdateRotation();
        }

        moveTime += (Time.deltaTime / GlobalSettings.EntityMoveTime);
        transform.position = Vector3.Lerp(moveStartPos, moveStartPos + (dirVector * TravelSpeed), moveTime);

        if (moveTime >= 1f)
        {
            moving = false;
            moveTime = 0f;
        }
    }

    public void Move()
    {
        moveStartPos = transform.position;
        moving = true;
    }

    private void UpdateDirection()
    {
        if (Target == null) { return; }

        dirVector = (Target.transform.position - transform.position).normalized;
    }

    private void UpdateRotation()
    {
        if (Target == null) { return; }

        float angleInDegrees = Mathf.Atan2(dirVector.y, dirVector.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angleInDegrees, Vector3.forward);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == GlobalSettings.MonsterLayerIndex)
        {
            other.gameObject.GetComponentInParent<MobBase>().GetComponentInChildren<MobHealth>().Damage(Damage);
            hits += 1;

            if (hits >= Pierce)
                Destroy(gameObject);

            // if (hits > Chain)
            //     Destroy(gameObject);
        }

    }
}
