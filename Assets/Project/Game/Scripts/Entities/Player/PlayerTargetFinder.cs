using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTargetFinder : MonoBehaviour
{

	[Header("References")]
	[SerializeField] private Transform monsterContainer;


	public Transform FindClosestTarget()
	{
		Transform closest = null;

		foreach (Transform mob in monsterContainer.transform)
		{
			if (closest == null) { closest = mob; }

			float close = Vector3.Distance(transform.position, closest.position);
			float currentCheck = Vector3.Distance(transform.position, mob.position);

			if (currentCheck < close)
			{
				closest = mob;
			}
		}

		return closest;
	}
}
