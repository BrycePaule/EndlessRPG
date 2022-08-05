using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

	private PlayerBase playerBase;
	private PlayerStats playerStats;

	private void Awake()
	{
		playerBase = GetComponentInParent<PlayerBase>();
		playerStats = playerBase.StatsAsset;
	}

	public void Move(Vector2 dir)
	{
		playerBase.transform.position += (Vector3) dir * (playerStats.MovementSpeed * GlobalSettings.MovementSpeedScalar);
	}

}
