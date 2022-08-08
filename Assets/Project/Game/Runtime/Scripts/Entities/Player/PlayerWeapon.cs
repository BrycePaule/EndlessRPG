using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerWeapon : MonoBehaviour
{
    [SerializeField] public Weapon currWeapon;
    [SerializeField] private PlayerTargetFinder targetFinder;
    [SerializeField] private InputHandler inputHandler;
    [SerializeField] private RectTransform uiCrosshair;

    private PlayerBase playerBase;

    private int stepCounter;

    private void Awake()
    {
        playerBase = GetComponentInParent<PlayerBase>();
        stepCounter = 0;
    }

    public Vector3 GenerateBulletSpawnPosOffset(int bulletNum, int totalBullets)
    {
        Vector3 dir = transform.position - inputHandler.mousePosWorld;
        float degrees = ((Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg) - 180f) % 360f;

        if (totalBullets > 1)
        {
            float increment = currWeapon.Spread / (totalBullets - 1);

            degrees -= (currWeapon.Spread / 2);
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
            for (int i = 0; i < currWeapon.Projectiles; i++)
            {
                Vector3 bulletInitPos = GenerateBulletSpawnPosOffset(i, currWeapon.Projectiles);

                switch (currWeapon.TravelStyle)
                {
                    // case (BulletTravelStyle.Homing):
                    //     currWeapon.ShootHoming(bulletInitOffset, target);
                    //     break;

                    // case (BulletTravelStyle.Mouse):
                    //     currWeapon.ShootHoming(bulletInitOffset, target);
                    //     break;
                    
                    default:
                        currWeapon.Shoot(transform.position, bulletInitPos);
                        break;
                }
            }
            stepCounter = 0;
        }
    }

    private void Update()
    {
        uiCrosshair.position = inputHandler.mousePosScreen;
    }
}
