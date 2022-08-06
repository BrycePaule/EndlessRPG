using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Weapon", fileName = "New Weapon")]
public class Weapon : ScriptableObject
{
	public enum TravelStyle
	{
		Straight,
		Target,
	}


	// delay in seconds
	public float FireCooldown;

	[Header("Bullet Settings")]
	public int Damage;
	public float TravelSpeed;
	public float BulletLife;  // time in seconds
	public TravelStyle Style;


	[Header("References")]
	public GameObject BulletPrefab;


	public void ShootAt(Vector3 from, Transform target)
	{
		GameObject _bulletObj = Instantiate(BulletPrefab, from, Quaternion.identity);
		Bullet _bullet = _bulletObj.GetComponent<Bullet>();

		_bullet.Target = target;
		_bullet.TravelSpeed = TravelSpeed;
		_bullet.BulletLife = BulletLife;
		_bullet.Damage = Damage;
	}
}
