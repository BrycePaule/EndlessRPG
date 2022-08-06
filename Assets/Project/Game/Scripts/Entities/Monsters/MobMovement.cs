using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobMovement : MonoBehaviour
{

	private MobBase mobBase;
	private MobStats stats;

	private Vector2 target;

	private void Awake()
	{
		mobBase = GetComponentInParent<MobBase>();
		stats = mobBase.StatsAsset;
	}

	private void FixedUpdate()
	{
		Move();
	}

	public void Move()
	{
		Vector3 dir = (mobBase.Player.transform.position - transform.position).normalized;
		mobBase.transform.position += dir * (stats.MovementSpeed * GlobalSettings.TravelSpeedScalar);
	}

}
