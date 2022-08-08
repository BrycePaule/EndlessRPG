using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField] private PlayerBase player;
    [SerializeField] private PlayerWeapon playerWeapon;

    private void Awake()
    {
        player.StatsAsset = Instantiate(player.StatsAsset);
        playerWeapon.currWeapon = Instantiate(playerWeapon.currWeapon);
        Cursor.visible = false;
    }
}
