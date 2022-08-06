using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
	[SerializeField] private Weapon equippedWeapon;
	[SerializeField] private PlayerTargetFinder targetFinder;

	private float timer;

	private Transform target;

	private void Update()
	{
		timer += Time.deltaTime;

		if (timer > equippedWeapon.FireCooldown)
		{
			UpdateTarget();
			if (target == null) { return; }

			equippedWeapon.ShootAt(transform.position, target);
			timer = 0f;
		}
	}

	public void UpdateTarget()
	{
		target = targetFinder.FindClosestTarget();
	}

}
