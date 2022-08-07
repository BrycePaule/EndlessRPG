using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Weapon", fileName = "New Weapon")]
public class Weapon : ScriptableObject
{
    public int StepsToShoot; // in number of steps

    [Header("Bullet Settings")]
    public int Damage;
    public float Spread;
    public float Lifetime;  // time in seconds

    public int Projectiles;
    public int Chain;
    public int Pierce;

    public float SizeMulti;
    public float SpeedMulti;

    public BulletTravelStyle TravelStyle;

    [Header("References")]
    [SerializeField] private GameObject BulletPrefab;

    public void Shoot(Vector3 shooterPos, Vector3 initPos)
    {
        Vector3 dirVector = (initPos - shooterPos).normalized;
        float angle = Mathf.Atan2(dirVector.y, dirVector.x) * Mathf.Rad2Deg;

        GameObject _bulletObj = Instantiate(BulletPrefab, initPos, Quaternion.AngleAxis(angle, Vector3.forward));
        _bulletObj.transform.localScale *= SizeMulti;

        Bullet _bullet = _bulletObj.GetComponent<Bullet>();
        InitBulletStats(_bullet);

        _bullet.DirVector = dirVector;
    }

    public void ShootHoming(Vector3 initPos, Transform target)
    {
        Vector3 dirVector = (initPos - target.transform.position).normalized;
        float angle = Mathf.Atan2(dirVector.y, dirVector.x) * Mathf.Rad2Deg;

        GameObject _bulletObj = Instantiate(BulletPrefab, initPos, Quaternion.AngleAxis(angle, Vector3.forward));
        _bulletObj.transform.localScale *= SizeMulti;

        Bullet _bullet = _bulletObj.GetComponent<Bullet>();
        InitBulletStats(_bullet);

        _bullet.Target = target;
    }

    private void InitBulletStats(Bullet _b)
    {
        _b.Damage = Damage;
        _b.TravelSpeed = SpeedMulti;

        _b.Projectiles = Projectiles;
        _b.Chain = Chain;
        _b.Pierce = Pierce;

        _b.BulletLife = Lifetime;
        _b.TravelStyle = TravelStyle;
    }
}
