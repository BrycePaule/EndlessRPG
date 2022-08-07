using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class UpgradeMenu : MonoBehaviour
{
    public PlayerBase Player;

    [SerializeField] private Canvas canvas;
    [SerializeField] private List<Upgrade> possibleUpgrades;

    private PlayerStats playerStats;
    private Weapon weapon;

    private float lastTimescale;
    private int upgradeChoices = 3;

    private List<UpgradeSlot> upgradeSlots;

    private void OnEnable()
    {
        playerStats = Player.StatsAsset;
        weapon = Player.GetComponentInChildren<PlayerWeapon>().currWeapon;

        upgradeSlots = GetComponentsInChildren<UpgradeSlot>().ToList();
    }

    public void EnableMenu() 
    {
        lastTimescale = Time.timeScale;
        Time.timeScale = 0f;

        RollUpgrades();

        canvas.enabled = true;
    }

    public void DisableMenu()
    {
        canvas.enabled = false;
        Time.timeScale = lastTimescale;
    }

    private void RollUpgrades()
    {
        System.Random r = new System.Random();
        List<int> choices = Enumerable.Range(0, possibleUpgrades.Count).OrderBy(x => r.Next()).Take(3).ToList();

        for (int i = 0; i < upgradeChoices; i++)
        {
            upgradeSlots[i].Upgrade = possibleUpgrades[choices[i]];
        }
    }
}
