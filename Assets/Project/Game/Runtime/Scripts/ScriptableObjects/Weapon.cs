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
    public GameObject BulletPrefab;

    public void Shoot(Vector3 from, Transform target)
    {
        Vector3 dirVector = (from - target.transform.position).normalized;
        float angle = Mathf.Atan2(dirVector.y, dirVector.x) * Mathf.Rad2Deg;

        GameObject _bulletObj = Instantiate(BulletPrefab, from, Quaternion.AngleAxis(angle, Vector3.forward));
        _bulletObj.transform.localScale *= SizeMulti;

        Bullet _bullet = _bulletObj.GetComponent<Bullet>();
        _bullet.Target = target;
        _bullet.Damage = Damage;
        _bullet.TravelSpeed = SpeedMulti;

        _bullet.Projectiles = Projectiles;
        _bullet.Chain = Chain;
        _bullet.Pierce = Pierce;

        _bullet.BulletLife = Lifetime;
        _bullet.TravelStyle = TravelStyle;
    }
}
