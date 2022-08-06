using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobHealth : MonoBehaviour, IHealth
{
    private MobBase mobBase;

    [SerializeField] private int health;
    private int maxHealth;

    [SerializeField] private GameObject pfEXPOrb;

    private bool dying = false;

    private void Awake()
    {
        mobBase = GetComponentInParent<MobBase>();

        maxHealth = mobBase.StatsAsset.MaxHealth;
        health = mobBase.StatsAsset.MaxHealth;
    }

    public void Damage(int amount)
    {
        if (amount <= 0) { return; }

        health -= amount;
        if (health <= 0) { Die(); }

        SpriteRenderer SR = mobBase.GetComponent<SpriteRenderer>();
        SR.color = new Color(SR.color.r + .1f, SR.color.g + .1f, SR.color.b + .1f);

    }

    public void Heal(int amount)
    {
        health += amount;
        health = Mathf.Clamp(health, 0, maxHealth);
    }

    public void Die()
    {
        if (!dying)
        {
            dying = true;
            Instantiate(pfEXPOrb, transform.position, Quaternion.identity);
        }

        Destroy(mobBase.gameObject);
    }
}