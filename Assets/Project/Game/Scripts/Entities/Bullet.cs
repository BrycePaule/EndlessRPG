using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public Transform Target;

    public int Damage;
    public int Projectiles;

    public float SizeMultiplier;
    public float TravelSpeed;

    public float BulletLife;
    public TravelStyle TravelStyle;

    private float destructTimer;

    private Vector3 dirVector;

    private void Start()
    {
        UpdateDirection();
        UpdateRotation();
    }

    private void FixedUpdate()
    {
        destructTimer += Time.deltaTime;
        if (destructTimer >= BulletLife) { Destroy(gameObject); }

        if (TravelStyle == TravelStyle.Target)
        {
            UpdateDirection();
            UpdateRotation();
        }
        
        Move();
    }

    private void Move()
    {
        transform.position += dirVector * (TravelSpeed * GlobalSettings.TravelSpeedScalar);

        // transform.position = Vector3.Lerp(moveStartPos, moveEndPos, moveTime);
        // moveTime += (Time.deltaTime / GlobalSettings.EntityMoveTime);

        // if (moveTime >= 1f)
        // {
        //     moving = false;
        //     moveTime = 0f;
        //     playerBase.transform.position = Utils.CentrePosOnTile(playerBase.transform.position);
        // }
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
            Destroy(gameObject);
        }
    }
}
