using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    [SerializeField] public Weapon currWeapon;
    [SerializeField] private PlayerTargetFinder targetFinder;

    private PlayerBase playerBase;
    private Transform target;

    private int stepCounter;

    private void Awake()
    {
        playerBase = GetComponentInParent<PlayerBase>();
        stepCounter = 0;
    }

    public void UpdateTarget()
    {
        target = targetFinder.FindClosestTarget();
    }

    public Vector3 GenerateBulletSpawnPosOffset(int bulletNum, int totalBullets)
    {
        Vector3 dir = transform.position - target.position;
        float degrees = ((Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg) - 180f) % 360f;

        if (totalBullets > 1)
        {
            float increment = currWeapon.BulletSpread / (totalBullets - 1);

            degrees -= (currWeapon.BulletSpread / 2);
            degrees += (bulletNum * increment);
        }

        float radians = degrees * Mathf.Deg2Rad;
        float x = Mathf.Cos(radians);
        float y = Mathf.Sin(radians);

        return new Vector3(x, y, 0) + transform.position;
    }

    public void Shoot()
    {
        stepCounter += 1;

        if (stepCounter >= currWeapon.StepsToShoot)
        {
            UpdateTarget();
            if (target == null) { return; }

            for (int i = 0; i < currWeapon.Projectiles; i++)
            {
                currWeapon.Shoot(GenerateBulletSpawnPosOffset(i, currWeapon.Projectiles), target);
            }

            stepCounter = 0;
        }
    }
}
