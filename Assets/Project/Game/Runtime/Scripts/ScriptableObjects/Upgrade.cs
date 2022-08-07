using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Upgrade", fileName = "New Upgrade")]
public class Upgrade : ScriptableObject
{
    public string UpgradeText;
    public Sprite Sprite;

    [Header("Player Stats")]
    public float MovementSpeedMultiplier = 1f;
    public float PickupRadiusMultipler = 1f;
    public float HealthMultipler = 1f;


    [Header("Weapon Stats")]
    public float WeaponDamageMultiplier = 1f;
    public int WeaponDamageIncrease = 0;
    public int BonusProjectiles = 0;

    public float BulletSpreadMultipler = 1f;
    public float BulletSizeMultiplier = 1f;
    public float BulletTravelSpeedMultiplier = 1f;
    public float BulletLifeMultipler = 1f;

    public void Apply(PlayerStats pStats, Weapon weapon)
    {
        pStats.MovementSpeed *= MovementSpeedMultiplier;
        pStats.PickupRadius *= PickupRadiusMultipler;
        pStats.MaxHealth *= Mathf.FloorToInt(pStats.MaxHealth * HealthMultipler);

        weapon.Damage *= Mathf.FloorToInt(weapon.Damage * WeaponDamageMultiplier);
        weapon.Damage += WeaponDamageIncrease;
        weapon.Projectiles += BonusProjectiles;

        weapon.BulletSpread *= BulletSpreadMultipler;
        weapon.SizeMultiplier *= BulletSizeMultiplier;
        weapon.TravelSpeed *= BulletTravelSpeedMultiplier;
        weapon.BulletLife *= BulletLifeMultipler;
    }

}
