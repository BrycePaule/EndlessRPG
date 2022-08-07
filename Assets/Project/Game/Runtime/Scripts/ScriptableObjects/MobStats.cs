using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/MobStats", fileName = "New MobStats")]
public class MobStats : ScriptableObject
{

    public int MaxHealth;
    public int TurnsToMove;

    public int CollisionDamage;
    
    // for knockback??
    public float Bounciness;


}
