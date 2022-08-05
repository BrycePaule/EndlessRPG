using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobHealth : MonoBehaviour, IHealth
{
	private MobBase mobBase;

	private int health;
	private int maxHealth;

	// small change

	private void Awake()
	{
		maxHealth = mobBase.StatsAsset.MaxHealth;
		health = mobBase.StatsAsset.MaxHealth;
	}

	public void Damage(int amount)
	{
		if (amount <= 0) { return; }

		health -= amount;
		if (health == 0) { Die(); }
	}

	public void Heal(int amount)
	{
		health += amount;
		health = Mathf.Clamp(health, 0, maxHealth);
	}

	public void Die()
	{
		Destroy(mobBase.gameObject);
	}

}