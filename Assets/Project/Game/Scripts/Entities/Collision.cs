using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
	private PlayerBase playerBase;
	private PlayerHealth playerHealth;

	const int PlayerLayerIndex = 8;
	const int MonsterLayerIndex = 9;

	private float timer = 0f;

	private void Awake()
	{
		playerBase = GetComponentInParent<PlayerBase>();
		playerHealth = playerBase.GetComponentInChildren<PlayerHealth>();
	}

	private void OnCollisionEnter2D(Collision2D other)
	{
		timer = 0f;

		if (gameObject.layer == PlayerLayerIndex)	
		{
			if (other.gameObject.layer == MonsterLayerIndex)
			{
				playerHealth.Damage(other.gameObject.GetComponentInParent<MobBase>().StatsAsset.CollisionDamage);
				timer = 0f;
			}
		}	
	}

	private void OnCollisionStay2D(Collision2D other)
	{
		if (gameObject.layer != PlayerLayerIndex) { return; }
		if (other.gameObject.layer != MonsterLayerIndex) { return; }

		timer += Time.deltaTime;

		if (timer >= GlobalSettings.PlayerHitTimer)
		{
			playerHealth.Damage(other.gameObject.GetComponentInParent<MobBase>().StatsAsset.CollisionDamage);
			timer = 0f;
		}
	}
}
