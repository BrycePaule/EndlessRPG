using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public Transform Target;

    public int Damage;
    public float TravelSpeed;
    public float BulletLife;

    private float timer;

    private Vector3 dirVector;

    private void FixedUpdate()
    {
        timer += Time.deltaTime;
        if (timer >= BulletLife) { Destroy(gameObject); }

        UpdateDirection();
        UpdateRotation();
        Move();
    }

    private void Move()
    {
        transform.position += dirVector * (TravelSpeed * GlobalSettings.TravelSpeedScalar);
    }

    private void UpdateDirection()
    {
        if (Target == null) { return; }
        dirVector = (Target.transform.position - transform.position).normalized;
    }

    private void UpdateRotation()
    {
        if (Target == null) { return; }

        float angle = Mathf.Atan2(dirVector.y, dirVector.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
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
