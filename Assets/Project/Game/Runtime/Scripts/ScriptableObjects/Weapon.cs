using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Weapon", fileName = "New Weapon")]
public class Weapon : ScriptableObject
{
    public int StepsToShoot; // in number of steps

    [Header("Bullet Settings")]
    public int Damage;
    public int Projectiles;
    public float BulletSpread;
    public float SizeMultiplier;
    public float TravelSpeed;
    public float BulletLife;  // time in seconds

    public BulletTravelStyle TravelStyle;


    [Header("References")]
    public GameObject BulletPrefab;

    public void Shoot(Vector3 from, Transform target)
    {
        Vector3 dirVector = (from - target.transform.position).normalized;
        float angle = Mathf.Atan2(dirVector.y, dirVector.x) * Mathf.Rad2Deg;

        GameObject _bulletObj = Instantiate(BulletPrefab, from, Quaternion.AngleAxis(angle, Vector3.forward));
        _bulletObj.transform.localScale *= SizeMultiplier;

        Bullet _bullet = _bulletObj.GetComponent<Bullet>();
        _bullet.Target = target;
        _bullet.Damage = Damage;
        _bullet.Projectiles = Projectiles;
        _bullet.SizeMultiplier = SizeMultiplier;
        _bullet.TravelSpeed = TravelSpeed;
        _bullet.BulletLife = BulletLife;
        _bullet.TravelStyle = TravelStyle;
    }
}
