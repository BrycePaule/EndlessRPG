using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobBase : MonoBehaviour
{

    public MobStats StatsAsset;
    public PlayerBase Player;

    private void Awake()
    {
        Player = FindObjectOfType<PlayerBase>();
    }

}
