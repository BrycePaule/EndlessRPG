using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour, IHealth
{
	[SerializeField] private Slider healthBar;

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

		InitHealthBar();
	}

	public void Damage(int amount)
	{
		if (amount <= 0) { return; }

		health -= amount;
		UpdateHealthBar();

		if (health == 0) { Die(); }
	}

	public void Heal(int amount)
	{
		health += amount;
		health = Mathf.Clamp(health, 0, maxHealth);

		UpdateHealthBar();
	}

	public void Die()
	{
		print("You died bruh");
		// Destroy(playerBase.gameObject);
	}

	public void InitHealthBar()
	{
		healthBar.minValue = 0;
		healthBar.maxValue = 1;
		healthBar.value = health;
	}

	public void UpdateHealthBar()
	{
		healthBar.value = (float) health / (float) maxHealth;
	}

}