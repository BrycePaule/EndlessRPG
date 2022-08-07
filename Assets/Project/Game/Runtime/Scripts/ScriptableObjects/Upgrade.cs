using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Upgrade", fileName = "New Upgrade")]
public class Upgrade : ScriptableObject
{
    public string UpgradeText;
    public Sprite Sprite;

    [Header("Flat", order = 0)]

    [Header("Player", order = 1)]
    public int Health = 0;
    public int PickupRadius = 0;

    [Header("Weapon", order = 1)]
    public int Damage = 0;
    public int Cooldown = 0;
    public int Spread = 0;
    public int BonusProjectiles = 0;
    public int Chain = 0;
    public int Pierce = 0;
    public float BulletLife = 0;

    [Space(20, order = 2)]

    [Header("Multi", order = 2)]

    [Header("Player", order = 3)]
    // public float MovementSpeedMultiplier = 1f;

    [Header("Weapon", order = 3)]
    public float BulletSpeedMultiplier =- 1f;
    public float SizeMultiplier = 1f;


    public void Apply(PlayerStats pStats, Weapon weapon)
    {
        // PLAYER
        // Multipliers
        // pStats.MovementSpeed *= MovementSpeedMultiplier;

        // Flat
        pStats.MaxHealth += Health;
        pStats.PickupRadius += PickupRadius;

        // WEAPON
        // Multipliers
        weapon.SpeedMulti *= BulletSpeedMultiplier;
        weapon.SizeMulti *= SizeMultiplier;

        // Flat
        weapon.Damage += Damage;
        weapon.Spread += Spread;
        weapon.Projectiles += BonusProjectiles;
        weapon.Chain += Chain;
        weapon.Pierce += Pierce;
        weapon.Lifetime += BulletLife;

        weapon.StepsToShoot = Mathf.Max(1, weapon.StepsToShoot - Cooldown);

    }

    // IDEAS
    // knockback, pierce, ammo + reload mechanic?

}
