using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
	private PlayerBase playerBase;
	private PlayerHealth playerHealth;


	private float timer = 0f;

	private void Awake()
	{
		playerBase = GetComponentInParent<PlayerBase>();
		playerHealth = playerBase.GetComponentInChildren<PlayerHealth>();
	}

	private void OnCollisionEnter2D(Collision2D other)
	{
		timer = 0f;

		if (gameObject.layer == GlobalSettings.PlayerLayerIndex)	
		{
			if (other.gameObject.layer == GlobalSettings.MonsterLayerIndex)
			{
				playerHealth.Damage(other.gameObject.GetComponentInParent<MobBase>().StatsAsset.CollisionDamage);
				timer = 0f;
			}
		}	
	}

	private void OnCollisionStay2D(Collision2D other)
	{
		if (gameObject.layer != GlobalSettings.PlayerLayerIndex) { return; }
		if (other.gameObject.layer != GlobalSettings.MonsterLayerIndex) { return; }

		timer += Time.deltaTime;

		if (timer >= GlobalSettings.PlayerHitTimer)
		{
			playerHealth.Damage(other.gameObject.GetComponentInParent<MobBase>().StatsAsset.CollisionDamage);
			timer = 0f;
		}
	}
}
