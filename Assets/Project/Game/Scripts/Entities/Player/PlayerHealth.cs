using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, IHealth
{
	private PlayerBase playerBase;

	[SerializeField] private int health;
	private int maxHealth;

	private void Awake()
	{
		playerBase = GetComponentInParent<PlayerBase>();
	}

	private void Start()
	{
		maxHealth = playerBase.StatsAsset.MaxHealth;
		health = playerBase.StatsAsset.MaxHealth;
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
		print("You died bruh");
	}

}