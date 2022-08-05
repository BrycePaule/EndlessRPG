using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/MobStats", fileName = "New MobStats")]
public class MobStats : ScriptableObject
{

	public int MaxHealth;
	public float MovementSpeed;

	public int CollisionDamage;
	
	// for knockback??
	public float Bounciness;


}
